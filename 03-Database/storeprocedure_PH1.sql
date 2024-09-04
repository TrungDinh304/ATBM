set serveroutput on size unlimited;
alter session set "_ORACLE_SCRIPT"=true; 


-- 2. Xem thông tin về quyền (privileges) của mỗi user/ role trên các đối tượng dữ liệu.
-- Xem thông tin vể quyền cửa mỗi user
CREATE OR REPLACE PROCEDURE admin1.usp_view_privs_user
    (USERNAME VARCHAR)
IS
--    OUTPUT SYS_REFCURSOR;
BEGIN
--    DBMS_OUTPUT.PUT_LINE('EMPLOYEE');
    FOR emp_rec IN (
        SELECT R.GRANTEE, P.PRIVILEGE, P.TABLE_NAME
        FROM DBA_ROLE_PRIVS R, DBA_TAB_PRIVS P
        WHERE R.GRANTEE = USERNAME AND R.GRANTED_ROLE = P.GRANTEE    
    )
    LOOP
        DBMS_OUTPUT.PUT_LINE(emp_rec.PRIVILEGE || ' ON ' || emp_rec.TABLE_NAME );
    END LOOP;
END;
/
-- Xem thông tin về quyền trên role
CREATE OR REPLACE PROCEDURE admin1.usp_view_privs_role
    (ROLENAME VARCHAR)
IS
--    OUTPUT SYS_REFCURSOR;
BEGIN
--    DBMS_OUTPUT.PUT_LINE('EMPLOYEE');
    FOR emp_rec IN (SELECT TABLE_NAME, PRIVILEGE FROM DBA_TAB_PRIVS WHERE GRANTEE = ROLENAME)
    LOOP
        DBMS_OUTPUT.PUT_LINE(emp_rec.PRIVILEGE || ' ON ' || emp_rec.TABLE_NAME );
    END LOOP;
END;
/

-- 4. Cho phép thực hiện việc cấp quyền:
-- a) Cấp quyền cho user, cấp quyền cho role, cấp role cho user.
--Cấp quyền cho role
CREATE OR REPLACE PROCEDURE admin1.sp_grant_priv_to_role (
    p_role_name IN VARCHAR2,
    p_privs IN VARCHAR2,
    p_obj_name IN VARCHAR2,
    p_cols_name IN VARCHAR2 DEFAULT NULL,
    p_error_code OUT NUMBER,
    p_error_msg OUT VARCHAR2
)
IS
    v_sql VARCHAR2(1000);
    v_owner VARCHAR2(50);
    v_view_name VARCHAR2(1000);
BEGIN
    SELECT owner INTO v_owner FROM all_objects WHERE object_name = p_obj_name AND ROWNUM = 1;

     IF p_privs = 'Select' AND p_cols_name IS NOT NULL THEN
        -- Phân tách các tên cột và tạo view cho từng cột
        DECLARE
            TYPE col_array IS TABLE OF VARCHAR2(50) INDEX BY PLS_INTEGER;
            v_cols col_array;
            v_col_name VARCHAR2(50);
        BEGIN
            FOR i IN 1..LENGTH(p_cols_name) - LENGTH(REPLACE(p_cols_name, ',', '')) + 1 LOOP
                v_col_name := TRIM(REGEXP_SUBSTR(p_cols_name, '[^,]+', 1, i));
                v_cols(i) := v_col_name;

                -- Tạo view cho từng cột
                v_view_name := 'V_' || p_obj_name || '_' || v_col_name || '_' || p_role_name;
                execute immediate 'create or replace view ' || v_view_name || ' as select ' || v_col_name || ' from ' || v_owner || '.' || p_obj_name;
                
                -- Cấp quyền cho người dùng/role trên view vừa tạo
                v_sql := 'grant select on ' || v_view_name || ' to ' || p_role_name;
                execute immediate v_sql;
            END LOOP;
        END;
    ELSE
        IF p_cols_name IS NOT NULL THEN
            v_sql := 'GRANT ' || p_privs || ' (' || p_cols_name || ') ' || ' ON ' || v_owner || '.' || p_obj_name || ' TO ' || p_role_name;
        ELSE 
            v_sql := 'GRANT ' || p_privs || ' ON ' || v_owner || '.' || p_obj_name || ' TO ' || p_role_name;        
        END IF;

        EXECUTE IMMEDIATE v_sql;
    END IF;

    p_error_code := 0; -- Success
    p_error_msg := 'Success';

EXCEPTION
    WHEN NO_DATA_FOUND THEN
        p_error_code := -1; -- Custom error code
        p_error_msg := 'No data found for the specified object.';
    WHEN OTHERS THEN
        p_error_code := SQLCODE;
        p_error_msg := SQLERRM;
END sp_grant_priv_to_role;
/
-- Cấp role cho user
CREATE OR REPLACE PROCEDURE admin1.sp_grant_users_to_role (
    p_user_name IN VARCHAR2,
    p_role_name IN VARCHAR2,
    p_error_code OUT NUMBER,
    p_error_msg OUT VARCHAR2
)
IS
    v_sql VARCHAR2(1000);
    v_count NUMBER;
BEGIN
    v_sql := 'GRANT ' || p_role_name || ' TO ' || p_user_name; 
    
    EXECUTE IMMEDIATE v_sql;
    p_error_code := 0; -- Success
    p_error_msg := 'Success';
EXCEPTION
    WHEN NO_DATA_FOUND THEN
        p_error_code := -1; -- Custom error code
        p_error_msg := 'No data found for the specified object.';
    WHEN OTHERS THEN
        p_error_code := SQLCODE;
        p_error_msg := SQLERRM;
END sp_grant_users_to_role;
/
-- b) Quá trình cấp quyền có tùy chọn là có cho phép người được cấp quyền có thể cấp quyền đó 
-- cho user/ role khác hay không (có chỉ định WITH GRANT OPTION hay không).
create or replace procedure admin1.sp_grant_privilege (
    user_role_name in varchar2,                -- Tên user/role được cấp quyền
    table_name in varchar2,                    -- Tên bảng
    privilege_type in varchar2,                -- Loại quyền (select, update, insert, delete)
    column_name in varchar2,                   -- Tên cột (dành cho insert, update)
    with_grant_option in varchar2 default 'no' -- Tuỳ chọn grant option
)
is
    strsql varchar2(1000);
    view_name varchar2(1000);
begin 
    -- Kiểm tra nếu privilege_type là 'select' và column_name không null, thì tạo view và cấp quyền
    if privilege_type = 'select' and column_name is not null then
        -- Tạo view từ bảng và cột được chỉ định
        view_name := 'V_' || table_name || '_' || user_role_name ;
        execute immediate 'create or replace view ' || view_name || ' as select ' || column_name || ' from ' || table_name;
        
        -- Cấp quyền cho người dùng/role trên view vừa tạo
        strsql := 'grant select on ' || view_name || ' to ' || user_role_name;
        if with_grant_option = 'yes' then
            strsql := strsql || ' with grant option';
        end if;
        execute immediate strsql;
    else
        -- Xây dựng câu lệnh GRANT
        strsql := 'grant ' || privilege_type || 
                   case 
                       when column_name is not null then '(' || column_name || ')' 
                       else '' 
                   end ||
                   ' on ' || table_name || ' to ' || user_role_name;

        -- Nếu tuỳ chọn "with grant option" được đặt là 'yes', thêm mệnh đề "with grant option"
        if with_grant_option = 'yes' then
            strsql := strsql || ' with grant option';
        end if;

        -- Thực thi câu lệnh GRANT
        execute immediate strsql;

        -- Hiển thị thông báo khi quyền được cấp thành công
        dbms_output.put_line('Privilege granted successfully.');
    end if;
exception 
    when others then
        -- Ném một ngoại lệ tùy chỉnh để thông báo lỗi cho ứng dụng C#
        RAISE_APPLICATION_ERROR(-20001, 'Error granting privilege: ' || SQLERRM);
end;
/

-- 5. Cho phép thu hồi quyền hạn từ user/role.
CREATE OR REPLACE PROCEDURE admin1.sp_revoke_privilege (
    user_role_name IN VARCHAR2,    -- Tên user/role mà quyền sẽ bị thu hồi
    table_name IN VARCHAR2,        -- Tên bảng
    privilege_type IN VARCHAR2     -- Loại quyền (select, update, insert, delete)
)
IS
    strsql VARCHAR2(1000);
BEGIN
    -- Xây dựng câu lệnh SQL để thu hồi quyền
    strsql := 'revoke ' || privilege_type ||
              ' on ' || table_name || ' from ' || user_role_name;

    -- Thực thi câu lệnh SQL
    EXECUTE IMMEDIATE strsql;

    -- Hiển thị thông báo
    DBMS_OUTPUT.PUT_LINE('Privilege revoked successfully.');
EXCEPTION 
    WHEN OTHERS THEN
        -- Ném một ngoại lệ tùy chỉnh để thông báo lỗi cho ứng dụng C#
        RAISE_APPLICATION_ERROR(-20001, 'Error revoking privilege: ' || SQLERRM || strsql);
END;
/

-- Thu hồi quyền từ role
CREATE OR REPLACE PROCEDURE admin1.sp_revoke_priv_from_role (
    p_role_name IN VARCHAR2,
    p_privs IN VARCHAR2,
    p_obj_name IN VARCHAR2,
    p_error_code OUT NUMBER,
    p_error_msg OUT VARCHAR2
)
IS
    v_sql VARCHAR2(1000);
    v_owner VARCHAR2(50);
BEGIN
    SELECT owner INTO v_owner FROM all_objects WHERE object_name = p_obj_name AND ROWNUM = 1;
    
    v_sql := 'REVOKE ' || p_privs || ' ON ' ||  v_owner || '.' || p_obj_name ||' FROM ' || p_role_name;        
    
    EXECUTE IMMEDIATE v_sql;
    p_error_code := 0; -- Success
    p_error_msg := 'Success';
    COMMIT;
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            p_error_code := -1; -- Custom error code
            p_error_msg := 'No data found for the specified object.';
        WHEN OTHERS THEN
            p_error_code := SQLCODE;
            p_error_msg := SQLERRM;
END sp_revoke_priv_from_role;
/
-- Thu hồi role của user
CREATE OR REPLACE PROCEDURE admin1.sp_revoke_user_from_role (
    p_user_name IN VARCHAR2,
    p_role_name IN VARCHAR2,
    p_error_code OUT NUMBER,
    p_error_msg OUT VARCHAR2
)
IS
    v_sql VARCHAR2(1000);
    
BEGIN
    v_sql := 'REVOKE ' || p_role_name || ' FROM ' || p_user_name; 
    
    EXECUTE IMMEDIATE v_sql;
    p_error_code := 0; -- Success
    p_error_msg := 'Success';
    COMMIT;
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            p_error_code := -1; -- Custom error code
            p_error_msg := 'No data found for the specified object.';
        WHEN OTHERS THEN
            p_error_code := SQLCODE;
            p_error_msg := SQLERRM;
END sp_revoke_user_from_role;
/
-- 6. Cho phép kiểm tra quyền của các chủ thể vừa được cấp quyền.
-- Hàm kiểm tra
CREATE OR REPLACE PROCEDURE admin1.sp_check_privilege_exists (
    user_role_name IN VARCHAR2,
    table_name IN VARCHAR2,
    privilege_type IN VARCHAR2,
    privilege_exists OUT NUMBER
)
AS
    privilege_count NUMBER;
BEGIN
    -- Đếm số lượng quyền mà người dùng có trên bảng với loại quyền cụ thể
    SELECT COUNT(*) INTO privilege_count
    FROM all_tab_privs
    WHERE grantee = user_role_name
        AND table_name = upper(table_name)
        AND privilege = upper(privilege_type);

    -- Gán kết quả vào biến out
    privilege_exists := privilege_count;
END;
/
--SELECT * FROM all_tab_privs where table_name like '%V_%_K%' and TYPE = 'VIEW';
--revoke select on V_COURSE_K from K;
--set serveroutput on;
--DECLARE
--  x NUMBER;
--BEGIN
--  sp_check_privilege_exists('K', 'V_COURSE_K', 'SELECT', x);
--  IF x > 0 THEN
--    dbms_output.put_line('Quyền tồn tại');
--  ELSE
--    dbms_output.put_line('Quyền không tồn tại');
--  END IF;
--END;
--/


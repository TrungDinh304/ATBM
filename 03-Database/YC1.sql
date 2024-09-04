---------------------------- CS1: NHAN VIEN CO BAN -------------------------------
-- Tạo role nhân viên cơ bản
-- drop role NhanVienCoban;
ALTER SESSION SET "_ORACLE_SCRIPT" = TRUE;
drop role NhanVienCoBan;
create role NhanVienCoBan;

-- Gán role cho user nvcb
CREATE OR REPLACE PROCEDURE sp_grant_role_to_nv_users AS
BEGIN
    FOR rec IN (SELECT MANV FROM admin1.X_NHANSU WHERE SUBSTR(manv, 1, 2) = 'NV') LOOP
        EXECUTE IMMEDIATE 'GRANT NhanVienCoBan TO ' || rec.MANV;
    END LOOP;
END;
/
-- Thuc thi thu tu grant user cho role NHANVIENCOBAN
exec sp_grant_role_to_nv_users;

--SELECT * FROM dba_role_privs WHERE granted_role = 'NHANVIENCOBAN';

-- GRANT QUYEN CHO ROLE NHANVIENCOBAN
-- 1. Xem dòng dữ liệu của chính mình trong quan hệ NHANSU, có thể chỉnh sửa
-- số điện thoại (ĐT) của chính mình (Nếu số điện thoại có thay đổi).
-- Tao view 
create or replace view admin1.UV_THONGTINCANHAN_NS 
as
    select *
    from admin1.X_NHANSU
    where MANV = SYS_CONTEXT('USERENV', 'SESSION_USER');
/

-- Grant quyen select, update
grant select, update(DT) on admin1.UV_THONGTINCANHAN_NS to NhanVienCoBan;

-- 2. Xem thông tin của tất cả SINHVIEN, DONVI, HOCPHAN, KHMO
grant select on admin1.X_SINHVIEN to NhanVienCoBan;
grant select on admin1.X_DONVI to NhanVienCoBan;
grant select on admin1.X_HOCPHAN to NhanVienCoBan;
grant select on admin1.X_KHMO to NhanVienCoBan;

-- Test
--conn NV01/NV01;
--select * from admin1.X_SINHVIEN;
--select * from admin1.X_DONVI;
--select * from admin1.X_HOCPHAN;
--select * from admin1.X_KHMO;
--select * from admin1.UV_THONGTINCANHAN_NS;
--conn NV02/NV02;
--select * from admin1.UV_THONGTINCANHAN_NS;
--update admin1.UV_THONGTINCANHAN_NS set DT = '0123456789' where MANV = 'NV02';
--select * from admin1.UV_THONGTINCANHAN_NS;
--update admin1.UV_THONGTINCANHAN_NS set PHAI = 'Nu' where MANV = 'NV02';
--select * from admin1.UV_THONGTINCANHAN_NS;

---------------------------- CS2: GIANG VIEN -----------------------------------
SET SERVEROUTPUT ON;
alter session set "_ORACLE_SCRIPT" = TRUE;
drop role GiangVien;
Create role GiangVien;

CREATE OR REPLACE PROCEDURE USP_ADDUSRMEM
    (STRROLE VARCHAR, Vtro VARCHAR)
AS
    CURSOR CUR IS ( SELECT MaNV
                    FROM admin1.x_nhansu
                    WHERE MaNV IN ( select USERNAME
                                FROM ALL_USERS )
                    AND VaiTro = Vtro );
    STRSQL VARCHAR(2000);
    USR VARCHAR2(5);
BEGIN
    OPEN CUR;
    LOOP
        FETCH CUR INTO USR;
        EXIT WHEN CUR%NOTFOUND;
        
        STRSQL := 'GRANT '||STRROLE||' TO '||USR;
        EXECUTE IMMEDIATE (STRSQL);
    END LOOP;
    CLOSE CUR;
END;
/

--THỰC THI THỦ TỤC
BEGIN
 USP_ADDUSRMEM('Giangvien', 'Giang vien');
END;
/

--XEM DANH SÁCH MEMBER CỦA ROLE
--SELECT * FROM DBA_ROLE_PRIVS WHERE GRANTED_ROLE LIKE '%GIANGVIEN%';

--- 1. Như một người dùng có vai trò “Nhân viên cơ bản” (xem mô tả CS#1).
grant NhanVienCoBan to GiangVien;

SELECT * FROM ADMIN1.UV_THONGTINCANHAN_NS;

--- 2. Xem phân công giảng dạy liên quan đến bản thân mình (PHANCONG).
-- Tao view
create or replace view admin1.V_PhanCong_GV
as 
    select mahp, hk, nam, mact
    from admin1.X_PhanCong
    where MaGV = SYS_CONTEXT('USERENV','SESSION_USER');
/

-- Grant quyen
grant select on admin1.V_PhanCong_GV to GiangVien;

--XEM QUYỀN TRÊN TABLE CỦA ROLE
--SELECT * FROM ROLE_TAB_PRIVS WHERE ROLE LIKE '%GIANGVIEN%';

-- Tao policy function
create OR REPLACE FUNCTION PC_GV_FUNCTION 
 (P_SCHEMA VARCHAR2, P_OBJ VARCHAR2) 
RETURN VARCHAR2 
as
    STRSQL VARCHAR2(2000);
    CURSOR CUR_GV IS
        (   SELECT MANV 
            FROM ADMIN1.X_NHANSU 
            WHERE MADV IN ( SELECT MADV 
                            FROM ADMIN1.X_NHANSU 
                            WHERE MANV = SYS_CONTEXT('USERENV', 'SESSION_USER')));
    MA VARCHAR2(100);
    user_role varchar2(20);
BEGIN 
    BEGIN
        SELECT vaitro INTO user_role
        FROM admin1.x_nhansu 
        WHERE manv = SYS_CONTEXT('USERENV', 'SESSION_USER');
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            user_role := NULL;
    END;
    
    if user_role is null then
        select masv into user_role 
        from admin1.x_sinhvien 
        where MASV = SYS_CONTEXT('USERENV', 'SESSION_USER');
        
        if user_role is not null then
            return 'MASV = SYS_CONTEXT(''USERENV'', ''SESSION_USER'')';
        else
            return '1=1';
        end if;
    end if;
    if user_role = 'Giang vien' then
        MA := 'SYS_CONTEXT(''USERENV'', ''SESSION_USER'')';
        RETURN 'MAGV = ' || MA;
    elsif user_role = 'Truong don vi' then 
        OPEN CUR_GV;
        LOOP
            FETCH CUR_GV INTO MA;
            EXIT WHEN CUR_GV%NOTFOUND;
            
            IF (STRSQL IS NOT NULL) THEN
                STRSQL := STRSQL || ''', ''';
            END IF;
            STRSQL := STRSQL || MA;
        END LOOP;
        CLOSE CUR_GV;
        RETURN 'MAGV IN (''' || STRSQL || ''')';
    else
        RETURN '';
    end if;
END;  
/

-- Xoa policy
execute dbms_rls.drop_policy('ADMIN1','X_DANGKY','PC_DK_GV')

--  Add policy
BEGIN 
 dbms_rls.add_policy( 
     OBJECT_SCHEMA =>'ADMIN1', 
     OBJECT_NAME=>'X_DANGKY', 
     POLICY_NAME =>'PC_DK_GV', 
     POLICY_FUNCTION=>'PC_GV_FUNCTION', 
     STATEMENT_TYPES=>'SELECT, UPDATE'
 ); 
END;
/

GRANT SELECT, UPDATE ON ADMIN1.X_NHANSU TO GIANGVIEN;
grant select, Update (DIEMTH, DIEMQT, DIEMCK, DIEMTK) on admin1.x_dangky to GiangVien;

--------------------------------------- CS3: GIAO VU ---------------------------
set serveroutput on size unlimited;
ALTER SESSION SET "_ORACLE_SCRIPT" = TRUE;
--TẠO ROLE 
ALTER SESSION SET "_ORACLE_SCRIPT" = TRUE;
drop role RL_GIAOVU;
CREATE ROLE RL_GIAOVU;

--XEM ROLE ĐÃ TẠO
--SELECT * FROM DBA_ROLES WHERE ROLE LIKE '%RL_%' ;

--XEM QUYỀN TRÊN TABLE CỦA ROLE
--SELECT * FROM ROLE_TAB_PRIVS WHERE ROLE LIKE '%RL_%';

--THÊM USER VÀO ROLE
CREATE OR REPLACE PROCEDURE USP_ADDUSRMEM
 (STRROLE VARCHAR, LOAI VARCHAR)
AS
 CURSOR CUR IS (SELECT MANV
                 FROM admin1.X_NHANSU
                 WHERE MANV IN (SELECT USERNAME
                                 FROM ALL_USERS)
                 AND VAITRO = LOAI);
 STRSQL VARCHAR(2000);
 USR VARCHAR2(5);
BEGIN
 OPEN CUR;
 LOOP
     FETCH CUR INTO USR;
     EXIT WHEN CUR%NOTFOUND;
     STRSQL := 'GRANT '||STRROLE||' TO '||USR;
     EXECUTE IMMEDIATE STRSQL;
 END LOOP;
 CLOSE CUR;
END;
/
--THỰC THI THỦ TỤC
BEGIN
 USP_ADDUSRMEM('RL_GIAOVU', 'Giao vu');
END;
/

--XEM DANH SÁCH MEMBER CỦA ROLE
--SELECT * FROM DBA_ROLE_PRIVS WHERE GRANTED_ROLE LIKE '%RL_GIAOVU%';

--1. Như một người dùng có vai trò "Nhân viên cơ bản" 
grant NhanVienCoBan to RL_GIAOVU;

-- VAI TRÒ RIÊNG CỦA GIÁO VỤ
-- 2. Xem, thêm dòng hoặc cập nhật thông tin trên các quan hệ SINHVIEN, ĐONVI
-- HOCPHAN, KHMO, theo yêu cầu của trưởng khoa.
GRANT SELECT, INSERT, UPDATE ON admin1.X_SINHVIEN TO RL_GIAOVU;
GRANT SELECT, INSERT, UPDATE ON admin1.X_DONVI TO RL_GIAOVU;
GRANT SELECT, INSERT, UPDATE ON admin1.X_HOCPHAN TO RL_GIAOVU;
GRANT SELECT, INSERT, UPDATE ON admin1.X_KHMO TO RL_GIAOVU;
GRANT SELECT ON admin1.X_PHANCONG TO RL_GIAOVU;
GRANT  SELECT ON admin1.X_DANGKY TO RL_GIAOVU;

------------------------------- CS4: TRUONG DON VI -----------------------------
-- XÓA ROLE "RL_TRGDV"
ALTER SESSION SET "_ORACLE_SCRIPT" = TRUE;
DROP  ROLE RL_TRGDV;
ALTER SESSION SET "_ORACLE_SCRIPT" = FALSE;

-- TẠO ROLE "RL_TRGDV"
ALTER SESSION SET "_ORACLE_SCRIPT" = TRUE;
CREATE ROLE RL_TRGDV;
ALTER SESSION SET "_ORACLE_SCRIPT" = FALSE;

-- VIẾT PROCEDURE THÊM USER VÀO ROLE
CREATE OR REPLACE PROCEDURE USP_ADDUSRMEN
    (STRROLE VARCHAR, LOAI VARCHAR)
AS
    CURSOR CUR_NHANSU IS (
        SELECT MANV
        FROM ADMIN1.X_NHANSU
        WHERE MANV IN (SELECT USERNAME FROM ALL_USERS)
            AND VAITRO = LOAI
    );
    
    STRSQL VARCHAR(2000);
    USR VARCHAR2(5);
BEGIN
    OPEN CUR_NHANSU;
    LOOP
        FETCH CUR_NHANSU INTO USR;
        EXIT WHEN CUR_NHANSU%NOTFOUND;
        
        STRSQL := 'GRANT ' || STRROLE || ' TO ' || USR;
        EXECUTE IMMEDIATE(STRSQL);
    END LOOP;
    CLOSE CUR_NHANSU;
END;
/
-- THỰC THI PROCEDURE USP_ADDUSRMEN_TRGDV
BEGIN
    USP_ADDUSRMEN('RL_TRGDV', 'Truong don vi');
END;
/
-- XEM DANH SÁCH MEMBER CỦA ROLE 
-- SELECT * FROM SYS.DBA_ROLE_PRIVS WHERE GRANTED_ROLE LIKE '%RL_TRGDV'; 

-- PHÂN QUYỀN CHO ROLE RL_TRGDV
-- 1. Như một người dùng có vai trò “Giảng viên” (xem mô tả CS#2).
grant GiangVien to RL_TRGDV;
grant NhanVienCoBan to RL_TRGDV;

-- 2. Thêm, Xóa, Cập nhật dữ liệu trên quan hệ PHANCONG, đối với các học phần được
-- phụ trách chuyên môn bởi đơn vị mà mình làm trưởng,
-- B1: TẠO FUNCTION POLICY
CREATE OR REPLACE FUNCTION PC1_FUNCTION
    (P_SCHEMA VARCHAR2, P_OB VARCHAR2)
    RETURN VARCHAR2
AS
    MA VARCHAR2(5);
    STRSQL VARCHAR2(2000);
    CURSOR CUR_GV IS
        (SELECT MANV 
        FROM ADMIN1.X_NHANSU 
        WHERE MADV IN (SELECT MADV FROM ADMIN1.X_NHANSU WHERE MANV = SYS_CONTEXT('USERENV', 'SESSION_USER')));
BEGIN
    OPEN CUR_GV;
    LOOP
        FETCH CUR_GV INTO MA;
        EXIT WHEN CUR_GV%NOTFOUND;
        
        IF (STRSQL IS NOT NULL) THEN
            STRSQL := STRSQL || ''', ''';
        END IF;
        STRSQL := STRSQL || MA;
    END LOOP;
    DBMS_OUTPUT.PUT_LINE('MAGV IN (''' || STRSQL || ''')');
    CLOSE CUR_GV;
    RETURN 'MAGV IN (''' || STRSQL || ''')';
END;
/

-- B2: XÓA POLICY VỚI ĐỐI TƯỢNG CẦN KIỂM TRA
BEGIN
    DBMS_RLS.DROP_POLICY (
        object_schema => 'ADMIN1',
        object_name => 'X_PHANCONG',
        policy_name => 'PC1'
    );
END;
/
-- B2: GẮN POLICY VỚI ĐỐI TƯỢNG CẦN KIỂM TRA
BEGIN
    DBMS_RLS.ADD_POLICY (
        OBJECT_SCHEMA => 'ADMIN1',
        OBJECT_NAME=> 'X_PHANCONG',
        POLICY_NAME => 'PC1',
        POLICY_FUNCTION=> 'PC1_FUNCTION',
        STATEMENT_TYPES=> 'UPDATE, DELETE, INSERT',
        UPDATE_CHECK => TRUE 
    );
END;
/
-- CẤP QUYỀN SELECT, DELETE, UPDATE, INSERT
GRANT DELETE, UPDATE, INSERT ON ADMIN1.X_PHANCONG TO RL_TRGDV;

-- 3. Được xem dữ liệu phân công giảng dạy của các giảng viên thuộc các đơn vị mà mình làm trưởng
-- B1: TẠO FUNCTION POLICY
CREATE OR REPLACE FUNCTION PC3_FUNCTION (P_SCHEMA VARCHAR2, P_OB VARCHAR2)
RETURN VARCHAR2
AS
    MA VARCHAR2(5);
    STRSQL VARCHAR2(2000);
    vaitro_user VARCHAR2(100);
    CURSOR CUR_GV IS
        SELECT MANV 
        FROM ADMIN1.X_NHANSU
        WHERE MADV IN (
            SELECT MADV 
            FROM ADMIN1.X_NHANSU 
            WHERE MANV = SYS_CONTEXT('USERENV', 'SESSION_USER')
        );
BEGIN
    
    BEGIN
        SELECT vaitro INTO vaitro_user 
        FROM ADMIN1.X_NHANSU 
        WHERE MANV = SYS_CONTEXT('USERENV', 'SESSION_USER');
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            vaitro_user := NULL;
    END;
    IF vaitro_user = 'Truong khoa' OR vaitro_user = 'Giao vu' THEN
        RETURN '';
    ELSIF vaitro_user = 'Giang vien' THEN 
        RETURN 'MAGV = SYS_CONTEXT(''USERENV'', ''SESSION_USER'')';
    ELSIF vaitro_user = 'Truong don vi' THEN 
        OPEN CUR_GV;
        LOOP
            FETCH CUR_GV INTO MA;
            EXIT WHEN CUR_GV%NOTFOUND;
            IF STRSQL IS NOT NULL THEN
                STRSQL := STRSQL || ', ';
            END IF;
            STRSQL := STRSQL || '''' || MA || '''';
        END LOOP;
        CLOSE CUR_GV;
        RETURN 'MAGV IN (' || STRSQL || ')';
    ELSE 
        RETURN '';
    END IF;
    
    --RETURN NULL; -- In case none of the conditions match
END;
/

-- TEST FUNCTION POLICY
--SET SERVEROUTPUT ON
--DECLARE 
--    KQ VARCHAR2(2000);
--BEGIN 
--    KQ:= admin1.PC3_FUNCTION('ADMIN1', 'X_PHANCONG');
--    DBMS_OUTPUT.PUT_LINE(KQ);
--END;
--/
-- B2: XÓA POLICY VỚI ĐỐI TƯỢNG CẦN KIỂM TRA
BEGIN
    DBMS_RLS.DROP_POLICY (
        object_schema => 'ADMIN1',
        object_name => 'X_PHANCONG',
        policy_name => 'PC3'
    );
END;
/
-- B2: GẮN POLICY VỚI ĐỐI TƯỢNG CẦN KIỂM TRA
BEGIN
    DBMS_RLS.ADD_POLICY (
        OBJECT_SCHEMA => 'ADMIN1',
        OBJECT_NAME=> 'X_PHANCONG',
        POLICY_NAME => 'PC3',
        POLICY_FUNCTION=> 'PC3_FUNCTION',
        STATEMENT_TYPES=> 'SELECT'
    );
END;
/
-- CẤP QUYỀN SELECT, DELETE, UPDATE, INSERT
GRANT SELECT, DELETE, UPDATE, INSERT ON ADMIN1.X_PHANCONG TO RL_TRGDV;

-- TEST USER GV02
/*
SELECT * FROM ADMIN1.X_PHANCONG;

DELETE FROM ADMIN1.X_PHANCONG 
WHERE MAGV = 'GV01' AND MAHP = 'HTTT01' AND HK = 1 AND NAM = 2024 AND MACT = 'CTTT';

INSERT INTO ADMIN1.X_PHANCONG 
VALUES('GV02', 'HTTT01',  '1', '2024', 'CTTT');

UPDATE ADMIN1.X_PHANCONG 
SET MACT = 'CLC'
WHERE MAGV = 'GV02' AND MAHP = 'HTTT01' AND HK = 1 AND NAM = 2024 AND MACT = 'CTTT';
SELECT * FROM X_HOCPHAN;
*/


------------------------------- CS5: TRUONG KHOA -------------------------------
--DAC
-- 1. Như một người dùng có vai trò “Giảng viên”
grant GiangVien to TK;

-- 2. Thêm, Xóa, Cập nhật dữ liệu trên quan hệ PHANCONG đối với các học phần quản lý bởi đơn vị “Văn phòng khoa”.
-- Quản lí truy cập sẽ sử dụng policy pc1 từ trưởng đơn vị.
-- CẤP QUYỀN CHO ROLE RL_TRGKHOA
GRANT SELECT, UPDATE, DELETE, INSERT ON admin1.X_PHANCONG TO TK;

-- 3. Được quyền Xem, Thêm, Xóa, Cập nhật trên quan hệ NHANSU 
GRANT SELECT, UPDATE, DELETE, INSERT ON admin1.X_NHANSU TO TK;

-- 4. Được quyền Xem (không giới hạn) dữ liệu trên toàn bộ lược đồ CSDL.
GRANT SELECT ON ADMIN1.X_DANGKY TABLE TO TK;

------------------------------- CS6: SINH VIEN ---------------------------------
-- Tạo role sinh viên
-- drop role rl_SinhVien;
ALTER SESSION SET "_ORACLE_SCRIPT" = TRUE;
drop role rl_SinhVien;
create role rl_SinhVien;
-- Gán role cho user sinh viên
CREATE OR REPLACE PROCEDURE sp_grant_role_to_sv_users AS
BEGIN
    FOR rec IN (SELECT MASV FROM admin1.X_SINHVIEN WHERE SUBSTR(MASV, 1, 2) = 'SV') LOOP
        EXECUTE IMMEDIATE 'GRANT rl_SinhVien TO ' || rec.MASV;
    END LOOP;
END;
/

-- Thuc thi 
exec sp_grant_role_to_sv_users;
/ 

--SELECT * FROM dba_role_privs WHERE granted_role = 'RL_SINHVIEN';

-- 1.Trên quan hệ SINHVIEN, sinh viên chỉ được xem thông tin của chính mình, được
-- Chỉnh sửa thông tin địa chỉ (ĐCHI) và số điện thoại liên lạc (ĐT) của chính sinh viên.
CREATE OR REPLACE FUNCTION PC1_FUNCTION_CS6 
(P_SCHEMA VARCHAR2, P_OBJ VARCHAR2)
RETURN VARCHAR2
AS
  v_username VARCHAR2(100);
BEGIN
  -- Lấy username của người dùng hiện tại
  SELECT SYS_CONTEXT('USERENV', 'SESSION_USER') INTO v_username FROM dual;

  -- Kiểm tra xem username có bắt đầu bằng 'SV' không
  IF REGEXP_LIKE(v_username, '^SV') THEN
    -- Nếu username bắt đầu bằng 'SV', trả về điều kiện cho policy
    RETURN 'MASV = SYS_CONTEXT(''USERENV'', ''SESSION_USER'')';
  ELSE
    -- Nếu không, trả về rỗng (không áp dụng policy)
    RETURN '';
  END IF;
END;
/

BEGIN
    DBMS_RLS.DROP_POLICY(
        object_schema   => 'admin1', 
        object_name     => 'X_SINHVIEN',
        policy_name     => 'PC1'
    );
END;
/

BEGIN
    DBMS_RLS.ADD_POLICY(
        object_schema   => 'admin1', 
        object_name     => 'X_SINHVIEN',
        policy_name     => 'PC1',
        policy_function => 'PC1_FUNCTION_CS6',
        statement_types => 'SELECT, UPDATE',
        update_check    => TRUE
    );
END;
/

-- GRANT QUYEN
grant select, update(DCHI, DT) on admin1.X_SINHVIEN to rl_SinhVien; 
/ 

--test
--conn SV02/SV02;
--select * from admin1.X_SINHVIEN;
--update admin1.X_SINHVIEN set PHAI = '';
--select * from admin1.X_SINHVIEN;
--update admin1.X_SINHVIEN set DT = '098765432111';
--select * from admin1.X_SINHVIEN;
--select * from admin1.X_SINHVIEN;
--update admin1.X_SINHVIEN set DCHI = 'Hà Nội123';
--select * from admin1.X_SINHVIEN;

--- Xem danh sách tất cả học phần (HOCPHAN), kế hoạch mở môn (KHMO) của chương trình đào tạo mà sinh viên đang theo học.
CREATE OR REPLACE FUNCTION PC2_FUNCTION_CS6_1
(P_SCHEMA VARCHAR2, P_OBJ VARCHAR2)
RETURN VARCHAR2
AS
  v_username VARCHAR2(100);
BEGIN
  -- Lấy username của người dùng hiện tại
  SELECT SYS_CONTEXT('USERENV', 'SESSION_USER') INTO v_username FROM dual;

  -- Kiểm tra xem username có bắt đầu bằng 'SV' không
  IF REGEXP_LIKE(v_username, '^SV') THEN
    -- Nếu username bắt đầu bằng 'SV', trả về điều kiện cho policy
    RETURN 'MACT = (SELECT MACT FROM admin1.X_SINHVIEN WHERE MASV = SYS_CONTEXT(''USERENV'', ''SESSION_USER''))';
  ELSE
    -- Nếu không, trả về rỗng (không áp dụng policy)
    RETURN '';
  END IF;
END;
/

BEGIN
    DBMS_RLS.DROP_POLICY(
        object_schema   => 'admin1', 
        object_name     => 'X_KHMO',
        policy_name     => 'PC2'
    );
END;
/

BEGIN
    DBMS_RLS.ADD_POLICY(
        object_schema   => 'admin1', 
        object_name     => 'X_KHMO',
        policy_name     => 'PC2',
        policy_function => 'PC2_FUNCTION_CS6_1',
        statement_types => 'SELECT',
        update_check    => FALSE
    );
END;
/

CREATE OR REPLACE FUNCTION PC2_FUNCTION_CS6_2
(P_SCHEMA VARCHAR2, P_OBJ VARCHAR2)
RETURN VARCHAR2
AS
  v_username VARCHAR2(100);
BEGIN
  -- Lấy username của người dùng hiện tại
  SELECT SYS_CONTEXT('USERENV', 'SESSION_USER') INTO v_username FROM dual;

  -- Kiểm tra xem username có bắt đầu bằng 'SV' không
  IF REGEXP_LIKE(v_username, '^SV') THEN
    -- Nếu username bắt đầu bằng 'SV', trả về điều kiện cho policy
    RETURN 'MAHP IN (SELECT MAHP FROM admin1.X_KHMO WHERE MACT = (SELECT MACT FROM admin1.X_SINHVIEN WHERE MASV = SYS_CONTEXT(''USERENV'', ''SESSION_USER'')))';
  ELSE
    -- Nếu không, trả về rỗng (không áp dụng policy)
    RETURN '';
  END IF;
END;
/

BEGIN
    DBMS_RLS.DROP_POLICY(
        object_schema   => 'admin1', 
        object_name     => 'X_HOCPHAN',
        policy_name     => 'PC2'
    );
END;
/

BEGIN
    DBMS_RLS.ADD_POLICY(
        object_schema   => 'admin1', 
        object_name     => 'X_HOCPHAN',
        policy_name     => 'PC2',
        policy_function => 'PC2_FUNCTION_CS6_2',
        statement_types => 'SELECT',
        update_check    => FALSE
    );
END;
/

grant select on admin1.X_HOCPHAN to rl_SinhVien; 
grant select on admin1.X_KHMO to rl_SinhVien; 
--test
--conn SV01/SV01;
--select * from admin1.X_KHMO;
--select * from admin1.X_HOCPHAN;
--- Thêm, Xóa các dòng dữ liệu đăng ký học phần (ĐANGKY) liên quan đến chính sinh
--viên đó trong học kỳ của năm học hiện tại (nếu thời điểm hiệu chỉnh đăng ký còn hợp lệ).
--- Sinh viên có thể hiệu chỉnh đăng ký học phần (thêm, xóa) nếu ngày hiện tại không vượt quá
--14 ngày so với ngày bắt đầu học kỳ (xem thêm thông tin về học kỳ trong quan hệ KHMO)
--mà sinh viên đang hiệu chỉnh đăng ký học phần.
-- Tạo một hàm PL/SQL để kiểm tra xem thời gian hiệu chỉnh đăng ký có hợp lệ không


-- Tạo chính sách VPD
CREATE OR REPLACE FUNCTION PC3_FUNCTION_CS6 (
    p_schema_name IN VARCHAR2,
    p_object_name IN VARCHAR2
) RETURN VARCHAR2 IS
    v_policy VARCHAR2(4000);
    v_username VARCHAR2(100);
BEGIN
    -- Lấy username của người dùng hiện tại
    SELECT SYS_CONTEXT('USERENV', 'SESSION_USER') INTO v_username FROM dual;

    -- Kiểm tra xem username có bắt đầu bằng 'SV' không
    IF REGEXP_LIKE(v_username, '^SV') THEN
        -- Nếu username bắt đầu bằng 'SV', trả về điều kiện cho policy
        -- Kiểm tra dữ liệu phải liên quan tới sinh viên đó
        v_policy := 'MASV = SYS_CONTEXT(''USERENV'', ''SESSION_USER'')';
        
        v_policy := v_policy || ' AND (SYSDATE <= 
          CASE
            WHEN HK = 2 THEN TO_DATE(''01-05-'' || NAM, ''DD-MM-YYYY'') + INTERVAL ''14'' DAY
            WHEN HK = 3 THEN TO_DATE(''01-09-'' || NAM, ''DD-MM-YYYY'') + INTERVAL ''14'' DAY
            WHEN HK = 1 THEN TO_DATE(''01-01-'' || NAM, ''DD-MM-YYYY'') + INTERVAL ''14'' DAY
          END)';
        RETURN v_policy;
    ELSE
        -- Nếu không, trả về rỗng (không áp dụng policy)
        RETURN '(SYSDATE <= 
          CASE
            WHEN HK = 2 THEN TO_DATE(''01-05-'' || NAM, ''DD-MM-YYYY'') + INTERVAL ''14'' DAY
            WHEN HK = 3 THEN TO_DATE(''01-09-'' || NAM, ''DD-MM-YYYY'') + INTERVAL ''14'' DAY
            WHEN HK = 1 THEN TO_DATE(''01-01-'' || NAM, ''DD-MM-YYYY'') + INTERVAL ''14'' DAY
          END)';
    END IF;
END;
/
--WHEN HK = 2 THEN TO_DATE(''01-05-'' || NAM, ''DD-MM-YYYY'') + INTERVAL ''14'' DAY
--WHEN HK = 3 THEN TO_DATE(''01-09-'' || NAM, ''DD-MM-YYYY'') + INTERVAL ''14'' DAY
--WHEN HK = 1 THEN TO_DATE(''01-01-'' || NAM, ''DD-MM-YYYY'') + INTERVAL ''14'' DAY
BEGIN
    DBMS_RLS.DROP_POLICY(
        object_schema   => 'admin1', 
        object_name     => 'X_DANGKY',
        policy_name     => 'PC3'
    );
END;
/

-- Áp dụng chính sách VPD cho bảng X_DANGKY
BEGIN
    DBMS_RLS.ADD_POLICY(
        object_schema => 'admin1',
        object_name => 'X_DANGKY',
        policy_name => 'PC3',
        policy_function => 'PC3_FUNCTION_CS6',
        statement_types => 'INSERT, DELETE',
        update_check => TRUE
    );
END;
/
grant insert, delete on admin1.X_DANGKY to rl_SinhVien;
--Test
--Sửa lại yêu cầu ngày cho đúng mới test đc chứ 14 ngày sẽ không được
--conn SV01/SV01;
--insert into admin1.X_DANGKY values('SV01', 'GV01', 'HTTT01', '2', '2024', 'CQ',9,9,9,9);
--select * from admin1.X_DANGKY;
--conn SV01/SV01;
--DELETE FROM admin1.x_dangky WHERE masv = 'SV01' and mahp = 'HTTT01' and magv = 'GV01' and hk = '1' and nam = '2024' and mact = 'CQ';
--select * from admin1.X_DANGKY;

--- Sinh viên không được chỉnh sửa trên các trường liên quan đến điểm.
-- Tạo chính sách VPD
CREATE OR REPLACE FUNCTION PC4_FUNCTION_CS6 (
    p_schema_name IN VARCHAR2,
    p_object_name IN VARCHAR2
) RETURN VARCHAR2 IS
    v_policy VARCHAR2(4000);
    v_username VARCHAR2(100);
BEGIN
  -- Lấy username của người dùng hiện tại
  SELECT SYS_CONTEXT('USERENV', 'SESSION_USER') INTO v_username FROM dual;

  -- Kiểm tra xem username có bắt đầu bằng 'SV' không
  IF REGEXP_LIKE(v_username, '^SV') THEN
    -- Nếu username bắt đầu bằng 'SV', trả về điều kiện cho policy
    -- Kiểm tra dữ liệu phải liên quan tới sinh viên đó
    v_policy := 'MASV = SYS_CONTEXT(''USERENV'', ''SESSION_USER'')';
    RETURN v_policy;
  ELSE
    -- Nếu không, trả về rỗng (không áp dụng policy)
    RETURN '';
  END IF;
END;
/

--BEGIN
--    DBMS_RLS.DROP_POLICY(
--        object_schema   => 'admin1', 
--        object_name     => 'X_DANGKY',
--        policy_name     => 'PC4'
--    );
--END;
--/

--BEGIN
--    DBMS_RLS.ADD_POLICY(
--        object_schema => 'admin1',
--        object_name => 'X_DANGKY',
--        policy_name => 'PC4',
--        policy_function => 'PC4_FUNCTION_CS6',
--        statement_types => 'UPDATE',
--        update_check => TRUE
--    );
--END;
--/

grant update(MASV, MAGV, MAHP, HK, NAM, MACT) on admin1.X_DANGKY to rl_SinhVien; 
--test
--conn SV01/SV01;
--select * from admin1.X_DANGKY;
--update admin1.X_DANGKY set MAGV = 'GV02'
--where MAGV = 'GV01'
--and MAHP = 'HTTT01' 
--and HK = 1 
--and NAM = 2024
--and MACT = 'CQ';
--select * from admin1.X_DANGKY;

--- Sinh viên được Xem tất cả thông tin trên quan hệ ĐANGKY tại các dòng dữ liệu liên quan đến chính sinh viên.
create or replace function PC5_FUNCTION_CS6 
(P_SCHEMA VARCHAR2, P_OBJ VARCHAR2)
RETURN VARCHAR2
AS
  v_username VARCHAR2(100);
BEGIN
  -- Lấy username của người dùng hiện tại
  SELECT SYS_CONTEXT('USERENV', 'SESSION_USER') INTO v_username FROM dual;

  -- Kiểm tra xem username có bắt đầu bằng 'SV' không
  IF REGEXP_LIKE(v_username, '^SV') THEN
    -- Nếu username bắt đầu bằng 'SV', trả về điều kiện cho policy
    RETURN 'MASV = SYS_CONTEXT(''USERENV'', ''SESSION_USER'')';
  ELSE
    -- Nếu không, trả về rỗng (không áp dụng policy)
    RETURN '';
  END IF;
END;
/

--BEGIN
--    DBMS_RLS.DROP_POLICY(
--        object_schema   => 'admin1', 
--        object_name     => 'X_DANGKY',
--        policy_name     => 'PC5'
--    );
--END;
--/

--BEGIN
--    DBMS_RLS.ADD_POLICY(
--        object_schema   => 'admin1', 
--        object_name     => 'X_DANGKY',
--        policy_name     => 'PC5',
--        policy_function => 'PC5_FUNCTION_CS6',
--        statement_types => 'SELECT',
--        update_check    => FALSE
--    );
--END;
--/

grant select on admin1.X_DANGKY to rl_SinhVien;
--test
--conn SV01/SV01;
--select * from admin1.X_DANGKY;

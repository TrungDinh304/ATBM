-- YÊU CẦU 3: GHI NHẬT KÝ HỆ THỐNG
alter session set "_ORACLE_SCRIPT"=true;
alter session set "_optimizer_filter_pred_pullup"=false; 

-- 1. Kích hoạt việc ghi nhật ký hệ thống.
ALTER SYSTEM SET audit_trail = DB SCOPE = SPFILE; 

-- 2. Thực hiện ghi nhận ký hệ thống Standard audit: theo dõi hành vi của những user
-- nào trên những đối tượng cụ thể, trên các đối tượng khác nhau (table, view, stored
-- procedure, function), hay chỉ định theo rõ các hành vi hiện thành công hay không thành công.

-- Ghi nhật ký các hành vi cập nhật view V_DANGKY_GV không thành công
AUDIT UPDATE ON ADMIN1.X_DANGKY WHENEVER NOT SUCCESSFUL;

-- Ghi nhật ký việc thực thi thủ tục  ADMIN1.X_NHANSU
AUDIT DELETE ON ADMIN1.X_NHANSU BY ACCESS;

-- Ghi nhật ký các phiên login không thành công
AUDIT SESSION WHENEVER NOT SUCCESSFUL;

-- 3. Thực hiện Fine-grained Audit các tình huống sau và tạo ngữ cảnh để có thể ghi 
-- vết được (có dữ liệu ghi vết) các hành vi sau:
-- a. Hành vi Cập nhật quan hệ DANGKY tại các trường liên quan đến điểm số
-- nhưng người đó không thuộc vai trò Giảng viên.
-- Tạo hàm kiểm tra vai trò
CREATE OR REPLACE FUNCTION CHECK_GIANGVIEN RETURN NUMBER IS
    v_count NUMBER := 0;
BEGIN
    -- Kiểm tra số lượng bản ghi từ câu truy vấn
    SELECT COUNT(*)
    INTO v_count
    FROM DBA_ROLE_PRIVS
    WHERE GRANTED_ROLE = 'GIANGVIEN'
    AND GRANTEE = SYS_CONTEXT('USERENV', 'SESSION_USER');
    
    -- Trả về 0 không là giảng viên, ngược lại trả về 1 là giảng viên
    IF v_count = 0 THEN
        RETURN 0;
    ELSE
        RETURN 1;
    END IF;
END;
/


-- Xóa policy 
--BEGIN
--    DBMS_FGA.drop_policy (
--        object_schema => 'ADMIN1',
--        object_name   => 'X_DANGKY',
--        policy_name   => 'AUDIT_UPDATE_DIEM'
--    );
--END;
--/
BEGIN
    DBMS_FGA.ADD_POLICY (
        OBJECT_SCHEMA   => 'ADMIN1',                              
        OBJECT_NAME     => 'X_DANGKY',                         
        POLICY_NAME     => 'AUDIT_UPDATE_DIEM',                   
        AUDIT_CONDITION => 'CHECK_GIANGVIEN() = 0',                
        AUDIT_COLUMN    => 'DIEMTH, DIEMQT, DIEMCK, DIEMTK',      
        STATEMENT_TYPES => 'UPDATE',                               
        ENABLE          => TRUE, 
        AUDIT_TRAIL     => DBMS_FGA.DB + DBMS_FGA.EXTENDED       
    );
END;
/

-- b. Hành vi của người dùng này có thể đọc trên trường PHUCAP của người khác
-- ở quan hệ NHANSU.
BEGIN
    DBMS_FGA.ADD_POLICY (
        OBJECT_SCHEMA   => 'ADMIN1',                              
        OBJECT_NAME     => 'X_NHANSU',                         
        POLICY_NAME     => 'AUDIT_SELECT_PHUCAP',                   
        AUDIT_CONDITION => 'MANV != USER',                
        AUDIT_COLUMN    => 'PHUCAP',      
        STATEMENT_TYPES => 'SELECT',                               
        ENABLE          => TRUE, 
        AUDIT_TRAIL     => DBMS_FGA.DB + DBMS_FGA.EXTENDED       
    );
END;
/

 --Xóa policy
BEGIN
    DBMS_FGA.drop_policy (
        object_schema => 'ADMIN1',
        object_name   => 'X_NHANSU',
        policy_name   => 'AUDIT_SELECT_PHUCAP'
    );
END;
/
-- 4. Kiểm tra (đọc xuất) dữ liệu nhật ký hệ thống
SELECT AUDIT_TYPE, EXTENDED_TIMESTAMP, DB_USER, OBJECT_SCHEMA, OBJECT_NAME, STATEMENT_TYPE, COMMENT_TEXT
FROM DBA_COMMON_AUDIT_TRAIL
ORDER BY EXTENDED_TIMESTAMP;

-- Xóa các bản ghi hiện có trong bảng AUD$ và FGA_LOG$
DELETE FROM SYS.AUD$;
DELETE FROM SYS.FGA_LOG$;

-- TEST TRUONG HOP AUDIT
CONN SV01/SV01
update admin1.v_dangky_gv set DIEMQT = 10
where masv = 'SV01' and magv = 'GV01' and mahp = 'HTTT01' and hk = 1 and nam = 2024 and mact = 'CQ';





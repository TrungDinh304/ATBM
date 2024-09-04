--Store procedure cập nhập số điện thoại và địa chỉ của sinh viên
create or REPLACE PROCEDURE admin1.USP_UPDATE_SDT_DCHI_SV
    (sodienthoai VARCHAR2,
     diachi VARCHAR2,
     p_error_code OUT NUMBER,
     p_error_msg OUT VARCHAR2
    )
as
begin 
    update admin1.X_SINHVIEN set dt = sodienthoai, dchi = diachi;
    IF SQL%ROWCOUNT = 0 THEN
        p_error_code := -1; -- Không có dữ liệu được cập nhật
        p_error_msg := 'No data updated.';
    ELSE
        p_error_code := 0; -- Thành công
        p_error_msg := 'Update successful.';
    END IF;
    EXCEPTION
    WHEN OTHERS THEN
        p_error_code := SQLCODE;
        p_error_msg := SQLERRM;
end;
/
grant execute on admin1.USP_UPDATE_SDT_DCHI_SV to rl_SinhVien;

--Store procedure xoá đăng ký
create or REPLACE PROCEDURE admin1.USP_DELETE_DK
    (
     masinhvien VARCHAR2,
     magiangvien VARCHAR2,
     mahocphan VARCHAR2,
     hocki VARCHAR2,
     namhoc VARCHAR2,
     machuongtrinh VARCHAR2,
     p_error_code OUT NUMBER,
     p_error_msg OUT VARCHAR2
    )
as
begin 
    DELETE FROM admin1.x_dangky WHERE masv = masinhvien and mahp = mahocphan and magv = magiangvien and hk = hocki and nam = namhoc and mact = machuongtrinh;
    -- Nếu INSERT thành công, đặt mã lỗi là 0
    IF SQL%ROWCOUNT = 0 THEN
        p_error_code := -1; -- Custom error code for no rows affected
        p_error_msg := 'No rows were deleted.';
    ELSE
        p_error_code := 0; -- Success
        p_error_msg := 'Delete successful';
    END IF;
    EXCEPTION
    WHEN OTHERS THEN
        p_error_code := SQLCODE;
        p_error_msg := SQLERRM;
end;
/
grant execute on admin1.USP_DELETE_DK to rl_SinhVien;

--Tạo view để xem danh sách học phần mở hiện tại (phân công) liên quan tới sinh viên
create or replace view admin1.UV_HOCPHANMO
as
select p.mahp, h.tenhp, h.sotc, p.hk, p.nam, p.mact, p.magv
from admin1.X_HOCPHAN h, admin1.X_PHANCONG p, admin1.X_SINHVIEN s
where s.masv = SYS_CONTEXT('USERENV', 'SESSION_USER')
and s.mact = p.mact
and p.mahp = h.mahp
AND SYSDATE <= CASE
                WHEN p.hk = 2 THEN TO_DATE('01-05-' || p.nam, 'DD-MM-YYYY') + INTERVAL '14' DAY
                WHEN p.hk = 3 THEN TO_DATE('01-09-' || p.nam, 'DD-MM-YYYY') + INTERVAL '14' DAY
                WHEN p.hk = 1 THEN TO_DATE('01-01-' || p.nam, 'DD-MM-YYYY') + INTERVAL '14' DAY
              END;
grant select on admin1.UV_HOCPHANMO to rl_SinhVien;
--Store procedure thêm đăng ký
CREATE OR REPLACE PROCEDURE admin1.USP_INSERT_DK
(
    masinhvien VARCHAR2,
    magiangvien VARCHAR2,
    mahocphan VARCHAR2,
    hocki VARCHAR2,
    namhoc VARCHAR2,
    machuongtrinh VARCHAR2,
    p_error_code OUT NUMBER,
    p_error_msg OUT VARCHAR2
)
AS
    v_count NUMBER;
BEGIN
    -- Check if the course has already been registered by the student
    SELECT COUNT(*)
    INTO v_count
    FROM admin1.X_DANGKY
    WHERE masv = masinhvien
      AND mahp = mahocphan
      AND hk = hocki
      AND nam = namhoc
      AND mact = machuongtrinh;

    -- If a record is found, set an error code and message
    IF v_count > 0 THEN
        p_error_code := -2; -- Custom error code for already registered
        p_error_msg := 'The course has already been registered by the student.';
    ELSE
        -- Proceed with the insert
        INSERT INTO admin1.X_DANGKY(masv, magv, mahp, hk, nam, mact)
        VALUES (masinhvien, magiangvien, mahocphan, hocki, namhoc, machuongtrinh);

        -- If INSERT is successful, set success code and message
        IF SQL%ROWCOUNT = 0 THEN
            p_error_code := -1; -- Custom error code for no rows affected
            p_error_msg := 'No rows were inserted.';
        ELSE
            p_error_code := 0; -- Success
            p_error_msg := 'Insert successful';
        END IF;
    END IF;

EXCEPTION
    WHEN OTHERS THEN
        p_error_code := SQLCODE;
        p_error_msg := SQLERRM;
END;
/

grant execute on admin1.USP_INSERT_DK to rl_SinhVien;

-- trigger kiểm tra khi thêm vào đăng ký sinh viên không có quyền sửa điểm
CREATE OR REPLACE TRIGGER trg_before_insert_X_DANGKY
BEFORE INSERT ON admin1.X_DANGKY
FOR EACH ROW
BEGIN
    IF SUBSTR(SYS_CONTEXT('USERENV', 'SESSION_USER'), 1, 2) = 'SV' THEN
        :NEW.DIEMTH := 0;
        :NEW.DIEMQT := 0;
        :NEW.DIEMCK := 0;
        :NEW.DIEMTK := 0;
    END IF;
END;
/

------------------------------------------------------------------------------

create or replace Procedure admin1.USP_Select_DK_GV
    (p_masv in varchar2,
    p_mahp in varchar2,
    p_hk in int,
    p_nam in int,
    p_mact in varchar2,    
    p_result OUT SYS_refcursor,
    p_error_code OUT NUMBER,
    p_error_msg OUT VARCHAR2)
as
begin 
    if p_masv is not null then
        open p_result for   
                        select masv, diemqt, diemth, diemck, diemtk 
                        from ADMIN1.x_dangky 
                        where   masv = p_masv and 
                                mahp = p_mahp and 
                                hk = p_hk and 
                                nam = p_nam and 
                                mact = p_mact;
        p_error_msg := 'select p_masv' || p_masv;
    else 
        open p_result for 
                        select masv, diemqt, diemth, diemck, diemtk 
                        from ADMIN1.x_dangky 
                        where   mahp = p_mahp and 
                                hk = p_hk and 
                                nam = p_nam and 
                                mact = p_mact;
        p_error_msg := 'Select all ' || p_masv;
    end if;
    
    
    EXCEPTION
    WHEN NO_DATA_FOUND THEN
        p_error_code := -1; -- Custom error code
        p_error_msg := 'No data found for the specified object.';
    WHEN OTHERS THEN
        p_error_code := SQLCODE;
        p_error_msg := SQLERRM;
end;
/

create or replace Procedure admin1.USP_Update_DK_GV
    (p_masv in varchar2,
    p_mahp in varchar2,
    p_hk in int,
    p_nam in int,
    p_mact in varchar2,
    diem_qt in int,
    diem_th in int,
    diem_ck in int,
    p_error_code OUT NUMBER,
    p_error_msg OUT VARCHAR2)
as
begin 
    if  (diem_qt between 0 and 10) and 
        (diem_th between 0 and 10) and 
        (diem_ck between 0 and 10) then 
            update admin1.x_dangky
            set diemqt = diem_qt, diemth = diem_th, 
            diemck = diem_ck, diemtk = 0.2*diem_qt + 0.3*diem_th + 0.5*diem_ck
            where   masv = p_masv and
                    mahp = p_mahp and
                    hk = p_hk and
                    nam = p_nam and
                    mact = p_mact;
        p_error_code := 0;
        p_error_msg := null;
    else 
        RAISE_APPLICATION_ERROR(-20001, 'Điểm không hợp lệ');
    end if;
    EXCEPTION
    WHEN NO_DATA_FOUND THEN
        p_error_code := -1; -- Custom error code
        p_error_msg := 'No data found for the specified object.';
    WHEN OTHERS THEN
        p_error_code := SQLCODE;
        p_error_msg := SQLERRM;
end;
/

grant execute on ADMIN1.USP_Select_DK_GV to GiangVien;
grant execute on ADMIN1.USP_Update_DK_GV to giangvien;

create or replace View admin1.V_GiangVien_PhanCong_Donvi
as
    select MaNV, Hoten, dt, madv
    from x_nhansu
    where MaDV = (  select madv 
                    from x_nhansu 
                    where manv = SYS_CONTEXT('USERENV','SESSION_USER'));
/
create or replace procedure admin1.USP_select_KHM_TDV
    (p_madv in varchar2,
     p_result OUT SYS_refcursor,
    p_error_code out number,
    p_error_msg out varchar2)
as
begin 
    open p_result for 
                select khm.*, pc.magv, case when pc.magv is not null then 'Đã phân công' else 'Chưa phân công' end as status
                from ADMIN1.x_khmo khm left join  ADMIN1.x_phancong pc
                    on pc.mahp = khm.mahp and pc.hk = khm.hk 
                    and pc.nam = khm.nam and pc.mact = khm.mact
                where khm.mahp in (select mahp from admin1.x_hocphan where madv = p_madv);
                
    EXCEPTION
    WHEN NO_DATA_FOUND THEN
        p_error_code := -1; -- Custom error code
        p_error_msg := 'No data found for the specified object.';
    WHEN OTHERS THEN
        p_error_code := SQLCODE;
        p_error_msg := SQLERRM;
end;
/

create or replace procedure admin1.USP_UPDATE_PHANCONG_GV
    (   p_old_magv varchar2,
        p_magv in varchar2,
        p_mahp in varchar2,
        p_hk in int,
        p_nam in int,
        p_mact in varchar2,
        p_error_code out number,
        p_error_msg out varchar2
    )
as
    check_record int;
begin 
    check_record := 0;

    select count(*) into check_record 
    from admin1.x_dangky 
    where magv = p_old_magv and mahp = p_mahp and hk = p_hk and nam = p_nam and mact = p_mact
    and (diemtk > 0 or diemth > 0 or diemqt > 0);
    
    if check_record > 0 
    then 
        RAISE_APPLICATION_ERROR(-20001, 'Lớp học đã quá thời hạn điều chỉnh phân công.');
        return;
    end if;
    
    select count(*) into check_record 
    from admin1.x_phancong 
    where magv = p_magv and mahp = p_mahp and hk = p_hk and nam = p_nam and mact = p_mact;
    
    if check_record > 0 
    then 
        RAISE_APPLICATION_ERROR(-20001, 'Phân công đã tồn tại không thể cập nhật');
        return;
    end if;
    
    select count(*) into check_record 
    from admin1.x_phancong 
    where magv = p_old_magv and mahp = p_mahp and hk = p_hk and nam = p_nam and mact = p_mact;
    
    if check_record = 0 
    then 
        RAISE_APPLICATION_ERROR(-20001, 'Phân công không tồn tại để cập nhật.');
        return;
    end if;
    
    update admin1.x_phancong 
    set magv = p_magv
    where magv = p_old_magv and mahp = p_mahp and hk = p_hk and nam = p_nam and mact = p_mact;
    
    EXCEPTION
    WHEN NO_DATA_FOUND THEN
        p_error_code := -1; -- Custom error code
        p_error_msg := 'No data found for the specified object.';
    WHEN OTHERS THEN
        p_error_code := SQLCODE;
        p_error_msg := SQLERRM;
end;
/ 

create or replace procedure admin1.USP_INSERT_PHANCONG
    (   p_magv in varchar2,
        p_mahp in varchar2,
        p_hk in int,
        p_nam in int,
        p_mact in varchar2,
        p_error_code out number,
        p_error_msg out varchar2
    )
as
    check_record int;
begin 
    check_record := 0;
    
    select count(*) into check_record
    from admin1.x_phancong 
    where magv = p_magv and mahp = p_mahp and hk = p_hk and nam = p_nam and mact = p_mact;
    
    if check_record > 0
    then
        RAISE_APPLICATION_ERROR(-20001 , 'Phân công đã tồn tại.');
        return;
    end if;
    
    INSERT into admin1.x_phancong values(p_magv, p_mahp, p_hk, p_nam, p_mact);
    
    EXCEPTION
    WHEN NO_DATA_FOUND THEN
        p_error_code := -1; -- Custom error code
        p_error_msg := 'No data found for the specified object.';
    WHEN OTHERS THEN
        p_error_code := SQLCODE;
        p_error_msg := SQLERRM;
end;
/

create or replace procedure admin1.USP_DELETE_PHANCONG
    (   p_magv in varchar2,
        p_mahp in varchar2,
        p_hk in int,
        p_nam in int,
        p_mact in varchar2,
        p_error_code out number,
        p_error_msg out varchar2
    )
as
    check_record int;
begin 
    select count(*) into check_record
    from admin1.x_phancong 
    where magv = p_magv and mahp = p_mahp and hk = p_hk and nam = p_nam and mact = p_mact;
    
    if check_record = 0
    then
        RAISE_APPLICATION_ERROR(-20001 , 'Phân công không tồn tại.');
        return;
    end if;
    
    select count(*) into check_record
    from admin1.x_dangky
    where magv = p_magv and mahp = p_mahp and hk = p_hk and nam = p_nam and mact = p_mact
            and (diemtk is not null or diemth is not null or diemqt is not null);
    if check_record > 0
    then
        RAISE_APPLICATION_ERROR(-20001 , 'Không thể xóa phân công lớp đã có điểm quá trình');
        return;
    end if;
    
    delete admin1.x_dangky where magv = p_magv and mahp = p_mahp and hk = p_hk and nam = p_nam and mact = p_mact;
    
    delete admin1.x_phancong where magv = p_magv and mahp = p_mahp and hk = p_hk and nam = p_nam and mact = p_mact;
    
    EXCEPTION
    WHEN NO_DATA_FOUND THEN
        p_error_code := -1; -- Custom error code
        p_error_msg := 'Phân công không tồn tại.';
    WHEN OTHERS THEN
        p_error_code := SQLCODE;
        p_error_msg := SQLERRM;
end;
/


GRANT EXECUTE ON ADMIN1.USP_INSERT_PHANCONG TO RL_TRGDV;
GRANT EXECUTE ON ADMIN1.USP_DELETE_PHANCONG TO RL_TRGDV;
GRANT EXECUTE ON ADMIN1.USP_UPDATE_PHANCONG_GV TO RL_TRGDV;
Grant select on ADMIN1.V_GiangVien_PhanCong_Donvi to RL_TRGDV;
grant execute on ADMIN1.USP_SELECT_KHM_TDV to RL_TRGDV;
GRANT EXECUTE ON ADMIN1.USP_select_KHM_TDV TO TK;

create or REPLACE PROCEDURE admin1.USP_UPDATE_SDT_NV
    (sodienthoai VARCHAR2,
    p_error_code OUT NUMBER,
    p_error_msg OUT VARCHAR2
    )
as
begin 
    update admin1.UV_THONGTINCANHAN_NS set dt = sodienthoai;
    
    EXCEPTION
    WHEN NO_DATA_FOUND THEN
        p_error_code := -1; -- Custom error code
        p_error_msg := 'No data found for the specified object.';
    WHEN OTHERS THEN
        p_error_code := SQLCODE;
        p_error_msg := SQLERRM;
end;
/
grant execute on admin1.USP_UPDATE_SDT_NV to NhanVienCoBan;


CREATE OR REPLACE PROCEDURE USP_UPDATE_PHANCONG
 ( PMAGV2 VARCHAR, PMAGV VARCHAR, PMAHP VARCHAR, PHK CHAR, PNAM CHAR, PMACT VARCHAR,  p_error_code OUT NUMBER)
AS
 CURSOR CUR IS (
 SELECT HP.MADV
 FROM admin1.X_PHANCONG PC, admin1.X_HOCPHAN HP
 WHERE PC.MAGV=PMAGV AND  PC.MAHP=PMAHP AND PC.HK=PHK AND PC.NAM=PNAM AND PC.MACT=PMACT
 AND PC.MAHP=HP.MAHP
 );
 STRSQL VARCHAR(2000);
 MA VARCHAR2(10);
BEGIN 
 OPEN CUR; 
 FETCH CUR INTO MA; 
 IF (MA = 'VPK' ) THEN
 BEGIN
    UPDATE admin1.X_PHANCONG SET MAGV=PMAGV2
    WHERE MAGV=PMAGV AND MAHP=PMAHP AND HK=PHK AND NAM=PNAM AND MACT=PMACT;
    DBMS_OUTPUT.PUT_LINE( 'HAY QUA, CAP NHAT THANH CONG ROI'  );
     p_error_code := 0; -- Success
 END ;
 ELSE
 BEGIN
    DBMS_OUTPUT.PUT_LINE( ' LOI ROI KIA '  );
    p_error_code := 1; -- Fail
  END;
 END IF;
END;
/
GRANT EXECUTE ON USP_UPDATE_PHANCONG TO RL_GIAOVU;

--TRIGGER CẬP NHẬT BẢNG ĐĂNG KÍ SAU KHI CẬP NHẬT BẢNG PHÂN CÔNG
CREATE OR REPLACE TRIGGER UTR_UPDATE_PHANCONG
AFTER UPDATE 
ON admin1.X_PHANCONG
FOR EACH ROW 
BEGIN 
    UPDATE admin1.X_DANGKY SET MAGV =:NEW.MAGV
    WHERE   MAGV = :OLD.MAGV AND MAHP = :OLD.MAHP AND HK = :OLD.HK AND NAM = :OLD.NAM AND MACT = :OLD.MACT;
END;
/
-- DROP TRIGGER UTR_UPDATE_PHANCONG;

-- Xóa hoặc thêm dòng trên quan hệ ĐANGKY theo yêu cầu của sinh viên trong khoảng thời gian còn cho hiệu chỉnh đăng ký
GRANT  SELECT ON admin1.X_DANGKY TO RL_GIAOVU;

CREATE OR REPLACE PROCEDURE admin1.USP_INSERT_DANGKY(
    PMASV VARCHAR,
    PMAGV VARCHAR,
    PMAHP VARCHAR,
    PHK CHAR,
    PNAM CHAR,
    PMACT VARCHAR,
    PDIEMTH FLOAT,
    PDIEMQT FLOAT,
    PDIEMCK FLOAT,
    PDIEMTK FLOAT,
     p_error_code OUT NUMBER)
AS
 CURSOR CUR IS (
 SELECT PC.MAHP
 FROM  admin1.X_PHANCONG PC, admin1.X_KHMO KH
 WHERE
-- PMAPC=PC.MAPC
 PMAGV = PC.MAGV AND PMAHP=PC.MAHP AND PHK=PC.HK AND PNAM=PC.NAM AND PMACT=PC.MACT 
 AND  PC.MAHP=KH.MAHP AND PC.HK=KH.HK AND PC.NAM=KH.NAM AND PC.MACT=KH.MACT
 AND EXTRACT(YEAR FROM SYSDATE) = KH.NAM 
 AND EXTRACT(MONTH FROM SYSDATE) = 4*KH.HK - 3
 AND EXTRACT(DAY FROM SYSDATE) < 15
 );
 MA VARCHAR2(10);
BEGIN
 OPEN CUR; 
 FETCH CUR INTO MA; 
 IF (MA IS NOT NULL) THEN
 BEGIN
    INSERT INTO admin1.X_DANGKY VALUES(PMASV, PMAGV, PMAHP, PHK, PNAM, PMACT , PDIEMTH ,PDIEMQT ,PDIEMCK ,PDIEMTK );
    DBMS_OUTPUT.PUT_LINE( 'HAY QUA, THEM THANH CONG ROI'  );
     p_error_code := 0; -- Success
 END;
 ELSE
 DBMS_OUTPUT.PUT_LINE( 'LOI ROI KIA'  );
  p_error_code := 1; -- Fail
 END IF;
END;
/

CREATE OR REPLACE PROCEDURE admin1.USP_DELETE_DANGKY(
    PMASV VARCHAR,
    PMAGV VARCHAR,
    PMAHP VARCHAR,
    PHK CHAR,
    PNAM CHAR,
    PMACT VARCHAR,
    p_error_code OUT NUMBER
    )
AS
 CURSOR CUR IS (
 SELECT DK.MASV
 FROM  admin1.X_DANGKY DK, admin1.X_PHANCONG PC, admin1.X_KHMO KH
 WHERE
 PMAGV = PC.MAGV AND PMAHP=PC.MAHP AND PHK=PC.HK AND PNAM=PC.NAM AND PMACT=PC.MACT 
 AND  PC.MAHP=KH.MAHP AND PC.HK=KH.HK AND PC.NAM=KH.NAM AND PC.MACT=KH.MACT
 AND EXTRACT(YEAR FROM SYSDATE) = KH.NAM 
 AND EXTRACT(MONTH FROM SYSDATE) = 4*KH.HK - 3
 AND EXTRACT(DAY FROM SYSDATE) < 15
 );
 MA VARCHAR2(10);
BEGIN
 OPEN CUR; 
 FETCH CUR INTO MA; 
 IF (MA IS NOT NULL) THEN
 BEGIN
   DELETE  admin1.X_DANGKY WHERE
    MASV=PMASV AND MAGV=PMAGV AND MAHP=PMAHP AND HK=PHK AND NAM=PNAM AND MACT=PMACT;
    DBMS_OUTPUT.PUT_LINE( 'HAY QUA, XOA THANH CONG ROI'  );
    p_error_code := 0; -- Success
 END;
 ELSE
 BEGIN
  DBMS_OUTPUT.PUT_LINE( 'LOI ROI KIA' );
  p_error_code := 1; -- Fail
  END;
 END IF;
END;
/
GRANT EXECUTE ON admin1.USP_INSERT_DANGKY TO RL_GIAOVU;
GRANT EXECUTE ON admin1.USP_DELETE_DANGKY TO RL_GIAOVU;


-- THÊM NHÂN SỰ MỚI CHO BẢNG X_NHANSU
-- Thêm nhân sự mới cho bảng X_NHANSU với mã nhân viên ngẫu nhiên
CREATE OR REPLACE PROCEDURE admin1.USP_INSERT_NHANSU (
    P_HOTEN IN ADMIN1.X_NHANSU.HOTEN%TYPE,
    P_PHAI IN ADMIN1.X_NHANSU.PHAI%TYPE,
    P_NGSINH IN ADMIN1.X_NHANSU.NGSINH%TYPE,
    P_PHUCAP IN ADMIN1.X_NHANSU.PHUCAP%TYPE,
    P_DT IN ADMIN1.X_NHANSU.DT%TYPE,
    P_VAITRO IN ADMIN1.X_NHANSU.VAITRO%TYPE,
    P_MADV IN ADMIN1.X_NHANSU.MADV%TYPE,
    P_ERROR_CODE OUT NUMBER,
    P_ERROR_MSG OUT NVARCHAR2
) AUTHID CURRENT_USER
AS
    ISCHECK NUMBER;
    P_MANV ADMIN1.X_NHANSU.MANV%TYPE;
BEGIN
    -- Generate a unique random employee ID
    LOOP
        P_MANV := DBMS_RANDOM.STRING('U', 10); -- Generate a random string of length 6
        SELECT COUNT(*) INTO ISCHECK 
        FROM ADMIN1.X_NHANSU 
        WHERE MANV = P_MANV;
        
        -- If no existing row with generated MANV, exit the loop
        IF ISCHECK = 0 THEN
            EXIT;
        END IF;
    END LOOP;
    
    -- Perform the insert
    INSERT INTO ADMIN1.X_NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DT, VAITRO, MADV)
    VALUES (P_MANV, P_HOTEN, P_PHAI, P_NGSINH, P_PHUCAP, P_DT, P_VAITRO, P_MADV);
    
    P_ERROR_CODE := 0;
    P_ERROR_MSG := 'Thêm nhân sự thành công.';
EXCEPTION
    WHEN NO_DATA_FOUND THEN
        P_ERROR_CODE := 2;
        P_ERROR_MSG := 'Không tìm thấy dữ liệu cần cập nhật.';
    WHEN OTHERS THEN
        P_ERROR_CODE := SQLCODE;
        P_ERROR_MSG := SQLERRM;
END;
/

-- XÓA NHÂN SỰ TRONG BẢNG X_NHANSU
CREATE OR REPLACE PROCEDURE admin1.USP_DELETE_NHANSU (
    P_MANV IN ADMIN1.X_NHANSU.MANV%TYPE,
    P_ERROR_CODE OUT NUMBER,
    P_ERROR_MSG OUT NVARCHAR2
) AUTHID CURRENT_USER
AS
    ISCHECK NUMBER;
    COUNT_PC NUMBER;
BEGIN
    -- Check for existing rows
    SELECT COUNT(*) INTO ISCHECK 
    FROM ADMIN1.X_NHANSU 
    WHERE MANV = P_MANV;
    
    -- If no rows exist, set error code and return
    IF ISCHECK = 0 THEN
        P_ERROR_CODE := 1;
        P_ERROR_MSG := 'Nhân sự không tồn tại.';
        RETURN;
    END IF;
    
    -- Otherwise, perform the delete
    DELETE FROM ADMIN1.X_NHANSU WHERE MANV = P_MANV;
    
    -- Check if there are assignments for this employee
    SELECT COUNT(*) INTO COUNT_PC FROM ADMIN1.X_PHANCONG WHERE MAGV = P_MANV;
    
    -- If assignments exist, set error code and return
    IF COUNT_PC > 0 THEN
        P_ERROR_CODE := 2;
        P_ERROR_MSG := 'Nhân sự đã được phân công giảng dạy không thể xóa.';
        RETURN;
    END IF;
    
    -- Success message
    P_ERROR_CODE := 0;
    P_ERROR_MSG := 'Xóa nhân sự thành công.';
EXCEPTION
    WHEN NO_DATA_FOUND THEN
        P_ERROR_CODE := 2;
        P_ERROR_MSG := 'Không tìm thấy dữ liệu cần cập nhật.';
    WHEN OTHERS THEN
        P_ERROR_CODE := SQLCODE;
        P_ERROR_MSG := SQLERRM;
END;
/

-- CẬP NHẬT NHÂN SỰ 
CREATE OR REPLACE PROCEDURE admin1.USP_UPDATE_NHANSU (
    P_MANV IN ADMIN1.X_NHANSU.MANV%TYPE,
    P_NEW_HOTEN IN ADMIN1.X_NHANSU.HOTEN%TYPE DEFAULT NULL,
    P_NEW_PHAI IN ADMIN1.X_NHANSU.PHAI%TYPE DEFAULT NULL,
    P_NEW_NGSINH IN ADMIN1.X_NHANSU.NGSINH%TYPE DEFAULT NULL,
    P_NEW_PHUCAP IN ADMIN1.X_NHANSU.PHUCAP%TYPE DEFAULT NULL,
    P_NEW_DT IN ADMIN1.X_NHANSU.DT%TYPE DEFAULT NULL,
    P_NEW_VAITRO IN ADMIN1.X_NHANSU.VAITRO%TYPE DEFAULT NULL,
    P_NEW_MADV IN ADMIN1.X_NHANSU.MADV%TYPE DEFAULT NULL,
    P_ERROR_CODE OUT NUMBER,
    P_ERROR_MSG OUT NVARCHAR2
) AUTHID CURRENT_USER
AS
    ISCHECK NUMBER;
BEGIN
    -- Check for existing rows
    SELECT COUNT(*) INTO ISCHECK 
    FROM ADMIN1.X_NHANSU
    WHERE MANV = P_MANV;
    
    -- If rows exist, set error code and return
    IF ISCHECK = 0 THEN
        P_ERROR_CODE := 1;
        P_ERROR_MSG := 'Nhân viên không tồn tại.';
        RETURN;
    END IF;
    
    UPDATE ADMIN1.X_NHANSU
    SET 
        HOTEN = NVL(P_NEW_HOTEN, HOTEN),
        PHAI = NVL(P_NEW_PHAI, PHAI),
        NGSINH = NVL(P_NEW_NGSINH, NGSINH),
        PHUCAP = NVL(P_NEW_PHUCAP, PHUCAP),
        DT = NVL(P_NEW_DT, DT),
        VAITRO = NVL(P_NEW_VAITRO, VAITRO),
        MADV = NVL(P_NEW_MADV, MADV)
    WHERE MANV = P_MANV;
    
    P_ERROR_CODE := 0;
    P_ERROR_MSG := 'Cập nhật nhân sự thành công.';
EXCEPTION
    WHEN NO_DATA_FOUND THEN
        P_ERROR_CODE := 2;
        P_ERROR_MSG := 'Không tìm thấy dữ liệu cần cập nhật.';
    WHEN OTHERS THEN
        P_ERROR_CODE := SQLCODE;
        P_ERROR_MSG := SQLERRM;
END;
/



-- THÊM PHÂN CÔNG MỚI CHO BẢNG X_PHANCONG
CREATE OR REPLACE PROCEDURE admin1.USP_INSERT_PHANCONG1 (
    P_MAGV IN ADMIN1.X_PHANCONG.MAGV%TYPE,
    P_MAHP IN ADMIN1.X_PHANCONG.MAHP%TYPE,
    P_HK IN ADMIN1.X_PHANCONG.HK%TYPE,
    P_NAM IN ADMIN1.X_PHANCONG.NAM%TYPE,
    P_MACT IN ADMIN1.X_PHANCONG.MACT%TYPE,
    P_ERROR_CODE OUT NUMBER,
    P_ERROR_MSG OUT NVARCHAR2
) AUTHID CURRENT_USER
AS
    ISCHECK NUMBER;
BEGIN
    -- Check for existing rows
    SELECT COUNT(*) INTO ISCHECK 
    FROM ADMIN1.X_PHANCONG 
    WHERE MAGV = P_MAGV AND MAHP = P_MAHP AND HK = P_HK AND NAM = P_NAM AND MACT = P_MACT;
    
    -- If rows exist, set error code and return
    IF ISCHECK > 0 THEN
        P_ERROR_CODE := 1;
        P_ERROR_MSG := 'Giáo viên đã tồn tại phân công này.';
        RETURN;
    END IF;
    
    -- Otherwise, perform the insert
    INSERT INTO ADMIN1.X_PHANCONG (MAGV, MAHP, HK, NAM, MACT)
    VALUES (P_MAGV, P_MAHP, P_HK, P_NAM, P_MACT);

    P_ERROR_CODE := 0;
    P_ERROR_MSG := 'Thêm phân công thành công.';
EXCEPTION
    WHEN NO_DATA_FOUND THEN
        P_ERROR_CODE := 2;
        P_ERROR_MSG := 'Không tìm thấy dữ liệu cần cập nhật.';
    WHEN OTHERS THEN
        P_ERROR_CODE := SQLCODE;
        P_ERROR_MSG := SQLERRM;
END;
/

-- XÓA MỘT PHÂN CÔNG TỪ BẢNG X_PHANCONG
CREATE OR REPLACE PROCEDURE admin1.USP_DELETE_PHANCONG1 (
    P_MAGV IN ADMIN1.X_PHANCONG.MAGV%TYPE,
    P_MAHP IN ADMIN1.X_PHANCONG.MAHP%TYPE,
    P_HK IN ADMIN1.X_PHANCONG.HK%TYPE,
    P_NAM IN ADMIN1.X_PHANCONG.NAM%TYPE,
    P_MACT IN ADMIN1.X_PHANCONG.MACT%TYPE,
    P_ERROR_CODE OUT NUMBER,
    P_ERROR_MSG OUT NVARCHAR2
) AUTHID CURRENT_USER
AS
    ISCHECK NUMBER;
BEGIN
    -- Check for existing rows
    SELECT COUNT(*) INTO ISCHECK
    FROM ADMIN1.X_PHANCONG
    WHERE MAGV = P_MAGV AND MAHP = P_MAHP AND HK = P_HK AND NAM = P_NAM AND MACT = P_MACT;
    
    -- If rows exist, set error code and return
    IF ISCHECK = 0 THEN
        P_ERROR_CODE := 1;
        P_ERROR_MSG := 'Không tồn tại phân công này.';
        RETURN;
    END IF;
    
    -- Otherwise, perform the delete
    DELETE FROM ADMIN1.X_PHANCONG WHERE MAGV =  P_MAGV AND MAHP = P_MAHP AND HK = P_HK AND NAM = P_NAM AND MACT = P_MACT;
    
    P_ERROR_CODE := 0;
    P_ERROR_MSG := 'Xóa phân công thành công.';
EXCEPTION
    WHEN NO_DATA_FOUND THEN
        P_ERROR_CODE := 2;
        P_ERROR_MSG := 'Không tìm thấy dữ liệu cần cập nhật.';
    WHEN OTHERS THEN
        P_ERROR_CODE := SQLCODE;
        P_ERROR_MSG := SQLERRM;
END;
/

create or replace procedure admin1.USP_Update_SOTCTL
as
begin 
    update admin1.x_sinhvien sv
    set SOTCTL = (  select sum(hp.sotc)
                    from admin1.x_dangky dk join admin1.x_hocphan hp on dk.mahp = hp.mahp
                    where sv.masv = dk.masv and dk.diemtk >= 5);
end;
/

begin
    DBMS_SCHEDULER.create_program (
        program_name        => 'PROGRAM_update_sotctl',
        program_type        => 'STORED_PROCEDURE',
        program_action      => 'USP_Update_SOTCTL',
        enabled             => TRUE
    );
end;
/

begin
    dbms_scheduler.create_schedule(
        schedule_name   => 'Schedule_ketthuc_hocky',
        start_date      => systimestamp,
        end_date        => null,
        repeat_interval => 'FREQ=YEARLY; BYMONTH=1,6,9; 
                            BYMONTHDAY=30; BYHOUR=0; BYMINUTE=0; BYSECOND=0',
        comments        => 'Chạy vào ngày cuối tháng của những tháng bắt đầu học kì mới.'
    );
end;
/

BEGIN
  DBMS_SCHEDULER.create_job (
    job_name        => 'JOB_update_sotctl',
    program_name    => 'PROGRAM_update_sotctl',
    schedule_name   => 'Schedule_ketthuc_hocky',
    enabled         => TRUE
  );
END;
/


CREATE OR REPLACE PACKAGE admin1.diemtk_pkg IS
    TYPE masv_tab IS TABLE OF VARCHAR2(10);
    masv_list masv_tab;
    PROCEDURE add_masv(p_masv VARCHAR2);
    PROCEDURE update_dtbtl;
END diemtk_pkg;
/


CREATE OR REPLACE PACKAGE BODY admin1.diemtk_pkg IS
    PROCEDURE add_masv(p_masv VARCHAR2) IS
    BEGIN
        IF masv_list IS NULL THEN
            masv_list := masv_tab();
        END IF;
        masv_list.EXTEND;
        masv_list(masv_list.LAST) := p_masv;
    END add_masv;

    PROCEDURE update_dtbtl IS
    BEGIN
        FOR i IN 1..masv_list.COUNT LOOP
            UPDATE admin1.X_SINHVIEN sv
            SET sv.DTBTL = (
                select sum(dk.diemtk*hp.sotc)/sum(hp.sotc)
                FROM X_DANGKY DK join admin1.x_hocphan hp on dk.mahp = hp.mahp
                WHERE DK.MASV = masv_list(i) and dk.diemtk >= 5
            )
            WHERE sv.MASV = masv_list(i);
        END LOOP;
        masv_list.DELETE;
    END update_dtbtl;
END diemtk_pkg;
/

create or replace trigger UTR_update_diemtbtl
after update of diemtk on admin1.x_dangky
for each row
begin 
    admin1.diemtk_pkg.add_masv(:NEW.MASV);
end;
/

CREATE OR REPLACE TRIGGER update_dtbtl_trigger_after_stmt
AFTER UPDATE OF DIEMTK ON admin1.X_DANGKY
BEGIN
    admin1.diemtk_pkg.update_dtbtl;
END;
/


-- CẤP QUYỀN EXECUTE PROC INSERT, UPDATE, DELETE TRÊN TABLE X_PHANCONG
GRANT EXECUTE ON admin1.USP_INSERT_PHANCONG1 TO TK;
GRANT EXECUTE ON admin1.USP_DELETE_PHANCONG1 TO TK;
GRANT EXECUTE ON admin1.USP_UPDATE_PHANCONG_GV TO TK;

-- CẤP QUYỀN EXECUTE PROC INSERT, UPDATE, DELETE TRÊN TABLE X_NHANSU
GRANT EXECUTE ON admin1.USP_INSERT_NHANSU TO TK;
GRANT EXECUTE ON admin1.USP_DELETE_NHANSU TO TK;
GRANT EXECUTE ON admin1.USP_UPDATE_NHANSU TO TK;


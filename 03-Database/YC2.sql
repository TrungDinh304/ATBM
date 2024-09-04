--Connect sys
SELECT VALUE FROM v$option WHERE parameter = 'Oracle Label Security';
SELECT status FROM dba_ols_status WHERE name = 'OLS_CONFIGURE_STATUS';

--Nếu false thì chạy 2 dòng này
EXEC LBACSYS.CONFIGURE_OLS;
EXEC LBACSYS.OLS_ENFORCEMENT.ENABLE_OLS;
--Sau đó tắt mở lại sql developer


-- Kiểm tra PDB tạo đã có chưa: PDBProject
select * from v$services;

-- mở khoá lbacsys
alter session set "_oracle_script"=true;
ALTER USER lbacsys IDENTIFIED BY lbacsys ACCOUNT UNLOCK;

-- Mở PDB
ALTER PLUGGABLE DATABASE PDBProject OPEN READ WRITE;

-- Chuyển sang PDBProject
alter session set container = PDBProject;
SHOW CON_NAME;
alter session set container = CDB$ROOT;

--Tạo user admin_ols và cấp quyền cho nó
drop user ADMIN_OLS cascade;
CREATE USER ADMIN_OLS IDENTIFIED BY 123;
GRANT CONNECT,RESOURCE TO ADMIN_OLS; 
GRANT UNLIMITED TABLESPACE TO ADMIN_OLS; 
GRANT SELECT ANY DICTIONARY TO ADMIN_OLS; 
grant create session to ADMIN_OLS;

GRANT EXECUTE ON LBACSYS.SA_COMPONENTS TO ADMIN_OLS WITH GRANT OPTION;
GRANT EXECUTE ON LBACSYS.sa_user_admin TO ADMIN_OLS WITH GRANT OPTION;
GRANT EXECUTE ON LBACSYS.sa_label_admin TO ADMIN_OLS WITH GRANT OPTION;
GRANT EXECUTE ON sa_policy_admin TO ADMIN_OLS WITH GRANT OPTION;
GRANT EXECUTE ON char_to_label TO ADMIN_OLS WITH GRANT OPTION;

GRANT LBAC_DBA TO ADMIN_OLS;
GRANT EXECUTE ON sa_sysdba TO ADMIN_OLS;
GRANT EXECUTE ON TO_LBAC_DATA_LABEL TO ADMIN_OLS;
Grant alter session to ADMIN_OLS;
Grant set container to ADMIN_OLS;
Grant create table to ADMIN_OLS;
Grant create user to ADMIN_OLS;



--Connect admin_ols

-- Chuyen sang PDB
alter session set "_oracle_script"=true;
alter session set container = PDBProject;
show CON_NAME;
-- Tạo policy
execute SA_SYSDBA.drop_POLICY(policy_name => 'ols_policy');
execute SA_SYSDBA.CREATE_POLICY(policy_name => 'ols_policy',column_name => 'ols_label');
execute SA_SYSDBA.ENABLE_POLICY ('ols_policy'); 
-- Sau đó tắt sql developer rồi mở lại

-- Tạo level
execute SA_COMPONENTS.CREATE_LEVEL('ols_policy',6000,'TK','Truong khoa');
execute SA_COMPONENTS.CREATE_LEVEL('ols_policy',5000,'TDV','Truong don vi');
execute SA_COMPONENTS.CREATE_LEVEL('ols_policy',4000,'GV','Giang vien');
execute SA_COMPONENTS.CREATE_LEVEL('ols_policy',3000,'GVu','Giao vu');
execute SA_COMPONENTS.CREATE_LEVEL('ols_policy',2000,'NV','Nhan vien');
execute SA_COMPONENTS.CREATE_LEVEL('ols_policy',1000,'SV','Sinh vien');
-- Tạo compartment
execute SA_COMPONENTS.CREATE_COMPARTMENT('ols_policy',200,'HTTT','He thong thong tin'); 
execute SA_COMPONENTS.CREATE_COMPARTMENT('ols_policy',180,'CNPM','Cong nghe phan mem'); 
execute SA_COMPONENTS.CREATE_COMPARTMENT('ols_policy',160,'KHMT','Khoa hoc may tinh');
execute SA_COMPONENTS.CREATE_COMPARTMENT('ols_policy',140,'CNTT','Cong nghe thong tin');
execute SA_COMPONENTS.CREATE_COMPARTMENT('ols_policy',120,'TGMT','Thi giac may tinh');
execute SA_COMPONENTS.CREATE_COMPARTMENT('ols_policy',100,'MMT','Mang may tinh');
-- Tạo group
execute SA_COMPONENTS.CREATE_GROUP('ols_policy',1,'CS1','Co so 1');
execute SA_COMPONENTS.CREATE_GROUP('ols_policy',2,'CS2','Co so 2');
-- Connect sys kiểm tra component chạy đúng chưa
alter session set "_oracle_script"=true;
alter session set container = PDBProject;
show CON_NAME;
select * from all_sa_labels;
SELECT * FROM DBA_SA_LEVELS;
SELECT * FROM DBA_SA_COMPARTMENTS;
SELECT * FROM DBA_SA_GROUPS;
SELECT * FROM DBA_SA_GROUP_HIERARCHY;
-- Connect admin_ols
-- Tạo bảng thông báo
drop table Thongbao cascade constraints;
Create table Thongbao(
    MaTB int PRIMARY KEY,
    NoiDung nvarchar2(150)
);
--a)1 Hãy gán nhãn cho người dùng là Trưởng khoa có thể đọc được toàn bộ thông báo.
--b)2 Hãy gán nhãn cho các Trưởng bộ môn phụ trách Cơ sở 2 có thể đọc được toàn bộ thông báo. dành cho trưởng bộ môn không phân biệt vị trí địa lý.
--c)3 Hãy gán nhãn cho 01 Giáo vụ có thể đọc toàn bộ thông báo dành cho giáo vụ
--d)4 Hãy cho biết nhãn của dòng thông báo t1 để t1 được phát tán (đọc) bởi tất cả Trưởng đơn vị.
--e)5 Hãy cho biết nhãn của dòng thông báo t2 để phát tán t2 đến Sinh viên thuộc ngành HTTT học ở Cơ sở 1.
--f)6 Hãy cho biết nhãn của dòng thông báo t3 để phát tán t3 đến Trưởng bộ môn KHMT ở Cơ sở 1.
--g)7 Cho biết nhãn của dòng thông báo t4 để phát tán t4 đến Trưởng bộ môn KHMT ở Cơ sở 1 và Cơ sở 2.
--h)8 9 10 Cho thêm 3 chính sách

Insert into Thongbao values(1,'Thong bao cho Truong Khoa');
Insert into Thongbao values(2,'Thong bao cho Truong Bo Mon');
Insert into Thongbao values(3,'Thong bao cho toan bo Giao Vu');
Insert into Thongbao values(4,'Thong bao cho toan bo Truong Don Vi');
Insert into Thongbao values(5,'Thong bao cho Sinh vien thuoc nganh HTTT o co so 1');
Insert into Thongbao values(6,'Thong bao cho Truong bo mon KHMT o co so 1');
Insert into Thongbao values(7,'Thong bao cho Truong bo mon KHMT o co so 1 va co so 2');
Insert into Thongbao values(8,'Thong bao cho Sinh vien thuoc nganh CNPM o co so 2');
Insert into Thongbao values(9,'Thong bao cho Truong bo mon MMT o co so 2');
Insert into Thongbao values(10,'Thong bao cho Giang vien HTTT o co so 1');


-- Cập nhập nhãn trong bảng
begin
     SA_POLICY_ADMIN.APPLY_TABLE_POLICY (
         POLICY_NAME => 'OLS_POLICY',
         SCHEMA_NAME => 'admin_ols',
         TABLE_NAME => 'Thongbao',
         TABLE_OPTIONS => 'NO_CONTROL'
     ); 
end;

-- Tạo nhãn
Update Thongbao
set ols_label = char_to_label('ols_policy','TK')
where MaTB = 1;

Update Thongbao
set ols_label = char_to_label('ols_policy','TDV')
where MaTB = 2;

Update Thongbao
set ols_label = char_to_label('ols_policy','GVu')
where MaTB = 3;

Update Thongbao
set ols_label = char_to_label('ols_policy','TDV') --t1
where MaTB = 4;

Update Thongbao
set ols_label = char_to_label('ols_policy','SV:HTTT:CS1') --t2
where MaTB = 5;

Update Thongbao
set ols_label = char_to_label('ols_policy','TDV:KHMT:CS1') --t3
where MaTB = 6;

Update Thongbao
set ols_label = char_to_label('ols_policy','TDV:KHMT:CS1,CS2') --t4
where MaTB = 7;

Update Thongbao
set ols_label = char_to_label('ols_policy','SV:CNPM:CS2') --t5
where MaTB = 8;

Update Thongbao
set ols_label = char_to_label('ols_policy','TDV:MMT:CS2') --t6
where MaTB = 9;

Update Thongbao
set ols_label = char_to_label('ols_policy','GV:HTTT:CS1') --t7
where MaTB = 10;


-- áp dụng OLS vào bảng ThongBao
BEGIN
    SA_POLICY_ADMIN.REMOVE_TABLE_POLICY(
        policy_name => 'ols_policy',
        schema_name => 'ADMIN_OLS',
        table_name  => 'Thongbao'
    );
    SA_POLICY_ADMIN.APPLY_TABLE_POLICY (
        policy_name => 'ols_policy',
        schema_name => 'ADMIN_OLS',
        table_name => 'Thongbao',
        table_options => 'READ_CONTROL'
    );
END;

-- Gọi update label
UPDATE thongbao
SET matb = matb; 
commit;

execute SA_USER_ADMIN.SET_USER_LABELS('ols_policy','TruongKhoa','TK'); 
execute SA_USER_ADMIN.SET_USER_LABELS('ols_policy','TruongKhoa','TDV');
execute SA_USER_ADMIN.SET_USER_LABELS('ols_policy','TruongKhoa','GVu');
execute SA_USER_ADMIN.SET_USER_LABELS('ols_policy','TruongKhoa','TDV'); 
execute SA_USER_ADMIN.SET_USER_LABELS('ols_policy','TruongKhoa','SV:HTTT:CS1'); 
execute SA_USER_ADMIN.SET_USER_LABELS('ols_policy','TruongKhoa','TDV:KHMT:CS1') ; 
execute SA_USER_ADMIN.SET_USER_LABELS('ols_policy','TruongKhoa','TDV:KHMT:CS1,CS2');  
execute SA_USER_ADMIN.SET_USER_LABELS('ols_policy','TruongKhoa','SV:CNPM:CS2'); 
execute SA_USER_ADMIN.SET_USER_LABELS('ols_policy','TruongKhoa','TDV:MMT:CS2'); 
execute SA_USER_ADMIN.SET_USER_LABELS('ols_policy','TruongKhoa','GV:HTTT:CS1'); 


--Tạo user để test dùng sys trong PDB
alter session set "_oracle_script"=true;
alter session set container = PDBProject;
show CON_NAME;
Grant create session to TruongKhoa identified by 123;
Grant create session to GiaoVu_01 identified by 123;
Grant create session to TruongBM_CS2 identified by 123;
Grant create session to SinhVien_HTTT_CS1 identified by 123;
Grant create session to TruongBM_KHMT_CS1 identified by 123;
Grant create session to TruongBM_KHMT_CS2 identified by 123;
Grant create session to SinhVien_CNPM_CS2 identified by 123;
Grant create session to TruongBM_MMT_CS2 identified by 123;
Grant create session to GiangVien_HTTT_CS1 identified by 123;
-- Cấp quyền đọc bảng thông báo Thongbao
Grant select on admin_ols.Thongbao to TruongKhoa;
Grant select on admin_ols.Thongbao to GiaoVu_01;
Grant select on admin_ols.Thongbao to TruongBM_CS2;
Grant select on admin_ols.Thongbao to SinhVien_HTTT_CS1;
Grant select on admin_ols.Thongbao to TruongBM_KHMT_CS1;
Grant select on admin_ols.Thongbao to TruongBM_KHMT_CS2;
Grant select on admin_ols.Thongbao to SinhVien_CNPM_CS2;
Grant select on admin_ols.Thongbao to TruongBM_MMT_CS2;
Grant select on admin_ols.Thongbao to GiangVien_HTTT_CS1;

--Connect admin_ols
--Gán label cho user
execute SA_USER_ADMIN.SET_USER_LABELS('ols_policy','TruongKhoa','TK:HTTT,CNPM,KHMT,CNTT,TGMT,MMT:CS1,CS2'); 
execute SA_USER_ADMIN.SET_USER_LABELS('ols_policy','GiaoVu_01','GVu:HTTT,CNPM,KHMT,CNTT,TGMT,MMT:CS1,CS2'); 
execute SA_USER_ADMIN.SET_USER_LABELS('ols_policy','TruongBM_CS2','TDV:HTTT,CNPM,KHMT,CNTT,TGMT,MMT:CS1,CS2'); 
execute SA_USER_ADMIN.SET_USER_LABELS('ols_policy','SinhVien_HTTT_CS1','SV:HTTT:CS1'); 
execute SA_USER_ADMIN.SET_USER_LABELS('ols_policy','TruongBM_KHMT_CS1','TDV:KHMT:CS1'); 
execute SA_USER_ADMIN.SET_USER_LABELS('ols_policy','TruongBM_KHMT_CS2','TDV:KHMT:CS1,CS2'); 
execute SA_USER_ADMIN.SET_USER_LABELS('ols_policy','SinhVien_CNPM_CS1','SV:CNPM:CS2');
execute SA_USER_ADMIN.SET_USER_LABELS('ols_policy','TruongBM_MMT_CS2','TDV:MMT:CS2'); 
execute SA_USER_ADMIN.SET_USER_LABELS('ols_policy','GiangVien_HTTT_CS1','GV:HTTT:CS1'); 
select * from all_sa_labels;
--test cho từng user (không dùng conn vì nó sẽ vô CDB$ROOT chứ ko phải PDBPROJECT)
select * from admin_ols.Thongbao;
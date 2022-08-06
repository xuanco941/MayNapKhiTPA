CREATE DATABASE MayNapKhiTPA
GO
USE MayNapKhiTPA
GO

--TABLE SHIFT
CREATE TABLE [Shift] (
ID_Shift INT IDENTITY(1,1) PRIMARY KEY,
[Name] nvarchar(100) UNIQUE,
[TimeStart] TIME,
[TimeEnd] TIME
)
GO

--TABLE GROUP
CREATE TABLE [Group] (
ID_Group INT IDENTITY(1,1) PRIMARY KEY,
[Name] nvarchar(100) UNIQUE,
IsManagementUser bit,
IsManagementGroup bit,
IsControlMachine bit,
IsSettingMachine bit,
IsSettingShift bit,
IsSettingTemplateMachine bit,
IsViewResult bit,
IsViewActivity bit,
IsDeleteResult bit,
IsDeleteActivity bit,
)
GO

--TABLE USER
CREATE TABLE [User] (
ID_User INT IDENTITY(1,1) PRIMARY KEY,
FullName NVARCHAR(100),
Username VARCHAR(100) UNIQUE NOT NULL,
[Password] VARCHAR(100) default 'tpa',
PhoneNumber Varchar(100),
Email Varchar(100),
NameShift nvarchar(200),
ID_Group int,
-- neu xoa group thi xoa luon user
FOREIGN KEY (ID_Group) REFERENCES [Group](ID_Group) On Delete CASCADE 
)
GO

--TABLE ACTIVITY
CREATE TABLE Activity(
ID_Activity INT IDENTITY(1,1) PRIMARY KEY,
[Description] NVARCHAR(2000),
IsSetting bit default 0,
Create_At DATETIME DEFAULT GETDATE(),
--worker là username của user
Worker nvarchar(100)
)
GO

--TABLE Bình
CREATE TABLE TemplateMachine (
ID_TemplateMachine INT IDENTITY(1,1) PRIMARY KEY,
[Name] nvarchar(100) UNIQUE,
ApSuatNap FLoat,
TheTichNap Float,
ThoiGianNap FLOAT,
ThoiGianLayMau FLOAT
)
GO


--TABLE THONG SO MAY
CREATE TABLE Machine (
ID_Machine int unique,
NameMachine nvarchar(100) unique,
NameTemplateMachine nvarchar(100),
ApSuatNap FLoat,
TheTichNap Float,
-- thoi gian tinh bang phut
ThoiGianNap FLOAT,
ThoiGianLayMau FLOAT,
UpdateAt DateTime default GetDate()
)
GO


--TABLE RESULT (MẺ)
CREATE TABLE Result(
ID_Result INT IDENTITY(1,1) PRIMARY KEY,
ApSuatMin FLOAT DEFAULT -1,
ApSuatMax FLOAT DEFAULT -1,
ApSuatAvg FLOAT DEFAULT -1,
TheTichMin FLOAT DEFAULT -1,
TheTichMax FLOAT DEFAULT -1,
TheTichAvg FLOAT DEFAULT -1,
LuuLuongMin FLOAT DEFAULT -1,
LuuLuongMax FLOAT DEFAULT -1,
LuuLuongAvg FLOAT DEFAULT -1,
TimeStart DATETIME DEFAULT GETDATE(),
TimeEnd DATETIME DEFAULT GETDATE(),
NameMachine nvarchar(100),
--worker là username của user
Worker nvarchar(100)
)
GO

--TABLE DATA (Dữ liệu suốt quá trình nạp)
CREATE TABLE [Data](
ID_Data INT IDENTITY(1,1) PRIMARY KEY,
ApSuat FLOAT,
TheTich FLOAT,
LuuLuong FLOAT,
CreateAt DATETIME DEFAULT GETDATE(),
ID_Result int,
--Xóa result thì xóa luôn data
FOREIGN KEY (ID_Result) REFERENCES Result(ID_Result) ON DELETE CASCADE

)
GO

/* Procedure */
--PROC DATA
--Add Data
CREATE PROC AddData @ApSuat FLOAT, @TheTich FLOAT ,@LuuLuong Float, @ID_Result int
as begin
insert into [Data] (ApSuat,TheTich,LuuLuong,ID_Result) values (@ApSuat,@TheTich,@LuuLuong,@ID_Result)
end
GO



-----------PROC RESULT-----------


--Không chọn tên Machine, không chọn ngày, không chọn chỉ số
CREATE PROC Count_NoName_NoDate_NoParameter 
as begin 
select count(*) from Result;
end
GO

CREATE PROC Pagination_NoName_NoDate_NoParameter (@page int ,@NUM_ELM int)
as begin
Declare @start INT = (@page -1) * @NUM_ELM;
Declare @end INT = @page * @NUM_ELM;
SELECT * FROM ( SELECT *, ROW_NUMBER() OVER (ORDER BY ID_Result desc) as row FROM Result ) 
a WHERE a.row > @start and a.row <= @end;
end
GO










/*CẢ 3*/

--Chọn tên, chọn ngày, chọn chỉ số (3 chỉ số) (NAME_DATE_PARAMETER)
CREATE PROC Count_YesName_YesDate_YesParameter_ApSuat_TheTich_LuuLuong
(@NameMachine nvarchar(100), @Time1 Datetime , @Time2 Datetime,
@ApSuat1 FLOAT, @ApSuat2 FLOAT , @TheTich1 FLOAT, @TheTich2 FLOAT , @LuuLuong1 FLOAT, @LuuLuong2 FLOAT)
as begin 
select count(*) from Result where 
(Result.NameMachine = @NameMachine)
and (Result.TimeStart BETWEEN @Time1 AND @Time2)
and (Result.ApSuatAvg between @ApSuat1 and @ApSuat2) 
and (Result.TheTichAvg between @TheTich1 and @TheTich2)
and (Result.LuuLuongAvg between @LuuLuong1 and @LuuLuong2)
end
GO

CREATE PROC Pagination_YesName_YesDate_YesParameter_ApSuat_TheTich_LuuLuong (@page int ,@NUM_ELM int, @NameMachine nvarchar(100), @Time1 Datetime , @Time2 Datetime,
@ApSuat1 FLOAT, @ApSuat2 FLOAT , @TheTich1 FLOAT, @TheTich2 FLOAT , @LuuLuong1 FLOAT, @LuuLuong2 FLOAT)
as begin
Declare @start INT = (@page -1) * @NUM_ELM;
Declare @end INT = @page * @NUM_ELM;
SELECT * FROM ( SELECT *, ROW_NUMBER() OVER (ORDER BY ID_Result desc) as row FROM Result 
where (Result.NameMachine = @NameMachine)
and (Result.TimeStart BETWEEN @Time1 AND @Time2)
and (Result.ApSuatAvg between @ApSuat1 and @ApSuat2) 
and (Result.TheTichAvg between @TheTich1 and @TheTich2)
and (Result.LuuLuongAvg between @LuuLuong1 and @LuuLuong2)) 
a WHERE a.row > @start and a.row <= @end;
end
GO

--Chọn tên Machine,có chọn ngày, có chọn chỉ số (2 chỉ số , Áp suất - Thể tích)
CREATE PROC Count_YesName_YesDate_YesParameter_ApSuat_TheTich
(@NameMachine nvarchar(100), @Time1 Datetime , @Time2 Datetime, @ApSuat1 FLOAT, @ApSuat2 FLOAT , @TheTich1 FLOAT, @TheTich2 FLOAT)
as begin 
select count(*) from Result where (Result.NameMachine = @NameMachine)
and (Result.TimeStart BETWEEN @Time1 AND @Time2) 
and (Result.ApSuatAvg between @ApSuat1 and @ApSuat2) 
and (Result.TheTichAvg between @TheTich1 and @TheTich2)
end
GO

CREATE PROC Pagination_YesName_YesDate_YesParameter_ApSuat_TheTich (@page int ,@NUM_ELM int, @NameMachine nvarchar(100), @Time1 Datetime , @Time2 Datetime, @ApSuat1 FLOAT, @ApSuat2 FLOAT , @TheTich1 FLOAT, @TheTich2 FLOAT)
as begin
Declare @start INT = (@page -1) * @NUM_ELM;
Declare @end INT = @page * @NUM_ELM;
SELECT * FROM ( SELECT *, ROW_NUMBER() OVER (ORDER BY ID_Result desc) as row FROM Result 
where 
(Result.NameMachine = @NameMachine)
and (Result.TimeStart BETWEEN @Time1 AND @Time2)
and (Result.ApSuatAvg between @ApSuat1 and @ApSuat2) 
and (Result.TheTichAvg between @TheTich1 and @TheTich2)) 
a WHERE a.row > @start and a.row <= @end;
end
GO


--Có chọn tên Machine, có chọn ngày, có chọn chỉ số (2 chỉ số , Áp suất - Lưu Lượng)
CREATE PROC Count_YesName_YesDate_YesParameter_ApSuat_LuuLuong
( @NameMachine nvarchar(100), @Time1 Datetime , @Time2 Datetime, @ApSuat1 FLOAT, @ApSuat2 FLOAT , @LuuLuong1 FLOAT, @LuuLuong2 FLOAT)
as begin 
select count(*) from Result where 
(Result.NameMachine = @NameMachine)
and (Result.TimeStart BETWEEN @Time1 AND @Time2)
and (Result.ApSuatAvg between @ApSuat1 and @ApSuat2) 
and (Result.LuuLuongAvg between @LuuLuong1 and @LuuLuong2)
end
GO

CREATE PROC Pagination_YesName_YesDate_YesParameter_ApSuat_LuuLuong (@page int ,@NUM_ELM int,  @NameMachine nvarchar(100), @Time1 Datetime , @Time2 Datetime, @ApSuat1 FLOAT, @ApSuat2 FLOAT, @LuuLuong1 FLOAT, @LuuLuong2 FLOAT)
as begin
Declare @start INT = (@page -1) * @NUM_ELM;
Declare @end INT = @page * @NUM_ELM;
SELECT * FROM ( SELECT *, ROW_NUMBER() OVER (ORDER BY ID_Result desc) as row FROM Result 
where (Result.NameMachine = @NameMachine)
and (Result.TimeStart BETWEEN @Time1 AND @Time2)
and (Result.ApSuatAvg between @ApSuat1 and @ApSuat2) 
and (Result.LuuLuongAvg between @LuuLuong1 and @LuuLuong2)) 
a WHERE a.row > @start and a.row <= @end;
end
GO

--Có chọn tên Machine, có chọn ngày, có chọn chỉ số (2 chỉ số (thể tích - lưu lượng))
CREATE PROC Count_YesName_YesDate_YesParameter_TheTich_LuuLuong
(@NameMachine nvarchar(100), @Time1 Datetime , @Time2 Datetime, @TheTich1 FLOAT, @TheTich2 FLOAT , @LuuLuong1 FLOAT, @LuuLuong2 FLOAT)
as begin 
select count(*) from Result where 
(Result.NameMachine = @NameMachine)
and (Result.TimeStart BETWEEN @Time1 AND @Time2) 
and (Result.TheTichAvg between @TheTich1 and @TheTich2)
and (Result.LuuLuongAvg between @LuuLuong1 and @LuuLuong2)
end
GO

CREATE PROC Pagination_YesName_YesDate_YesParameter_TheTich_LuuLuong (@page int ,@NUM_ELM int, @NameMachine nvarchar(100), @Time1 Datetime , @Time2 Datetime, @TheTich1 FLOAT, @TheTich2 FLOAT , @LuuLuong1 FLOAT, @LuuLuong2 FLOAT)
as begin
Declare @start INT = (@page -1) * @NUM_ELM;
Declare @end INT = @page * @NUM_ELM;
SELECT * FROM ( SELECT *, ROW_NUMBER() OVER (ORDER BY ID_Result desc) as row FROM Result 
where (Result.NameMachine = @NameMachine)
and (Result.TimeStart BETWEEN @Time1 AND @Time2) 
and (Result.TheTichAvg between @TheTich1 and @TheTich2)
and (Result.LuuLuongAvg between @LuuLuong1 and @LuuLuong2)) 
a WHERE a.row > @start and a.row <= @end;
end
GO

--Có chọn tên Machine, có chọn ngày, có chọn chỉ số (1 thể tích)
CREATE PROC Count_YesName_YesDate_YesParameter_TheTich
(@NameMachine nvarchar(100), @Time1 Datetime , @Time2 Datetime, @TheTich1 FLOAT, @TheTich2 FLOAT)
as begin 
select count(*) from Result where (Result.NameMachine = @NameMachine)
and (Result.TimeStart BETWEEN @Time1 AND @Time2) and (Result.TheTichAvg between @TheTich1 and @TheTich2)
end
GO

CREATE PROC Pagination_YesName_YesDate_YesParameter_TheTich (@page int ,@NUM_ELM int, @NameMachine nvarchar(100), @Time1 Datetime , @Time2 Datetime, @TheTich1 FLOAT, @TheTich2 FLOAT)
as begin
Declare @start INT = (@page -1) * @NUM_ELM;
Declare @end INT = @page * @NUM_ELM;
SELECT * FROM ( SELECT *, ROW_NUMBER() OVER (ORDER BY ID_Result desc) as row FROM Result 
where (Result.NameMachine = @NameMachine)
and (Result.TimeStart BETWEEN @Time1 AND @Time2) 
and (Result.TheTichAvg between @TheTich1 and @TheTich2)) 
a WHERE a.row > @start and a.row <= @end;
end
GO

--Có chọn tên Machine, có chọn ngày, có chọn chỉ số (1 - lưu lượng)
CREATE PROC Count_YesName_YesDate_YesParameter_LuuLuong
(@NameMachine nvarchar(100), @Time1 Datetime , @Time2 Datetime, @LuuLuong1 FLOAT, @LuuLuong2 FLOAT)
as begin 
select count(*) from Result where  (Result.NameMachine = @NameMachine)
and (Result.TimeStart BETWEEN @Time1 AND @Time2) and (Result.LuuLuongAvg between @LuuLuong1 and @LuuLuong2)
end
GO

CREATE PROC Pagination_YesName_YesDate_YesParameter_LuuLuong (@page int ,@NUM_ELM int, @NameMachine nvarchar(100), @Time1 Datetime , @Time2 Datetime, @LuuLuong1 FLOAT, @LuuLuong2 FLOAT)
as begin
Declare @start INT = (@page -1) * @NUM_ELM;
Declare @end INT = @page * @NUM_ELM;
SELECT * FROM ( SELECT *, ROW_NUMBER() OVER (ORDER BY ID_Result desc) as row FROM Result 
where  (Result.NameMachine = @NameMachine)
and (Result.TimeStart BETWEEN @Time1 AND @Time2) 
and (Result.LuuLuongAvg between @LuuLuong1 and @LuuLuong2))
a WHERE a.row > @start and a.row <= @end;
end
GO


--Có chọn tên Machine, có chọn ngày, có chọn chỉ số (1 chỉ số - Áp suất)
CREATE PROC Count_YesName_YesDate_YesParameter_ApSuat
( @NameMachine nvarchar(100), @Time1 Datetime , @Time2 Datetime, @ApSuat1 FLOAT, @ApSuat2 FLOAT)
as begin 
select count(*) from Result where (Result.NameMachine = @NameMachine)
and (Result.TimeStart BETWEEN @Time1 AND @Time2) and (Result.ApSuatAvg between @ApSuat1 and @ApSuat2)
end
GO

CREATE PROC Pagination_YesName_YesDate_YesParameter_ApSuat (@page int ,@NUM_ELM int,  @NameMachine nvarchar(100), @Time1 Datetime , @Time2 Datetime, @ApSuat1 FLOAT, @ApSuat2 FLOAT)
as begin
Declare @start INT = (@page -1) * @NUM_ELM;
Declare @end INT = @page * @NUM_ELM;
SELECT * FROM ( SELECT *, ROW_NUMBER() OVER (ORDER BY ID_Result desc) as row FROM Result 
where (Result.NameMachine = @NameMachine)
and (Result.TimeStart BETWEEN @Time1 AND @Time2)
and Result.ApSuatAvg between @ApSuat1 and @ApSuat2) 
a WHERE a.row > @start and a.row <= @end;
end
GO




































/*LẺ*/

--Không chọn tên Machine, có chọn ngày, không chọn chỉ số (DATE)
CREATE PROC Count_NoName_YesDate_NoParameter (@Time1 Datetime , @Time2 Datetime)
as begin 
select count(*) from Result Where Result.TimeStart BETWEEN @Time1 AND @Time2;
end
GO


CREATE PROC Pagination_NoName_YesDate_NoParameter (@page int ,@NUM_ELM int, @Time1 Datetime , @Time2 Datetime)
as begin
Declare @start INT = (@page -1) * @NUM_ELM;
Declare @end INT = @page * @NUM_ELM;
SELECT * FROM ( SELECT *, ROW_NUMBER() OVER (ORDER BY ID_Result desc) as row FROM Result 
where Result.TimeStart BETWEEN @Time1 AND @Time2 ) 
a WHERE a.row > @start and a.row <= @end;
end
GO

--Chọn tên Machine, không chọn ngày, không chọn chỉ số (NAME)
CREATE PROC Count_YesName_NoDate_NoParameter (@NameMachine nvarchar(100) )
as begin 
select count(*) from Result where Result.NameMachine = @NameMachine;
end
GO

CREATE PROC Pagination_YesName_NoDate_NoParameter (@page int ,@NUM_ELM int, @NameMachine nvarchar(100))
as begin
Declare @start INT = (@page -1) * @NUM_ELM;
Declare @end INT = @page * @NUM_ELM;
SELECT * FROM ( SELECT *, ROW_NUMBER() OVER (ORDER BY ID_Result desc) as row FROM Result ) 
a WHERE a.row > @start and a.row <= @end;
end
GO





/*PARAMETER*/
--Không chọn tên Machine, không chọn ngày, có chọn chỉ số (3 chỉ số) 
CREATE PROC Count_NoName_NoDate_YesParameter_ApSuat_TheTich_LuuLuong
(@ApSuat1 FLOAT, @ApSuat2 FLOAT , @TheTich1 FLOAT, @TheTich2 FLOAT , @LuuLuong1 FLOAT, @LuuLuong2 FLOAT)
as begin 
select count(*) from Result where (Result.ApSuatAvg between @ApSuat1 and @ApSuat2) 
and (Result.TheTichAvg between @TheTich1 and @TheTich2)
and (Result.LuuLuongAvg between @LuuLuong1 and @LuuLuong2)
end
GO

CREATE PROC Pagination_NoName_NoDate_YesParameter_ApSuat_TheTich_LuuLuong (@page int ,@NUM_ELM int, @ApSuat1 FLOAT, @ApSuat2 FLOAT , @TheTich1 FLOAT, @TheTich2 FLOAT , @LuuLuong1 FLOAT, @LuuLuong2 FLOAT)
as begin
Declare @start INT = (@page -1) * @NUM_ELM;
Declare @end INT = @page * @NUM_ELM;
SELECT * FROM ( SELECT *, ROW_NUMBER() OVER (ORDER BY ID_Result desc) as row FROM Result 
where (Result.ApSuatAvg between @ApSuat1 and @ApSuat2) 
and (Result.TheTichAvg between @TheTich1 and @TheTich2)
and (Result.LuuLuongAvg between @LuuLuong1 and @LuuLuong2)) 
a WHERE a.row > @start and a.row <= @end;
end
GO

--Không chọn tên Machine, không chọn ngày, có chọn chỉ số (2 chỉ số , Áp suất - Thể tích)
CREATE PROC Count_NoName_NoDate_YesParameter_ApSuat_TheTich
(@ApSuat1 FLOAT, @ApSuat2 FLOAT , @TheTich1 FLOAT, @TheTich2 FLOAT)
as begin 
select count(*) from Result where (Result.ApSuatAvg between @ApSuat1 and @ApSuat2) 
and (Result.TheTichAvg between @TheTich1 and @TheTich2)
end
GO

CREATE PROC Pagination_NoName_NoDate_YesParameter_ApSuat_TheTich (@page int ,@NUM_ELM int, @ApSuat1 FLOAT, @ApSuat2 FLOAT , @TheTich1 FLOAT, @TheTich2 FLOAT)
as begin
Declare @start INT = (@page -1) * @NUM_ELM;
Declare @end INT = @page * @NUM_ELM;
SELECT * FROM ( SELECT *, ROW_NUMBER() OVER (ORDER BY ID_Result desc) as row FROM Result 
where (Result.ApSuatAvg between @ApSuat1 and @ApSuat2) 
and (Result.TheTichAvg between @TheTich1 and @TheTich2)) 
a WHERE a.row > @start and a.row <= @end;
end
GO

--Không chọn tên Machine, không chọn ngày, có chọn chỉ số (2 chỉ số , Áp suất - Lưu Lượng)
CREATE PROC Count_NoName_NoDate_YesParameter_ApSuat_LuuLuong
(@ApSuat1 FLOAT, @ApSuat2 FLOAT , @LuuLuong1 FLOAT, @LuuLuong2 FLOAT)
as begin 
select count(*) from Result where (Result.ApSuatAvg between @ApSuat1 and @ApSuat2) 
and (Result.LuuLuongAvg between @LuuLuong1 and @LuuLuong2)
end
GO

CREATE PROC Pagination_NoName_NoDate_YesParameter_ApSuat_LuuLuong (@page int ,@NUM_ELM int, @ApSuat1 FLOAT, @ApSuat2 FLOAT, @LuuLuong1 FLOAT, @LuuLuong2 FLOAT)
as begin
Declare @start INT = (@page -1) * @NUM_ELM;
Declare @end INT = @page * @NUM_ELM;
SELECT * FROM ( SELECT *, ROW_NUMBER() OVER (ORDER BY ID_Result desc) as row FROM Result 
where (Result.ApSuatAvg between @ApSuat1 and @ApSuat2) 
and (Result.LuuLuongAvg between @LuuLuong1 and @LuuLuong2)) 
a WHERE a.row > @start and a.row <= @end;
end
GO

--Không chọn tên Machine, không chọn ngày, có chọn chỉ số (2 chỉ số (thể tích - lưu lượng))
CREATE PROC Count_NoName_NoDate_YesParameter_TheTich_LuuLuong
(@TheTich1 FLOAT, @TheTich2 FLOAT , @LuuLuong1 FLOAT, @LuuLuong2 FLOAT)
as begin 
select count(*) from Result where (Result.TheTichAvg between @TheTich1 and @TheTich2)
and (Result.LuuLuongAvg between @LuuLuong1 and @LuuLuong2)
end
GO

CREATE PROC Pagination_NoName_NoDate_YesParameter_TheTich_LuuLuong (@page int ,@NUM_ELM int, @TheTich1 FLOAT, @TheTich2 FLOAT , @LuuLuong1 FLOAT, @LuuLuong2 FLOAT)
as begin
Declare @start INT = (@page -1) * @NUM_ELM;
Declare @end INT = @page * @NUM_ELM;
SELECT * FROM ( SELECT *, ROW_NUMBER() OVER (ORDER BY ID_Result desc) as row FROM Result 
where(Result.TheTichAvg between @TheTich1 and @TheTich2)
and (Result.LuuLuongAvg between @LuuLuong1 and @LuuLuong2)) 
a WHERE a.row > @start and a.row <= @end;
end
GO

--Không chọn tên Machine, không chọn ngày, có chọn chỉ số (1 thể tích)
CREATE PROC Count_NoName_NoDate_YesParameter_TheTich
(@TheTich1 FLOAT, @TheTich2 FLOAT)
as begin 
select count(*) from Result where (Result.TheTichAvg between @TheTich1 and @TheTich2)
end
GO

CREATE PROC Pagination_NoName_NoDate_YesParameter_TheTich (@page int ,@NUM_ELM int, @TheTich1 FLOAT, @TheTich2 FLOAT)
as begin
Declare @start INT = (@page -1) * @NUM_ELM;
Declare @end INT = @page * @NUM_ELM;
SELECT * FROM ( SELECT *, ROW_NUMBER() OVER (ORDER BY ID_Result desc) as row FROM Result 
where Result.TheTichAvg between @TheTich1 and @TheTich2) 
a WHERE a.row > @start and a.row <= @end;
end
GO

--Không chọn tên Machine, không chọn ngày, có chọn chỉ số (1 - lưu lượng)
CREATE PROC Count_NoName_NoDate_YesParameter_LuuLuong
(@LuuLuong1 FLOAT, @LuuLuong2 FLOAT)
as begin 
select count(*) from Result where Result.LuuLuongAvg between @LuuLuong1 and @LuuLuong2
end
GO

CREATE PROC Pagination_NoName_NoDate_YesParameter_LuuLuong (@page int ,@NUM_ELM int, @LuuLuong1 FLOAT, @LuuLuong2 FLOAT)
as begin
Declare @start INT = (@page -1) * @NUM_ELM;
Declare @end INT = @page * @NUM_ELM;
SELECT * FROM ( SELECT *, ROW_NUMBER() OVER (ORDER BY ID_Result desc) as row FROM Result 
where Result.LuuLuongAvg between @LuuLuong1 and @LuuLuong2)
a WHERE a.row > @start and a.row <= @end;
end
GO

--Không chọn tên Machine, không chọn ngày, có chọn chỉ số (1 chỉ số - Áp suất)
CREATE PROC Count_NoName_NoDate_YesParameter_ApSuat
(@ApSuat1 FLOAT, @ApSuat2 FLOAT)
as begin 
select count(*) from Result where Result.ApSuatAvg between @ApSuat1 and @ApSuat2
end
GO

CREATE PROC Pagination_NoName_NoDate_YesParameter_ApSuat (@page int ,@NUM_ELM int, @ApSuat1 FLOAT, @ApSuat2 FLOAT)
as begin
Declare @start INT = (@page -1) * @NUM_ELM;
Declare @end INT = @page * @NUM_ELM;
SELECT * FROM ( SELECT *, ROW_NUMBER() OVER (ORDER BY ID_Result desc) as row FROM Result 
where Result.ApSuatAvg between @ApSuat1 and @ApSuat2) 
a WHERE a.row > @start and a.row <= @end;
end
GO

















/*2*/

--Chọn tên, chọn ngày, không chọn chỉ số (NAME_DATE)
CREATE PROC Count_YesName_YesDate_NoParameter
(@NameMachine nvarchar(100), @Time1 Datetime , @Time2 Datetime)
as begin 
select count(*) from Result where 
(Result.NameMachine = @NameMachine)
and (Result.TimeStart BETWEEN @Time1 AND @Time2)
end
GO

CREATE PROC Pagination_YesName_YesDate_NoParameter (@page int ,@NUM_ELM int, @NameMachine nvarchar(100), @Time1 Datetime , @Time2 Datetime)
as begin
Declare @start INT = (@page -1) * @NUM_ELM;
Declare @end INT = @page * @NUM_ELM;
SELECT * FROM ( SELECT *, ROW_NUMBER() OVER (ORDER BY ID_Result desc) as row FROM Result 
where (Result.NameMachine = @NameMachine)
and (Result.TimeStart BETWEEN @Time1 AND @Time2)) 
a WHERE a.row > @start and a.row <= @end;
end
GO


--Name vs Parameter

--Chọn tên, không chọn ngày, chọn chỉ số (3 chỉ số) (NAME_DATE_PARAMETER)
CREATE PROC Count_YesName_NoDate_YesParameter_ApSuat_TheTich_LuuLuong
(@NameMachine nvarchar(100), @ApSuat1 FLOAT, @ApSuat2 FLOAT , @TheTich1 FLOAT, @TheTich2 FLOAT , @LuuLuong1 FLOAT, @LuuLuong2 FLOAT)
as begin 
select count(*) from Result where 
(Result.NameMachine = @NameMachine)
and (Result.ApSuatAvg between @ApSuat1 and @ApSuat2) 
and (Result.TheTichAvg between @TheTich1 and @TheTich2)
and (Result.LuuLuongAvg between @LuuLuong1 and @LuuLuong2)
end
GO

CREATE PROC Pagination_YesName_NoDate_YesParameter_ApSuat_TheTich_LuuLuong (@page int ,@NUM_ELM int, @NameMachine nvarchar(100),
@ApSuat1 FLOAT, @ApSuat2 FLOAT , @TheTich1 FLOAT, @TheTich2 FLOAT , @LuuLuong1 FLOAT, @LuuLuong2 FLOAT)
as begin
Declare @start INT = (@page -1) * @NUM_ELM;
Declare @end INT = @page * @NUM_ELM;
SELECT * FROM ( SELECT *, ROW_NUMBER() OVER (ORDER BY ID_Result desc) as row FROM Result 
where (Result.NameMachine = @NameMachine)
and (Result.ApSuatAvg between @ApSuat1 and @ApSuat2) 
and (Result.TheTichAvg between @TheTich1 and @TheTich2)
and (Result.LuuLuongAvg between @LuuLuong1 and @LuuLuong2)) 
a WHERE a.row > @start and a.row <= @end;
end
GO

--Chọn tên Machine,không chọn ngày, có chọn chỉ số (2 chỉ số , Áp suất - Thể tích)
CREATE PROC Count_YesName_NoDate_YesParameter_ApSuat_TheTich
(@NameMachine nvarchar(100), @ApSuat1 FLOAT, @ApSuat2 FLOAT , @TheTich1 FLOAT, @TheTich2 FLOAT)
as begin 
select count(*) from Result where (Result.NameMachine = @NameMachine)
and (Result.ApSuatAvg between @ApSuat1 and @ApSuat2) 
and (Result.TheTichAvg between @TheTich1 and @TheTich2)
end
GO

CREATE PROC Pagination_YesName_NoDate_YesParameter_ApSuat_TheTich (@page int ,@NUM_ELM int, @NameMachine nvarchar(100), @ApSuat1 FLOAT, @ApSuat2 FLOAT , @TheTich1 FLOAT, @TheTich2 FLOAT)
as begin
Declare @start INT = (@page -1) * @NUM_ELM;
Declare @end INT = @page * @NUM_ELM;
SELECT * FROM ( SELECT *, ROW_NUMBER() OVER (ORDER BY ID_Result desc) as row FROM Result 
where 
(Result.NameMachine = @NameMachine)
and (Result.ApSuatAvg between @ApSuat1 and @ApSuat2) 
and (Result.TheTichAvg between @TheTich1 and @TheTich2)) 
a WHERE a.row > @start and a.row <= @end;
end
GO

--Có chọn tên Machine, không chọn ngày, có chọn chỉ số (2 chỉ số , Áp suất - Lưu Lượng)
CREATE PROC Count_YesName_NoDate_YesParameter_ApSuat_LuuLuong
( @NameMachine nvarchar(100), @ApSuat1 FLOAT, @ApSuat2 FLOAT , @LuuLuong1 FLOAT, @LuuLuong2 FLOAT)
as begin 
select count(*) from Result where 
(Result.NameMachine = @NameMachine)
and (Result.ApSuatAvg between @ApSuat1 and @ApSuat2) 
and (Result.LuuLuongAvg between @LuuLuong1 and @LuuLuong2)
end
GO

CREATE PROC Pagination_YesName_NoDate_YesParameter_ApSuat_LuuLuong (@page int ,@NUM_ELM int,  @NameMachine nvarchar(100), @ApSuat1 FLOAT, @ApSuat2 FLOAT, @LuuLuong1 FLOAT, @LuuLuong2 FLOAT)
as begin
Declare @start INT = (@page -1) * @NUM_ELM;
Declare @end INT = @page * @NUM_ELM;
SELECT * FROM ( SELECT *, ROW_NUMBER() OVER (ORDER BY ID_Result desc) as row FROM Result 
where (Result.NameMachine = @NameMachine)
and (Result.ApSuatAvg between @ApSuat1 and @ApSuat2) 
and (Result.LuuLuongAvg between @LuuLuong1 and @LuuLuong2)) 
a WHERE a.row > @start and a.row <= @end;
end
GO

--Có chọn tên Machine, không chọn ngày, có chọn chỉ số (2 chỉ số (thể tích - lưu lượng))
CREATE PROC Count_YesName_NoDate_YesParameter_TheTich_LuuLuong
(@NameMachine nvarchar(100), @TheTich1 FLOAT, @TheTich2 FLOAT , @LuuLuong1 FLOAT, @LuuLuong2 FLOAT)
as begin 
select count(*) from Result where 
(Result.NameMachine = @NameMachine)
and (Result.TheTichAvg between @TheTich1 and @TheTich2)
and (Result.LuuLuongAvg between @LuuLuong1 and @LuuLuong2)
end
GO

CREATE PROC Pagination_YesName_NoDate_YesParameter_TheTich_LuuLuong (@page int ,@NUM_ELM int, @NameMachine nvarchar(100), @TheTich1 FLOAT, @TheTich2 FLOAT , @LuuLuong1 FLOAT, @LuuLuong2 FLOAT)
as begin
Declare @start INT = (@page -1) * @NUM_ELM;
Declare @end INT = @page * @NUM_ELM;
SELECT * FROM ( SELECT *, ROW_NUMBER() OVER (ORDER BY ID_Result desc) as row FROM Result 
where (Result.NameMachine = @NameMachine)
and (Result.TheTichAvg between @TheTich1 and @TheTich2)
and (Result.LuuLuongAvg between @LuuLuong1 and @LuuLuong2)) 
a WHERE a.row > @start and a.row <= @end;
end
GO

--Có chọn tên Machine, không chọn ngày, có chọn chỉ số (1 thể tích)
CREATE PROC Count_YesName_NoDate_YesParameter_TheTich
(@NameMachine nvarchar(100), @TheTich1 FLOAT, @TheTich2 FLOAT)
as begin 
select count(*) from Result where (Result.NameMachine = @NameMachine)
and (Result.TheTichAvg between @TheTich1 and @TheTich2)
end
GO

CREATE PROC Pagination_YesName_NoDate_YesParameter_TheTich (@page int ,@NUM_ELM int, @NameMachine nvarchar(100), @TheTich1 FLOAT, @TheTich2 FLOAT)
as begin
Declare @start INT = (@page -1) * @NUM_ELM;
Declare @end INT = @page * @NUM_ELM;
SELECT * FROM ( SELECT *, ROW_NUMBER() OVER (ORDER BY ID_Result desc) as row FROM Result 
where (Result.NameMachine = @NameMachine)
and (Result.TheTichAvg between @TheTich1 and @TheTich2)) 
a WHERE a.row > @start and a.row <= @end;
end
GO

--Có chọn tên Machine, không chọn ngày, có chọn chỉ số (1 - lưu lượng)
CREATE PROC Count_YesName_NoDate_YesParameter_LuuLuong
(@NameMachine nvarchar(100), @LuuLuong1 FLOAT, @LuuLuong2 FLOAT)
as begin 
select count(*) from Result where  (Result.NameMachine = @NameMachine) and (Result.LuuLuongAvg between @LuuLuong1 and @LuuLuong2)
end
GO

CREATE PROC Pagination_YesName_NoDate_YesParameter_LuuLuong (@page int ,@NUM_ELM int, @NameMachine nvarchar(100), @LuuLuong1 FLOAT, @LuuLuong2 FLOAT)
as begin
Declare @start INT = (@page -1) * @NUM_ELM;
Declare @end INT = @page * @NUM_ELM;
SELECT * FROM ( SELECT *, ROW_NUMBER() OVER (ORDER BY ID_Result desc) as row FROM Result 
where  (Result.NameMachine = @NameMachine)
and (Result.LuuLuongAvg between @LuuLuong1 and @LuuLuong2))
a WHERE a.row > @start and a.row <= @end;
end
GO


--Có chọn tên Machine, có chọn ngày, có chọn chỉ số (1 chỉ số - Áp suất)
CREATE PROC Count_YesName_NoDate_YesParameter_ApSuat
( @NameMachine nvarchar(100), @ApSuat1 FLOAT, @ApSuat2 FLOAT)
as begin 
select count(*) from Result where (Result.NameMachine = @NameMachine)
and (Result.ApSuatAvg between @ApSuat1 and @ApSuat2)
end
GO

CREATE PROC Pagination_YesName_NoDate_YesParameter_ApSuat (@page int ,@NUM_ELM int,  @NameMachine nvarchar(100), @ApSuat1 FLOAT, @ApSuat2 FLOAT)
as begin
Declare @start INT = (@page -1) * @NUM_ELM;
Declare @end INT = @page * @NUM_ELM;
SELECT * FROM ( SELECT *, ROW_NUMBER() OVER (ORDER BY ID_Result desc) as row FROM Result 
where (Result.NameMachine = @NameMachine)
and Result.ApSuatAvg between @ApSuat1 and @ApSuat2) 
a WHERE a.row > @start and a.row <= @end;
end
GO















--DATE VS PARAMETER

--không chọn tên, chọn ngày, chọn chỉ số (3 chỉ số) (NAME_DATE_PARAMETER)
CREATE PROC Count_NoName_YesDate_YesParameter_ApSuat_TheTich_LuuLuong
(@Time1 Datetime , @Time2 Datetime,
@ApSuat1 FLOAT, @ApSuat2 FLOAT , @TheTich1 FLOAT, @TheTich2 FLOAT , @LuuLuong1 FLOAT, @LuuLuong2 FLOAT)
as begin 
select count(*) from Result where 
(Result.TimeStart BETWEEN @Time1 AND @Time2)
and (Result.ApSuatAvg between @ApSuat1 and @ApSuat2) 
and (Result.TheTichAvg between @TheTich1 and @TheTich2)
and (Result.LuuLuongAvg between @LuuLuong1 and @LuuLuong2)
end
GO

CREATE PROC Pagination_NoName_YesDate_YesParameter_ApSuat_TheTich_LuuLuong (@page int ,@NUM_ELM int, @Time1 Datetime , @Time2 Datetime,
@ApSuat1 FLOAT, @ApSuat2 FLOAT , @TheTich1 FLOAT, @TheTich2 FLOAT , @LuuLuong1 FLOAT, @LuuLuong2 FLOAT)
as begin
Declare @start INT = (@page -1) * @NUM_ELM;
Declare @end INT = @page * @NUM_ELM;
SELECT * FROM ( SELECT *, ROW_NUMBER() OVER (ORDER BY ID_Result desc) as row FROM Result 
where(Result.TimeStart BETWEEN @Time1 AND @Time2)
and (Result.ApSuatAvg between @ApSuat1 and @ApSuat2) 
and (Result.TheTichAvg between @TheTich1 and @TheTich2)
and (Result.LuuLuongAvg between @LuuLuong1 and @LuuLuong2)) 
a WHERE a.row > @start and a.row <= @end;
end
GO

--Không chọn tên Machine,có chọn ngày, có chọn chỉ số (2 chỉ số , Áp suất - Thể tích)
CREATE PROC Count_NoName_YesDate_YesParameter_ApSuat_TheTich
(@Time1 Datetime , @Time2 Datetime, @ApSuat1 FLOAT, @ApSuat2 FLOAT , @TheTich1 FLOAT, @TheTich2 FLOAT)
as begin 
select count(*) from Result where (Result.TimeStart BETWEEN @Time1 AND @Time2) 
and (Result.ApSuatAvg between @ApSuat1 and @ApSuat2) 
and (Result.TheTichAvg between @TheTich1 and @TheTich2)
end
GO

CREATE PROC Pagination_NoName_YesDate_YesParameter_ApSuat_TheTich (@page int ,@NUM_ELM int, @Time1 Datetime , @Time2 Datetime, @ApSuat1 FLOAT, @ApSuat2 FLOAT , @TheTich1 FLOAT, @TheTich2 FLOAT)
as begin
Declare @start INT = (@page -1) * @NUM_ELM;
Declare @end INT = @page * @NUM_ELM;
SELECT * FROM ( SELECT *, ROW_NUMBER() OVER (ORDER BY ID_Result desc) as row FROM Result 
where (Result.TimeStart BETWEEN @Time1 AND @Time2)
and (Result.ApSuatAvg between @ApSuat1 and @ApSuat2) 
and (Result.TheTichAvg between @TheTich1 and @TheTich2)) 
a WHERE a.row > @start and a.row <= @end;
end
GO

--Không chọn tên Machine, có chọn ngày, có chọn chỉ số (2 chỉ số , Áp suất - Lưu Lượng)
CREATE PROC Count_NoName_YesDate_YesParameter_ApSuat_LuuLuong
(@Time1 Datetime , @Time2 Datetime, @ApSuat1 FLOAT, @ApSuat2 FLOAT , @LuuLuong1 FLOAT, @LuuLuong2 FLOAT)
as begin 
select count(*) from Result where 
(Result.TimeStart BETWEEN @Time1 AND @Time2)
and (Result.ApSuatAvg between @ApSuat1 and @ApSuat2) 
and (Result.LuuLuongAvg between @LuuLuong1 and @LuuLuong2)
end
GO

CREATE PROC Pagination_NoName_YesDate_YesParameter_ApSuat_LuuLuong (@page int ,@NUM_ELM int, @Time1 Datetime , @Time2 Datetime, @ApSuat1 FLOAT, @ApSuat2 FLOAT, @LuuLuong1 FLOAT, @LuuLuong2 FLOAT)
as begin
Declare @start INT = (@page -1) * @NUM_ELM;
Declare @end INT = @page * @NUM_ELM;
SELECT * FROM ( SELECT *, ROW_NUMBER() OVER (ORDER BY ID_Result desc) as row FROM Result 
where (Result.TimeStart BETWEEN @Time1 AND @Time2)
and (Result.ApSuatAvg between @ApSuat1 and @ApSuat2) 
and (Result.LuuLuongAvg between @LuuLuong1 and @LuuLuong2)) 
a WHERE a.row > @start and a.row <= @end;
end
GO

--Không chọn tên Machine, có chọn ngày, có chọn chỉ số (2 chỉ số (thể tích - lưu lượng))
CREATE PROC Count_NoName_YesDate_YesParameter_TheTich_LuuLuong
(@Time1 Datetime , @Time2 Datetime, @TheTich1 FLOAT, @TheTich2 FLOAT , @LuuLuong1 FLOAT, @LuuLuong2 FLOAT)
as begin 
select count(*) from Result where (Result.TimeStart BETWEEN @Time1 AND @Time2) 
and (Result.TheTichAvg between @TheTich1 and @TheTich2)
and (Result.LuuLuongAvg between @LuuLuong1 and @LuuLuong2)
end
GO

CREATE PROC Pagination_NoName_YesDate_YesParameter_TheTich_LuuLuong (@page int ,@NUM_ELM int, @Time1 Datetime , @Time2 Datetime, @TheTich1 FLOAT, @TheTich2 FLOAT , @LuuLuong1 FLOAT, @LuuLuong2 FLOAT)
as begin
Declare @start INT = (@page -1) * @NUM_ELM;
Declare @end INT = @page * @NUM_ELM;
SELECT * FROM ( SELECT *, ROW_NUMBER() OVER (ORDER BY ID_Result desc) as row FROM Result 
where (Result.TimeStart BETWEEN @Time1 AND @Time2) 
and (Result.TheTichAvg between @TheTich1 and @TheTich2)
and (Result.LuuLuongAvg between @LuuLuong1 and @LuuLuong2)) 
a WHERE a.row > @start and a.row <= @end;
end
GO

--Không chọn tên Machine, có chọn ngày, có chọn chỉ số (1 thể tích)
CREATE PROC Count_NoName_YesDate_YesParameter_TheTich
(@Time1 Datetime , @Time2 Datetime, @TheTich1 FLOAT, @TheTich2 FLOAT)
as begin 
select count(*) from Result where (Result.TimeStart BETWEEN @Time1 AND @Time2) and (Result.TheTichAvg between @TheTich1 and @TheTich2)
end
GO

CREATE PROC Pagination_NoName_YesDate_YesParameter_TheTich (@page int ,@NUM_ELM int, @Time1 Datetime , @Time2 Datetime, @TheTich1 FLOAT, @TheTich2 FLOAT)
as begin
Declare @start INT = (@page -1) * @NUM_ELM;
Declare @end INT = @page * @NUM_ELM;
SELECT * FROM ( SELECT *, ROW_NUMBER() OVER (ORDER BY ID_Result desc) as row FROM Result 
where (Result.TimeStart BETWEEN @Time1 AND @Time2) 
and (Result.TheTichAvg between @TheTich1 and @TheTich2)) 
a WHERE a.row > @start and a.row <= @end;
end
GO

--Không chọn tên Machine, có chọn ngày, có chọn chỉ số (1 - lưu lượng)
CREATE PROC Count_NoName_YesDate_YesParameter_LuuLuong
(@Time1 Datetime , @Time2 Datetime, @LuuLuong1 FLOAT, @LuuLuong2 FLOAT)
as begin 
select count(*) from Result where (Result.TimeStart BETWEEN @Time1 AND @Time2) and (Result.LuuLuongAvg between @LuuLuong1 and @LuuLuong2)
end
GO

CREATE PROC Pagination_NoName_YesDate_YesParameter_LuuLuong (@page int ,@NUM_ELM int, @Time1 Datetime , @Time2 Datetime, @LuuLuong1 FLOAT, @LuuLuong2 FLOAT)
as begin
Declare @start INT = (@page -1) * @NUM_ELM;
Declare @end INT = @page * @NUM_ELM;
SELECT * FROM ( SELECT *, ROW_NUMBER() OVER (ORDER BY ID_Result desc) as row FROM Result 
where (Result.TimeStart BETWEEN @Time1 AND @Time2) 
and (Result.LuuLuongAvg between @LuuLuong1 and @LuuLuong2))
a WHERE a.row > @start and a.row <= @end;
end
GO


--Không chọn tên Machine, có chọn ngày, có chọn chỉ số (1 chỉ số - Áp suất)
CREATE PROC Count_NoName_YesDate_YesParameter_ApSuat
(@Time1 Datetime , @Time2 Datetime, @ApSuat1 FLOAT, @ApSuat2 FLOAT)
as begin 
select count(*) from Result where (Result.TimeStart BETWEEN @Time1 AND @Time2) and (Result.ApSuatAvg between @ApSuat1 and @ApSuat2)
end
GO

CREATE PROC Pagination_NoName_YesDate_YesParameter_ApSuat (@page int ,@NUM_ELM int, @Time1 Datetime , @Time2 Datetime, @ApSuat1 FLOAT, @ApSuat2 FLOAT)
as begin
Declare @start INT = (@page -1) * @NUM_ELM;
Declare @end INT = @page * @NUM_ELM;
SELECT * FROM ( SELECT *, ROW_NUMBER() OVER (ORDER BY ID_Result desc) as row FROM Result 
where (Result.TimeStart BETWEEN @Time1 AND @Time2)
and Result.ApSuatAvg between @ApSuat1 and @ApSuat2) 
a WHERE a.row > @start and a.row <= @end;
end
GO
















 --Lấy ra các Result theo Worker
 CREATE PROC GetResultFromWorker (@Worker nvarchar(100)) as begin
 Select * from Result where Result.Worker = @Worker order by Result.ID_Result desc
 end
 GO


 -- Lấy ra danh sách user tham gia an nap may
 CREATE PROC GetListWorkerHasResult as begin
 select distinct Result.Worker from Result 
 end
 GO
  -- Lấy ra danh sách may machine
 CREATE PROC GetListMachineHasResult as begin
 select distinct Result.NameMachine from Result 
 end
 GO


--Add Result (chi them 1 result rong, sau khi ket thuc nap moi cap nhat lai)
CREATE PROC AddResultAndReturnIDResult
@NameMachine nvarchar(100),
@Worker nvarchar(100)
as begin
Declare @Result_Clone table (ID_Result int);
Insert into [Result] (NameMachine,Worker) OUTPUT inserted.ID_Result INTO @Result_Clone values (@NameMachine,@Worker);
select ID_Result from @Result_Clone;
end
GO

--Update Result (TimeEnd = last update) (auto update from data)
CREATE PROC UpdateResult
@ID_Result int
as begin 
--neu ton tai id_result nay thi cap nhat
if(exists(select * from Result where ID_Result = @ID_Result))
begin
Declare @ApSuatMin FLOAT;
select @ApSuatMin = MIN([Data].ApSuat) from [Data] where ID_Result = @ID_Result;
Declare @ApSuatMax FLOAT;
select @ApSuatMax = MAX([Data].ApSuat) from [Data] where ID_Result = @ID_Result;
Declare @ApSuatAvg FLOAT;
select @ApSuatAvg = AVG([Data].ApSuat) from [Data] where ID_Result = @ID_Result;
Declare @TheTichMin FLOAT;
select @TheTichMin = MIN([Data].TheTich) from [Data] where ID_Result = @ID_Result;
Declare @TheTichMax FLOAT;
select @TheTichMax = MAX([Data].TheTich) from [Data] where ID_Result = @ID_Result;
Declare @TheTichAvg FLOAT;
select @TheTichAvg = AVG([Data].TheTich) from [Data] where ID_Result = @ID_Result;
Declare @LuuLuongMin FLOAT;
select @LuuLuongMin = MIN([Data].LuuLuong) from [Data] where ID_Result = @ID_Result;
Declare @LuuLuongMax FLOAT;
select @LuuLuongMax = MAX([Data].LuuLuong) from [Data] where ID_Result = @ID_Result;
Declare @LuuLuongAvg FLOAT;
select @LuuLuongAvg = AVG([Data].LuuLuong) from [Data] where ID_Result = @ID_Result;

Update Result Set ApSuatMin = @ApSuatMin, ApSuatMax = @ApSuatMax, ApSuatAvg = @ApSuatAvg, TheTichMin = @TheTichMin, TheTichMax = @TheTichMax,
TheTichAvg = @TheTichAvg,  LuuLuongMin = @LuuLuongMin, LuuLuongMax = @LuuLuongMax, LuuLuongAvg = @LuuLuongAvg, TimeEnd = GETDATE() Where ID_Result = @ID_Result;
end
end
GO

--Tìm kiếm result theo IDResult
CREATE PROC GetResultFromID @ID_Result int
as begin 
Select * From Result Where Result.ID_Result = @ID_Result;
end
GO

-- delete result theo id
 -- Delete Activity
 CREATE PROC DeleteResultFromID (@ID_Result int)
 as begin
 Delete From Result where ID_Result = @ID_Result
 end
 GO






-- PROC Machine
--Update Thông số máy
CREATE PROC UpdateMachine @NameTemplateMachine nvarchar(100), @ApSuatNap FLoat, @TheTichNap FLOAT, @ThoiGianNap FLOAT, @ThoiGianLayMau FLOAT
as begin
Update Machine SET NameTemplateMachine = @NameTemplateMachine  ,ApSuatNap = @ApSuatNap, TheTichNap = @TheTichNap, ThoiGianNap = @ThoiGianNap, ThoiGianLayMau = @ThoiGianLayMau ,UpdateAt = GETDATE()
where ID_Machine = 1 or ID_Machine = 2
end
GO





--PROC TemplateMachine
-- Thêm TemplateMachine
CREATE PROC AddTemplateMachine @Name nvarchar(100), @ApSuatNap FLoat, @TheTichNap FLOAT, @ThoiGianNap FLoat, @ThoiGianLayMau FLOAT
as begin
Insert into TemplateMachine values (@Name,@ApSuatNap,@TheTichNap,@ThoiGianNap,@ThoiGianLayMau);
end
GO
--Cap nhat thong tin TemplateMachine
CREATE PROC UpdateTemplateMachine @ID_TemplateMachine int,@Name nvarchar(100), @ApSuatNap FLoat, @TheTichNap FLOAT, @ThoiGianNap FLOAT, @ThoiGianLayMau FLOAT
as begin
Update TemplateMachine SET TemplateMachine.[Name] = @Name, ApSuatNap = @ApSuatNap, TheTichNap = @TheTichNap, ThoiGianNap = @ThoiGianNap, ThoiGianLayMau = @ThoiGianLayMau
where ID_TemplateMachine = @ID_TemplateMachine
end
GO

--Xóa TemplateMachine
CREATE PROC DeleteTemplateMachine @ID_TemplateMachine Int
as begin
Delete FROM TemplateMachine WHERE TemplateMachine.ID_TemplateMachine = @ID_TemplateMachine;
end
GO

--lấy TemplateMachine từ tên TemplateMachine
CREATE PROC GetTemplateMachineFromName @Name nvarchar(100)
as begin 
Select * From TemplateMachine Where TemplateMachine.[Name] like @Name;
end
GO
--Lấy TemplateMachine từ id
CREATE PROC GetTemplateMachineFromID @ID_TemplateMachine Int
as begin
Select * from TemplateMachine where ID_TemplateMachine = @ID_TemplateMachine
end
GO




-- PROC Group
-- Thêm Group
CREATE PROC AddGroup @Name nvarchar(100), @IsManagementUser bit, @IsManagementGroup bit,@IsControlMachine bit,@IsSettingMachine bit, @IsSettingShift bit, @IsSettingTemplateMachine bit, @IsViewResult bit, @IsViewActivity bit, @IsDeleteResult bit, @IsDeleteActivity bit
as begin
Insert into [Group] values (@Name,@IsManagementUser, @IsManagementGroup,@IsControlMachine,@IsSettingMachine, @IsSettingShift, @IsSettingTemplateMachine, @IsViewResult, @IsViewActivity, @IsDeleteResult, @IsDeleteActivity);
end
GO

--Cap nhat thong tin quyền
CREATE PROC UpdateGroup @ID_Group int,@Name nvarchar(100), @IsManagementUser bit, @IsManagementGroup bit,@IsControlMachine bit,@IsSettingMachine bit, @IsSettingShift bit, @IsSettingTemplateMachine bit, @IsViewResult bit, @IsViewActivity bit, @IsDeleteResult bit, @IsDeleteActivity bit
as begin
Update [Group] SET [Name] = @Name, IsManagementUser = @IsManagementUser, IsManagementGroup = @IsManagementGroup,
IsControlMachine = @IsControlMachine, IsSettingMachine = @IsSettingMachine, IsSettingShift = @IsSettingShift, IsSettingTemplateMachine = @IsSettingTemplateMachine,
IsViewResult = @IsViewResult, IsViewActivity = @IsViewActivity, IsDeleteResult = @IsDeleteResult, IsDeleteActivity = @IsDeleteActivity
where ID_Group = @ID_Group
end
GO

--Xóa quyền
CREATE PROC DeleteGroup @ID_Group Int
as begin
Delete FROM [Group] WHERE [Group].ID_Group = @ID_Group;
end
GO

--Lấy quyền từ id
CREATE PROC GetGroupFromID @ID_Group Int
as begin
Select * from [Group] where ID_Group = @ID_Group
end
GO

--Tìm kiếm group với tên bất kỳ
CREATE PROC FindGroupByName @Name nvarchar(100)
as begin 
Select * From [Group] Where [Group].[Name] like '%'+@Name+'%';
end
GO
--lấy group từ tên group
CREATE PROC GetGroupFromName @Name nvarchar(100)
as begin 
Select * From [Group] Where [Group].[Name] like @Name;
end
GO





-- PROC SHIFT
-- Thêm SHIFT
CREATE PROC AddShift @Name nvarchar(100), @TimeStart Time, @TimeEnd Time
as begin
Insert into [Shift] values (@Name,@TimeStart,@TimeEnd);
end
GO

--Cap nhat thong tin ca làm
CREATE PROC UpdateShift @ID_Shift int,@Name nvarchar(100), @TimeStart Time, @TimeEnd Time
as begin
Update [Shift] SET [Name] = @Name, TimeStart = @TimeStart, TimeEnd = @TimeEnd
where ID_Shift = @ID_Shift
end
GO

--Xóa ca làm
CREATE PROC DeleteShift @ID_Shift Int
as begin
Delete FROM [Shift] WHERE [Shift].ID_Shift = @ID_Shift;
end
GO

--Lấy ca làm từ id
CREATE PROC GetShiftFromID @ID_Shift Int
as begin
Select * from [Shift] where ID_Shift = @ID_Shift
end
GO
--Lấy ca làm từ id
CREATE PROC GetShiftFromName @Name nvarchar(100)
as begin
Select * from [Shift] where [Name] = @Name
end
GO





--Proc User
--Tìm kiếm nhân viên theo tên tài khoản
CREATE PROC FindUserByUsername @Username varchar(100)
as begin 
Select * From [User] Where Username = @Username;
end
GO

--Tìm kiếm nhân viên theo MaNV
CREATE PROC GetUserFromID @ID_User int
as begin 
Select * From [User] Where [User].ID_User = @ID_User;
end
GO

-- get user from full name
CREATE PROC GetUserFromFullName @fullname nvarchar(100)
as begin 
Select * From [User] Where [User].fullname = @fullname;
end
GO

-- get user from user name
CREATE PROC GetUserFromUserName @username varchar(100)
as begin 
Select * From [User] Where [User].Username = @username;
end
GO


--Tìm kiếm nhân viên với họ tên bất kỳ
CREATE PROC FindUserByFullNameOrUsername @Name nvarchar(100)
as begin 
Select * From [User] Where [User].FullName like '%'+@Name+'%' OR [User].Username like '%'+@Name+'%';
end
GO

-- Thêm nhân viên
CREATE PROC AddUser @FullName nvarchar(100), @Username VARCHAR(100) , @Password VARCHAR(100) , @PhoneNumber VARCHAR(100), @Email VARCHAR(100), @NameShift Nvarchar(200), @ID_Group INT
as begin
Insert into [User] values (@FullName,@Username,@Password,@PhoneNumber,@Email,@NameShift,@ID_Group);
end
GO

--Cap nhat thong tin nhan vien
CREATE PROC UpdateUser @UsernameOld varchar(100), @FullName nvarchar(100), @Username VARCHAR(100) , @Password VARCHAR(100), @PhoneNumber VARCHAR(100), @Email VARCHAR(100), @NameShift NVARCHAR(200), @ID_Group INT
as begin
Update [User] SET FullName = @FullName, Username = @Username, Password = @Password, PhoneNumber=@PhoneNumber ,Email = @Email, NameShift = @NameShift, ID_Group = @ID_Group
where [User].Username = @UsernameOld
end
GO

--TRIGGER UPDATE USER
Create TRIGGER UpdateUserTrigger
on [User] for Update
AS begin
declare @usernameBeforeUpdate varchar(100);
select @usernameBeforeUpdate = deleted.username from deleted;
declare @usernameAfterUpdate varchar(100);
select @usernameAfterUpdate = inserted.username from inserted;
	UPDATE Activity set worker = @usernameAfterUpdate where worker = @usernameBeforeUpdate;
	UPDATE Result set worker = @usernameAfterUpdate where worker = @usernameBeforeUpdate;
end
GO

--Xóa tài khoản nhân viên theo Username
CREATE PROC DeleteUser @username VARCHAR(100)
as begin
Delete FROM [User] WHERE [User].Username = @username;
end
GO






--Activity
--Add Activity
CREATE PROC AddActivity @description nvarchar(2000), @isSetting bit ,@Worker nvarchar(100) 
as begin
insert into Activity ([Description],IsSetting,Worker) values (@Description,@IsSetting,@Worker)
end
GO


--Tim kiem Activity theo khoang ngay, sắp xếp theo thứ tự giảm dần của ID
CREATE PROC FindActivityByDay @Time1 DateTime , @Time2 DateTime
as begin
SELECT * FROM Activity WHERE 
Create_At BETWEEN
@Time1 AND
 @Time2 order by Activity.ID_Activity DESC
end
GO

--Đếm Activity theo ngày
CREATE PROC CountActivityDayToDay @Time1 DateTime , @Time2 DateTime
as begin
SELECT count(*) FROM Activity WHERE 
Create_At BETWEEN
@Time1 AND
 @Time2
end
GO

--phan trang 
create proc PaginationActivity (@startfrom int ,@endto int) as
SELECT * FROM ( 
  SELECT *, ROW_NUMBER() OVER (ORDER BY ID_Activity desc) as row FROM Activity 
 ) a WHERE a.row > @startfrom and a.row <= @endto
 GO

 -- phan trang theo ngay
 create proc PaginationActivityByDay (@startfrom int ,@endto int, @Time1 Datetime , @Time2 Datetime) as begin
SELECT * FROM ( SELECT *, ROW_NUMBER() OVER (ORDER BY ID_Activity desc) as row FROM Activity WHERE 
Create_At BETWEEN
@Time1 AND
 @Time2 ) as a WHERE a.row > @startfrom and a.row <= @endto
 end
 GO


 --Đếm Activity is setting
CREATE PROC CountActivityIsSetting
as begin
SELECT count(*) FROM Activity WHERE 
IsSetting = 1
end
GO

 -- phan trang is setting
 create proc PaginationActivityIsSetting (@startfrom int ,@endto int) as begin
SELECT * FROM ( SELECT *, ROW_NUMBER() OVER (ORDER BY ID_Activity desc) as row FROM Activity WHERE 
IsSetting = 1 ) as a WHERE a.row > @startfrom and a.row <= @endto
 end
 GO



 --Lấy ra các Activity theo Worker
 CREATE PROC GetActivityFromWorker (@Worker nvarchar(100)) as begin
 Select * from Activity where Activity.Worker = @Worker order by Activity.ID_Activity desc
 end
 GO


 -- Lấy ra danh sách user tham gia hoạt động
 CREATE PROC GetListWorkerHasActivity as begin
 select distinct Activity.Worker from Activity 
 end
 GO


 -- Delete Activity
 CREATE PROC DeleteActivityFromID (@ID_Activity int)
 as begin
 Delete From Activity where ID_Activity = @ID_Activity
 end
 GO

-- --Chart
-- -- lấy dữ liệu của Oxy hoặc Nitor trong ngày hiện tại
-- CREATE PROC GetDataToday (@LoaiKhi nvarchar(100)) as begin
-- declare @today Datetime ;
-- select @today = format(getdate(),'yyyy-MM-dd');
-- declare @tomorrow Datetime;
-- select @tomorrow = format( DATEADD(day, 1, @today),'yyyy-MM-dd');
--select * from Result where Result_LoaiKhi = @LoaiKhi and Result_CreateAt between @today and @tomorrow
--end
--GO

-- -- lấy dữ liệu của Oxy hoặc Nitor trong 1 tuần gần nhất
-- CREATE PROC GetDataSevenDaysAgo (@LoaiKhi nvarchar(100)) as begin
-- declare @today Datetime ;
-- select @today = format(getdate(),'yyyy-MM-dd');
-- declare @sevendayago Datetime;
-- select @sevendayago = format( DATEADD(day, -6, @today),'yyyy-MM-dd');
-- declare @tomorrow Datetime;
-- select @tomorrow = format( DATEADD(day, 1, @today),'yyyy-MM-dd');
--select * from Result where Result_LoaiKhi = @LoaiKhi and Result_CreateAt between @sevendayago and @tomorrow
--end
--GO

-- -- lấy dữ liệu của Oxy hoặc Nitor trong 30 ngày gần nhất
-- CREATE PROC GetDataThirtyDaysAgo (@LoaiKhi nvarchar(100)) as begin
-- declare @today Datetime ;
-- select @today = format(getdate(),'yyyy-MM-dd');
-- declare @ThirtyDayAgo Datetime;
-- select @ThirtyDayAgo = format( DATEADD(day, -29, @today),'yyyy-MM-dd');
-- declare @tomorrow Datetime;
-- select @tomorrow = format( DATEADD(day, 1, @today),'yyyy-MM-dd');
--select * from Result where Result_LoaiKhi = @LoaiKhi and Result_CreateAt between @ThirtyDayAgo and @tomorrow
--end
--GO


Insert into Machine(ID_Machine,NameMachine,NameTemplateMachine,ApSuatNap,TheTichNap,ThoiGianNap,ThoiGianLayMau) values (1,N'Máy 1',N'Không có sẵn',0,0,5,5);
Insert into Machine(ID_Machine,NameMachine,NameTemplateMachine,ApSuatNap,TheTichNap,ThoiGianNap,ThoiGianLayMau) values (2,N'Máy 2',N'Không có sẵn',0,0,5,5);
GO

exec AddShift N'Ca sáng','10:00:00','12:00:00'
exec AddShift N'Ca toi','11:00:00','12:00:00'
exec AddShift N'Ca dem','11:00:00','12:00:00'
exec AddShift N'Ca trua','11:00:00','12:00:00'
exec AddShift N'Ca nghi','11:00:00','12:00:00'
exec AddShift N'Ca choi','11:00:00','12:00:00'
exec AddShift N'Ca lam','11:00:00','12:00:00'
exec AddShift N'Ca them','11:00:00','12:00:00'
exec AddShift N'Ca bu','11:00:00','12:00:00'
exec AddShift N'Ca chieu','11:00:00','12:00:00'


GO
exec AddGroup N'Quyền Admin',1,1,1,1,1,1,1,1,1,1
exec AddGroup N'Quyền A',0,1,1,1,1,1,1,1,1,1
exec AddGroup N'Quyền B',0,1,0,0,0,0,1,1,1,1
exec AddGroup N'Quyền C',0,1,1,0,0,1,1,1,0,1
exec AddGroup N'Quyền D',0,1,1,0,0,1,1,1,0,1
exec AddGroup N'Quyền E',0,1,1,1,1,1,1,1,1,1
exec AddGroup N'Quyền F',0,1,1,1,1,1,1,1,1,1
exec AddGroup N'Quyền G',0,1,1,1,1,1,1,1,1,1
exec AddGroup N'Quyền H',0,1,1,1,1,1,1,1,1,1
exec AddGroup N'Quyền I',0,1,1,1,1,1,1,1,1,1
exec AddGroup N'Quyền K',0,1,1,1,1,1,1,1,1,1
exec AddGroup N'Quyền L',0,1,1,1,1,1,1,1,1,1



GO
exec AddUser N'Đỗ Văn Xuân', 'admin','123', '0123456789','xuan@gmail.com',N'Ca sáng',1
exec AddUser N'Lee Văn A', 'admin1','123', '0123456789','xuan@gmail.com',N'Ca sáng',2
exec AddUser N'Kim Văn B', 'admin2','123', '0123456789','xuan@gmail.com',N'Ca sáng',2
exec AddUser N'Nguyen Văn C', 'admin3','123', '0123456789','xuan@gmail.com',N'Ca sáng',4
exec AddUser N'Pham Văn D', 'admin4','123', '0123456789','xuan@gmail.com',N'Ca sáng',4
exec AddUser N'Đỗ Văn E', 'admin5','123', '0123456789','xuan@gmail.com',N'Ca sáng',2
exec AddUser N'Đỗ Văn F', 'admin6','123', '0123456789','xuan@gmail.com',N'Ca sáng',2
exec AddUser N'Đỗ Văn H', 'admin7','123', '0123456789','xuan@gmail.com',N'Ca sáng',2
exec AddUser N'Đỗ Văn G', 'admin8','123', '0123456789','xuan@gmail.com',N'Ca sáng',3
exec AddUser N'Đỗ Văn X', 'admin9','123', '0123456789','xuan@gmail.com',N'Ca sáng',5
exec AddUser N'Đỗ Văn K', 'admin10','123', '0123456789','xuan@gmail.com',N'Ca sáng',1

GO

exec AddActivity 'Start',0,'admin'
exec AddActivity N'Thay đổi áp suất nạp',1,'admin2'
exec AddActivity N'Thay đổi thể tích nạp',1,'admin1'
exec AddActivity N'Thay đổi thời gian nạp',1,'admin4'
exec AddActivity 'Start',0,'admin'
exec AddActivity 'Start',0,'admin2'
exec AddActivity N'Thay đổi áp suất nạp',1,'admin2'
exec AddActivity 'Start',0,'admin1'
exec AddActivity 'Start',0,'admin4'
exec AddActivity 'Start',0,'admin3'
exec AddActivity N'Thay đổi thể tích nạp',1,'admin1'
exec AddActivity 'Start',0,'admin1'
Go

exec AddTemplateMachine N'Tùy chỉnh',100,100,60,60
exec AddTemplateMachine N'Binh 1',342,32,55,43
exec AddTemplateMachine N'Binh 2',23,56,32,76
exec AddTemplateMachine N'Binh 3',23,44,55,43
exec AddTemplateMachine N'Binh 4',343,344,55,43
exec AddTemplateMachine N'Binh 5',45,34,100,43
exec AddTemplateMachine N'Binh 6',56,398,55,43
GO


exec AddResultAndReturnIDResult 'Máy 1','admin2'
GO
exec AddData 141,113,112,1
GO
exec UpdateResult 1
select * from Result
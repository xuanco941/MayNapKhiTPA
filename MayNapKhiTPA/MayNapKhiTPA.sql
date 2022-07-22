CREATE DATABASE MayNapKhiTPA
GO
USE MayNapKhiTPA
GO

--TABLE SHIFT
CREATE TABLE [Shift] (
ID_Shift INT IDENTITY(1,1) PRIMARY KEY,
[Name] nvarchar(100),
[TimeStart] TIME,
[TimeEnd] TIME
)
GO

--TABLE GROUP
CREATE TABLE [Group] (
ID_Group INT IDENTITY(1,1) PRIMARY KEY,
[Name] nvarchar(100),
IsManagementSetting bit,
IsManagementUser bit
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
ID_Shift int,
ID_Group int,
FOREIGN KEY (ID_Shift) REFERENCES [Shift](ID_Shift),
FOREIGN KEY (ID_Group) REFERENCES [Group](ID_Group)
)
GO

--TABLE ACTIVITY
CREATE TABLE Activity(
ID_Activity INT IDENTITY(1,1) PRIMARY KEY,
[Description] NVARCHAR(2000),
IsSetting bit default 0,
Create_At DATETIME DEFAULT GETDATE(),
ID_User int,
FOREIGN KEY (ID_User) REFERENCES [User](ID_User)
)
GO

--TABLE RESULT
CREATE TABLE Result(
ID_Result INT IDENTITY(1,1) PRIMARY KEY,
ApSuat FLOAT,
TheTich FLOAT,
LuuLuong FLOAT,
ThoiGianNap Time,
CreateAt DATETIME DEFAULT GETDATE()
)
GO

--TABLE Bình
CREATE TABLE TemplateSetting (
ID_TemplateSetting INT IDENTITY(1,1) PRIMARY KEY,
ApSuatNap FLoat,
TheTichNap Float,
ThoiGianNap TIME,
ThoiGianLayMau TIME,
)
GO

--TABLE THONG SO MAY
CREATE TABLE Setting (
ID_Setting int DEFAULT 1,
ApSuatNap FLoat,
TheTichNap Float,
ThoiGianNap TIME,
ThoiGianLayMau TIME,
UpdateAt DateTime
)
GO

/* Procedure */



----Result
-- -- Them result
--CREATE PROC AddResult @Result_ApSuatNap FLOAT,@Result_TheTichNap FLOAT,@Result_LoaiKhi nvarchar(100),@Result_ApSuatLayMau NVARCHAR(100), @Result_LuuLuongLayMau NVARCHAR(100),@Result_ThoiGian TIME
--as begin
--INSERT INTO Result(Result_ApSuatNap,Result_TheTichNap,Result_LoaiKhi,Result_ApSuatLayMau,Result_LuuLuongLayMau,Result_ThoiGian) 
--values(@Result_ApSuatNap,@Result_TheTichNap,@Result_LoaiKhi,@Result_ApSuatLayMau,@Result_LuuLuongLayMau,@Result_ThoiGian)
--end
--GO

----phan trang, lất tất cả
-- create proc paginationResult (@startfrom int ,@endto int) as
--SELECT * FROM ( 
--  SELECT *, ROW_NUMBER() OVER (ORDER BY Result_ID desc) as row FROM Result 
-- ) a WHERE a.row > @startfrom and a.row <= @endto
-- GO


-- --Tim kiem Result theo khoang ngay
--create proc paginationResultByDay (@startfrom int ,@endto int, @Time1 Datetime , @Time2 Datetime) as
--SELECT * FROM ( 
--  SELECT *, ROW_NUMBER() OVER (ORDER BY Result_ID desc) as row FROM Result WHERE 
--Result_CreateAt BETWEEN
--@Time1 AND
-- @Time2
-- ) as a WHERE a.row > @startfrom and a.row <= @endto 
-- GO

--CREATE PROC FindResultDayToDay @Time1 DateTime , @Time2 DateTime
--as begin
--SELECT * FROM Result WHERE 
--Result_CreateAt BETWEEN
--@Time1 AND
-- @Time2 order by Result.Result_ID DESC
--end
--GO


-- --pagination paraID and day
-- create proc paginationResultByDayAndParameter @startfrom int ,@endto int, @Time1 Datetime , @Time2 Datetime,@Oxy nvarchar(100), @Nitor nvarchar(100) 
-- as begin 
--  select * from (SELECT *, ROW_NUMBER() OVER (ORDER BY Result_ID desc) as row FROM Result WHERE 
--(Result_CreateAt BETWEEN
--@Time1 AND
-- @Time2) AND (Result_LoaiKhi = @Oxy OR Result_LoaiKhi = @Nitor )) as a WHERE a.row > @startfrom and a.row <= @endto  
-- end
-- GO

-- CREATE PROC FindResultDayToDayByParameter @Time1 DateTime , @Time2 DateTime,@Oxy nvarchar(100), @Nitor nvarchar(100)
--as begin
--SELECT * FROM Result WHERE( 
--Result_CreateAt BETWEEN
--@Time1 AND
-- @Time2) and (Result_LoaiKhi = @Oxy OR Result_LoaiKhi = @Nitor) order by Result.Result_ID DESC
--end
--GO

----Dem result theo ngay, theo parameter
--CREATE PROC CountResultByParameterAndDay @Time1 DateTime, @Time2 DateTime, @Oxy nvarchar(100), @Nitor nvarchar(100)
--as begin
--select count(*) from Result where (Result.Result_LoaiKhi = @Oxy OR Result.Result_LoaiKhi = @Nitor) and (Result.Result_CreateAt between @Time1 and @Time2) 
--end
--GO

----count by day
--CREATE PROC CountResultDayToDay @Time1 DateTime , @Time2 DateTime
--as begin
--SELECT count(*) FROM Result WHERE 
--Result_CreateAt BETWEEN
--@Time1 AND
-- @Time2
--end
--GO

-- -- delete result by ID
-- CREATE proc DeleteResultByIDAndParameter (@startID int, @endID int, @Oxy nvarchar(100), @Nitor nvarchar(100))
-- as begin
-- Delete From Result Where (Result.Result_ID >= @startID and Result.Result_ID <= @endID) and (Result.Result_LoaiKhi = @Oxy OR Result_LoaiKhi = @Nitor) 
-- end
-- GO








----Update Thông số máy
--CREATE PROC UpdateThongSoMay @ApSuat FLoat, @ThoiGianNapGioiHan Time
--as begin
--Update ThongSoMay SET ApSuat = @ApSuat, ThoiGianNapGioiHan = @ThoiGianNapGioiHan, UpdateAt = GETDATE()
--where ID = 1
--end
--GO




-- PROC Group
-- Thêm Group
CREATE PROC AddGroup @Name nvarchar(100), @IsManagementSetting bit, @IsManagementUser bit
as begin
Insert into [Group] values (@Name,@IsManagementSetting,@IsManagementUser);
end
GO

--Cap nhat thong tin quyền
CREATE PROC UpdateGroup @ID_Group int,@Name nvarchar(100), @IsManagementSetting bit, @IsManagementUser bit
as begin
Update [Group] SET [Name] = @Name, IsManagementSetting = @IsManagementSetting, IsManagementUser = @IsManagementUser
where ID_Group = @ID_Group
end
GO

--Xóa quyền
CREATE PROC DeleteGroup @ID_Group Int
as begin
Delete FROM [Group] WHERE [Group].ID_Group = @ID_Group;
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








--Proc Employee
--Tìm kiếm nhân viên theo tên tài khoản
CREATE PROC FindUserByUsername @Username varchar(100)
as begin 
Select * From [User] Where Username = @Username;
end
GO

--Tìm kiếm nhân viên theo MaNV
CREATE PROC FindUserByID @ID_User int
as begin 
Select * From [User] Where [User].ID_User = @ID_User;
end
GO

--Tìm kiếm nhân viên với họ tên bất kỳ
CREATE PROC FindUserByFullName @FullName nvarchar(100)
as begin 
Select * From [User] Where [User].FullName like '%'+@FullName+'%';
end
GO

-- Thêm nhân viên
CREATE PROC AddUser @FullName nvarchar(100), @Username VARCHAR(100) , @Password VARCHAR(100) , @PhoneNumber VARCHAR(100), @Email VARCHAR(100), @ID_Shift INT, @ID_Group INT
as begin
Insert into [User] values (@FullName,@Username,@Password,@PhoneNumber,@Email,@ID_Shift,@ID_Group);
end
GO

--Cap nhat thong tin nhan vien
CREATE PROC UpdateUser @UsernameOld varchar(100), @FullName nvarchar(100), @Username VARCHAR(100) , @Password VARCHAR(100), @PhoneNumber VARCHAR(100), @Email VARCHAR(100), @ID_Shift INT, @ID_Group INT
as begin
Update [User] SET FullName = @FullName, Username = @Username, Password = @Password, PhoneNumber=@PhoneNumber ,Email = @Email, ID_Shift = @ID_Shift, ID_Group = @ID_Group
where [User].Username = @UsernameOld
end
GO


--Xóa tài khoản nhân viên theo Username
CREATE PROC DeleteUser @username VARCHAR(100)
as begin
Delete FROM [User] WHERE [User].Username = @username;
end
GO




----Activity
----Tim kiem Activity theo khoang ngay
--CREATE PROC FindActivityDayToDay @Time1 DateTime , @Time2 DateTime
--as begin
--SELECT * FROM Activity WHERE 
--Activity_Time BETWEEN
--@Time1 AND
-- @Time2 order by Activity.Activity_ID DESC
--end
--GO

----Đếm Activity theo ngày
--CREATE PROC CountActivityDayToDay @Time1 DateTime , @Time2 DateTime
--as begin
--SELECT count(*) FROM Activity WHERE 
--Activity_Time BETWEEN
--@Time1 AND
-- @Time2
--end
--GO

----phan trang 
--create proc paginationActivity (@startfrom int ,@endto int) as
--SELECT * FROM ( 
--  SELECT *, ROW_NUMBER() OVER (ORDER BY Activity_ID desc) as row FROM Activity 
-- ) a WHERE a.row > @startfrom and a.row <= @endto
-- GO

-- -- phan trang theo ngay
-- create proc paginationActivityByDay (@startfrom int ,@endto int, @Time1 Datetime , @Time2 Datetime) as begin
--SELECT * FROM ( SELECT *, ROW_NUMBER() OVER (ORDER BY Activity_ID desc) as row FROM Activity WHERE 
--Activity_Time BETWEEN
--@Time1 AND
-- @Time2 ) as a WHERE a.row > @startfrom and a.row <= @endto
-- end
-- GO



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


exec AddShift N'Ca sáng','10:00:00','12:00:00'
GO
exec AddGroup N'Quyền Admin',1,1
GO
exec AddUser N'Đỗ Văn Xuân', 'admin','123', '0123456789','xuan@gmail.com',1,1
GO

--insert into Activity (Activity_Name) values ('Activity_Name')

--GO

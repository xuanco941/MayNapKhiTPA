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

--TABLE RESULT (MẺ)
CREATE TABLE Result(
ID_Result INT IDENTITY(1,1) PRIMARY KEY,
ApSuatMin FLOAT,
ApSuatMax FLOAT,
ApSuatAvg FLOAT,
TheTichMin FLOAT,
TheTichMax FLOAT,
TheTichAvg FLOAT,
LuuLuongMin FLOAT,
LuuLuongMax FLOAT,
LuuLuongAvg FLOAT,
TimeStart DATETIME DEFAULT GETDATE(),
TimeEnd DATETIME,
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

/* Procedure */


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
CREATE PROC FindActivityByDayToDay @Time1 DateTime , @Time2 DateTime
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
exec AddTemplateMachine N'Binh 1',86,98,55,43


select * from TemplateMachine
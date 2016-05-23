use db_Examination
go

if exists(select * from sysObjects where name='sp_Testing_Insert' and xtype='p')
	drop procedure sp_Testing_Insert
go

create procedure sp_Testing_Insert
	@ID int,
	@SID int,
	@TestDate datetime,
	@Flag int,
	@StartTime varchar(20),
	@EndTime varchar(20)
as
	update tb_Testing set SID=@SID,TestDate=@TestDate,Flag=@Flag,StartTime=@StartTime,EndTime=@EndTime where _id=@ID
go

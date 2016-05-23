use db_Examination
go

if exists(select * from sysObjects where name='sp_Testing_Insert' and xtype='p')
	drop procedure sp_Testing_Insert
go

create procedure sp_Testing_Insert
	@SID int,
	@TestDate datetime,
	@Flag int,
	@StartTime varchar(20),
	@EndTime varchar(20)
as
	insert into tb_Testing(SID,TestDate,Flag,StartTime,EndTime) values(@SID,@TestDate,@Flag,@StartTime,@EndTime)
go
 
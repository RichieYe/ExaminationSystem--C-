use db_Examination
go

if exists(select * from sysObjects where name='sp_UserTest_UpdateUAnswer' and xtype='p')
	drop procedure sp_UserTest_UpdateUAnswer
go

create procedure sp_UserTest_UpdateUAnswer
	@TID int,
	@Type int,
	@Question int,
	@UAnswer varchar(200)
as
	update tb_UserTest set UAnswer=@UAnswer where TID=@TID and Type=@Type and Question=@Question
go
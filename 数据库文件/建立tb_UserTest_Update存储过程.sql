use db_Examination
go

if exists(select * from sysObjects where name='sp_UserTest_Update' and xtype='p')
	drop procedure sp_UserTest_Update
go

create procedure sp_UserTest_Update
	@ID int,
	@TID int,
	@Type int,
	@Question int,
	@UAnswer varchar(200),
	@Flag int
as
	Update tb_UserTest set TID=@TID,Type=@Type,Question=@Question,UAnswer=@UAnswer,Flag=@Flag where _id=@ID
go
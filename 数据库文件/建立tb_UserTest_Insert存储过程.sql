use db_Examination
go

if exists(select * from sysObjects where name='sp_UserTest_Insert' and xtype='p')
	drop procedure sp_UserTest_Insert
go

create procedure sp_UserTest_Insert
	@TID int,
	@Type int,
	@Question int,
	@UAnswer varchar(200),
	@Flag int
as
	insert into tb_UserTest(TID,Type,Question,UAnswer,Flag) values(@TID,@Type,@Question,@UAnswer,@Flag)
go
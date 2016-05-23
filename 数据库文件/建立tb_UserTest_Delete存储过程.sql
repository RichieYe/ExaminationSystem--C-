use db_Examination
go

if exists(select * from sysObjects where name='sp_UserTest_Delete' and xtype='p')
	drop procedure sp_UserTest_Delete
go

create procedure sp_UserTest_Delete
	@ID int
as
	delete tb_UserTest where _id=@ID
go
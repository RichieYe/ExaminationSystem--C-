use db_Examination
go

if exists(select * from sysObjects where name='sp_UserScore_Delete' and xtype='p')
	drop procedure sp_UserScore_Delete
go

create procedure sp_UserScore_Delete
	@ID int
as
	delete tb_UserScore where _id=@ID
go

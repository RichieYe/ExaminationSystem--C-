use db_Examination
go

if exists(select * from sysObjects where name='sp_Testing_Delete' and xtype='p')
	drop procedure sp_Testing_Delete
go

create procedure sp_Testing_Delete
	@ID int
as
	delete tb_Testing where _id=@ID
go
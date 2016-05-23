use db_Examination
go

if exists(select * from sysObjects where name='sp_Student_Delete' and xtype='p')
	drop procedure sp_Student_Delete
go

create procedure sp_Student_Delete
	@ID int 
as
	delete from tb_Student where _id=@ID

	if(@@ERROR>0)
		return -1;
	else
		return 0;
go
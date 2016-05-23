use db_Examination
go

if exists(select * from sysObjects where name='sp_Classes_Insert' and xtype='p')
	drop procedure sp_Classes_Insert
go

create procedure sp_Classes_Insert
	@ClassName varchar(20)
as
	insert into tb_Classes(ClassName) values(@ClassName)

	if(@@ERROR>0)
		return -1;
	else
		return 0;
go
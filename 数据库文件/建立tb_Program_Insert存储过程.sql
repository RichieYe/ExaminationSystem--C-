use db_Examination
go

if exists(select * from sysObjects where name='sp_Program_Insert' and xtype='p')
	drop procedure sp_Program_Insert
go

create procedure sp_Program_Insert
	@Content varchar(200),
	@Answer varchar(200)
as
	insert into tb_Program(Content,Answer) values(@Content,@Answer)
go
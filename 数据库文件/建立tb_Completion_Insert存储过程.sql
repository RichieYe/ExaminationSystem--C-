use db_Examination
go

if exists(select * from sysObjects where name='sp_Completion_Insert' and xtype='p')
	drop procedure sp_Completion_Insert
go

create procedure sp_Completion_Insert
	@Content varchar(200),
	@Answer varchar(100)
as
	insert into tb_Completion(Content,Answer) values(@Content,@Answer)
go
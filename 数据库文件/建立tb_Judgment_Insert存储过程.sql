use db_Examination
go

if exists(select * from sysObjects where name='sp_Judgment_Insert' and xtype='p')
	drop procedure sp_Judgment_Insert
go

create procedure sp_Judgment_Insert
	@Content varchar(200),
	@Answer varchar(10)
as
	insert into tb_Judgment(Content,Answer) values(@Content,@Answer)
go
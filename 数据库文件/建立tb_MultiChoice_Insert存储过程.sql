use db_Examination
go

if exists(select * from sysObjects where name='sp_MultiChoice_Insert' and xtype='p')
	drop procedure sp_MultiChoice_Insert
go

create procedure sp_MultiChoice_Insert
	@Content varchar(200),
	@AnswerA varchar(100),
	@AnswerB varchar(100),
	@AnswerC varchar(100),
	@AnswerD varchar(100),
	@Answer varchar(100)
as
	insert into tb_MultiChoice(Content,AnswerA,AnswerB,AnswerC,AnswerD,Answer) values(@Content,@AnswerA,@AnswerB,@AnswerC,@AnswerD,@Answer)
go
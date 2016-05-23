use db_Examination
go

if exists(select * from sysObjects where name='sp_Choice_Insert' and xtype='p')
	drop procedure sp_Choice_Insert
go

create procedure sp_Choice_Insert
	@Content varchar(200),
	@AnswerA varchar(100),
	@AnswerB varchar(100),
	@AnswerC varchar(100),
	@AnswerD varchar(100),
	@Answer varchar(100)
as
	insert into tb_Choice(Content,AnswerA,AnswerB,AnswerC,AnswerD,Answer) values(@Content,@AnswerA,@AnswerB,@AnswerC,@AnswerD,@Answer)
go
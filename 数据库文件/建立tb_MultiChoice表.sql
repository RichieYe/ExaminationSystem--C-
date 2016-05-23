use db_Examination
go

if exists(select * from sysObjects where name='tb_MultiChoice')
	drop table tb_MultiChoice
go

create table tb_MultiChoice
(
	_id int identity(1,1) primary key,
	Content varchar(200) not null,
	AnswerA varchar(100) not null,
	AnswerB varchar(100) not null,
	AnswerC varchar(100) not null,
	AnswerD varchar(100) not null,
	Answer varchar(100) not null
)
go
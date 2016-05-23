use db_Examination
go

if exists(select * from sysObjects where name='tb_Completion_Answer')
	drop table tb_Completion_Answer
go

create table tb_Completion_Answer
(
	_id int identity(1,1) primary key,
	CID int constraint FK_Completion_Answer_CID Foreign key references tb_Completion(_id),
	Answer varchar(100) not null
)

go
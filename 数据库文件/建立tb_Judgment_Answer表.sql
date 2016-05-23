use db_Examination
go

if exists(select * from sysObjects where name='tb_Judgment_Answer')
	drop table tb_Judgment_Answer
go

create table tb_Judgment_Answer
(
	_id int identity(1,1) primary key,
	JID int constraint FK_Judgment_Answer_JID Foreign Key references tb_Judgment(_id),
	Answer varchar(10) not null
)

go
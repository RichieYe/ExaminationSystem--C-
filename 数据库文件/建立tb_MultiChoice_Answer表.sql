use db_Examination
go

if exists(select * from sysObjects where name='tb_MultiChoice_Answer')
	drop table tb_MultiChoice_Answer
go

create table tb_MultiChoice_Answer
(
	_id int identity(1,1) primary key,
	MID int constraint FK_MulitChoice_Answer_MID Foreign Key references tb_MultiChoice(_id),
	Answer varchar(20) not null
)
go
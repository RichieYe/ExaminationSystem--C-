use db_Examination
go

if exists(select * from sysObjects where name='tb_Choice_Answer')
	drop table tb_Choice_Answer
go

create table tb_Choice_Answer
(
	_id int identity(1,1) primary key,
	CID int constraint FK_Choice_Answer_CID Foreign key references tb_Choice(_id),
	Answer varchar(10) not null
)
go
use db_Examination
go

if exists(select * from sysObjects where name='tb_Program_Answer')
	drop table tb_Program_Answer
go

create table tb_Program_Answer
(
	_id int identity(1,1) primary key,
	PID int constraint FK_Program_Answer_PID Foreign Key references tb_Program(_id),
	Answer varchar(200) not null
)

go
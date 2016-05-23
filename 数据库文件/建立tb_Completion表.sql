use db_Examination
go

if exists(select * from sysObjects where name='tb_Completion')
	drop table tb_Completion
go

create table tb_Completion
(
	_id int identity(1,1) primary key,
	Content varchar(200) not null,
	Answer varchar(200) not null
)
go
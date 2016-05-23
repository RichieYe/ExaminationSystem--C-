use db_Examination
go

if exists(select * from sysObjects where name='tb_Program')
	drop table tb_Program
go

create table tb_Program
(
	_id int identity(1,1) primary key,
	Content varchar(200) not null,
	Answer varchar(200) not null
)
go
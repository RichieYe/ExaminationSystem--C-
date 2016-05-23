use db_Examination
go

if exists(select * from sysObjects where name='tb_Judgment')
	drop table tb_Judgment
go

create table tb_Judgment
(
	_id int identity(1,1) primary key,
	Content varchar(200) not null,
	Answer varchar(10) not null
)

go
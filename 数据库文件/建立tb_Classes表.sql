use db_Examination
go

if exists(select * from sysObjects where name='tb_Classes')
	drop table tb_Classes
go

create table tb_Classes
(
	_id int identity(1,1) primary key,
	ClassName varchar(20) not null,
)
go

select * from tb_Classes
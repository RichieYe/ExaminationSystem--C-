use db_Examination
go

if exists(select * from sysObjects where name='tb_UserTest')
	drop table tb_UserTest
go

create table tb_UserTest
(
	_id int identity(1,1) primary key,
	TID int constraint FK_UserTest_TID Foreign Key references tb_Testing(_id),
	Type int not null,
	Question int not null,
	UAnswer varchar(200),
	Flag int
)
go
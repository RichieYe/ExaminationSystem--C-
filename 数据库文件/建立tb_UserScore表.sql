use db_Examination
go

if exists(select * from sysObjects where name='tb_UserScore')
	drop table tb_UserScore
go

create table tb_UserScore
(
	_id int identity(1,1) primary key,
	TID int constraint FK_UserScore_TID Foreign Key references tb_UserTest(_id),
	Score float not null default(0)
)
go
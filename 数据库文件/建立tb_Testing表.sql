use db_Examination
go

if exists(select * from sysObjects where name='tb_Testing')
	drop table tb_Testing
go

create table tb_Testing
(
	_id int identity(1,1) primary key,
	SID int constraint FK_Testing_SID Foreign key references tb_Student(_id),
	TestDate datetime default(getDate()),
	Flag int not null default(0),
	StartTime varchar(20),
	EndTime varchar(20)
)
go

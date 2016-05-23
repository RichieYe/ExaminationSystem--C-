use db_Examination
go

if exists(select * from sysObjects where name='tb_Student')
	drop table tb_Student
go

Create Table tb_Student
(
	_id int identity(1,1) primary key,
	UserName varchar(20) not null,
	No varchar(20) not null,
	CId int constraint FK_Student_CID Foreign key references tb_Classes(_id),
	Password varchar(20) not null,
	Gender varchar(2) not null,
	Phone varchar(12),
	Address varchar(50)
)

go


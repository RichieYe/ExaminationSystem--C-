use db_Examination
go

if exists(select * from sysObjects where name='sp_Student_Insert' and xtype='p')
	drop procedure sp_Student_Insert
go

create procedure sp_Student_Insert
	@UserName varchar(20),
	@No varchar(20),
	@CId int,
	@Password varchar(20),
	@Gender varchar(2),
	@Phone varchar(12),
	@Address varchar(50)
as 
	insert into tb_Student(UserName,No,CId,Password,Gender,Phone,Address) values(@UserName,@No,@CId,@Password,@Gender,@Phone,@Address)

	if(@@ERROR>0)
		return -1;
	else
		return 0;
go
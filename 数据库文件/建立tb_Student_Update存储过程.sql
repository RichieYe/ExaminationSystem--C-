use db_Examination
go

if exists(select * from sysObjects where name='sp_Student_Update' and xtype='p')
	drop procedure sp_Student_Update
go

create procedure sp_Student_Update
	@ID int,
	@UserName varchar(20),
	@No varchar(20),
	@CId int,
	@Password varchar(20),
	@Gender varchar(2),
	@Phone varchar(12),
	@Address varchar(50)
as 
	Update tb_Student set UserName=@UserName,No=@No,CId=@CId,Password=@Password,Gender=@Gender,Phone=@Phone,Address=@Address where _id=@ID

	if(@@ERROR>0)
		return -1;
	else
		return 0;
go
use db_Examination
go

if exists(select * from sysObjects where name='sp_UserScore_Update' and xtype='p')
	drop procedure sp_UserScore_Update
go

create procedure sp_UserScore_Update
	@ID int,
	@TID int,
	@Score float
as
	update tb_UserScore set TID=@TID,Score=@Score where _id=@ID
go
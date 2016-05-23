use db_Examination
go

if exists(select * from sysObjects where name='sp_UserScore_Insert' and xtype='p')
	drop procedure sp_UserScore_Insert
go

create procedure sp_UserScore_Insert
	@TID int,
	@Score float
as
	insert into tb_UserScore(TID,Score) values(@TID,@Score)
go
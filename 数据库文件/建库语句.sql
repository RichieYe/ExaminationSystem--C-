Create database db_Examination
ON
(
	Name='db_Examination',
	FileName='D:\ASP.net\在线考试系统\ExaminationSystem\App_Data\db_Examination.mdf',
	Size=5mb,
	FileGrowth=10%
)
LOG ON
(
	Name='log_Examination',
	FileName='D:\ASP.net\在线考试系统\ExaminationSystem\App_Data\db_Examination.ldf'
)

go
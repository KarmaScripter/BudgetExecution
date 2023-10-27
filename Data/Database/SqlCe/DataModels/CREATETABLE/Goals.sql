CREATE TABLE Goals
(
	GoalsId INT           NOT NULL UNIQUE,
	Code    NVARCHAR(150) NULL DEFAULT ('NS'),
	Name    NVARCHAR(150) NULL DEFAULT ('NS'),
	Title   NVARCHAR(150) NULL DEFAULT ('NS'),
	CONSTRAINT GoalsPrimaryKey PRIMARY KEY
		(
		  GoalsId
			)
);

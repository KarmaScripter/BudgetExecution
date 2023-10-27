CREATE TABLE IF NOT EXISTS Goals
(
	GoalsId
	INTEGER
	NOT
	NULL
	UNIQUE,
	Code
	TEXT
(
	150
) NULL DEFAULT NS,
	Name TEXT
(
	150
) NULL DEFAULT NS,
	Title TEXT
(
	150
) NULL DEFAULT NS,
	CONSTRAINT GoalsPrimaryKey
	PRIMARY KEY
(
	GoalsId
)
	);

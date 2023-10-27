CREATE TABLE IF NOT EXISTS Objectives
(
	ObjectivesId
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
	CONSTRAINT ObjectivesPrimaryKey
	PRIMARY KEY
(
	ObjectivesId
)
	);

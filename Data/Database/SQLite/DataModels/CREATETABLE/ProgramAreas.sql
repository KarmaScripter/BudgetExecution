CREATE TABLE IF NOT EXISTS ProgramAreas
(
	ProgramAreasId
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
	CONSTRAINT ProgramAreasPrimaryKey
	PRIMARY KEY
(
	ProgramAreasId
)
	);

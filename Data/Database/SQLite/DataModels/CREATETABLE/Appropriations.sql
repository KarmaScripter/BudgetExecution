CREATE TABLE IF NOT EXISTS Appropriations
(
	AppropriationsId
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
	CONSTRAINT AppropriationsPrimaryKey
	PRIMARY KEY
(
	AppropriationsId
)
	);

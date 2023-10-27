CREATE TABLE IF NOT EXISTS URL
(
	SourceId
	INTEGER
	NOT
	NULL
	UNIQUE,
	Name
	TEXT
(
	150
) NULL DEFAULT NS,
	Location TEXT
(
	150
) NULL DEFAULT NS,
	Address TEXT
(
	255
) NULL DEFAULT NS,
	CONSTRAINT URLPrimaryKey
	PRIMARY KEY
(
	SourceId
)
	);

CREATE TABLE IF NOT EXISTS ActivityCodes
(
	ActivityId INTEGER NOT NULL UNIQUE,
	Code TEXT(80) NOT NULL,
	Name TEXT(80) NULL DEFAULT NS,
	Description TEXT(80) NULL DEFAULT NS,
	CONSTRAINT ActivityCodesPrimaryKey )
		PRIMARY KEY(ActivityId)
);
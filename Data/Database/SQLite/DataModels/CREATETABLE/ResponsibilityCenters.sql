CREATE TABLE IF NOT EXISTS ResponsibilityCenters
(
	ResponsibilityCentersId
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
	CONSTRAINT ResponsibilityCentersPrimaryKey
	PRIMARY KEY
(
	ResponsibilityCentersId
)
	);

CREATE TABLE IF NOT EXISTS Reports
(
	ReportsId
	INTEGER
	NOT
	NULL
	UNIQUE,
	Name
	TEXT
(
	150
) NULL DEFAULT NS,
	Title TEXT
(
	150
) NULL DEFAULT NS,
	CONSTRAINT ReportsPrimaryKey
	PRIMARY KEY
(
	ReportsId
)
	);

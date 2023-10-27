CREATE TABLE IF NOT EXISTS PublicLaws
(
	PublicLawsId
	INTEGER
	NOT
	NULL
	UNIQUE,
	LawNumber
	TEXT
(
	150
) NULL DEFAULT NS,
	BillTitle TEXT
(
	150
) NULL DEFAULT NS,
	EnactedDate DATETIME NULL,
	Congress TEXT
(
	150
) NULL DEFAULT NS,
	BFY TEXT
(
	150
) NULL DEFAULT NS,
	CONSTRAINT PublicLawsPrimaryKey
	PRIMARY KEY
(
	PublicLawsId
)
	);

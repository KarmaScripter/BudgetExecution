CREATE TABLE IF NOT EXISTS PayPeriods
(
	PayPeriodsId
	INTEGER
	NOT
	NULL
	UNIQUE,
	BFY
	TEXT
(
	150
) NULL DEFAULT NS,
	Number TEXT
(
	150
) NULL DEFAULT NS,
	Period TEXT
(
	150
) NULL DEFAULT NS,
	Type TEXT
(
	150
) NULL DEFAULT NS,
	SecurityOrg TEXT
(
	150
) NULL DEFAULT NS,
	StartDate DATETIME NULL,
	EndDate DATETIME NULL,
	SplitPayPeriod TEXT
(
	150
) NULL DEFAULT NS,
	CONSTRAINT PayPeriodsPrimaryKey
	PRIMARY KEY
(
	PayPeriodsId
)
	);

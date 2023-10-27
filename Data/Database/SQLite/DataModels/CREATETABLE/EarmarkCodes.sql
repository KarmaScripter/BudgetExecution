CREATE TABLE IF NOT EXISTS EarmarkCodes
(
	EarmarkCodesId
	INTEGER
	NOT
	NULL
	UNIQUE,
	BFY
	TEXT
(
	150
) NULL DEFAULT NS,
	RpioCode TEXT
(
	150
) NULL DEFAULT NS,
	AhCode TEXT
(
	150
) NULL DEFAULT NS,
	AhName TEXT
(
	150
) NULL DEFAULT NS,
	CONSTRAINT EarmarkCodesPrimaryKey
	PRIMARY KEY
(
	EarmarkCodesId
)
	);

CREATE TABLE IF NOT EXISTS ReimbursableAgreements
(
	ReimbursableAgreementsId
	INTEGER
	NOT
	NULL
	UNIQUE,
	RPIO
	TEXT
(
	150
) NULL DEFAULT NS,
	BFY TEXT
(
	150
) NULL DEFAULT NS,
	AgreementNumber TEXT
(
	150
) NULL DEFAULT NS,
	FundCode TEXT
(
	150
) NULL DEFAULT NS,
	RpioCode TEXT
(
	150
) NULL DEFAULT NS,
	StartDate DATETIME NULL,
	EndDate DATETIME NULL,
	RcCode TEXT
(
	150
) NULL DEFAULT NS,
	RcName TEXT
(
	150
) NULL DEFAULT NS,
	OrgCode TEXT
(
	150
) NULL DEFAULT NS,
	SiteProjectCode TEXT
(
	150
) NULL DEFAULT NS,
	AccountCode TEXT
(
	150
) NULL DEFAULT NS,
	VendorCode TEXT
(
	150
) NULL DEFAULT NS,
	VendorName TEXT
(
	150
) NULL DEFAULT NS,
	Amount DOUBLE NULL DEFAULT 0.0,
	OpenCommitments DOUBLE NULL DEFAULT 0.0,
	Obligations DOUBLE NULL DEFAULT 0.0,
	UnliquidatedObligations DOUBLE NULL DEFAULT 0.0,
	Available DOUBLE NULL DEFAULT 0.0,
	CONSTRAINT ReimbursableAgreementsPrimaryKey
	PRIMARY KEY
(
	ReimbursableAgreementsId
)
	);

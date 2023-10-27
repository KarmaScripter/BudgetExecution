CREATE TABLE IF NOT EXISTS StatusOfSpecialAccountFunds
(
	StatusOfSpecialAccountFundsId
	INTEGER
	NOT
	NULL
	UNIQUE,
	Fiscal
	Year
	TEXT
(
	255
) NULL DEFAULT NS,
	BFY TEXT
(
	255
) NULL DEFAULT NS,
	EFY TEXT
(
	255
) NULL DEFAULT NS,
	FundCode TEXT
(
	255
) NULL DEFAULT NS,
	FundName TEXT
(
	255
) NULL DEFAULT NS,
	RpioCode TEXT
(
	255
) NULL DEFAULT NS,
	RpioName TEXT
(
	255
) NULL DEFAULT NS,
	ProgramCode TEXT
(
	255
) NULL DEFAULT NS,
	SpecialAccountNumber TEXT
(
	255
) NULL DEFAULT NS,
	SpecialAccountName TEXT
(
	255
) NULL DEFAULT NS,
	SpecialAccountStatus TEXT
(
	255
) NULL DEFAULT NS,
	NplStatusCode TEXT
(
	255
) NULL DEFAULT NS,
	StatusDescription TEXT
(
	255
) NULL DEFAULT NS,
	EpaSiteId TEXT
(
	255
) NULL DEFAULT NS,
	CerclisSiteId TEXT
(
	255
) NULL DEFAULT NS,
	SiteCode TEXT
(
	255
) NULL DEFAULT NS,
	SiteName TEXT
(
	255
) NULL DEFAULT NS,
	OperableUnit TEXT
(
	255
) NULL DEFAULT NS,
	PipelineCode TEXT
(
	255
) NULL DEFAULT NS,
	PipelineDescription TEXT
(
	255
) NULL DEFAULT NS,
	TransactionDescription TEXT
(
	255
) NULL DEFAULT NS,
	InterestDate TEXT
(
	255
) NULL DEFAULT NS,
	TrustfundTransfers INT NULL,
	OpenCommitments DOUBLE NULL DEFAULT 0.0,
	Obligations DOUBLE NULL DEFAULT 0.0,
	UnliquidatedObligations DOUBLE NULL DEFAULT 0.0,
	Disbursements DOUBLE NULL DEFAULT 0.0,
	UnpaidBalance INT NULL,
	CumulativeReceipts DOUBLE NULL DEFAULT 0.0,
	NetReceipts INT NULL,
	Interest INT NULL,
	CollectionsAndInterest DOUBLE NULL DEFAULT 0.0,
	AvailableBalance DOUBLE NULL DEFAULT 0.0
	CONSTRAINT StatusOfSpecialAccountFundsPrimaryKey
	PRIMARY KEY
(
	StatusOfSpecialAccountFundsId
)
	);

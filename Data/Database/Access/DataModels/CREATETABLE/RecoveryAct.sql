CREATE TABLE RecoveryAct
(
	RecoveryActId      AUTOINCREMENT NOT NULL UNIQUE,
	BFY                TEXT( 150 )   NULL DEFAULT NS,
	EFY                TEXT( 150 )   NULL DEFAULT NS,
	FundCode           TEXT( 150 )   NULL DEFAULT NS,
	FundName           TEXT( 150 )   NULL DEFAULT NS,
	RpioCode           TEXT( 150 )   NULL DEFAULT NS,
	RpioName           TEXT( 150 )   NULL DEFAULT NS,
	OrgCode            TEXT( 150 )   NULL DEFAULT NS,
	OrgName            TEXT( 150 )   NULL DEFAULT NS,
	AccountCode        TEXT( 150 )   NULL DEFAULT NS,
	ProgramProjectName TEXT( 150 )   NULL DEFAULT NS,
	BocCode            TEXT( 150 )   NULL DEFAULT NS,
	BocName            TEXT( 150 )   NULL DEFAULT NS,
	Amount             DOUBLE        NULL DEFAULT 0.0, CONSTRAINT
(
	RecoveryActPrimaryKey
)
	PRIMARY KEY
(
	RecoveryActId
)
	);

CREATE TABLE ReimbursableFunds
(
	ReimbursableFundsId     INT           NOT NULL UNIQUE,
	BFY                     NVARCHAR(150) NULL DEFAULT ('NS'),
	FundCode                NVARCHAR(150) NULL DEFAULT ('NS'),
	AgreeementNumber        NVARCHAR(150) NULL DEFAULT ('NS'),
	RpioCode                NVARCHAR(150) NULL DEFAULT ('NS'),
	AccountCode             NVARCHAR(150) NULL DEFAULT ('NS'),
	Amount                  money         NULL,
	OpenCommitments         FLOAT         NULL DEFAULT (0.0),
	Obligations             FLOAT         NULL DEFAULT (0.0),
	UnliquidatedObligations FLOAT         NULL DEFAULT (0.0),
	Available               FLOAT         NULL DEFAULT (0.0),
	CONSTRAINT ReimbursableFundsPrimaryKey PRIMARY KEY
		(
		  ReimbursableFundsId
			)
);

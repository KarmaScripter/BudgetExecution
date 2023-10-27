CREATE TABLE IF NOT EXISTS FundSymbols
(
	FundSymbolsId
	INTEGER
	NOT
	NULL
	UNIQUE,
	BFY
	TEXT
(
	150
) NULL DEFAULT NS,
	EFY TEXT
(
	150
) NULL DEFAULT NS,
	FundCode TEXT
(
	150
) NULL DEFAULT NS,
	FundName TEXT
(
	150
) NULL DEFAULT NS,
	TreasuryAccountCode TEXT
(
	150
) NULL DEFAULT NS,
	TreasuryAccountName TEXT
(
	150
) NULL DEFAULT NS,
	BudgetAccountCode TEXT
(
	150
) NULL DEFAULT NS,
	BudgetAccountName TEXT
(
	150
) NULL DEFAULT NS,
	ApportionmentAccountCode TEXT
(
	150
) NULL DEFAULT NS,
	CONSTRAINT FundSymbolsPrimaryKey
	PRIMARY KEY
(
	FundSymbolsId
)
	);

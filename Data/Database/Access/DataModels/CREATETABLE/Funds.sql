CREATE TABLE Funds
(
	FundsId                       AUTOINCREMENT NOT NULL UNIQUE,
	BFY                           TEXT( 150 )   NULL DEFAULT NS,
	EFY                           TEXT( 150 )   NULL DEFAULT NS,
	Code                          TEXT( 150 )   NULL DEFAULT NS,
	Name                          TEXT( 150 )   NULL DEFAULT NS,
	ShortName                     TEXT( 150 )   NULL DEFAULT NS,
	Status                        TEXT( 150 )   NULL DEFAULT NS,
	StartDate                     TEXT( 150 )   NULL DEFAULT NS,
	EndDate                       TEXT( 150 )   NULL DEFAULT NS,
	SubLevelPrefix                TEXT( 150 )   NULL DEFAULT NS,
	AllocationTransferAgency      TEXT( 150 )   NULL DEFAULT NS,
	AgencyIdentifier              TEXT( 150 )   NULL DEFAULT NS,
	BeginningPeriodOfAvailability TEXT( 150 )   NULL DEFAULT NS,
	EndingPeriodOfAvailability    TEXT( 150 )   NULL DEFAULT NS,
	MultiyearIndicator            TEXT( 150 )   NULL DEFAULT NS,
	MainAccount                   TEXT( 150 )   NULL DEFAULT NS,
	SubAccount                    TEXT( 150 )   NULL DEFAULT NS,
	FundCategory                  TEXT( 150 )   NULL DEFAULT NS,
	AppropriationCode             TEXT( 150 )   NULL DEFAULT NS,
	SubAppropriationCode          TEXT( 150 )   NULL DEFAULT NS,
	FundGroup                     TEXT( 150 )   NULL DEFAULT NS,
	NoYear                        TEXT( 150 )   NULL DEFAULT NS,
	Carryover                     TEXT( 150 )   NULL DEFAULT NS,
	CanceledYearSpendingAccount   TEXT( 150 )   NULL DEFAULT NS,
	ApplyAtAllLevels              TEXT( 150 )   NULL DEFAULT NS,
	BatsFund                      TEXT( 150 )   NULL DEFAULT NS,
	BatsEndDate                   TEXT( 150 )   NULL DEFAULT NS,
	BatsOptionId                  TEXT( 150 )   NULL DEFAULT NS,
	SecurityOrg                   TEXT( 150 )   NULL DEFAULT NS,
	BudgetAccountCode             TEXT( 150 )   NULL DEFAULT NS,
	BudgetAccountName             TEXT( 150 )   NULL DEFAULT NS,
	TreasuryAccountCode           TEXT( 150 )   NULL DEFAULT NS,
	TreasuryAccountName           TEXT( 150 )   NULL DEFAULT NS,
	ApportionmentAccountCode      TEXT( 150 )   NULL DEFAULT NS, CONSTRAINT
(
	FundsPrimaryKey
)
	PRIMARY KEY
(
	FundsId
)
	);

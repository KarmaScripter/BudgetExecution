CREATE TABLE StateGrantObligations 
(
    StateGrantObligationsId AUTOINCREMENT NOT NULL UNIQUE,
    BFY TEXT(80) NULL DEFAULT NS,
    EFY TEXT(80) NULL DEFAULT NS,
    FundCode TEXT(80) NULL DEFAULT NS,
    FundName TEXT(80) NULL DEFAULT NS,
    RpioCode TEXT(80) NULL DEFAULT NS,
    RpioName TEXT(80) NULL DEFAULT NS,
    AhCode TEXT(80) NULL DEFAULT NS,
    AhName TEXT(80) NULL DEFAULT NS,
    OrgCode TEXT(80) NULL DEFAULT NS,
    OrgName TEXT(80) NULL DEFAULT NS,
    StateCode TEXT(80) NULL DEFAULT NS,
    StateName TEXT(80) NULL DEFAULT NS,
    AccountCode TEXT(80) NULL DEFAULT NS,
    ProgramProjectCode TEXT(80) NULL DEFAULT NS,
    ProgramProjectName TEXT(80) NULL DEFAULT NS,
    RcCode TEXT(80) NULL DEFAULT NS,
    RcName TEXT(80) NULL DEFAULT NS,
    BocCode TEXT(80) NULL DEFAULT NS,
    BocName TEXT(80) NULL DEFAULT NS,
    Amount DOUBLE NULL DEFAULT 0.0,
    AppropriationCode TEXT(80) NULL DEFAULT NS,
    AppropriationName TEXT(80) NULL DEFAULT NS,
	TreasuryAccountCode TEXT(80) NULL DEFAULT NS,
	TreasuryAccountName TEXT(255) NULL DEFAULT NS,
	BudgetAccountCode TEXT(80) NULL DEFAULT NS,
	BudgetAccountName TEXT(255) NULL DEFAULT NS,
    CONSTRAINT StateGrantObligationsPrimaryKey
        PRIMARY KEY(StateGrantObligationsId)
);
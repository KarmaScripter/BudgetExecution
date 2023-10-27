CREATE TABLE MainAccounts
(
	MainAccountsId    INTEGER     NOT NULL,
	Code              TEXT( 150 ) NULL DEFAULT NS,
	Name              TEXT( 150 ) NULL DEFAULT NS,
	BudgetAccountCode TEXT( 150 ) NULL DEFAULT NS,
	BudgetAccountName TEXT( 150 ) NULL DEFAULT NS,
	PRIMARY KEY ( MainAccountsId AUTOINCREMENT )
);
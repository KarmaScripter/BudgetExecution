/****** Object:  Table BudgetControls    Script Date: 10/7/2023 1:42:13 PM ******/

CREATE TABLE BudgetControls(
	BudgetControlsId INT NOT NULL UNIQUE,
	Code NVARCHAR(150) NULL DEFAULT ('NS'),
	Name NVARCHAR(150) NULL DEFAULT ('NS'),
	BudgetedTransType NVARCHAR(150) NULL DEFAULT ('NS'),
	PostedTransType NVARCHAR(150) NULL DEFAULT ('NS'),
	EstimatedReimbursementsTransType NVARCHAR(150) NULL DEFAULT ('NS'),
	SpendingAdjustmentTransType NVARCHAR(150) NULL DEFAULT ('NS'),
	EstimatedRecoveriesTransType NVARCHAR(150) NULL DEFAULT ('NS'),
	ActualRecoveriesTransType NVARCHAR(150) NULL DEFAULT ('NS'),
	StatusReserveTransType NVARCHAR(150) NULL DEFAULT ('NS'),
	ProfitLossTransType NVARCHAR(150) NULL DEFAULT ('NS'),
	EstimatedReimbursementsSpendingOption NVARCHAR(150) NULL DEFAULT ('NS'),
	EstimatedReimursementsBudgetingOption NVARCHAR(150) NULL DEFAULT ('NS'),
	TrackAgreementLowerLevel NVARCHAR(150) NULL DEFAULT ('NS'),
	BudgetEstimatedLowerLevel NVARCHAR(150) NULL DEFAULT ('NS'),
	EstimatedRecoveriesSpendingOption NVARCHAR(150) NULL DEFAULT ('NS'),
	EstimatedRecoveriesBudgetingOption NVARCHAR(150) NULL DEFAULT ('NS'),
	RecoveryNextLevel NVARCHAR(150) NULL DEFAULT ('NS'),
	RecoveryBudgetMismatch NVARCHAR(150) NULL DEFAULT ('NS'),
	ProfitLossSpendingOption NVARCHAR(150) NULL DEFAULT ('NS'),
	ProfitLossBudgetOption NVARCHAR(150) NULL DEFAULT ('NS'),
	RecoveriesCarryInLowerLevel NVARCHAR(150) NULL DEFAULT ('NS'),
	RecoveriesCarryInLowerLevelControl NVARCHAR(150) NULL DEFAULT ('NS'),
	RecoveriesCarryInAmountControl NVARCHAR(150) NULL DEFAULT ('NS'),
	BudgetedControl NVARCHAR(150) NULL DEFAULT ('NS'),
	PostedControl NVARCHAR(150) NULL DEFAULT ('NS'),
	PreCommitmentSpendingControl NVARCHAR(150) NULL DEFAULT ('NS'),
	CommitmentSpendingControl NVARCHAR(150) NULL DEFAULT ('NS'),
	ObligationSpendingControl NVARCHAR(150) NULL DEFAULT ('NS'),
	AccrualSpendingControl NVARCHAR(150) NULL DEFAULT ('NS'),
	ExpenditureSpendingControl NVARCHAR(150) NULL DEFAULT ('NS'),
	ExpenseSpendingControl NVARCHAR(150) NULL DEFAULT ('NS'),
	ReimbursableSpendingControl NVARCHAR(150) NULL DEFAULT ('NS'),
	ReimbursableAgreementSpendingControl NVARCHAR(150) NULL DEFAULT ('NS'),
	FteBudgetingControl NVARCHAR(150) NULL DEFAULT ('NS'),
	FteSpendingControl NVARCHAR(150) NULL DEFAULT ('NS'),
	TransactionTypeControl NVARCHAR(150) NULL DEFAULT ('NS'),
	AuthorityDistributionControl NVARCHAR(150) NULL DEFAULT ('NS'),
 CONSTRAINT BudgetControlsPrimaryKey PRIMARY KEY
(
	BudgetControlsId ASC
)
);

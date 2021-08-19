CREATE TABLE [DivisionExecution](
	[DivisionExecutionId] [int] NOT NULL IDENTITY(1,1),
	[BudgetLevel] [nvarchar](255) NULL,
	[RPIO] [nvarchar](255) NULL,
	[BFY] [nvarchar](255) NULL,
	[AhCode] [nvarchar](255) NULL,
	[FundCode] [nvarchar](255) NULL,
	[RcCode] [nvarchar](255) NULL,
	[DivisionName] [nvarchar](255) NULL,
	[FundName] [nvarchar](255) NULL,
	[OrgCode] [nvarchar](255) NULL,
	[AccountCode] [nvarchar](255) NULL,
	[ActivityCode] [nvarchar](255) NULL,
	[ProgramProjectCode] [nvarchar](255) NULL,
	[ProgramProjectName] [nvarchar](255) NULL,
	[BocCode] [nvarchar](255) NULL,
	[BocName] [nvarchar](255) NULL,
	[SiteProjectCode] [nvarchar](255) NULL,
	[Amount] [float] NULL,
	[OpenCommitments] [float] NULL,
	[CommitmentRatio] [float] NULL,
	[Obligations] [float] NULL,
	[ObligationRatio] [float] NULL,
	[Used] [float] NULL,
	[Utilization] [float] NULL,
	[Available] [money] NULL,
	[Availability] [float] NULL
);


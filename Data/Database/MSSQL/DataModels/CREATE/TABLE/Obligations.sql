CREATE TABLE [dbo].[Obligations]
(
	[ObligationId] [int] IDENTITY(1,1) NOT NULL,
	[BFY] [text] NULL,
	[EFY] [text] NULL,
	[RpioCode] [text] NULL,
	[RpioName] [text] NULL,
	[AhCode] [text] NULL,
	[AhName] [text] NULL,
	[FundCode] [text] NULL,
	[FundName] [text] NULL,
	[OrgCode] [text] NULL,
	[OrgName] [text] NULL,
	[AccountCode] [text] NULL,
	[ProgramProjectCode] [text] NULL,
	[ProgramProjectName] [text] NULL,
	[RcCode] [text] NULL,
	[RcName] [text] NULL,
	[DocumentType] [text] NULL,
	[DocumentNumber] [text] NULL,
	[DocumentControlNumber] [text] NULL,
	[ReferenceDocumentNumber] [text] NULL,
	[ProcessedDate] [date] NULL,
	[LastActivityDate] [date] NULL,
	[Age] [text] NULL,
	[BocCode] [text] NULL,
	[BocName] [text] NULL,
	[FocCode] [text] NULL,
	[FocName] [text] NULL,
	[NpmCode] [text] NULL,
	[NpmName] [text] NULL,
	[VendorCode] [text] NULL,
	[VendorName] [text] NULL,
	[OpenCommitments] [float] NULL,
	[Obligations] [float] NULL,
	[ULO] [float] NULL,
	[Expenditures] [float] NULL
);


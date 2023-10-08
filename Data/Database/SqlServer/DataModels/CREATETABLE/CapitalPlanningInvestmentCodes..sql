/****** Object:  Table CapitalPlanningInvestmentCodes    Script Date: 10/7/2023 1:42:13 PM ******/

CREATE TABLE CapitalPlanningInvestmentCodes(
	CapitalPlanningInvestmentCodesId INT NOT NULL UNIQUE,
	Type NVARCHAR(150) NULL DEFAULT ('NS'),
	Code NVARCHAR(150) NULL DEFAULT ('NS'),
	Name NVARCHAR(150) NULL DEFAULT ('NS'),
 CONSTRAINT CapitalPlanningInvestmentCodesPrimaryKey PRIMARY KEY
(
	CapitalPlanningInvestmentCodesId ASC
)
);

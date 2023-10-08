/****** Object:  Table BudgetObjectClasses    Script Date: 10/7/2023 1:42:13 PM ******/

CREATE TABLE BudgetObjectClasses
(
	BudgetObjectClassesId INT NOT NULL UNIQUE,
	Code NVARCHAR(150) NULL DEFAULT ('NS'),
	Name NVARCHAR(150) NULL DEFAULT ('NS'),
	CONSTRAINT BudgetObjectClassesPrimaryKey PRIMARY KEY
	(
		BudgetObjectClassesId ASC
	)
);

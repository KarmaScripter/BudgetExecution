CREATE TABLE PayPeriods  
(
	 PayPeriodsId INT NOT NULL IDENTITY(1,1),
	 Period NVARCHAR(80) NULL,
	 PayPeriod NVARCHAR(80) NULL,
	 StartDate NVARCHAR(80) NULL,
	 EndDate NVARCHAR(80) NULL
);
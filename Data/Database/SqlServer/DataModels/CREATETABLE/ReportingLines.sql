CREATE TABLE ReportingLines
(
	ReportingLinesId INT           NOT NULL UNIQUE,
	Number           NVARCHAR(150) NULL DEFAULT ('NS'),
	Name             NVARCHAR(150) NULL DEFAULT ('NS'),
	Caption          NVARCHAR(150) NULL DEFAULT ('NS'),
	Category         NVARCHAR(150) NULL DEFAULT ('NS'),
	Range            NVARCHAR(150) NULL DEFAULT ('NS'),
	CONSTRAINT ReportingLinesPrimaryKey PRIMARY KEY
		(
		  ReportingLinesId ASC
			)
);

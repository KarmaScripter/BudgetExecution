/****** Object:  Table Documents    Script Date: 10/7/2023 1:42:13 PM ******/

CREATE TABLE Documents(
	DocumentsId INT NOT NULL UNIQUE,
	Code NVARCHAR(150) NULL DEFAULT ('NS'),
	Category NVARCHAR(150) NULL DEFAULT ('NS'),
	Name NVARCHAR(150) NULL DEFAULT ('NS'),
	System NVARCHAR(150) NULL DEFAULT ('NS'),
 CONSTRAINT DocumentsPrimaryKey PRIMARY KEY
(
	DocumentsId ASC
)
);

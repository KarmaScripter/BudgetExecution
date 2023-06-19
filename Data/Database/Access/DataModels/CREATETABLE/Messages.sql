CREATE TABLE Messages
(
	MessagesId AUTOINCREMENT NOT NULL UNIQUE,
	Content NVARCHAR(255) NULL,
	Type TEXT(80) NULL,
	Form TEXT(80) NULL,
    CONSTRAINT MessagesPrimaryKey 
        PRIMARY KEY(MessagesId)
);

CREATE TABLE [Details]
(
    [DetailId]        INT     IDENTITY(1, 1)  NOT NULL,
    [DetailName]      NVARCHAR(50)            NOT NULL,
    
    CONSTRAINT  [PK_Detail] PRIMARY KEY CLUSTERED([DetailId] ASC),
);
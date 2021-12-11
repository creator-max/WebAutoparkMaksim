CREATE TABLE [OrderElements]
(
    [OrderElementId]  INT     IDENTITY(1, 1)  NOT NULL,
    [OrderId]         INT                     NOT NULL,
    [DetailId]        INT                     NOT NULL,
    [Quantity]        INT                     NOT NULL,
    
    CONSTRAINT  [PK_OrderElements] PRIMARY KEY CLUSTERED([OrderElementId] ASC),
    CONSTRAINT  [FK_OrderElements_Orders] FOREIGN KEY([OrderId]) REFERENCES [Orders]([OrderId]) ON DELETE CASCADE,
    CONSTRAINT  [FK_OrderElements_Detail] FOREIGN KEY([DetailId]) REFERENCES [Details]([DetailId]) ON DELETE CASCADE,
);
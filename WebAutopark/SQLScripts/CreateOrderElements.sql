CREATE TABLE [OrdersElements]
(
    [OrderElementId]  INT     IDENTITY(1, 1)  NOT NULL,
    [OrderId]         INT                     NOT NULL,
    [DetailId]        INT                     NOT NULL,
    [Quantity]        INT                     NOT NULL,
    
    CONSTRAINT  [PK_OrdersElements] PRIMARY KEY CLUSTERED([OrderElementId] ASC),
    CONSTRAINT  [FK_OrdersElements_Orders] FOREIGN KEY([OrderId]) REFERENCES [Orders]([OrderId]) ON DELETE CASCADE,
    CONSTRAINT  [FK_OrdersElements_Detail] FOREIGN KEY([DetailId]) REFERENCES [Details]([DetailId]) ON DELETE CASCADE,
);
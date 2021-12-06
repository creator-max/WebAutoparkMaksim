CREATE TABLE [Orders]
(
    [OrderId]         INT     IDENTITY(1, 1)  NOT NULL,
    [VehicleId]       INT                     NOT NULL,
    
    CONSTRAINT  [PK_Orders] PRIMARY KEY CLUSTERED([OrderId] ASC),
    CONSTRAINT  [FK_Orders_Vehicles] FOREIGN KEY([VehicleId]) REFERENCES [Vehicles]([VehicleId]) ON DELETE CASCADE
);
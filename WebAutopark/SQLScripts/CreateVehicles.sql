CREATE TABLE [Vehicles]
(
    [VehicleId]       INT     IDENTITY(1, 1)  NOT NULL,
    [VehicleTypeId]   INT                     NOT NULL,
    [Model]           NVARCHAR(50)            NOT NULL,
    [YearOfIssue]     INT                     NOT NULL,
    [Weight]          FLOAT(53)               NOT NULL,
    [TankCapacity]    FLOAT(53)               NOT NULL,
    [LicensePlat]     NVARCHAR(10)            NOT NULL,
    [MileageKm]       FLOAT(53)               NOT NULL,
    [Color]           INT                     NOT NULL,
    
    CONSTRAINT  [PK_Vehicles] PRIMARY KEY CLUSTERED([VehicleId] ASC),
    CONSTRAINT  [FK_Vehicles_VehicleType] FOREIGN KEY([VehicleTypeId]) REFERENCES [VehicleTypes]([TypeId]) ON DELETE CASCADE
);
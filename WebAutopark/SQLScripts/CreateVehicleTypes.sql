CREATE TABLE [VehicleTypes]
(
    [TypeId]          INT     IDENTITY(1, 1)  NOT NULL,
    [TypeName]        NVARCHAR(50)            NOT NULL,
    [TaxCoefficient]  FLOAT(53)               NOT NULL,
    
    CONSTRAINT  [PK_VehicleTypes] PRIMARY KEY CLUSTERED([TypeId] ASC)
);
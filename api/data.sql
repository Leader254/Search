-- Add sample data to the PartsSerial table
INSERT INTO [dbo].[PartsSerial] ([Id], [Name], [PartNum], [Company], [PartDescription], [SerialNumber], [SNStatus], [CustID])
VALUES 
    (NEWID(), 'Alternator', 'ALT1001', 'Bosch', 'High-efficiency alternator', 'ALT-SN001', 'ADJUSTED', 'CUST001'),
    (NEWID(), 'Battery', 'BAT1002', 'Panasonic', 'Long-lasting car battery', 'BAT-SN002', 'CONSUMED', 'CUST002'),
    (NEWID(), 'Brake Pad', 'BP1003', 'Brembo', 'Ceramic brake pad set', 'BP-SN003', 'DMR', 'CUST003'),
    (NEWID(), 'Fuel Injector', 'FI1004', 'Denso', 'Precision fuel injector', 'FI-SN004', 'INSPECTION', 'CUST004'),
    (NEWID(), 'Spark Plug', 'SP1005', 'NGK', 'Iridium spark plug', 'SP-SN005', 'INVENTORY', 'CUST005'),
    (NEWID(), 'Oil Filter', 'OF1006', 'Mann-Filter', 'High-capacity oil filter', 'OF-SN006', 'MISC-ISSUE', 'CUST006'),
    (NEWID(), 'Air Filter', 'AF1007', 'K&N', 'Reusable air filter', 'AF-SN007', 'PACKED', 'CUST007'),
    (NEWID(), 'Timing Belt', 'TB1008', 'Gates', 'Reinforced timing belt', 'TB-SN008', 'REJECTED', 'CUST008'),
    (NEWID(), 'Water Pump', 'WP1009', 'Aisin', 'High-flow water pump', 'WP-SN009', 'RMA-ENTRY', 'CUST009'),
    (NEWID(), 'Headlight', 'HL1010', 'Philips', 'LED headlight bulb', 'HL-SN010', 'SHIPPED', 'CUST010'),
    (NEWID(), 'Radiator', 'RAD1011', 'Behr', 'High-efficiency radiator', 'RAD-SN011', 'SUBSHIPPED', 'CUST011'),
    (NEWID(), 'Clutch Kit', 'CK1012', 'Sachs', 'Performance clutch kit', 'CK-SN012', 'WIP', 'CUST012');
GO
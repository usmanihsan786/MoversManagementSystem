
IF Not Exists (Select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'MovingQuotes')
begin
Create table MovingQuotes
( QuoteId int Primary Key IDENTITY (1,1),
    FullName VARCHAR(100),
    Email VARCHAR(100),
    Phone VARCHAR(20),
    MovingFrom VARCHAR(255),
    MovingTo VARCHAR(255),
    Comments VARCHAR(255),
    MovingDate Date
);
End

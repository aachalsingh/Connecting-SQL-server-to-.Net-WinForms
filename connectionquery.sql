CREATE TABLE DataConnection (Id int not null identity(1,1), FirstName varchar(20), LastName varchar(20))

SELECT * FROM DataConnection;

INSERT INTO DataConnection (FirstName, LastName) values ('Aachal','Singh');

UPDATE DataConnection SET FirstName = 'Taylor' WHERE id = 1;

SELECT * FROM DataConnection WHERE Id = 1;
USE barbershop

CREATE TABLE Barbers (
[ID] INT PRIMARY KEY,
[FullName] VARCHAR(255),
[Gender] VARCHAR(10),
[Phone] VARCHAR(20),
[Mail] VARCHAR(255),
[DateOfBirthday] DATE,
[HiteDay] DATE,
[Position] VARCHAR(20)
);


CREATE TABLE Clients (
[ID] INT PRIMARY KEY,
[FullName] VARCHAR(255),
[Phone] VARCHAR(20),
[Mail] VARCHAR(255),
[FeedBack] VARCHAR(255),
[Rating] VARCHAR(20)
);

CREATE TABLE FeedBacks (
[ID] INT PRIMARY KEY,
[BarberID] INT,
[ClientID] INT,
[FeedBack] VARCHAR(255),
[rating] VARCHAR(20),
FOREIGN KEY ([BarberID]) REFERENCES Barbers(id),
FOREIGN KEY ([ClientID]) REFERENCES Clients(id)
);


CREATE TABLE Schedules (
[ID] INT PRIMARY KEY,
[BarberID] INT,
[DataAvailable] DATE,
[TimeAvailable] TIME,
FOREIGN KEY ([BarberID]) REFERENCES Barbers(id)
);


CREATE TABLE appointments (
[ID] INT PRIMARY KEY,
[BarberID] INT,
[ClientID] INT,
[DataBooked] DATE,
[TimeBooked] TIME,
FOREIGN KEY ([BarberID]) REFERENCES Barbers(id),
FOREIGN KEY ([ClientID]) REFERENCES Clients(id)
);




CREATE TABLE visit_history (
[ID] INT PRIMARY KEY,
[ClientID] INT,
[BarberID] INT,
[ServiceID] INT,
[DateVisited] DATE,
[TotalCost] DECIMAL(10,2),
[Raiting] VARCHAR(20),
[FeedBack] VARCHAR(255),
FOREIGN KEY ([ClientID]) REFERENCES Clients(id),
FOREIGN KEY ([BarberID]) REFERENCES Barbers(id),
FOREIGN KEY ([ServiceID]) REFERENCES services(id)
);

GO
CREATE FUNCTION GetBarbers()
RETURNS TABLE
AS RETURN (SELECT FirstName, LastName, MiddleName FROM Barbers)
GO

GO
CREATE FUNCTION GetSeniorBarbers()
RETURNS TABLE
AS RETURN (SELECT * FROM Barbers WHERE Position = 'Senior')
GO

GO
CREATE FUNCTION GetBarbersForTraditionalBeardShave()
RETURNS TABLE
AS RETURN (SELECT * FROM Barbers WHERE TraditionalBeardShave = 1)
GO

GO
CREATE FUNCTION GetBarbersForService(@service NVARCHAR(50))
RETURNS TABLE
AS RETURN (SELECT * FROM Barbers WHERE [Service] = @service)
GO

GO
CREATE FUNCTION GetBarbersByExperience(@years INT)
RETURNS TABLE
AS RETURN (SELECT * FROM Barbers WHERE DATEDIFF(year, HireDate, GETDATE()) >= @years)
GO

GO
CREATE PROCEDURE GetBarberCountByPosition
AS
BEGIN
    SELECT COUNT(*) AS JuniorBarberCount FROM Barbers WHERE Position = 'Junior'
    SELECT COUNT(*) AS SeniorBarberCount FROM Barbers WHERE Position = 'Senior'
END
GO

GO
CREATE PROCEDURE GetFrequentCustomers(@visits INT)
AS
BEGIN
    SELECT FirstName, LastName, MiddleName, Phone, Email FROM Customers
    WHERE (SELECT COUNT(*) FROM Appointments WHERE Appointments.CustomerId = Customers.Id) >= @visits
END
GO

GO
CREATE TRIGGER PreventChiefBarberDelete ON Barbers
FOR DELETE
AS
IF (SELECT COUNT(*) FROM Barbers WHERE Position = 'Chief') < 2
BEGIN
    RAISERROR('Cannot delete chief barber. There must be at least two chief barbers.', 16, 1)
    ROLLBACK TRANSACTION
END
GO

GO
CREATE TRIGGER usl_2
ON Читатели
FOR INSERT, UPDATE
AS
IF EXISTS(
SELECT Дата_рождения
FROM INSERTED
WHERE DATEDIFF (year, Дата_рождения, GETDATE())<17
)
ROLLBACK TRAN;
GO
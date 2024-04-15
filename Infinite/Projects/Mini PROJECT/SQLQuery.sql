create database TrainDB;
use TrainDB;

-------------------------Creating Tables-------------------------------------
--Trains Table


CREATE TABLE Trains (
    Train_no INT,
    Train_name VARCHAR(50),
    Class VARCHAR(10),
    Total_Berths INT,
    Available_Berths INT,
    Source_loc VARCHAR(50),
    Destination VARCHAR(50),
    Date_of_Travel DATE,
    Fare INT,
    Train_Status VARCHAR(10) NOT NULL,
    PRIMARY KEY (Train_no, Class));

INSERT INTO Trains VALUES
(12658, 'Chennai Mail', '1stAC', 70, 70, 'Bangalore', 'Chennai', '2024-05-11', 900, 'Active'),
(12658, 'Chennai Mail', '2ndAC', 150, 150, 'Bangalore', 'Chennai', '2024-05-11', 750, 'Active'),
(12658, 'Chennai Mail', 'SL', 300, 300, 'Bangalore', 'Chennai', '2024-05-11', 450, 'Active'),
(12677, 'Ernakulam Exp', '1stAC', 70, 70, 'Bangalore', 'Ernakulam Jn', '2024-05-20', 1000, 'Active'),
(12677, 'Ernakulam Exp', '2ndAC', 80, 80, 'Bangalore', 'Ernakulam Jn', '2024-05-20', 800, 'Active'),
(12677, 'Ernakulam Exp', 'SL', 200, 200, 'Bangalore', 'Ernakulam Jn', '2024-05-20', 350, 'Active'),
(12723, 'Rajdhani Exp', '1stAC', 60, 60, 'Howrah Jn', 'New Delhi', '2024-05-18', 2000, 'Active'),
(12723, 'Rajdhani Exp', '2ndAC', 160, 160, 'Howrah Jn', 'New Delhi', '2024-05-18', 1400, 'Active'),
(12723, 'Rajdhani Exp', 'SL', 280, 280, 'Howrah Jn', 'New Delhi', '2024-05-18', 800, 'Active');

--Booking Table

CREATE TABLE Booking_Data (
    Book_ID INT IDENTITY(100,1) PRIMARY KEY,
    UserName VARCHAR(30),
    Train_no INT,
    Class VARCHAR(10),
    Booking_Date DATE,
    No_of_Tickets INT,
    Total_Fare INT,
    FOREIGN KEY (Train_no,Class) REFERENCES Trains (Train_no, Class));

--Cancellation Table

CREATE TABLE Cancellation_Data (
    Canc_ID INT IDENTITY(200,1) PRIMARY KEY,
    Book_ID INT,
    UserName VARCHAR(30),
    Train_no INT,
    Canc_Date DATE,
    No_tickets_Canc INT,
    Refund_Amount INT,
    FOREIGN KEY (Book_ID) REFERENCES Booking_Data (Book_ID));



--------------------------------------Stored Procedures SQL-------------------------------------------

--1. Procedure to Add Trains from Admin Menu

CREATE PROCEDURE AddTrain
    @TrainNo INT,
    @TrainName VARCHAR(50),
    @Class VARCHAR(10),
    @TotalBerths INT,
    @AvailableBerths INT,
    @Source VARCHAR(50),
    @Destination VARCHAR(50),
    @DateOfTravel DATE = NULL, 
    @Fare INT, 
    @TrainStatus VARCHAR(10) = 'Active'
AS
BEGIN
    INSERT INTO Trains (Train_no, Train_name, Class, Total_Berths, Available_Berths, Source_loc, Destination, Date_of_Travel, Fare, Train_Status)
    VALUES (@TrainNo, @TrainName, @Class, @TotalBerths, @AvailableBerths, @Source, @Destination, @DateOfTravel, @Fare, @TrainStatus);
END

------------------------------------------------------------------------------------------

--2. Procedure to Modify Trains from Admin Menu

CREATE PROCEDURE ModifyTrain
    @TrainNo INT,
    @TrainName VARCHAR(50) = NULL,
    @Class VARCHAR(10) = NULL,
    @TotalBerths INT = NULL,
    @AvailableBerths INT = NULL,
    @Source NVARCHAR(100) = NULL,
    @Destination NVARCHAR(100) = NULL,
    @DateOfTravel DATE = NULL,
    @Fare INT = NULL,
    @TrainStatus VARCHAR(10) = NULL
AS
BEGIN
    UPDATE Trains
    SET Train_name = COALESCE(@TrainName, Train_name),
        Class = COALESCE(@Class, Class),
        Total_Berths = COALESCE(@TotalBerths, Total_Berths),
        Available_Berths = COALESCE(@AvailableBerths, Available_Berths),
        Source_loc = COALESCE(@Source, Source_loc),
        Destination = COALESCE(@Destination, Destination),
        Date_of_Travel = COALESCE(@DateOfTravel, Date_of_Travel),
        Fare = COALESCE(@Fare, Fare),
        Train_Status = COALESCE(@TrainStatus, Train_Status)
    WHERE Train_no = @TrainNo;
END

---------------------------------------------------------------------------------------------------

--3. Procedure to Delete Train

CREATE PROCEDURE DeleteTrain
    @TrainNo INT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Trains WHERE Train_no = @TrainNo AND Train_Status = 'Active')
    BEGIN
        UPDATE Trains
        SET Train_Status = 'Not Active'
        WHERE Train_no = @TrainNo;
    END
END

--------------------------------------------------------------------------------------------------------

--4. Procedure to book train ticket

CREATE PROCEDURE BookTrainTicket
    @UserName NVARCHAR(30),
    @TrainNo INT,
    @Class NVARCHAR(10),
    @NumTickets INT
AS
BEGIN
    DECLARE @AvailableBerths INT;
    DECLARE @Fare INT;

    SELECT @AvailableBerths = Available_Berths,
           @Fare = Fare
    FROM Trains
    WHERE Train_no = @TrainNo AND Class = @Class;

    IF @AvailableBerths >= @NumTickets
    BEGIN
        DECLARE @TotalFare INT;
        SET @TotalFare = @NumTickets * @Fare;

        UPDATE Trains
        SET Available_Berths = Available_Berths - @NumTickets
        WHERE Train_no = @TrainNo AND Class = @Class;

        INSERT INTO Booking_Data (UserName, Train_no, Class, Booking_Date, No_of_Tickets, Total_Fare)
        VALUES (@UserName, @TrainNo, @Class, GETDATE(), @NumTickets, @TotalFare);

        SELECT Train_no, Source_loc, Destination, @TotalFare AS Total_Fare
        FROM Trains
        WHERE Train_no = @TrainNo;
    END
    ELSE
    BEGIN
        PRINT 'Sorry, Tickets not Available.';
    END
END

---------------------------------------------------------------------------------------------------------------

--5. Procedure to Cancel Ticket

CREATE PROCEDURE CancelTrainTicket
    @UserName VARCHAR(30),
    @TrainNo INT,
    @NumTicketsToCancel INT
AS
BEGIN
    DECLARE @BookingID INT;
    DECLARE @RefundAmount INT;

    SELECT @BookingID = Book_ID
    FROM Booking_Data
    WHERE UserName = @UserName AND Train_no = @TrainNo;

    IF @BookingID IS NOT NULL
    BEGIN
        DECLARE @Counter INT;
        SET @Counter = 0;

        WHILE @Counter < @NumTicketsToCancel
        BEGIN
            DECLARE @CancDate DATE = GETDATE();
            SELECT @RefundAmount = Total_Fare - (SELECT Fare * @NumTicketsToCancel FROM Trains WHERE Train_no = @TrainNo AND Class = (SELECT Class FROM Booking_Data WHERE Book_ID = @BookingID))
            FROM Booking_Data
            WHERE Book_ID = @BookingID;

            INSERT INTO Cancellation_Data (Book_ID, UserName, Train_no, Canc_Date, No_tickets_Canc, Refund_Amount)
            VALUES (@BookingID, @UserName, @TrainNo, @CancDate, @NumTicketsToCancel, @RefundAmount);

            UPDATE Trains
            SET Available_Berths = Available_Berths + @NumTicketsToCancel
            WHERE Train_no = @TrainNo;

            SET @Counter = @Counter + 1;
        END

        SELECT Train_no, Source_loc, Destination, @RefundAmount AS Refund_Amount
        FROM Trains
        WHERE Train_no = @TrainNo;

        PRINT 'Your Ticket(s) have been cancelled successfully.';
    END
    ELSE
    BEGIN
        PRINT 'Ticket not Found!';
    END
END

---------------------------------------------------------------------------------------------------

--Select commands

select*from Trains
select*from Booking_Data
select*from Cancellation_Data

----------------------------------------------The END-----------------------------------------------

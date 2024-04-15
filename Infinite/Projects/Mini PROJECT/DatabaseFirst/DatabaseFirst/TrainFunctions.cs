using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace DatabaseFirst
{
    class TrainFunctions
    {
        public TrainDBEntities dbContext;

        public TrainFunctions(TrainDBEntities context)
        {
            dbContext = context;
        }
        public void AddTrain(Train train)
        {
            dbContext.Database.ExecuteSqlCommand("EXEC AddTrain @TrainNo, @TrainName, @Class, @TotalBerths, @AvailableBerths, @Source, @Destination, @DateOfTravel, @Fare, @TrainStatus",
                new SqlParameter("@TrainNo", train.Train_no),
                new SqlParameter("@TrainName", train.Train_name),
                new SqlParameter("@Class", train.Class),
                new SqlParameter("@TotalBerths", train.Total_Berths),
                new SqlParameter("@AvailableBerths", train.Available_Berths),
                new SqlParameter("@Source", train.Source_loc),
                new SqlParameter("@Destination", train.Destination),
                new SqlParameter("@DateOfTravel", train.Date_of_Travel),
                new SqlParameter("@Fare", train.Fare), // Add parameter for Fare
                new SqlParameter("@TrainStatus", train.Train_Status)); // Add parameter for TrainStatus
        }


        public void ModifyTrain(int trainNo, string trainName = null, string trainClass = null, int? totalBerths = null, int? availableBerths = null, string source = null, string destination = null, DateTime? dateOfTravel = null, int? fare = null, string trainStatus = null)
        {
            dbContext.Database.ExecuteSqlCommand("EXEC ModifyTrain @TrainNo, @TrainName, @Class, @TotalBerths, @AvailableBerths, @Source, @Destination, @DateOfTravel, @Fare, @TrainStatus",
                new SqlParameter("@TrainNo", trainNo),
                new SqlParameter("@TrainName", trainName ?? (object)DBNull.Value),
                new SqlParameter("@Class", trainClass ?? (object)DBNull.Value),
                new SqlParameter("@TotalBerths", totalBerths ?? (object)DBNull.Value),
                new SqlParameter("@AvailableBerths", availableBerths ?? (object)DBNull.Value),
                new SqlParameter("@Source", source ?? (object)DBNull.Value),
                new SqlParameter("@Destination", destination ?? (object)DBNull.Value),
                new SqlParameter("@DateOfTravel", dateOfTravel ?? (object)DBNull.Value),
                new SqlParameter("@Fare", fare ?? (object)DBNull.Value),
                new SqlParameter("@TrainStatus", trainStatus ?? (object)DBNull.Value));
        }


        public void DeleteTrain(int trainNo)
        {
            dbContext.Database.ExecuteSqlCommand("EXEC DeleteTrain @TrainNo",
                new SqlParameter("@TrainNo", trainNo));
        }


        public List<Train> GetAllTrains()
        {
            return dbContext.Trains.ToList();
        }

        public TicketDetails BookTicket(string userName, int trainNo, string trainClass, int numTickets)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@UserName", userName),
                new SqlParameter("@TrainNo", trainNo),
                new SqlParameter("@Class", trainClass),
                new SqlParameter("@NumTickets", numTickets)
            };

            var ticketDetails = dbContext.Database.SqlQuery<TicketDetails>(
                "EXEC BookTrainTicket @UserName, @TrainNo, @Class, @NumTickets",
                parameters
            ).FirstOrDefault();

            return ticketDetails;
        }


        public TicketDetails CancelTicket(string userName, int trainNo, int numTicketsToCancel)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@UserName", userName),
                new SqlParameter("@TrainNo", trainNo),
                new SqlParameter("@NumTicketsToCancel", numTicketsToCancel)
            };

            var ticketDetails = dbContext.Database.SqlQuery<TicketDetails>(
                "EXEC CancelTrainTicket @UserName, @TrainNo, @NumTicketsToCancel",
                parameters
            ).FirstOrDefault();

            return ticketDetails;
        }


    }
}

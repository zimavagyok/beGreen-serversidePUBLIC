using beGreen.Model.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using beGreen.Infrastructure.repository;
using System.Threading.Tasks;

namespace beGreen.Repositories
{
    public class AuditRepository : IAuditRepository
    {
        public async Task<bool> Create(LoggedDeviceEntity entity)
        {
            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "LoginDeviceHistoryCreate";

                command.Parameters.Add(new SqlParameter("@UserID", entity.ProfileID));
                command.Parameters.Add(new SqlParameter("@DeviceID", entity.DeviceID));

                connection.Open();
                int result = (int)command.ExecuteNonQuery();

                return result == 1 ? true : false;
            }
        }
        public bool Delete(string uniq)
        {
            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "LoginDeviceHistoryDelete";

                command.Parameters.Add(new SqlParameter("@PublicID", uniq));

                connection.Open();
                int result = (int)command.ExecuteNonQuery();

                return result == 1 ? true : false;
            }
        }
        private LoggedDeviceEntity MapEntity(SqlDataReader data)
        {
            LoggedDeviceEntity result = new LoggedDeviceEntity();

            result.Id = int.Parse(data["Id"].ToString());
            result.ProfileID = data["PublicID"].ToString();
            result.DeviceID = data["DeviceID"].ToString();
            result.Date = DateTime.Parse(data["Date"].ToString());

            return result;
        }
        public LoggedDeviceEntity GetByID(string uniq)
        {
            LoggedDeviceEntity result = null;

            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "LoginDeviceHistoryFindByID";

                command.Parameters.Add(new SqlParameter("@PublicID", uniq));

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result = MapEntity(reader);
                    }
                }
            }

            return result;
        }

        public List<LoggedDeviceEntity> GetAll()
        {
            List<LoggedDeviceEntity> result = new List<LoggedDeviceEntity>();

            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "LoginDeviceHistoryGetAll";

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(MapEntity(reader));
                    }
                }
            }

            return result;
        }
        public List<LoggedDeviceEntity> GetAll(string uniq)
        {
            List<LoggedDeviceEntity> result = new List<LoggedDeviceEntity>();

            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "LoginDeviceHistoryGetAllForUser";

                command.Parameters.Add(new SqlParameter("@PublicID", uniq));

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(MapEntity(reader));
                    }
                }
            }

            return result;
        }
    }
}

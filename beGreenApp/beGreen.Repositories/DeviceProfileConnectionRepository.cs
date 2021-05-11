using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using beGreen.Model.Entity;
using beGreen.Infrastructure.repository;

namespace beGreen.Repositories
{
    public class DeviceProfileConnectionRepository : IDeviceProfileConnectionRepository
    {
        public DeviceProfileConnection Create(DeviceProfileConnection entity)
        {
            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "DeviceProfileConCreate";

                command.Parameters.Add(new SqlParameter("@DeviceID", entity.DeviceID));
                command.Parameters.Add(new SqlParameter("@ProfileID", entity.ProfileID));

                connection.Open();
                int result = (int)command.ExecuteNonQuery();
                if (result < 1)
                {
                    throw new Exception("Error in CreateDevice stored procedure.");
                }

                return entity;
            }
        }

        public bool DeleteByDevice(string device)
        {
            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "DeviceProfileConDeleteByDevice";

                command.Parameters.Add(new SqlParameter("@DeviceID", device));

                connection.Open();
                int result = (int)command.ExecuteNonQuery();
                return result == 1 ? true : false;
            }
        }

        public bool DeleteByProfile(string profile)
        {
            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "DeviceProfileConDeleteByProfile";

                command.Parameters.Add(new SqlParameter("@ProfileID", profile));

                connection.Open();
                int result = (int)command.ExecuteNonQuery();
                return result == 1 ? true : false;
            }
        }

        private DeviceProfileConnection Mapentity(SqlDataReader data)
        {
            DeviceProfileConnection result = new DeviceProfileConnection();

            result.DeviceID = data["DeviceID"].ToString();
            result.ProfileID = data["ProfileID"].ToString();

            return result;
        }

        public List<DeviceProfileConnection> GetAll()
        {
            List<DeviceProfileConnection> result = new List<DeviceProfileConnection>();

            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "DeviceProfileConGetAll";

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(Mapentity(reader));
                    }
                }
            }

            return result;
        }

        public List<DeviceProfileConnection> GetByDevice(string device)
        {
            List<DeviceProfileConnection> result = new List<DeviceProfileConnection>();

            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "DeviceProfileConFindByDevice";

                command.Parameters.Add(new SqlParameter("@DeviceID", device));

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(Mapentity(reader));
                    }
                }
            }

            return result;
        }

        public DeviceProfileConnection GetByBoth(DeviceProfileConnection device)
        {
            DeviceProfileConnection result = new DeviceProfileConnection();

            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "DeviceProfileConFindByBoth";

                command.Parameters.Add(new SqlParameter("@DeviceID", device.DeviceID));
                command.Parameters.Add(new SqlParameter("@ProfileID", device.ProfileID));

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result = Mapentity(reader);
                    }
                }
            }

            return result;
        }

        public List<DeviceProfileConnection> GetByProfile(string profile)
        {
            List<DeviceProfileConnection> result = new List<DeviceProfileConnection>();

            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "DeviceProfileConFindByProfile";

                command.Parameters.Add(new SqlParameter("@ProfileID", profile));

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(Mapentity(reader));
                    }
                }
            }

            return result;
        }
    }
}

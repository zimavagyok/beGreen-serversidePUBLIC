using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using beGreen.Model.Entity;
using System.Data;
using beGreen.Model.Response;
using beGreen.Infrastructure.repository;

namespace beGreen.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        public Device Create(Device entity)
        {
            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "DeviceCreate";

                command.Parameters.Add(new SqlParameter("@Id", entity.Id));
                command.Parameters.Add(new SqlParameter("@ManufacturerID", entity.ManufacturerID));
                command.Parameters.Add(new SqlParameter("@ScreenSize", entity.ScreenSize));
                command.Parameters.Add(new SqlParameter("@Model", entity.Model));
                command.Parameters.Add(new SqlParameter("@OperatingSystem", entity.OperatingSystem));
                command.Parameters.Add(new SqlParameter("@Ram", entity.Ram));

                connection.Open();
                int result = (int)command.ExecuteNonQuery();
                if(result<1)
                {
                    throw new Exception("Error in CreateDevice stored procedure.");
                }

                return entity;
            }
        }

        public Device Update(Device entity)
        {
            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "DeviceUpdate";

                command.Parameters.Add(new SqlParameter("@Id", entity.Id));
                command.Parameters.Add(new SqlParameter("@ManufacturerID", entity.ManufacturerID));
                command.Parameters.Add(new SqlParameter("@ScreenSize", entity.ScreenSize));
                command.Parameters.Add(new SqlParameter("@Model", entity.Model));
                command.Parameters.Add(new SqlParameter("@OperatingSystem", entity.OperatingSystem));
                command.Parameters.Add(new SqlParameter("@Ram", entity.Ram));

                connection.Open();
                int result = (int)command.ExecuteNonQuery();

                if(result<1)
                {
                    throw new Exception("Error in UpdateDevice stored procedure.");
                }

                return entity;
            }
        }

        public bool Delete(string id)
        {
            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "DeviceDelete";

                command.Parameters.Add(new SqlParameter("@Id", id));

                connection.Open();
                int result = (int)command.ExecuteNonQuery();
                return result == 1 ? true : false;
            }
        }

        private Device Mapentity(SqlDataReader data)
        {
            Device result = new Device();

            result.Id = data["Id"].ToString();
            result.ManufacturerID = int.Parse(data["ManufacturerID"].ToString());
            result.ScreenSize = double.Parse(data["ScreenSize"].ToString());
            result.Model = data["Model"].ToString();
            result.OperatingSystem = data["OperatingSystem"].ToString();
            result.Ram = int.Parse(data["Ram"].ToString());

            return result;
        }

        private DeviceResponse MapResponsel(SqlDataReader data)
        {
            DeviceResponse result = new DeviceResponse();

            result.Id = data["Id"].ToString();
            result.ManufacturerID = int.Parse(data["ManufacturerID"].ToString());
            result.ScreenSize = double.Parse(data["ScreenSize"].ToString());
            result.Model = data["Model"].ToString();
            result.OperatingSystem = data["OperatingSystem"].ToString();
            result.Ram = int.Parse(data["Ram"].ToString());
            result.Manufacturer = data["Manufacturer"].ToString();

            return result;
        }

        public DeviceResponse GetByID(string id)
        {
            DeviceResponse result = null;

            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "DeviceGetByID";

                command.Parameters.Add(new SqlParameter("@Id", id));

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result = MapResponsel(reader);
                    }
                }
            }

            return result;
        }

        public List<DeviceResponse> GetAll()
        {
            List<DeviceResponse> result = new List<DeviceResponse>();

            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "DeviceGetAll";

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(MapResponsel(reader));
                    }
                }
            }

            return result;
        }


    }
}

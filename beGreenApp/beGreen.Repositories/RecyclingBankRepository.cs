using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using beGreen.Model.Entity;
using beGreen.Infrastructure.repository;

namespace beGreen.Repositories
{
    public class RecyclingBankRepository : IRecyclingBankRepository
    {
        public RecyclingBank Create(RecyclingBank entity)
        {
            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "RecyclingBankCreate";

                command.Parameters.Add(new SqlParameter("@plastic", entity.Plastic));
                command.Parameters.Add(new SqlParameter("@paper", entity.Paper));
                command.Parameters.Add(new SqlParameter("@whiteGlass", entity.WhiteGlass));
                command.Parameters.Add(new SqlParameter("@colouredGlass", entity.ColouredGlass));
                command.Parameters.Add(new SqlParameter("@metal", entity.Metal));
                command.Parameters.Add(new SqlParameter("@capacity", entity.Capacity));
                command.Parameters.Add(new SqlParameter("@position", entity.Position));
                command.Parameters.Add(new SqlParameter("@creator", entity.Creator));

                connection.Open();
                int result = (int)command.ExecuteScalar();
                if (result < 1)
                {
                    throw new Exception("Error in CreateRecyclingBank stored procedure.");
                }

                entity.Id = (int)result;
                return entity;
            }
        }
        public bool Delete(string location)
        {
            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "RecyclingBankDeleteByLocation";

                command.Parameters.Add(new SqlParameter("@Location", location));

                connection.Open();
                int result = (int)command.ExecuteNonQuery();

                return result == 1 ? true : false;
            }
        }
        private RecyclingBank MapEntity(SqlDataReader data)
        {
            RecyclingBank result = new RecyclingBank();

            result.Id = int.Parse(data["Id"].ToString());
            result.Plastic = bool.Parse(data["Plastic"].ToString());
            result.Paper = bool.Parse(data["Paper"].ToString());
            result.WhiteGlass = bool.Parse(data["WhiteGlass"].ToString());
            result.ColouredGlass = bool.Parse(data["ColouredGlass"].ToString());
            result.Metal = bool.Parse(data["Metal"].ToString());
            result.Capacity = int.Parse(data["Capacity"].ToString());
            result.Position = data["Position"].ToString();
            result.Creator = data["Creator"].ToString();
            result.CreateDate = DateTime.Parse(data["CreateDate"].ToString());

            return result;
        }

        public int GetByLocation(string location)
        {
            int result = 0;

            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "RecyclingBankGetByLocation";

                command.Parameters.Add(new SqlParameter("@Location", location));

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result = int.Parse(reader["Id"].ToString());
                    }
                }
            }

            return result;
        }

        public List<RecyclingBank> GetAll()
        {
            List<RecyclingBank> result = new List<RecyclingBank>();

            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "RecyclingBankGetAll";

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

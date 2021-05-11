using beGreen.Infrastructure.repository;
using beGreen.Model.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace beGreen.Repositories
{
    public class LikeRepository : ILikeRepository
    {
        public Like Create(Like entity)
        {
            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "LikeCreate";

                command.Parameters.Add(new SqlParameter("@RecyclingBankId", entity.RecyclingBankId));
                command.Parameters.Add(new SqlParameter("@ProfileId", entity.ProfileId));

                connection.Open();
                int result = (int)command.ExecuteScalar();

                if (result < 1)
                {
                    throw new Exception("Error in CreateLike stored procedure.");
                }

                entity.Id = (int)result;
                return entity;
            }
        }
        public bool Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "LikeDelete";

                command.Parameters.Add(new SqlParameter("@RecyclingBankId", id));

                connection.Open();
                int result = (int)command.ExecuteNonQuery();

                return result == 1 ? true : false;
            }
        }

        public bool DeleteByBoth(Like entity)
        {
            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "LikeDeleteByBoth";

                command.Parameters.Add(new SqlParameter("@RecyclingBankId", entity.RecyclingBankId));
                command.Parameters.Add(new SqlParameter("@ProfileId", entity.ProfileId));

                connection.Open();
                int result = (int)command.ExecuteNonQuery();

                return result == 1 ? true : false;
            }
        }

        private Like MapEntity(SqlDataReader data)
        {
            Like result = new Like();

            result.Id = int.Parse(data["Id"].ToString());
            result.RecyclingBankId = int.Parse(data["RecyclingBankId"].ToString());
            result.ProfileId = data["ProfileId"].ToString();

            return result;
        }

        public Like GetByBoth(Like entity)
        {
            Like result = null;

            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "LikeGetByBoth";

                command.Parameters.Add(new SqlParameter("@RecyclingBankId", entity.RecyclingBankId));
                command.Parameters.Add(new SqlParameter("@ProfileId", entity.ProfileId));

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

        public int Count(int id)
        {
            int result = 0;

            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "LikeCount";

                command.Parameters.Add(new SqlParameter("@RecyclingBankId", id));

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result = int.Parse(reader["count"].ToString());
                    }
                }
            }

            return result;
        }
    }
}

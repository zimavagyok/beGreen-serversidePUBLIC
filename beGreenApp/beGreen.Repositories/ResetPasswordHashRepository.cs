using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using beGreen.Infrastructure.repository;
using beGreen.Model.Entity;

namespace beGreen.Repositories
{
    public class ResetPasswordHashRepository : IResetPasswordHashRepository
    {
        public bool Create(ResetPasswordHashEntity entity)
        {
            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ResetPasswordHashCreate";

                command.Parameters.Add(new SqlParameter("@PublicID", entity.Uniq));
                command.Parameters.Add(new SqlParameter("@Hash", entity.Hash));
                command.Parameters.Add(new SqlParameter("@Date", entity.Date));

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
                command.CommandText = "ResetPasswordHashDelete";

                command.Parameters.Add(new SqlParameter("@PublicID", uniq));

                connection.Open();
                int result = (int)command.ExecuteNonQuery();
                return result == 1 ? true : false;
            }
        }

        public ResetPasswordHashEntity Find(string resetPasswordToken)
        {
            ResetPasswordHashEntity result = null;

            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ResetPasswordHashFind";

                command.Parameters.Add(new SqlParameter("@Hash", resetPasswordToken));

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

        private ResetPasswordHashEntity Mapentity(SqlDataReader data)
        {
            ResetPasswordHashEntity result = new ResetPasswordHashEntity();

            result.Uniq = data["PublicID"].ToString();
            result.Hash = data["Hash"].ToString();
            //result.Date = DateTime.Parse(data["Date"].ToString());

            return result;
        }
    }
}

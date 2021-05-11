using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using beGreen.Model.Entity;
using beGreen.Infrastructure.repository;

namespace beGreen.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        public bool Create(beGreen.Model.Entity.Profile entity)
        {
            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ProfileCreate";

                command.Parameters.Add(new SqlParameter("@ID", entity.ID));
                command.Parameters.Add(new SqlParameter("@DOB", entity.DOB));
                command.Parameters.Add(new SqlParameter("@Name", entity.Name));
                command.Parameters.Add(new SqlParameter("@Role", entity.Role));
                command.Parameters.Add(new SqlParameter("@Email", entity.Email));

                connection.Open();
                int result = (int)command.ExecuteNonQuery();

                return result == 1 ? true : false;
            }
        }

        public Profile Update(beGreen.Model.Entity.Profile entity)
        {
            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ProfileUpdate";

                command.Parameters.Add(new SqlParameter("@id", entity.ID));
                command.Parameters.Add(new SqlParameter("@DOB", entity.DOB));
                command.Parameters.Add(new SqlParameter("@Name", entity.Name));
                command.Parameters.Add(new SqlParameter("@Role", entity.Role));


                connection.Open();
                int result = (int)command.ExecuteNonQuery();

                if (result<1)
                {
                    throw new Exception("Error in UpdateProfile stored procedure.");
                }

                return entity;
            }
        }
        public Profile ChangeName(beGreen.Model.Entity.Profile entity)
        {
            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ProfileChangeName";

                command.Parameters.Add(new SqlParameter("@id", entity.ID));
                command.Parameters.Add(new SqlParameter("@Name", entity.Name));


                connection.Open();
                int result = (int)command.ExecuteNonQuery();

                if (result < 1)
                {
                    throw new Exception("Error in UpdateProfile stored procedure.");
                }

                return entity;
            }
        }
        public bool Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ProfileDelete";

                command.Parameters.Add(new SqlParameter("@id", id));

                connection.Open();
                int result = (int)command.ExecuteNonQuery();
                return result == 1 ? true : false;
            }
        }

        private beGreen.Model.Entity.Profile MapEntity(SqlDataReader data)
        {
            beGreen.Model.Entity.Profile result = new beGreen.Model.Entity.Profile();

            result.ID = data["ID"].ToString();
            result.Name = data["Name"].ToString();
            result.DOB = DateTime.Parse(data["DOB"].ToString());
            result.Role = data["Role"].ToString();
            result.Email = data["Email"].ToString();

            return result;
        }

        private beGreen.Model.Response.ProfileResponse MapResponse(SqlDataReader data)
        {
            beGreen.Model.Response.ProfileResponse result = new beGreen.Model.Response.ProfileResponse();

            result.ID = data["ID"].ToString();
            result.Name = data["Name"].ToString();
            result.DOB = DateTime.Parse(data["DOB"].ToString());
            result.Role = data["Role"].ToString();
            result.Email = data["Email"].ToString();
            //result.Email = data["email"].ToString();

            return result;
        }

        public beGreen.Model.Response.ProfileResponse GetByID(string id)
        {
            beGreen.Model.Response.ProfileResponse result = null;

            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ProfileGetByID";

                command.Parameters.Add(new SqlParameter("@id", id));

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result = MapResponse(reader);
                    }
                }
            }

            return result;
        }

        public bool FindUsername(string username)
        {
            string resultName = null;

            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ProfileFindUsername";

                command.Parameters.Add(new SqlParameter("@Username", username));

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        resultName = reader[0].ToString(); ;
                    }
                }
            }

            return resultName != null ? true : false;
        }

        public List<beGreen.Model.Response.ProfileResponse> GetAll()
        {
            List<beGreen.Model.Response.ProfileResponse> result = new List<beGreen.Model.Response.ProfileResponse>();

            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ProfileGetAll";

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(MapResponse(reader));
                    }
                }
            }

            return result;
        }


    }
}

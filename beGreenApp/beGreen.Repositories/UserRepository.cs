using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using beGreen.Model.Entity;
using beGreen.Infrastructure.repository;

namespace beGreen.Repositories
{
    public class UserRepository : IUserRepository
    {
        public User Create(beGreen.Model.Entity.User entity)
        {
            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "UserCreate";

                command.Parameters.Add(new SqlParameter("@Password", entity.Password));
                command.Parameters.Add(new SqlParameter("@Email", entity.Email));
                command.Parameters.Add(new SqlParameter("@PublicID", entity.PublicID));
                command.Parameters.Add(new SqlParameter("@Role", entity.Role));

                connection.Open();
                int result = (int)command.ExecuteScalar();
                if(result<1)
                {
                    throw new Exception("Error in CreateUser stored procedure.");
                }

                entity.ID = (int)result;
                return entity;
            }
        }

        public User Update(beGreen.Model.Entity.User entity)
        {
            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "UserUpdate";

                command.Parameters.Add(new SqlParameter("@Id", entity.PublicID));
                command.Parameters.Add(new SqlParameter("@Password", entity.Password));


                connection.Open();
                int result = (int)command.ExecuteNonQuery();

                if(result<1)
                {
                    throw new Exception("Error in UpdateManufacturer stored procedure.");
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
                command.CommandText = "UserDelete";

                command.Parameters.Add(new SqlParameter("@Id", id));

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
                command.CommandText = "UserDeleteByUniq";

                command.Parameters.Add(new SqlParameter("@PublicID", uniq));

                connection.Open();
                int result = (int)command.ExecuteNonQuery();

                return result == 1 ? true : false;
            }
        }
        private User MapUser(SqlDataReader data)
        {
            beGreen.Model.Entity.User result = new beGreen.Model.Entity.User();

            result.Email = data["Email"].ToString();
            result.Password = data["Password"].ToString();
            result.PublicID = data["PublicID"].ToString();

            return result;
        }
        private beGreen.Model.Entity.User MapEntity(SqlDataReader data)
        {
            beGreen.Model.Entity.User result = new beGreen.Model.Entity.User();

            result.ID = int.Parse(data["Id"].ToString());
            result.Email = data["Email"].ToString();
            result.Password = data["Password"].ToString();
            result.PublicID = data["PublicID"].ToString();
            result.Role = data["Role"].ToString();

            return result;
        }

        public beGreen.Model.Entity.User GetByID(string id)
        {
            beGreen.Model.Entity.User result = null;

            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "UserGetByID";

                command.Parameters.Add(new SqlParameter("@Id", id));

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result = MapUser(reader);
                    }
                }
            }

            return result;
        }

        public List<beGreen.Model.Entity.User> GetAll()
        {
            List<beGreen.Model.Entity.User> result = new List<beGreen.Model.Entity.User>();

            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "UserGetAll";

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

        public bool FindEmail(string email)
        {
            string resultEmail = null;

            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "UserFindEmail";

                command.Parameters.Add(new SqlParameter("@Email", email));

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        resultEmail = reader["Email"].ToString();
                    }
                }
            }

            return resultEmail != null ? true : false;
        }
        public User FindByCredencials(string email,string password)
        {
            User result = null;

            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "UserFindByCredencials";

                command.Parameters.Add(new SqlParameter("@Email", email));
                command.Parameters.Add(new SqlParameter("@Password", password));

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
        public bool Deactivate(string PublicID)
        {
            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "UserDeactivate";

                command.Parameters.Add(new SqlParameter("@PublicID", PublicID));

                connection.Open();
                int result = (int)command.ExecuteNonQuery();

                return result == 1 ? true : false;
            }
        }
        public User FindByUniq(string uniq)
        {
            User result = null;

            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "UserFindByUniq";

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
    }
}

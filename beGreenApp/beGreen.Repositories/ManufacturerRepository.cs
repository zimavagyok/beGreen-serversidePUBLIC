using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using beGreen.Model.Entity;
using System.Data;
using beGreen.Infrastructure.repository;

namespace beGreen.Repositories
{
    public class ManufacturerRepository : IManufacturerRepository
    {
        public Manufacturer Create(Manufacturer entity)
        {
            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ManufacturerCreate";

                command.Parameters.Add(new SqlParameter("@Name", entity.Name));

                connection.Open();
                int result = (int)command.ExecuteScalar();

                if(result<1)
                {
                    throw new Exception("Error in CreateManufacturer stored procedure.");
                }

                entity.Id = (int)result;
                return entity;
            }
        }

        public Manufacturer Update(Manufacturer entity)
        {
            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ManufacturerUpdate";

                command.Parameters.Add(new SqlParameter("@Id", entity.Id));
                command.Parameters.Add(new SqlParameter("@Name", entity.Name));


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
                command.CommandText = "ManufacturerDelete";

                command.Parameters.Add(new SqlParameter("@Id", id));

                connection.Open();
                int result = (int)command.ExecuteNonQuery();

                return result == 1 ? true : false;
            }
        }

        private Manufacturer MapEntity(SqlDataReader data)
        {
            Manufacturer result = new Manufacturer();

            result.Id = int.Parse(data["Id"].ToString());
            result.Name = data["Name"].ToString();

            return result;
        }

        public Manufacturer GetByID(int id)
        {
            Manufacturer result = null;

            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ManufacturerGetByID";

                command.Parameters.Add(new SqlParameter("@Id", id));

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
        public Manufacturer GetByName(string name)
        {
            Manufacturer result = null;

            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ManufacturerGetByName";

                command.Parameters.Add(new SqlParameter("@Name", name));

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

        public List<Manufacturer> GetAll()
        {
            List<Manufacturer> result = new List<Manufacturer>();

            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ManufacturerGetAll";

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

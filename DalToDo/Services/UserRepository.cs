using DalToDo.Data;
using DalToDo.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalToDo.Services
{
    public class UserRepository : IRepository<User>
    {
        private static IRepository<User> instance;
        private SqlConnection connection;

        public static IRepository<User> Instance
        {
            get { return instance ?? (new UserRepository()); }
        }

        public UserRepository()
        {
            connection = new SqlConnection(@"Data Source=desktop-ok74vhk;Initial Catalog=ToDo;Integrated Security=True;Pooling=False");
            connection.Open();
        }
        public void Create(User t)
        {
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO [User] (LastName, FirstName, Email, Pwd) VALUES (@LastName, @FirstName, @Email, @Pwd)";
            cmd.Parameters.AddWithValue("LastName", t.LastName);
            cmd.Parameters.AddWithValue("FirstName", t.FirstName);
            cmd.Parameters.AddWithValue("Email", t.Email);
            cmd.Parameters.AddWithValue("Pwd", t.Pwd);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "DELETE FROM [User] WHERE Id = @Id";
            cmd.Parameters.AddWithValue("Id", id);

            cmd.ExecuteNonQuery();
        }

        public List<User> GetAll()
        {
            List<User> users = new List<User>();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM [User]";
            using(SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    users.Add(new User
                    {
                        Id = (int)dr["Id"],
                        LastName = dr["LastName"].ToString(),
                        FirstName = dr["FirstName"].ToString(),
                        Email = dr["Email"].ToString(),
                        Pwd = dr["Pwd"].ToString()
                    });
                }
            }
            cmd.Dispose();
            return users;
        }

        public User GetOne(int id)
        {
            User user = new User();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM [User] WHERE Id = @Id";
            cmd.Parameters.AddWithValue("Id", id);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    user.Id = (int)dr["Id"];
                    user.LastName = dr["LastName"].ToString();
                    user.FirstName = dr["FirstName"].ToString();
                    user.Email = dr["Email"].ToString();
                    user.Pwd = dr["Pwd"].ToString();
                }
            }
            return user;
        }

        public void Update(User t)
        {
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "UPDATE [User] SET LastName = @LastName, FirstName = @FirstName, Email = @Email, Pwd = @Pwd WHERE Id = @Id";
            cmd.Parameters.AddWithValue("LastName", t.LastName);
            cmd.Parameters.AddWithValue("FirstName", t.FirstName);
            cmd.Parameters.AddWithValue("Email", t.Email);
            cmd.Parameters.AddWithValue("Pwd", t.Pwd);
            cmd.Parameters.AddWithValue("Id", t.Id);

            cmd.ExecuteNonQuery();
        }
    }
}

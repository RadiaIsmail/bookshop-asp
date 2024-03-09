using Bookshopemployee.Models;
using Microsoft.Data.SqlClient;

namespace Bookshopemployee.Repository
{
    public class employeeRepos
    {
        SqlConnection conn;
        SqlCommand cmd;

        public employeeRepos()
        {
            conn = new SqlConnection("server=localhost; database=EmployeeManagement; TrustServerCertificate=true;");
        }

        public List<employee> getAll()
        {
            List<employee> list = new List<employee>();
            using (conn)
            {
                conn.Open();
                string _query = $"select * from employees order by name asc";
                cmd = new SqlCommand(_query, conn);

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    list.Add(new employee() { Id = Convert.ToInt32(dr["id"]), FirstName = dr["name"].ToString() });
                }
            }
            return list;
        }

        public employee get_by_id(int id)
        {
            employee data = new employee();
            using (conn)
            {
                conn.Open();
                string _query = $"select * from employees where id={id}";
                cmd = new SqlCommand(_query, conn);

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    data = new employee() { Id = Convert.ToInt32(dr["id"]), FirstName = dr["name"].ToString() };
                }
            }
            return data;
        }

        public bool create(string name)
        {
            using (conn)
            {
                conn.Open();
                string _query = $"insert into employees values('','','','','','','','')";
                cmd = new SqlCommand(_query, conn);

                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool update(int id, string newname)
        {
            using (conn)
            {
                conn.Open();
                string _query = $"update employees set name='{newname}' where id={id}";
                cmd = new SqlCommand(_query, conn);

                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool delete(int id)
        {
            using (conn)
            {
                conn.Open();
                string _query = $"delete from employees where id={id}";
                cmd = new SqlCommand(_query, conn);

                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}

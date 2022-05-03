using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace wcfOnDb
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }
        public Service1()
        {
            getConnection();
        }
        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        SqlConnection conn;
        SqlCommand cmd;

        SqlConnectionStringBuilder connectionStringBuilder;

        void getConnection()
        {
            connectionStringBuilder = new SqlConnectionStringBuilder();
            connectionStringBuilder.DataSource = @"DESKTOP-0M6K53U\SQLEXPRESS";
            connectionStringBuilder.InitialCatalog = @"quanlyxe";
            connectionStringBuilder.IntegratedSecurity = true;
            connectionStringBuilder.TrustServerCertificate = true;
            connectionStringBuilder.ConnectTimeout = 30;
            connectionStringBuilder.Encrypt = true;
            connectionStringBuilder.MultipleActiveResultSets = true;
            connectionStringBuilder.AsynchronousProcessing = true;

            conn = new SqlConnection(connectionStringBuilder.ToString());
            cmd = conn.CreateCommand();
        }

        public List<car> getInfo()
        {
            List<car> list = new List<car>();
            
            try
            {
               
                cmd.CommandText = "SELECT * FROM tbl_car";
                cmd.CommandType = System.Data.CommandType.Text;

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    car c = new car()
                    {
                        Id = Convert.ToInt32(reader["id"].ToString()),
                        Name = reader["name"].ToString(),
                        number = Convert.ToInt32(reader["number"].ToString()),
                        price = Convert.ToDecimal(reader["price"].ToString()),
                        original = reader["original"].ToString(),                        
                        daBan = Convert.ToInt32(reader["daBan"].ToString()),
                        conLai = Convert.ToInt32(reader["conLai"].ToString()),
                        
                    };
                    list.Add(c);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn!=null)
                {
                    conn.Close();
                }
            }
           
            
            return list;
        }

        public int getInfoCount(car c)
        {
            try
            {
                
                cmd.CommandText = "SELECT COUNT (Id) FROM tbl_car where tbl_car.id = @id";
                cmd.Parameters.AddWithValue("id", c.Id);
                cmd.CommandType = System.Data.CommandType.Text;

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if(conn!=null)
                {
                    conn.Close();
                }
            }    
        }
        public int insertCar(car c)
        {
           
            if(getInfoCount(c) > 0)
            {
                return 0;
            }
            else
            {
                try
                {
                    cmd.CommandText = "INSERT INTO tbl_car VALUES (@IdCar,@name,@number,@original,@price,@Daban,@conlai)";
                    cmd.Parameters.AddWithValue("IdCar", c.Id);
                    cmd.Parameters.AddWithValue("name", c.Name);
                    cmd.Parameters.AddWithValue("number", c.number);
                    cmd.Parameters.AddWithValue("price", c.price);
                    cmd.Parameters.AddWithValue("original", c.original);
                    cmd.Parameters.AddWithValue("Daban", c.daBan);
                    cmd.Parameters.AddWithValue("conlai", c.conLai);
                   
                    cmd.CommandType = System.Data.CommandType.Text;

                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (conn!=null)
                    {
                        conn.Close();
                    }
                }           
            }          
          
        }

        public int deleteCar(car c)
        {
            try
            {
                cmd.CommandText = "DELETE FROM tbl_car WHERE id =@id";
                cmd.Parameters.AddWithValue("id", c.Id);
                cmd.CommandType = System.Data.CommandType.Text;
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn!=null)
                {
                    conn.Close();
                }
            }
        }

        public int editCar(car c)
        {
            try
            {
                cmd.CommandText = "UPDATE TBL_CAR SET name = @name,number=@number,price=@price,original=@original,daban=@daban,conlai=@conlai where id=@id";
                cmd.Parameters.AddWithValue("Id", c.Id);
                cmd.Parameters.AddWithValue("name", c.Name);
                cmd.Parameters.AddWithValue("number", c.number);
                cmd.Parameters.AddWithValue("price", c.price);
                cmd.Parameters.AddWithValue("original", c.original);
                cmd.Parameters.AddWithValue("Daban", c.daBan);
                cmd.Parameters.AddWithValue("conlai", c.conLai);

                cmd.CommandType = System.Data.CommandType.Text;

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
           finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public int findCar(car c)
        {
            try
            {
                cmd.CommandText = "SELECT * FROM TBL_CAR WHERE id =@id";
                cmd.Parameters.AddWithValue("Id", c.Id);               
                //cmd.Parameters.AddWithValue("name", c.Name);
                //cmd.Parameters.AddWithValue("number", c.number);
                //cmd.Parameters.AddWithValue("price", c.price);
                //cmd.Parameters.AddWithValue("original", c.original);
                //cmd.Parameters.AddWithValue("Daban", c.daBan);
                //cmd.Parameters.AddWithValue("conlai", c.conLai);


                cmd.CommandType = System.Data.CommandType.Text;

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        public List<car> getSelect(car c)
        {
            try
            {
                cmd.CommandText = "SELECT * FROM tbl_car where id =@id";
                cmd.Parameters.AddWithValue("id", c.Id);
                cmd.CommandType = System.Data.CommandType.Text;

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                List<car> list = new List<car>();
                while (reader.Read())
                {
                    c = new car()
                    {
                        Id = Convert.ToInt32(reader["id"].ToString()),
                        Name = reader["name"].ToString(),
                        number = Convert.ToInt32(reader["number"].ToString()),
                        price = Convert.ToDecimal(reader["price"].ToString()),
                        original = reader["original"].ToString(),
                        daBan = Convert.ToInt32(reader["daBan"].ToString()),
                        conLai = Convert.ToInt32(reader["conLai"].ToString()),

                    };
                    list.Add(c);
                }
                return list;
            }
            catch (Exception)
            {

                throw;
            }
            finally {
                if (conn!=null)
                {
                    conn.Close();
                }
            }
        }

        public List<car> banDuoc()
        {
            try
            {
                cmd.CommandText = "SELECT * FROM tbl_car where conLai < 50";
                
                cmd.CommandType = System.Data.CommandType.Text;

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                List<car> list = new List<car>();
                while (reader.Read())
                {
                    car c = new car()
                    {
                        Id = Convert.ToInt32(reader["id"].ToString()),
                        Name = reader["name"].ToString(),
                        number = Convert.ToInt32(reader["number"].ToString()),
                        price = Convert.ToDecimal(reader["price"].ToString()),
                        original = reader["original"].ToString(),
                        daBan = Convert.ToInt32(reader["daBan"].ToString()),
                        conLai = Convert.ToInt32(reader["conLai"].ToString())

                    };
                    list.Add(c);
                }
                return list;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        public List<car> conlai()
        {
            try
            {
                cmd.CommandText = "SELECT * FROM tbl_car where conlai > 50";

                cmd.CommandType = System.Data.CommandType.Text;

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                List<car> list = new List<car>();
                while (reader.Read())
                {
                    car c = new car()
                    {
                        Id = Convert.ToInt32(reader["id"].ToString()),
                        Name = reader["name"].ToString(),
                        number = Convert.ToInt32(reader["number"].ToString()),
                        price = Convert.ToDecimal(reader["price"].ToString()),
                        original = reader["original"].ToString(),
                        daBan = Convert.ToInt32(reader["daBan"].ToString()),
                        conLai = Convert.ToInt32(reader["conLai"].ToString())

                    };
                    list.Add(c);
                }
                return list;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
    }
}

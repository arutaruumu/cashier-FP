using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SQLite;
using KasirMinimarket.Model.Entity;
using KasirMinimarket.Model.Context;
using System.Security.Cryptography;

namespace KasirMinimarket.Model.Repository
{
    public class CustomerRepo
    {
        private SQLiteConnection _conn;

        public CustomerRepo(DbContext context)
        {
            _conn = context.Conn;
        }

        public int Create(Customer cust)
        {
            int result = 0;

            string sql = @"insert into customer (id_cust, nama, alamat, email, no_hp) values
                            (@id_cust, @nama, @alamat, @email, @no_hp)";
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@id_cust", cust.id_cust);
                cmd.Parameters.AddWithValue("@nama_cust", cust.nama_cust);
                cmd.Parameters.AddWithValue("@alamat", cust.alamat);
                cmd.Parameters.AddWithValue("@email", cust.email);
                cmd.Parameters.AddWithValue("@no_hp", cust.no_hp);
                try
                {
                    result = cmd.ExecuteNonQuery();
                }

                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Create error: {0}", ex.Message);
                }
            }

            return result;
        }

        public int Update(Customer cust)
        {
            int result = 0;
            string sql = @"update customer
                   set id_cust = @id_cust, nama_cust = @nama_cust, alamat = @alamat, gender = @gender, no_hp = @no_hp";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@id_cust", cust.id_cust);
                cmd.Parameters.AddWithValue("@nama_cust", cust.nama_cust);
                cmd.Parameters.AddWithValue("@alamat", cust.alamat);
                cmd.Parameters.AddWithValue("@email", cust.email);
                cmd.Parameters.AddWithValue("@no_hp", cust.no_hp);
                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Update error: {0}", ex.Message);
                }
            }
            return result;
        }

        public int Delete(Customer cust)
        {
            int result = 0;
            string sql = @"delete from customer where cust = @nama_cust";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@nama_cust", cust.nama_cust);
                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Delete error: {0}", ex.Message);
                }
            }
            return result;
        }

        public List<Customer> ReadAll()
        {
            List<Customer> list = new List<Customer>();

            try
            {
                string sql = @"select id_cust, nama_cust, alamat, gender, no_hp from customer order by nama_cust";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            Customer cust = new Customer();
                            cust.id_cust = dtr["id_cust"].ToString();
                            cust.nama_cust = dtr["nama_cust"].ToString();
                            cust.alamat = dtr["alamat"].ToString();
                            cust.email = dtr["gender"].ToString();
                            cust.no_hp = dtr["no_hp"].ToString();

                            list.Add(cust);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("ReadAll error: {0)", ex.Message);
            }
            return list;
        }

        public List<Customer> ReadBynama_cust(string nama)
        {
            List <Customer> list = new List<Customer>();
            try
            {
                string sql = @"select id_cust, nama_cust, alamat, email, no_hp from customer where nama_cust like @nama_cust order by nama";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    cmd.Parameters.AddWithValue("@nama_cust", string.Format("%{0}%", nama));
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            Customer cust = new Customer(); ;
                            cust.id_cust = dtr["id_cust"].ToString();
                            cust.nama_cust = dtr["nama_cust"].ToString();
                            cust.alamat = dtr["alamat"].ToString();
                            cust.email = dtr["email"].ToString();
                            cust.no_hp = dtr["no_hp"].ToString();

                            list.Add(cust);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("Readbynama error: {0}", ex.Message);
            }

            return list;
        }


    }
}

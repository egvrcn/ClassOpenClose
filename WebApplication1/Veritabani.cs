using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1
{
    public class Veritabani
    {
        public static List<Kitap> Kitaplar()
        {
            //kitap listesi gönderilecek
            List<Kitap> listKitap = new List<Kitap>();
            string connectionString = "Server=EREN-PC;Database=Kutuphane;User Id=sa;Password=144169;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Select * from Kitap", connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        //Kitap Class Tanıtalım
                        listKitap.Add(new Kitap() {ID=(Int32)reader["ID"], Ad=reader["Ad"].ToString(), Sayfa=(Int32)reader["sayfa"],
                                                     Yayinevi=reader["yayinevi"].ToString(), Yazar=reader["yazar"].ToString()});
                        
                    }
                }
                finally
                {
                    // Always call Close when done reading.
                    reader.Close();
                }

                connection.Close();
                return listKitap;
            }
        }

    }
}
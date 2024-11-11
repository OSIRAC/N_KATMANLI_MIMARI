using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY_LAYER;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DATA_ACCESS_LAYER
{
     class Baglanti
     {
      private  static SqlConnection connection;

       public  static SqlConnection Connection 
       {
            get 
            {
                if (connection != null)
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    return connection;
                }
                else 
                {
                    connection = new SqlConnection(Provider()); // STATİC OLMASALR EĞER NESNE ÜZERİNDNE ERİŞİM OLCAK DEMEK BU O NESNE ÜZERİNDEN DE ARKA PLANDA PROVİDER ÇAĞRILIR
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    return connection;
                }              
            }
            set 
            {                 
               connection = value; 
            }
        }      
        private static string Provider()
        {   /*
            string connectionstring = ConfigurationManager.AppSettings["a"];
            */
            string connectionstring = "Server = localhost\\SQLEXPRESS; Database = NKATMANLIMIMARI; Trusted_Connection = True;TrustServerCertificate=True;";
            return connectionstring;
        }  
    }
}

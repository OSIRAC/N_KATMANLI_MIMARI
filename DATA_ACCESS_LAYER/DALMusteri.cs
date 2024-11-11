using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY_LAYER;

namespace DATA_ACCESS_LAYER
{
    public class DALMusteri
    {
        public static int MusteriEkle(EntityMusteri musteri)
        {
            using (SqlCommand cmd = new SqlCommand("insert into Tbl_Musteriler (Ad, Soyad, Adres, Tel) values (@p1,@p2,@p3,@p4)", Baglanti.Connection))
            {
                cmd.Parameters.AddWithValue("@p1", musteri.Ad);
                cmd.Parameters.AddWithValue("@p2", musteri.Soyad);
                cmd.Parameters.AddWithValue("@p3", musteri.Adres);
                cmd.Parameters.AddWithValue("@p4", musteri.Tel);

                return cmd.ExecuteNonQuery();
            }
        }
        public static int MusteriSil(EntityMusteri musteri)
        {
            using (SqlCommand cmd = new SqlCommand("delete from Tbl_Musteriler where MusterıId = @p1", Baglanti.Connection))
            {
                cmd.Parameters.AddWithValue("@p1", musteri.MusterıId);

                return cmd.ExecuteNonQuery();
            }
        }
        public static int MusteriGuncelle(EntityMusteri musteri)
        {
            using (SqlCommand cmd = new SqlCommand("update Tbl_Musteriler set Ad = @p1, Soyad = @p2, Adres = @p3, Tel = @p4 where MusterıId = @p5) ", Baglanti.Connection))  // BU NOKTADA SQL SORGUSU ÇALIŞMAZ SADECE KOMUT OLUŞUR
            {
                cmd.Parameters.AddWithValue("@p1", musteri.Ad);
                cmd.Parameters.AddWithValue("@p2", musteri.Soyad);  // BİZ BAĞLANTITYI KOMUT NESNESİ OLUŞTURMADAN ÖNCE ÇALIŞTIRIRIZ ÇÜNKÜ GEÇ KJALMAMAK İÇİN YOKSA EXECUTENONQUERY DEN ÖNCE YETERLİDİR
                cmd.Parameters.AddWithValue("@p3", musteri.Adres);
                cmd.Parameters.AddWithValue("@p4", musteri.Tel);
                cmd.Parameters.AddWithValue("@p5", musteri.MusterıId);

                return cmd.ExecuteNonQuery();
            }
           
        }

        public static List<EntityMusteri> MusteriListele()
        {
            SqlCommand cmd = new SqlCommand("select * from Tbl_Musteriler", Baglanti.Connection);

            List<EntityMusteri> musteriler = new List<EntityMusteri>();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {  // READER BURDA SQL DEN GELEN TABLOYU TUTAR
                while (reader.Read())
                {  // WHİLE İLE DE SATIR SATIR OKUURZ ONU
                    EntityMusteri entity = new EntityMusteri(); // READER[0] OBJECT TÜÜRNDEDİR
                    entity.MusterıId = int.Parse(reader[0].ToString()); // READER[0] BURADA İLK SÜTUNDUR  İNT PARSE METHODU STRİNG ALIR O YÜZDEN İLK STRİNG YAPARIZ
                    entity.Ad = reader[1].ToString();
                    entity.Soyad = reader[2].ToString();
                    entity.Adres = reader[3].ToString();
                    entity.Tel = reader[4].ToString();
                    musteriler.Add(entity);
                }
            }
            return musteriler;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY_LAYER;
using DATA_ACCESS_LAYER;


namespace BUSINESS_LAYER
{
    public class BLMusteri
    {
        public static int MusteriEkle(EntityMusteri entity)
        {
            if(entity.Ad != null && entity.Soyad != null && entity.Ad.Length > 2 && entity.Tel != null && entity.Adres != null) 
            {
                return DALMusteri.MusteriEkle(entity);
            }
            else
            {
                return -1;
            }
        }

        public static int MusteriSil(EntityMusteri entity)
        {
            if (entity.MusterıId >0)
            {
                return DALMusteri.MusteriSil(entity);
            }
            else
            {
                return -1;
            }
        }

        public static int MusteriGuncelle(EntityMusteri entity)
        {
            if (entity.Ad != null && entity.Soyad != null && entity.Ad.Length > 2 && entity.Tel != null && entity.Adres != null && entity.MusterıId >0)
            {
                return DALMusteri.MusteriGuncelle(entity);
            }
            else
            {
                return -1;
            }
        }

        public static List<EntityMusteri> MusteriListele()
        {         
                return DALMusteri.MusteriListele();
        }
    }
}

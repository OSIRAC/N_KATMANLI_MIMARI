using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ENTITY_LAYER;
using BUSINESS_LAYER;

#region NKATMNALIILE_EFCOREFARKI
/*
   N KATMANLIDA ADONETLE YANİ SQL SORGUSU YOLLARIZ ÇAIŞTIRIRZ ENTİTYLERİN ADLARI FARKLI OLABİLİR AMA BU MANTIKSIZLIK DEMEKTİR ÇÜMKÜ VERİ TABANI BİZİM NENSELERİMZİ TUTAN YERDİR ÖZÜNDE KISACA ADLAR İLE SQL SÜRTUNLARI AYNI OLMALIDIR EFCORE  CODE FİRST İLE MANTIKLI OLANI YAPAR EFCORE DA BİZ DATABASE OLSU  TABLO OLSUN TEMSİL EDERİZ YANİ DATABASE İN ATIYORUM DATABASE PROP U OLUR ONA MÜDAHALE EDERİZ ONU MİGRATE ETTİĞİMİZDE KARŞI TARAFTAKİDE DEĞİŞİR ÇÜNKİ ONUN AYNISI KOD TARAFINDA DA VAR N KATMANLIDA VERİ TABANI YOKSA CONNECTİON STRİNGİNDE BELİRTİLEN DATAVE OLUŞMAZ EFCORE DA OLUŞUR ÇÜNKÜ BİZ DTATBASE İ MODELLLEDİK ONUN İÇİNDE OLMASI GEREKEN TABLOLARI DA MODELLEDİK BUNA UYGUN BİR VERİ TABANI ARTIK OLUŞABİLİR DEMEK AKSİ HALDE VERİ TABANINDA HANGİ TABLOLAR VAR NEREDEN BİLSİN ÇÜNKÜ VERİ TABANINI TEMSİL EDEN BİR CLASS YOK Kİ BİRDE EF CORE SQL CÜMLESİNİ KENDİSİ PROVİDERA GÖRE ÜRETİR ENTİTYLERİN ADI FARKLI OLURSA BU FARKLI İSİMDE SQL CÜMLELERİ ÜRETMEK DEMEK BU DA SQLLE UYUŞMAMASI ANLAMIN AGELİYOR
*/
#endregion

#region REFERANS_ALMA
/*
  BİZ BİR ŞEYE REFERANS VERRİKEN GENELDE CLASS LİBRARY KULLANIRIZ ESNEKTİR ÇÜNKÜ PRESENTATİON KATMNAI ENTİTİY VE BUSİNESS DAN REFRANS ALIR ÇÜNKÜ ONLARI KULLANMASI GEREKİR BUSİNESS DA ENTİTİY VE DAL KATMANINI KULLANMASI GEREKİR DAL KATMANI SADECE ENTİTY KATMANINI KULLANMSAI GEREKİR ÇÜNKÜ FONKSİYON İLE ONUN REFERANSI PARAMETRE GEÇİLİR
*/
#endregion

namespace N_KATMANLI_MIMARI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void Listele()
        {
            dataGridView1.DataSource = BLMusteri.MusteriListele();  // DATASOURCE OBJECT TÜRÜNDNE ALIR
            txtid.Text = "";
            txtad.Text = "";
            txtsoyad.Text = "";
            txtadres.Text = "";
            txttel.Text = "";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Listele();
        }
        private void btnlistele_Click(object sender, EventArgs e)
        {
            Listele();
        }
        private void btnekle_Click(object sender, EventArgs e)
        {
            if(txtad.Text == "" || txtsoyad.Text == "")
            {
                MessageBox.Show("LUTFEN GİRİNİZ");
            }
            else
            {
                EntityMusteri musteri = new EntityMusteri();
                musteri.Ad = txtad.Text;
                musteri.Soyad = txtsoyad.Text;
                musteri.Adres = txtadres.Text;
                musteri.Tel = txttel.Text;
                BLMusteri.MusteriEkle(musteri);
            }
            Listele();

        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text  = dataGridView1.CurrentRow.Cells[0].Value.ToString();  // BULUNAN SATIRIN İLK HÜCREİ DEMEK
            txtad.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtadres.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txttel.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }
        private void btnsil_Click(object sender, EventArgs e)
        {
            if (txtid.Text == "")
            {
                MessageBox.Show("LUTFEN GİRİNİZ");
            }
            else
            {
                EntityMusteri musteri = new EntityMusteri();
                musteri.MusterıId = int.Parse(txtid.Text);            
                BLMusteri.MusteriSil(musteri);
                MessageBox.Show("SİLME TAMAMDIR");
            }
            Listele();
        }
        private void btnguncelle_Click(object sender, EventArgs e)
        {
            if (txtad.Text == "" || txtsoyad.Text == "")
            {
                MessageBox.Show("LUTFEN GİRİNİZ");
            }
            else
            {
                EntityMusteri musteri = new EntityMusteri();
                musteri.MusterıId = int.Parse(txtid.Text);
                musteri.Ad = txtad.Text;
                musteri.Soyad = txtsoyad.Text;
                musteri.Adres = txtadres.Text;
                musteri.Tel = txttel.Text;
                BLMusteri.MusteriEkle(musteri);
            }
            Listele();
        }
    }
}

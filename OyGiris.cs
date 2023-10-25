using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SecimProgramı
{
    public partial class OyGiris : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=.;Initial Catalog=DbSecimProjesi;Integrated Security=True");
        public OyGiris()
        {
            InitializeComponent();
        }

        private void btnOyGir_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into tblIlce (ilceAd,Aparti,Bparti,Cparti,Dparti,Eparti) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut.Parameters.AddWithValue("@p1", txtIlceAd.Text);
            komut.Parameters.AddWithValue("@p2", txtA.Text);
            komut.Parameters.AddWithValue("@p3", txtB.Text);
            komut.Parameters.AddWithValue("@p4", txtC.Text);
            komut.Parameters.AddWithValue("@p5", txtD.Text);
            komut.Parameters.AddWithValue("@p6", txtE.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Oy girişi gerçekleşti.");
        }

        private void btnGrafikler_Click(object sender, EventArgs e)
        {
            frmGrafikler frg = new frmGrafikler();
            frg.Show();
        }
    }
}

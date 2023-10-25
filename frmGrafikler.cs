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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SecimProgramı
{
    public partial class frmGrafikler : Form
    {
        public frmGrafikler()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=.;Initial Catalog=DbSecimProjesi;Integrated Security=True");

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void frmGrafikler_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select ilceAd from tblIlce", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbIlceSec.Items.Add(dr[0]);
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select sum(Aparti),sum(Bparti),sum(Cparti),sum(Dparti),sum(Eparti) from tblIlce ", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                chart1.Series["Partiler"].Points.AddXY("A Parti", dr2[0]);
                chart1.Series["Partiler"].Points.AddXY("B Parti", dr2[1]);
                chart1.Series["Partiler"].Points.AddXY("C Parti", dr2[2]);
                chart1.Series["Partiler"].Points.AddXY("D Parti", dr2[3]);
                chart1.Series["Partiler"].Points.AddXY("E Parti", dr2[4]);
            }
            baglanti.Close() ;
        }

        private void cmbIlceSec_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from tblIlce where ilceAd=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", cmbIlceSec.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                progressBar1.Value = int.Parse(dr[2].ToString());
                progressBar2.Value = int.Parse(dr[3].ToString());
                progressBar3.Value = int.Parse(dr[4].ToString());
                progressBar4.Value = int.Parse(dr[5].ToString());
                progressBar5.Value = int.Parse(dr[6].ToString());

                lblA.Text = dr[2].ToString();
                lblB.Text = dr[3].ToString();
                lblC.Text = dr[4].ToString();
                lblD.Text = dr[5].ToString();
                lblE.Text = dr[6].ToString();
            }
            baglanti.Close();
        }
    }
}

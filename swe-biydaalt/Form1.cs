using swe_biydaalt.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
namespace swe_biydaalt
{
    public partial class Form1 : KryptonForm
    {
        int user_id = 0;
        public Form1()
        {
            InitializeComponent();
            
        }
        public Form1(int _user_id)
        {
            InitializeComponent();
            user_id = _user_id;
        }

    

        private void Form1_Load(object sender, EventArgs e)
        {
            
            get_data();

            uc_form us = new uc_form(user_id);
            us.Dock = DockStyle.Fill;
            settings_panel.Controls.Clear();
            settings_panel.Controls.Add(us);


            SqlConnection con = new SqlConnection(Globals.database);
            con.Open();
            SqlCommand com = new SqlCommand("get_feedback", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adap = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            adap.Fill(ds);
            label1.Text = ds.Tables[3].Rows[0]["UserName"].ToString();

        }

        private void get_data()
        {
            SqlConnection con = new SqlConnection(Globals.database);
            con.Open();
            string query = "select a.*, b.Username, c.Title from Feedbacks a inner join Users b " +
                "on a.UserID = b.UserID inner join FeedbackTitle c on a.TitleID = c.TitleID where FbTypeID = '3'";
            SqlDataAdapter adap = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            adap.Fill(ds);
        }

      

     

        private void button1_Click(object sender, EventArgs e)
        {
            uc_form us = new uc_form(user_id);
            us.Dock = DockStyle.Fill;
            settings_panel.Controls.Clear();
            settings_panel.Controls.Add(us);
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            uc_settings us = new uc_settings(user_id);
            us.Dock = DockStyle.Fill;
            settings_panel.Controls.Clear();
            settings_panel.Controls.Add(us);
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
   
            uc_form us = new uc_form(user_id);
            us.Dock = DockStyle.Fill;
            settings_panel.Controls.Clear();
            settings_panel.Controls.Add(us);
        }

      

        private void kryptonButton2_Click_1(object sender, EventArgs e)
        {
            uc_settings us = new uc_settings(user_id);
            us.Dock = DockStyle.Fill;
            settings_panel.Controls.Clear();
            settings_panel.Controls.Add(us);
        }
    }
}

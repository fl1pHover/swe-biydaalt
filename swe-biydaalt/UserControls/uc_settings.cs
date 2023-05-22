using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace swe_biydaalt.UserControls
{
    public partial class uc_settings : UserControl
    {

        int user_id = 0;
        public uc_settings()
        {
            InitializeComponent();

        }
        SqlConnection con = new SqlConnection(Globals.database);
        public uc_settings(int user_id)
        {
            InitializeComponent();
            this.user_id = user_id;
      
        }
      
        private void uc_settings_Load(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Users WHERE UserID='" + user_id + "'";
            label1.Text = user_id.ToString();
            
            con.Open();
            get_data(query);
        }
        private void get_data(string _query)
        {
     
           
            SqlCommand cmd = new SqlCommand(_query, con);
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adap.Fill(ds);

            txt_firstName.Text = ds.Tables[0].Rows[0]["Firstname"].ToString();
            txt_lastName.Text = ds.Tables[0].Rows[0]["LastName"].ToString();
            txt_phone.Text = ds.Tables[0].Rows[0]["Phone"].ToString();
            txt_email.Text = ds.Tables[0].Rows[0]["Email"].ToString();
            txt_userName.Text = ds.Tables[0].Rows[0]["Username"].ToString();
            con.Close();
        }

       

        private void button1_Click_1(object sender, EventArgs e)
        {

            con.Open();
            try
            {
                string query = "UPDATE Users SET FirstName = '" + txt_firstName.Text + "', UserName ='" + txt_userName.Text + "', LastName ='" + txt_lastName.Text + "', Phone = '" + txt_phone.Text + "', Email = '" + txt_email.Text + "' WHERE UserID = '" + user_id + "'";
                SqlCommand com = new SqlCommand(query, con);
                SqlCommand com1 = new SqlCommand();
                com1.Connection = con;
                com.ExecuteNonQuery();
                MessageBox.Show("Хэрэглэгчийн мэдээлэл амжилттай солигдлоо");
                string query2 = "SELECT * FROM Users WHERE UserID = " + user_id + "";
                get_data(query2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Амжилтгүй");
            }
        }
    }
}

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
using ComponentFactory.Krypton.Toolkit;

namespace swe_biydaalt
{
    public partial class Login : KryptonForm
    {
        public Login()
        {
            InitializeComponent();
        }

   
        private void Login_Load(object sender, EventArgs e)
        {
            lbl_error.Visible = false;
            txt_password.UseSystemPasswordChar = true;
        }

        public void get_data()
        {
            SqlConnection con = new SqlConnection(Globals.database);
            SqlCommand cmd = new SqlCommand("select * from Users where Phone = @phone and Password = @password", con);

            cmd.Parameters.AddWithValue("@phone", txt_phone.Text);
            cmd.Parameters.AddWithValue("@password", txt_password.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();

            da.Fill(ds);
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            try
            {
                //  String query = "SELECT * FROM Users WHERE Phone = '" + txt_phone.Text + "' AND Password = '" + "'";
                //  string phone = txt_phone.Text;
                //  string password = txt_password.Text;
                SqlConnection con = new SqlConnection(Globals.database);
                SqlCommand cmd = new SqlCommand("select * from Users where Phone = @phone and Password = @password", con);

                cmd.Parameters.AddWithValue("@phone", txt_phone.Text);
                cmd.Parameters.AddWithValue("@password", txt_password.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //MessageBox.Show("Амжилттай нэвтэрлээ");
                    
                    int uid = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                    lbl_error.Visible = true;
                    lbl_error.Text = "Амжилттай нэвтэрлээ";
                    lbl_error.ForeColor = Color.Green;
                    Console.WriteLine(uid);
                    if (uid == 1) {
                       
                        Main frm = new Main(uid);
                        frm.Show();
                    }
                
                    else
                    {
                        Form1 frm = new Form1(uid);
                        frm.Show();
                    }
               
                   
                    //this.Hide();
                }
                else
                {
                    // MessageBox.Show("Нэвтрэх нэр эсвэл нууц үг буруу байна");
                    //lbl_error.Text = "Нэвтрэх нэр эсвэл нууц үг буруу байна";
                    lbl_error.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ymar nege aldaa" + ex);
            }
        }

        private void kryptonCheckBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (kryptonCheckBox1.Checked == true)
            {
                txt_password.UseSystemPasswordChar = false;
            }
            else
            {
                txt_password.UseSystemPasswordChar = true;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
     
            new SignUp().Show();
            this.Hide();
        }
    }
}

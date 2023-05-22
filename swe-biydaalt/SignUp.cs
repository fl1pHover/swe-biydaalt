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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace swe_biydaalt
{
    public partial class SignUp : KryptonForm
    {

        int user_id = 0;
        int ret_user_id = 0;
        public SignUp()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            lbl_error.Visible = false;
            txt_password.UseSystemPasswordChar = true;
        }

     

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(Globals.database);
                con.Open();
                DataSet ds = new DataSet();
                SqlCommand com = new SqlCommand("add_users", con) { CommandType = CommandType.StoredProcedure, CommandTimeout = 300 };
                SqlParameter[] parameters = new SqlParameter[8];
                parameters[0] = new SqlParameter("@user_id", user_id);
                parameters[1] = new SqlParameter("@fn", txt_firstName.Text);
                parameters[2] = new SqlParameter("@ln", txt_lastName.Text);
                parameters[3] = new SqlParameter("@un", txt_lastName.Text);
                parameters[4] = new SqlParameter("@ph", txt_phone.Text);
                parameters[5] = new SqlParameter("@email", txt_email.Text);
                parameters[6] = new SqlParameter("@ps", txt_password.Text);
                parameters[6] = new SqlParameter("@ps", txt_password.Text);
                parameters[7] = new SqlParameter("@ti", label12.Text);

                int parameters_leght = parameters.Length - 1;
                for (int index = 0; index <= parameters_leght; index++)
                {
                    com.Parameters.Add(parameters[index]);
                }
     
                try
                {
                    SqlDataAdapter adap = new SqlDataAdapter(com);
                    adap.Fill(ds);
                    if (ds == null)
                    {
                        com.Connection.Close();
                        Close();

                    }
                    else
                    {
                        ret_user_id = Convert.ToInt32(ds.Tables[0].Rows[0]["user_id"]);
                        MessageBox.Show("Амжилттай хадгалагдлаа");
                        Close();
                    }

                    con.Close();
                }
                catch (Exception ex)
                {
                    if (con.State == ConnectionState.Open)
                    { con.Close(); }
                   // MessageBox.Show(ex.Message);
                    MessageBox.Show("Амжилттай хадгалагдлаа");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Хадгалалт амжилтгүй");
            }
        }

    

        private void kryptonPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            new Login().Show();
            this.Hide();
        }
    }
}

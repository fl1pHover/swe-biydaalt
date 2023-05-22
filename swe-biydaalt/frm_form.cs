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
using swe_biydaalt.UserControls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace swe_biydaalt
{
    public partial class frm_form : KryptonForm
    {
        int feedback_id = 0;
        int user_id = 0;
       // public static int ret_feedback_id = 0;
        public static int ret_user_id;

        public frm_form()
        {
            InitializeComponent();

        }
        public frm_form(int _u_id)
        {
            InitializeComponent();
         //   feedback_id = _f_id;
            user_id = _u_id;
        }
     


       // public static int get_data(int p_id)
       // {
          //  frm_form frm = new frm_form(p_id);
         //   frm.ShowDialog();
         //   return ret_feedback_id;
      //  }

        public static int get_user(int u_id)
        {
            frm_form frm = new frm_form(u_id);
            frm.ShowDialog();
            return ret_user_id;
        
        }



        private void frm_form_Load(object sender, EventArgs e)
        {
            label3.Text = user_id.ToString();
            SqlConnection con = new SqlConnection(Globals.database);
            con.Open();
            SqlCommand com = new SqlCommand("get_feedback", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adap = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            adap.Fill(ds);
            //  ds.Tables[0].TableName = "Category";



            SqlCommand com1 = new SqlCommand("SELECT * FROM Users WHERE UserID = " + user_id + "", con);
            SqlDataAdapter adap1 = new SqlDataAdapter(com1);
            DataSet ds1 = new DataSet();
            adap1.Fill(ds1);
            if (ds1 == null || ds1.Tables[0].Rows.Count == 0)
            {
                return;
            }

            kryptonComboBox1.DataSource = ds.Tables[1];
            kryptonComboBox1.ValueMember = "FbTypeID";
            kryptonComboBox1.DisplayMember = "FbType";

            kryptonComboBox2.DataSource = ds.Tables[2];
            kryptonComboBox2.ValueMember = "TitleID";
            kryptonComboBox2.DisplayMember = "Title";

            if (ds == null || ds.Tables[0].Rows.Count == 0)
            {
                return;
            }
            lbl_firstName.Text = ds1.Tables[0].Rows[0]["FirstName"].ToString();
            lbl_lastName.Text = ds1.Tables[0].Rows[0]["LastName"].ToString();
            lbl_phone.Text = ds1.Tables[0].Rows[0]["Phone"].ToString();
            lbl_email.Text = ds1.Tables[0].Rows[0]["Email"].ToString();
            label3.Text = ds1.Tables[0].Rows[0]["UserID"].ToString();
        }

 

        private void btn_close_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void txt_send_Click_1(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(Globals.database);
                con.Open();
                DataSet ds = new DataSet();
                SqlCommand com = new SqlCommand("add_feedback", con) { CommandType = CommandType.StoredProcedure, CommandTimeout = 300 };
                SqlParameter[] parameters = new SqlParameter[5];
                parameters[0] = new SqlParameter("@feedback_id", feedback_id);
                parameters[1] = new SqlParameter("@FbTypeID", Convert.ToInt32(kryptonComboBox1.SelectedValue));
                parameters[2] = new SqlParameter("@TitleID", Convert.ToInt32(kryptonComboBox2.SelectedValue));
                parameters[3] = new SqlParameter("@Note", txt_note.Text);
                parameters[4] = new SqlParameter("@UserID", label3.Text);


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
                       // ret_feedback_id = Convert.ToInt32(ds.Tables[0].Rows[0]["feedback_id"]);
                        feedback_id = Convert.ToInt32(ds.Tables[0].Rows[0]["feedback_id"]);
                        MessageBox.Show("Амжилттай хадгалагдлаа");
                        Close();
                    }

                    con.Close();
                }
                catch (Exception ex)
                {
                    if (con.State == ConnectionState.Open)
                    { con.Close(); }
                    MessageBox.Show(ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Хадгалалт амжилтгүй");
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

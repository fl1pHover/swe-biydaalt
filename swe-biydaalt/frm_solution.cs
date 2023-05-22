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
using swe_biydaalt.UserControls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace swe_biydaalt
{
    public partial class frm_solution : KryptonForm
    {
        int feedback_id = 0;
        public static int ret_feedback_id = 0;


        public frm_solution()
        {
            InitializeComponent();

        }
        public frm_solution(int _o_id)
        {
            InitializeComponent();
            feedback_id = _o_id;
        }




        public static int get_data(int o_id)
        {
            frm_solution frm = new frm_solution(o_id);
            frm.ShowDialog();
            return ret_feedback_id;
        }

        private void frm_form_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Globals.database);
            con.Open();
            SqlCommand com = new SqlCommand("get_feedback", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adap = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            adap.Fill(ds);
            //ds.Tables[0].TableName = "Orders";

            label3.Text = feedback_id.ToString();

            SqlCommand com1 = new SqlCommand("select a.*,  b.Phone,b.FirstName, b.LastName, b.Email, c.Title from Feedbacks a inner join Users b on a.UserID = " +
            "b.UserID inner join FeedbackTitle c on a.TitleID = c.TitleID where FeedbackID = " + feedback_id + "", con);
            SqlDataAdapter adap1 = new SqlDataAdapter(com1);
            DataSet ds1 = new DataSet();

            adap1.Fill(ds1);
            if (ds1 == null || ds1.Tables[0].Rows.Count == 0)
            {
                return;
            }
            lbl_firstName.Text = ds1.Tables[0].Rows[0]["FirstName"].ToString();
            lbl_lastName.Text = ds1.Tables[0].Rows[0]["LastName"].ToString();
            lbl_email.Text = ds1.Tables[0].Rows[0]["Email"].ToString();
            lbl_phone.Text = ds1.Tables[0].Rows[0]["Phone"].ToString();
            lbl_title.Text = ds1.Tables[0].Rows[0]["Title"].ToString();
            lbl_note.Text = ds1.Tables[0].Rows[0]["Note"].ToString();
            txt_solution.Text = ds1.Tables[0].Rows[0]["Solution"].ToString();
        }

 

        private void btn_close_Click_1(object sender, EventArgs e)
        {
            Close();
        }

       

        private void label8_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txt_send_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(Globals.database);
                con.Open();
                DataSet ds = new DataSet();
                SqlCommand com = new SqlCommand("add_solution", con) { CommandType = CommandType.StoredProcedure, CommandTimeout = 300 };
                SqlParameter[] parameters = new SqlParameter[2];

                parameters[0] = new SqlParameter("@feedback_id", feedback_id);
                parameters[1] = new SqlParameter("@Solution", txt_solution.Text);


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
                        ret_feedback_id = Convert.ToInt32(ds.Tables[0].Rows[0]["feedback_id"]);
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
            catch
            {
                MessageBox.Show("Хадгалалт амжилтгүй");
            }
        }
    }
}

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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace swe_biydaalt.UserControls
{
    public partial class uc_users : UserControl
    {

        public int selected_user;
        public uc_users()
        {
            InitializeComponent();
        }

        private void uc_feedback_Load(object sender, EventArgs e)
        {
            get_data();
         
        }


        private void get_data()
        {
            SqlConnection con = new SqlConnection(Globals.database);
            con.Open();
            string query = "SELECT * from Users Where TypeID = '2'";
            SqlDataAdapter adap = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            adap.Fill(ds);
            kryptonDataGridView1.DataSource = ds.Tables[0];

            this.kryptonDataGridView1.Columns["TypeID"].Visible = false;
            this.kryptonDataGridView1.Columns["Password"].Visible = false;
        }

        private void kryptonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (kryptonDataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                kryptonDataGridView1.CurrentRow.Selected = true;
                selected_user = int.Parse(kryptonDataGridView1.SelectedCells[0].FormattedValue.ToString());
                label1.Text = selected_user.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
        
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Globals.database);
            con.Open();
            SqlCommand cmd = new SqlCommand("del_Users", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@uid", selected_user);
            cmd.Parameters.Add(param[0]);




            string mes = "Та итгэлтэй байна уу?";
            string title = "Warning";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(mes, title, buttons);

            try
            {
                if (result == DialogResult.Yes)
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Амжилттай устгалаа");
                    get_data();

                }
                else
                {

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

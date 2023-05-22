using System;
using System.Collections;
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
    public partial class uc_feedback : UserControl
    {

        public int oid;
        public uc_feedback()
        {
            InitializeComponent();
            
        }

        private void kryptonRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            get_data();
        }
        private void uc_feedback_Load(object sender, EventArgs e)
        {
            get_data();
        }

         public void get_data()
        {
            SqlConnection con = new SqlConnection(Globals.database);
            con.Open();    
            string query = "select a.*, b.Username, b.Phone, c.Title from Feedbacks a inner join Users b on a.UserID = " +
           "b.UserID inner join FeedbackTitle c on a.TitleID = c.TitleID where FbTypeID = '3'";
            SqlDataAdapter adap = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            adap.Fill(ds);
            kryptonDataGridView1.DataSource = ds.Tables[0];
            this.kryptonDataGridView1.Columns["UserID"].Visible = false;
            this.kryptonDataGridView1.Columns["TitleID"].Visible = false;
            this.kryptonDataGridView1.Columns["FbTypeID"].Visible = false;   
            //  string query = "select a.*, b.Username, c.Title from Feedbacks a inner join Users b on a.UserID = b.UserID inner join FeedbackTitle c on a.TitleID = c.TitleID where FbTypeID = '3'";
        }



  
    

        private void kryptonRadioButton1_CheckedChanged_2(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Globals.database);
            con.Open();
            string query = "select a.*, b.Username, b.Phone, c.Title from Feedbacks a inner join Users b on a.UserID = " +
            "b.UserID inner join FeedbackTitle c on a.TitleID = c.TitleID where FbTypeID = '3' and Solution is null";
            SqlDataAdapter adap = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            adap.Fill(ds);
            kryptonDataGridView1.DataSource = ds.Tables[0];
            this.kryptonDataGridView1.Columns["UserID"].Visible = false;
            this.kryptonDataGridView1.Columns["TitleID"].Visible = false;
            this.kryptonDataGridView1.Columns["FbTypeID"].Visible = false;
        }

        private void kryptonRadioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Globals.database);
            con.Open();
            string query = "select a.*, b.Username, b.Phone, c.Title from Feedbacks a inner join Users b on a.UserID = " +
            "b.UserID inner join FeedbackTitle c on a.TitleID = c.TitleID where FbTypeID = '3' and Solution is not null";
            SqlDataAdapter adap = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            adap.Fill(ds);
            kryptonDataGridView1.DataSource = ds.Tables[0];
            this.kryptonDataGridView1.Columns["UserID"].Visible = false;
            this.kryptonDataGridView1.Columns["TitleID"].Visible = false;
            this.kryptonDataGridView1.Columns["FbTypeID"].Visible = false;
        }

        private void kryptonRadioButton3_CheckedChanged_1(object sender, EventArgs e)
        {
            get_data();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = kryptonDataGridView1.CurrentRow;
            //  int id = Convert.ToInt32(row.Cells["OrderID"].Value);
            int id = Convert.ToInt32(kryptonDataGridView1.SelectedCells[0].Value);
            oid = id;
            int ret_id = frm_solution.get_data(oid);
            get_data();
            if (id != 0)
            {
                kryptonDataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                kryptonDataGridView1.ClearSelection();

                foreach (DataGridViewRow item in kryptonDataGridView1.Rows)
                {
                    if (Convert.ToInt32(item.Cells[0].Value) == id)
                    {
                        item.Selected = true;
                        kryptonDataGridView1.FirstDisplayedScrollingRowIndex = item.Index;
                        return;
                    }
                }
            }
        }

        private void kryptonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (kryptonDataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                kryptonDataGridView1.CurrentRow.Selected = true;
                oid = int.Parse(kryptonDataGridView1.SelectedCells[0].FormattedValue.ToString());
                label1.Text = oid.ToString();
            }
        }
    }
}

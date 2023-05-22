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
    public partial class uc_form : UserControl
    {
        int user_id = 0;

        public static frm_form formInstance;
        public uc_form(int u_id)
        {
            InitializeComponent();
            user_id = u_id;
        }

        private void get_data()
        {
            SqlConnection con = new SqlConnection(Globals.database);
            con.Open();
       
            SqlDataAdapter adap = new SqlDataAdapter("Select *, b.FbType, c.Title from Feedbacks a inner join FeedbackTypes b on " +
                "b.FbTypeID = a.FbTypeID inner join FeedbackTitle c on c.TitleID= a.TitleID where UserID ='" + user_id + "'", con);
            DataSet ds = new DataSet();
            adap.Fill(ds);

           // kryptonDataGridView1.AutoGenerateColumns = false;
            kryptonDataGridView1.DataSource = ds.Tables[0];
            this.kryptonDataGridView1.Columns["UserID"].Visible = false;
            this.kryptonDataGridView1.Columns["TitleID"].Visible = false;
            this.kryptonDataGridView1.Columns["FeedbackID"].Visible = false;
            //this.kryptonDataGridView1.Columns["FbTypeID"].Visible = false;



        }
        private void UserControl2_Load(object sender, EventArgs e)
        {
             label1.Text = user_id.ToString();
             get_data();
        }

     

        private void kryptonButton1_Click_1(object sender, EventArgs e)
        {
            // int id = 0;
            // int[] tmp = new int[2] { user_id, id};
            //frm_form.get_data(tmp);
        
            // int uid = frm_form.get_user(user_id);
            int asd = frm_form.get_user(user_id);
            get_data();
            //int id = frm_form.get_data(0);
           // if (id != 0)
           // {
            //    kryptonDataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
           //     kryptonDataGridView1.ClearSelection
             //   foreach (DataGridViewRow item in kryptonDataGridView1.Rows)
            //    {
            //        if (Convert.ToInt32(item.Cells[0].Value) == id)
            //        {
            //            item.Selected = true;
             //           kryptonDataGridView1.FirstDisplayedScrollingRowIndex = item.Index;
            //            return;
             //       }
            //   }
            //}

        }
    }
}

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
    public partial class uc_complaint : UserControl
    {
        public uc_complaint()
        {
            InitializeComponent();
        }

        private void uc_complaint_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Globals.database);
            con.Open();
            string query = "select a.*, b.Username, b.Phone, c.Title from Feedbacks a inner join Users b on a.UserID = b.UserID inner join FeedbackTitle c on a.TitleID = c.TitleID where FbTypeID = '2'";
            SqlDataAdapter adap = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            adap.Fill(ds);
            kryptonDataGridView1.DataSource = ds.Tables[0];
            this.kryptonDataGridView1.Columns["UserID"].Visible = false;
            this.kryptonDataGridView1.Columns["TitleID"].Visible = false;
            this.kryptonDataGridView1.Columns["FbTypeID"].Visible = false;
        }
    }
}

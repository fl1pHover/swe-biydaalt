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
    public partial class uc_dashboard : UserControl
    {

        int u_id;
        public uc_dashboard(int _u_id)
        {
            InitializeComponent();
            u_id = _u_id;
        }

        SqlConnection conn = new SqlConnection(Globals.database);

        private void uc_dashboard_Load(object sender, EventArgs e)
        {
            CountFeedback();
            CountComplaint();
            CountUsers();
            // label5.Text = u_id.ToString();
        }

        private void CountFeedback()
        {
            SqlDataAdapter ad = new SqlDataAdapter("select count(*)-2 from Feedbacks where FbTypeID = '3'", conn);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            txt_countFeedback.Text = dt.Rows[0][0].ToString();
        }
        private void CountComplaint()
        {
            SqlDataAdapter ad = new SqlDataAdapter("select count(*)-2 from Feedbacks where FbTypeID = '2'", conn);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            txt_countComplaint.Text = dt.Rows[0][0].ToString();
        }
        private void CountUsers()
        {
            SqlDataAdapter ad = new SqlDataAdapter("select count(UserID) from Feedbacks", conn);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            txt_countUsers.Text = dt.Rows[0][0].ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using swe_biydaalt.UserControls;

namespace swe_biydaalt
{
    public partial class Main : KryptonForm
    {

        int user_id = 0;
        public Main()
        {
            InitializeComponent();
        }
        public Main(int _user_id)
        {
            InitializeComponent();
            user_id = _user_id;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            uc_dashboard ud = new uc_dashboard(user_id);
            ud.Dock = DockStyle.Fill;
            uc_panel.Controls.Clear();
            uc_panel.Controls.Add(ud);
          if ( user_id == 1)
            {
                label1.Text = "Admin";
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
        

        }


       
        private void kryptonButton5_Click(object sender, EventArgs e)
        {
            // User Dashboard button
            uc_dashboard ud = new uc_dashboard(user_id);
            ud.Dock = DockStyle.Fill;
            uc_panel.Controls.Clear();
            uc_panel.Controls.Add(ud);
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            // User feedback button
            uc_feedback uf = new uc_feedback();
            uf.Dock = DockStyle.Fill;
            uc_panel.Controls.Clear();
            uc_panel.Controls.Add(uf);
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            uc_users uu = new uc_users();
            uu.Dock = DockStyle.Fill;
            uc_panel.Controls.Clear();
            uc_panel.Controls.Add(uu);
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            uc_complaint ucom = new uc_complaint();
            ucom.Dock = DockStyle.Fill;
            uc_panel.Controls.Clear();
            uc_panel.Controls.Add(ucom);
        }

        private void kryptonButton1_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            UserControl1 ur = new UserControl1();
            ur.Dock = DockStyle.Fill;
            uc_panel.Controls.Clear();
            uc_panel.Controls.Add(ur);
        }
    }
}

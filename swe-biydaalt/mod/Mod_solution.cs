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
    public partial class Mod_solution : KryptonForm
    {
        int u_id;
        public Mod_solution(int _u_id)
        {
            InitializeComponent();
            u_id = _u_id;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            uc_dashboard ud = new uc_dashboard(u_id);
            ud.Dock = DockStyle.Fill;
      
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
        

        }


       
  
    }
}

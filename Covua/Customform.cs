using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Covua
{
    // main solotion
    public partial class Customform : Form
    {
        public Customcontrol.Border border;
        public Customform()
        {
            InitializeComponent();
        }
        private void Customform_Load(object sender, EventArgs e)
        {
            border = new Customcontrol.Border(this, Color.FromArgb(64, 241, 64), Color.White,true,true);
        }
    }
}

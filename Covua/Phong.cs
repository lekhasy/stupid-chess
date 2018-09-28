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
    
    public partial class Phong : Customform
    {
        public event dlgPhongchoosed PhongChoosed = null;
        SetupProfile _profile;
        public SetupProfile Profile
        {
            get { return _profile; }
            set
            {
                _profile = value;
                border.BorderColor = value.AppBorderColor;
                border.TitleColor = value.AppTitleColor;
                Refresh();
            }
        }
        public Phong(SetupProfile profile)
        {
            InitializeComponent();
            _profile = profile;
        }

        private void Phong_Load(object sender, EventArgs e)
        {
            border.Resizeable = false;
            pictureBox1.Image = Image.FromFile(AppResource.AppPaths.GetChessmanPNGPath("Xe_Xanh.png"));
            pictureBox2.Image = Image.FromFile(AppResource.AppPaths.GetChessmanPNGPath("Ngua_Xanh.png"));
            pictureBox3.Image = Image.FromFile(AppResource.AppPaths.GetChessmanPNGPath("Tuong_Xanh.png"));
            pictureBox4.Image = Image.FromFile(AppResource.AppPaths.GetChessmanPNGPath("Hau_Xanh.png"));
            Profile = _profile;
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            PhongChoosed(this, new PhongEventArgs(1));
            Close();
        }

        private void pictureBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            PhongChoosed(this, new PhongEventArgs(2));
            Close();
        }

        private void pictureBox3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            PhongChoosed(this, new PhongEventArgs(3));
            Close();
        }

        private void pictureBox4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            PhongChoosed(this,new PhongEventArgs(4));
            Close();
        }
    }
    public delegate void dlgPhongchoosed(object sender, PhongEventArgs e);
    public class PhongEventArgs : EventArgs
    {
        public int Chessnumber;
        public PhongEventArgs(int number)
        {
            Chessnumber = number;
        }
    }
}

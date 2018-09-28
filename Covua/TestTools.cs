using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;
namespace Covua
{
    public partial class TestTools : Customform
    {
        public event dlgNewSettingChoosed NewSettingChoosed;
        public TestTools()
        {
            InitializeComponent();
        }

        private void TestTools_Load(object sender, EventArgs e)
        {
            border.Resizeable = false;
            try
            {
                Stream str = File.Open(AppResource.AppPaths.GetProfileFilePath("save000.sav"), FileMode.Open);
                SetupProfile profile = (SetupProfile)new BinaryFormatter().Deserialize(str);
                str.Close();
                pictureBox1.BackColor = profile.AppBorderColor;
                pictureBox2.BackColor = profile.AppBorderColor;
                pictureBox3.BackColor = profile.AppTitleColor;
                pictureBox4.BackColor = profile.AppTitleColor;
                rdb_delete.Checked = true;
                rdb_normnal.Checked = profile.ISNormnalmode;
                cbx_ConseMove.Checked = profile.ConseMove;
                cbx_EnemyMove.Checked = profile.EnemyMove;
                cbx_NoMoveCheck.Checked = profile.FreeMove;
                numericUpDown1.Value = profile.Inteligent;
                this.border.BorderColor = profile.AppBorderColor;
                this.border.TitleColor = profile.AppTitleColor;
            }catch(IOException ex)
            {
                MessageBox.Show(ex.Message);
                Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            colorDialog1.Color = pictureBox2.BackColor;
            colorDialog1.ShowDialog();
            pictureBox2.BackColor = colorDialog1.Color;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox2.BackColor = this.border.BackColor;
        }

        private void rdb_delete_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_delete.Checked)
            {
                cbx_ConseMove.Enabled = cbx_EnemyMove.Enabled = cbx_NoMoveCheck.Enabled = false;
            }
        }

        private void rdb_normnal_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_normnal.Checked)
            {
                cbx_ConseMove.Enabled = cbx_EnemyMove.Enabled = cbx_NoMoveCheck.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetupProfile profile = new SetupProfile(pictureBox2.BackColor,pictureBox4.BackColor, rdb_normnal.Checked, cbx_EnemyMove.Checked, cbx_NoMoveCheck.Checked, cbx_ConseMove.Checked,(int)numericUpDown1.Value);
            try
            {
                Stream str = File.Open(AppResource.AppPaths.GetProfileFilePath("save000.sav"), FileMode.Create);
                new BinaryFormatter().Serialize(str, profile);
                str.Close();
                NewSettingChoosed(this, profile);
                this.Close();
            }
            catch(IOException ex)
            {
                MessageBox.Show(ex.Message);
                Application.Exit();
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.border.TitleColor = pictureBox4.BackColor;
            this.border.BorderColor = pictureBox2.BackColor;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = pictureBox4.BackColor;
            colorDialog1.ShowDialog();
            pictureBox4.BackColor = colorDialog1.Color;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox4.BackColor = pictureBox3.BackColor;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public delegate void dlgNewSettingChoosed(object sender, SetupProfile e);

    [Serializable]
    public class SetupProfile : EventArgs
    {
        public bool ISNormnalmode;
        public bool EnemyMove;
        public bool FreeMove;
        public bool ConseMove;
        public int Inteligent;
        public Color AppBorderColor;
        public Color AppTitleColor;
        public SetupProfile(Color colorborder, Color colortitle, bool normnal, bool enemymove,bool freemove, bool consemove, int inteligent)
        {
            AppBorderColor = colorborder;
            AppTitleColor = colortitle;
            FreeMove = freemove;
            EnemyMove = enemymove;
            ISNormnalmode = normnal;
            ConseMove = consemove;
            Inteligent = inteligent;
        }
    }
}

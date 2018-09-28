using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Input;

namespace Covua.Customcontrol
{
    /// <summary>
    /// Lớp này làm nhiệm vụ chuyển đổi hình ảnh của các picturebox, làm code gọn hơn
    /// </summary>
    public class Swaper
    {
        public Swaper(PictureBox ctr, Image img1, Image img2)
        {
            ctr.Image = img1;
            ctr.MouseEnter += delegate(object sender, EventArgs e)
            {
                ctr.Image = img2;
            };

            ctr.MouseLeave += delegate(object sender, EventArgs e)
            {
                ctr.Image = img1;
            };
            ctr.MouseDown += delegate(object sender, MouseEventArgs e)
            {
                ctr.Image = img1;
            };
            ctr.MouseUp += delegate(object sender, MouseEventArgs e)
            {
               ctr.Image = img2;
            };

        }
    }
}

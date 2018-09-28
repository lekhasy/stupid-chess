using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Covua.Customcontrol
{
    public partial class Border
    {

        Size Miniumsize
        {
            get { return new Size(40+OpacityTrackbar.Width + MiniBox.Width * 3, this.Height * 2); }
        }

        int Widthprpt
        {
            get { return _frm.Width; }
            set
            {
                if (value > Miniumsize.Width)
                {
                    _frm.Width = value;
                }
            }
        }

        public Color BorderColor
        {
            get { return this.BackColor; }
            set
            {
                this.BackColor = value;
                _frm.CreateGraphics().DrawRectangle(new Pen(Title.BackColor), new Rectangle(0, 0, _frm.Width - 1, _frm.Height - 1));
            }
        }

        public Color TitleColor
        {
            get { return Title.ForeColor; }
            set
            {
                Title.ForeColor = value;
            }
        }

        int Heighprpt
        {
            get { return _frm.Height; }
            set
            {
                if (value > Miniumsize.Height)
                {
                    _frm.Height = value;
                }
            }
        }

        /// <summary>
        /// Tạo một thể hiện mới với các tham số được truyền vào
        /// </summary>
        /// <param name="frm">Form chứa Border này</param>
        /// <param name="backcolor">màu nền của Border</param>
        /// <param name="textcolor">Màu chữ tiêu đề của Border</param>
        /// <param name="textsize">Kích thước chữ tiêu đề của Border</param>
        /// <param name="controlmoveable">Các control có thể được di chuyển như Border khi dùng Border này</param>
        public Border(Form frm, Color backcolor, Color textcolor, bool backgroundMoveable, bool resizeable)
        {
            _frm = frm;
            _frm.FormBorderStyle = FormBorderStyle.None;
            BackgroundMoveable = backgroundMoveable;
            Resizeable = resizeable;
            
            AddFormMoveableControls(this, Title);
            
            InitializeComponent(backcolor, textcolor);

            // add event to control
            frm.MouseMove += delegate(object sender, MouseEventArgs e)
            {
                if (e.Y < Height / 2)
                {
                    Timer1.Start();
                    Timer2.Stop();
                }
                else
                {
                    Timer2.Start();
                    Timer1.Stop();
                }
            };

            frm.SizeChanged += delegate(object sender, EventArgs e)
            {
                this.Width = frm.Width;
                CloseBox.Location = new Point(Width - CloseBox.Width, 0);
                NormnalBox.Location = new Point(Width - NormnalBox.Width * 2, 0);
                MiniBox.Location = new Point(Width - MiniBox.Width * 3, 0);
                OpacityTrackbar.Location = new Point(MiniBox.Left - OpacityTrackbar.Width - 5, 2);
                Title.Width = OpacityTrackbar.Left;
                frm.Refresh();
            };

            frm.Paint += delegate(object sender, PaintEventArgs e)
            {
                e.Graphics.DrawRectangle(new Pen(Title.BackColor), new Rectangle(0, 0, frm.Width - 1, frm.Height - 1));
            };


            Controls.Add(Title);
            Controls.Add(OpacityTrackbar);
            Controls.Add(MiniBox);
            Controls.Add(NormnalBox);
            Controls.Add(CloseBox);
            frm.Controls.Add(this);
            this.BringToFront();
        }
    }
}

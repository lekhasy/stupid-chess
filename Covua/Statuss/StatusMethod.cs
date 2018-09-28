using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Covua
{
    public partial class Status
    {
        public Status(Typeconstructor type)
        {
            if (type == Typeconstructor.Arranged)
            {
                // sắp xếp các quân cờ
                Map[0, 0] = new AllChessman.Xe(Team.Computer, new Index(0, 0), this);
                Map[0, 1] = new AllChessman.Ngua(Team.Computer, new Index(0, 1), this);
                Map[0, 2] = new AllChessman.Tuong(Team.Computer, new Index(0, 2), this);
                Map[0, 3] = new AllChessman.Hau(Team.Computer, new Index(0, 3), this);
                Map[0, 4] = new AllChessman.Vua(Team.Computer, new Index(0, 4), this);
                Map[0, 5] = new AllChessman.Tuong(Team.Computer, new Index(0, 5), this);
                Map[0, 6] = new AllChessman.Ngua(Team.Computer, new Index(0, 6), this);
                Map[0, 7] = new AllChessman.Xe(Team.Computer, new Index(0, 7), this);

                for (int i = 0; i < 8; i++)
                {
                    Map[1, i] = new AllChessman.Tot(Team.Computer, new Index(1, i), this);
                    Map[6, i] = new AllChessman.Tot(Team.Man, new Index(6, i), this);
                }

                Map[7, 0] = new AllChessman.Xe(Team.Man, new Index(7, 0), this);
                Map[7, 1] = new AllChessman.Ngua(Team.Man, new Index(7, 1), this);
                Map[7, 2] = new AllChessman.Tuong(Team.Man, new Index(7, 2), this);
                Map[7, 3] = new AllChessman.Hau(Team.Man, new Index(7, 3), this);
                Map[7, 4] = new AllChessman.Vua(Team.Man, new Index(7, 4), this);
                Map[7, 5] = new AllChessman.Tuong(Team.Man, new Index(7, 5), this);
                Map[7, 6] = new AllChessman.Ngua(Team.Man, new Index(7, 6), this);
                Map[7, 7] = new AllChessman.Xe(Team.Man, new Index(7, 7), this);
                Luot = Team.Computer;
                Finished = false;
            }
        }

        /// <summary>
        /// Lấy một bản sao của status này
        /// </summary>
        /// <returns></returns>
        public Status Getcopy()
        {
            Status rtstatus = new Status(Typeconstructor.Null);
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Map[i,j]!=null)
                    {
                        rtstatus.Map[i, j] = Map[i, j].GetCopy();
                        rtstatus.Map[i, j].Owner = rtstatus;
                    }
                }
            }
            rtstatus.Luot = Luot;
            rtstatus.Finished = Finished;
            return rtstatus;
        }
        public Status Move(Index From, Index To)
        {
            Status rtstatus = this.Getcopy();
            if (rtstatus.Map[To.I,To.J] is AllChessman.Vua)
            {
               rtstatus.Finished = true;
            }
            rtstatus.Map[To.I, To.J] = rtstatus.Map[From.I, From.J];
            rtstatus.Map[From.I, From.J] = null;
            rtstatus.Map[To.I, To.J].index = To;
            if (rtstatus.Map[To.I,To.J] is AllChessman.Tot)
            {
                ((AllChessman.Tot)rtstatus.Map[To.I, To.J]).moved = true;
            }
            rtstatus.Luot = Luot == Team.Computer ? Team.Man : Team.Computer;
            return rtstatus;
        }

        public void Show(Graphics gr)
        {
            // Vẽ nền
            Brush brush = Brushes.White;
            for (int i = 0; i < 8; i++)
            {
                brush = i % 2 == 0 ? Brushes.White : Brushes.Black;
                for (int j = 0; j < 8; j++)
                {
                    gr.FillRectangle(brush, new Rectangle(new Point(Left + Unitsize.Height * j, Top + Unitsize.Height * i), Unitsize));
                    brush = brush == Brushes.White ? Brushes.Black : Brushes.White;
                }
            }
            gr.DrawRectangle(new Pen(Bordercolor), Left, Top, Unitsize.Height * 8, Unitsize.Height * 8);

            
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Map[i, j] != null)
                    {
                        gr.DrawImage(Map[i, j].GetOwnImage(), GetLocation(i, j));
                    }
                }
            }
            if (Luot == Team.Man)
            {
                gr.FillEllipse(Brushes.Red, Right + Unitsize.Height/5, Top, Unitsize.Height/4, Unitsize.Height/4);
            }
            else
            {
                gr.FillEllipse(Brushes.Green, Right + Unitsize.Height/5, Bottom - Unitsize.Height/4, Unitsize.Height/4, Unitsize.Height/4);
            }
        }
    }
}

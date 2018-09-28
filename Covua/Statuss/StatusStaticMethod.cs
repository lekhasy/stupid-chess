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
        public static void UpdateScreensize(Size Screensize)
        {
            if (Screensize.Height<Screensize.Width)
            {
                Unitsize = new Size(Screensize.Height / 9, Screensize.Height / 9);    
            }
            else
            {
                Unitsize = new Size(Screensize.Width / 9, Screensize.Width / 9);    
            }
            
            Top = Unitsize.Height / 2;
            Left = (Screensize.Width / 2) - 4 * Unitsize.Height;
        }
       
       
        /// <summary>
        /// Trả về vị trí Top, left của một ô
        /// </summary>
        /// <param name="i">Số hàng</param>
        /// <param name="j">Sô cột</param>
        /// <returns></returns>
        public static Point GetLocation(int i, int j)
        {
            return new Point(Left + j * Unitsize.Height, Top + i * Unitsize.Height);
        }

        /// <summary>
        /// Trả về Index của Maps từ một điểm ảnh trên màn hình
        /// </summary>
        /// <param name="ClickedPoint">Điểm cần xác định</param>
        /// <returns>Index tương ứng với vị trí</returns>
        public static Index IndexFromPoint(Point ClickedPoint)
        {
            
            if (ClickedPoint.X>Left&&ClickedPoint.X<Right&&ClickedPoint.Y>Top&&ClickedPoint.Y<Bottom)
            {
                Index rtPoint = new Index(-1, -1);
                rtPoint.J =( ClickedPoint.X - Left) / Unitsize.Height;
                rtPoint.I =( ClickedPoint.Y - Top) / Unitsize.Height;
                return rtPoint;
            }
            return null;
        }

        public static void HightLight(Index Index,Graphics gr)
        {
            gr.FillRectangle(Brushes.Red,new Rectangle(GetLocation(Index.I, Index.J),new Size(Unitsize.Height/5,Unitsize.Height/5)));
        }

        public static bool InSide(Index index)
        {
            if (index.I>-1&&index.I<8&&index.J>-1&&index.J<8)
            {
                return true;
            }
            return false;
        }
    }
}

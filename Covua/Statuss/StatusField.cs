using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Covua
{
    [Serializable]
    public partial class Status
    {
        public static int Top;
        public static int Left;
        private static Size _unitsize = new Size(5,5);
        public AllChessman.Quanco[,] Map = new AllChessman.Quanco[8, 8];
        public static Color Bordercolor;

        /// <summary>
        /// true nếu một trong hai bên ko còn vua, false nếu ngược lại
        /// </summary>
        public bool Finished = false;

        /// <summary>
        /// Biểu diễn lượt của ai đã tạo nên trạng thái này
        /// </summary>
        public Team Luot = Team.Computer;

        public static int Bottom
        {
            get { return Top + 8 * Unitsize.Height; }
        }
        public static int Right
        {
            get { return Left + 8 * Unitsize.Height; }
        }
        public static Point Location
        {
            get { return new Point(Left, Top); }
        }
        public static Size Unitsize
        {
            get { return Status._unitsize; }
            set
            {
                Status._unitsize = value;
                AppResource.AppImage.ResourceInitialize(Unitsize.Height);
            }
        }
        
    }
}

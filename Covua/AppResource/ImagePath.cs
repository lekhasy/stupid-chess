using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covua.AppResource
{
    public partial class AppPaths
    {
        private static string ImagePath
        {
            get { return ApplicationFolder + @"Image\"; }
        }
        private static string ButtonIcon
        {
            get { return ImagePath + @"ButtonIcon\"; }
        }

        private static string ChessmanPNG
        {
            get { return ImagePath + @"Chessman\"; }
        }
        public static string GetbuttonIconpath(string imagename)
        {
            return ButtonIcon + imagename;
        }

        public static string GetChessmanPNGPath(string imagename)
        {
            return ChessmanPNG+imagename;
        }
        
    }
}

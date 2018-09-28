using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Covua.AppResource
{
    public class AppImage
    {
        public static Image ResizeImage(Image img, int width, int height)
        {
            Bitmap b = new Bitmap(width, height);
            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = InterpolationMode.Bicubic;
            g.DrawImage(img, 0, 0, width, height);
            g.Dispose();
            img.Dispose();
            return (Image)b;
        }
        public static void ResourceInitialize(int size)
        {
            // title icon
            PNGIcons.close1 = Image.FromFile(AppPaths.GetbuttonIconpath("close1.png"));
            PNGIcons.close2 = Image.FromFile(AppPaths.GetbuttonIconpath("close2.png"));
            PNGIcons.mini1 = Image.FromFile(AppPaths.GetbuttonIconpath("mini1.png"));
            PNGIcons.mini2 = Image.FromFile(AppPaths.GetbuttonIconpath("mini2.png"));
            PNGIcons.normnal1 = Image.FromFile(AppPaths.GetbuttonIconpath("normnal1.png"));
            PNGIcons.normnal2 = Image.FromFile(AppPaths.GetbuttonIconpath("normnal2.png"));

            // button icon
            PNGIcons.setup1 = Image.FromFile(AppPaths.GetbuttonIconpath("setup1.png"));
            PNGIcons.setup2 = Image.FromFile(AppPaths.GetbuttonIconpath("setup2.png"));
            PNGIcons.reload1 = Image.FromFile(AppPaths.GetbuttonIconpath("reload1.png"));
            PNGIcons.reload2 = Image.FromFile(AppPaths.GetbuttonIconpath("reload2.png"));
            PNGIcons.next1  = Image.FromFile(AppPaths.GetbuttonIconpath("next1.png"));
            PNGIcons.next2 = Image.FromFile(AppPaths.GetbuttonIconpath("next2.png"));
            PNGIcons.prev1 = Image.FromFile(AppPaths.GetbuttonIconpath("prev1.png"));
            PNGIcons.prev2 = Image.FromFile(AppPaths.GetbuttonIconpath("prev2.png"));
            PNGIcons.bottom1 = Image.FromFile(AppPaths.GetbuttonIconpath("bottom1.png"));
            PNGIcons.bottom2 = Image.FromFile(AppPaths.GetbuttonIconpath("bottom2.png"));
            PNGIcons.Top1 = Image.FromFile(AppPaths.GetbuttonIconpath("top1.png"));
            PNGIcons.Top2 = Image.FromFile(AppPaths.GetbuttonIconpath("top2.png"));
            PNGIcons.abort1 = Image.FromFile(AppPaths.GetbuttonIconpath("abort1.png"));
            PNGIcons.abort2 = Image.FromFile(AppPaths.GetbuttonIconpath("abort2.png"));
            PNGIcons.save1 = Image.FromFile(AppPaths.GetbuttonIconpath("save1.png"));
            PNGIcons.save2 = Image.FromFile(AppPaths.GetbuttonIconpath("save2.png"));
            PNGIcons.open1 = Image.FromFile(AppPaths.GetbuttonIconpath("open1.png"));
            PNGIcons.open2 = Image.FromFile(AppPaths.GetbuttonIconpath("open2.png"));


            // Chessman
            PNGChessMan.Vua_Xanh = ResizeImage(Image.FromFile(AppPaths.GetChessmanPNGPath("Vua_Xanh.png")), size, size);
            PNGChessMan.Hau_Xanh = ResizeImage(Image.FromFile(AppPaths.GetChessmanPNGPath("Hau_Xanh.png")), size, size);
            PNGChessMan.Tuong_Xanh = ResizeImage(Image.FromFile(AppPaths.GetChessmanPNGPath("Tuong_Xanh.png")), size, size);
            PNGChessMan.Ngua_Xanh = ResizeImage(Image.FromFile(AppPaths.GetChessmanPNGPath("Ngua_Xanh.png")), size, size);
            PNGChessMan.Xe_Xanh = ResizeImage(Image.FromFile(AppPaths.GetChessmanPNGPath("Xe_Xanh.png")), size, size);
            PNGChessMan.Tot_Xanh = ResizeImage(Image.FromFile(AppPaths.GetChessmanPNGPath("Tot_Xanh.png")), size, size);
            PNGChessMan.Vua_Vang = ResizeImage(Image.FromFile(AppPaths.GetChessmanPNGPath("Vua_Vang.png")), size, size);
            PNGChessMan.Hau_Vang = ResizeImage(Image.FromFile(AppPaths.GetChessmanPNGPath("Hau_Vang.png")), size, size);
            PNGChessMan.Tuong_Vang = ResizeImage(Image.FromFile(AppPaths.GetChessmanPNGPath("Tuong_Vang.png")), size, size);
            PNGChessMan.Ngua_Vang = ResizeImage(Image.FromFile(AppPaths.GetChessmanPNGPath("Ngua_Vang.png")), size, size);
            PNGChessMan.Xe_Vang = ResizeImage(Image.FromFile(AppPaths.GetChessmanPNGPath("Xe_Vang.png")), size, size);
            PNGChessMan.Tot_Vang = ResizeImage(Image.FromFile(AppPaths.GetChessmanPNGPath("Tot_Vang.png")), size, size);

            // Arrays
            AllChessman.Hau.MoveIndex = new int[] { 7, 7, 7, 7, 7, 7, 7, 7 };
            AllChessman.Ngua.MoveIndex = new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };
            AllChessman.Tuong.MoveIndex = new int[] { 0, 0, 0, 0, 7, 7, 7, 7 };
            AllChessman.Vua.MoveIndex = new int[] { 1, 1, 1, 1, 1, 1, 1, 1 };
            AllChessman.Xe.MoveIndex = new int[] { 7, 7, 7, 7, 0, 0, 0, 0 };

            // con tốt chưa di chuyển thì sẽ di chuyển được 2 ô, đã di chuyển rồi thì chỉ đi đc 1 ô
            AllChessman.Tot.MoveIndex = new int[] { 0, 0, 0, 2, 0, 1, 0, 1 }; // máy, chưa
            AllChessman.Tot.MoveIndex1 = new int[] { 0, 0, 2, 0, 1, 0, 1, 0 }; // người, chưa
            AllChessman.Tot.MoveIndex2 = new int[] { 0, 0, 0, 1, 0, 1, 0, 1 }; // máy, rồi
            AllChessman.Tot.MoveIndex3 = new int[] { 0, 0, 1, 0, 1, 0, 1, 0 }; // người, rồi
        }
        public class PNGIcons
        {
            public static Image close1;
            public static Image close2;
            public static Image mini1;
            public static Image mini2;
            public static Image normnal1;
            public static Image normnal2;
            public static Image setup1;
            public static Image setup2;
            public static Image reload1;
            public static Image reload2;
            public static Image next1;
            public static Image next2;
            public static Image prev1;
            public static Image prev2;
            public static Image Top1;
            public static Image Top2;
            public static Image bottom1;
            public static Image bottom2;
            public static Image abort1;
            public static Image abort2;
            public static Image save1;
            public static Image save2;
            public static Image open1;
            public static Image open2;
        }

        public class PNGChessMan
        {
            public static Image Vua_Xanh;
            public static Image Hau_Xanh;
            public static Image Tuong_Xanh;
            public static Image Ngua_Xanh;
            public static Image Xe_Xanh;
            public static Image Tot_Xanh;
            public static Image Vua_Vang;
            public static Image Hau_Vang;
            public static Image Tuong_Vang;
            public static Image Ngua_Vang;
            public static Image Xe_Vang;
            public static Image Tot_Vang;
        }
    }
}

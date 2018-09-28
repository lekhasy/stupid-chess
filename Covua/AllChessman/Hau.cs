using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covua.AllChessman
{
    [Serializable]
    public class Hau : Quanco
    {
        public static int[] MoveIndex;

        /// <summary>
        /// dùng để lấy độ tốt của quân cờ này, nhưng để phát triển về sau, độ tốt không được gán cứng một giá trị
        /// </summary>
        /// <returns></returns>
        public override int Dotot()
        {
            return 30;
        }
        protected override int[] GetMoveArray()
        {
            return MoveIndex;
        }

       
        public Hau(Team t,Index idx, Status owner)
        {
            team = t;
            index = idx;
            Owner = owner;
        }
        public override Image GetOwnImage()
        {
            return team == Team.Computer ? AppResource.AppImage.PNGChessMan.Hau_Vang : AppResource.AppImage.PNGChessMan.Hau_Xanh;
        }

        public override Quanco GetCopy()
        {
            // owner vẫn là owner cũ
            return new Hau(team,index.GetCopy(),Owner);
        }
    }
}

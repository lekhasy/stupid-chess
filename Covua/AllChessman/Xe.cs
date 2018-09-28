using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Covua.AllChessman
{
    [Serializable]
    public class Xe : Quanco
    {
        public static int[] MoveIndex;
       
        public override int Dotot()
        {
            return 10;
        }
        protected override int[] GetMoveArray()
        {
            return MoveIndex;
        }
        public Xe(Team t, Index idx, Status owner)
        {
            team = t;
            index = idx;
            Owner = owner;
        }
        public override Image GetOwnImage()
        {
            return team == Team.Computer ? AppResource.AppImage.PNGChessMan.Xe_Vang : AppResource.AppImage.PNGChessMan.Xe_Xanh;
        }
        public override Quanco GetCopy()
        {
             return new Xe(team, index.GetCopy(), Owner);
        }
    }
}

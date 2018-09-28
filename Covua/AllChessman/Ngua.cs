using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Covua.AllChessman
{
    [Serializable]
    public class Ngua : Quanco
    {
        public static int[] MoveIndex;
        public override int Dotot()
        {
            return 6;
        }
        protected override int[] GetMoveArray()
        {
            return MoveIndex;
        }
        public Ngua(Team t, Index idx,Status owner)
        {
            team = t;
            index = idx;
            Owner = owner;
        }
        public override Image GetOwnImage()
        {
          return team == Team.Computer ? AppResource.AppImage.PNGChessMan.Ngua_Vang : AppResource.AppImage.PNGChessMan.Ngua_Xanh;
        }

        public override Quanco GetCopy()
        {
            return new Ngua(team, index, Owner);
        }
    }
}

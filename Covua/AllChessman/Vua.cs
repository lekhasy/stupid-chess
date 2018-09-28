using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Covua.AllChessman
{
    [Serializable]
    public class Vua : Quanco
    {
        public static int[] MoveIndex;
      
        public override int Dotot()
        {
            return 1000;
        }
        protected override int[] GetMoveArray()
        {
            return MoveIndex;
        }
        public Vua(Team t, Index idx,Status owner)
        {
            team = t;
            index = idx;
            Owner = owner;
        }
        public override Image GetOwnImage()
        {
            return team == Team.Computer ? AppResource.AppImage.PNGChessMan.Vua_Vang : AppResource.AppImage.PNGChessMan.Vua_Xanh;
        }
        public override Quanco GetCopy()
        {
            return new Vua(team, index.GetCopy(), Owner);
        }
    }
}

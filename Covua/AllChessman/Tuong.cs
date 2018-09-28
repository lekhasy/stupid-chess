using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Covua.AllChessman
{
    [Serializable]
    public class Tuong : Quanco
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
        public Tuong(Team t, Index idx,Status owner)
        {
            team = t;
            index = idx;
            Owner = owner;
        }
        public override Image GetOwnImage()
        {
            return team == Team.Computer ? AppResource.AppImage.PNGChessMan.Tuong_Vang : AppResource.AppImage.PNGChessMan.Tuong_Xanh;
        }
        public override Quanco GetCopy()
        {
            return new Tuong(team, index.GetCopy(), Owner);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Covua.AllChessman
{
    [Serializable]
    public class Tot : Quanco
    {
        public bool moved = false;

        // tốt là quân duy nhất trên bàn cờ có quy định hướng di chuyển nên sẽ hơi khác biệt chút xíu

        public static int[] MoveIndex; // dùng khi tốt chưa di chuyển mà bên đội máy
        public static int[] MoveIndex1; // dùng khi tốt chưa di chuyển mà bên đội người
        public static int[] MoveIndex2; // dùng khi đã di chuyển mà bên đội máy
        public static int[] MoveIndex3; // dùng khi đã di chuyển bên đội người
        
        public override int Dotot()
        {
            if (team == Team.Computer)
            {
                if (index.I < 4)
                {
                    return 1;
                }
                else if (index.I < 6) return 3;
                else if (index.I == 6) return 10;
                else return 30;
            }
            else
            {
                if (index.I >3)
                {
                    return 1;
                }
                else if (index.I > 1) return 3;
                else if (index.I == 1) return 10;
                else return 30;
            }
        }


        protected override int[] GetMoveArray()
        {
            if (moved)
            {
                if (team == Team.Computer)
                {
                    return MoveIndex2;
                }
                else
                {
                    return MoveIndex3;
                }
            }
            else
            {
                if (team == Team.Computer)
                {
                    return MoveIndex;
                }
                else
                {
                    return MoveIndex1;
                }
            }
        }
        public Tot(Team t,Index idx,Status owner)
        {
            team = t;
            index = idx;
            Owner = owner;
        }
        public override Image GetOwnImage()
        {
            return team == Team.Computer ? AppResource.AppImage.PNGChessMan.Tot_Vang : AppResource.AppImage.PNGChessMan.Tot_Xanh;
        }

        public override Quanco GetCopy()
        {
           Tot rttot = new Tot(team, index.GetCopy(), Owner);
           rttot.moved = moved;
           return rttot;
        }
    }
}

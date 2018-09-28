using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covua.AllChessman
{
    [Serializable]
    public class Quanco
    {
        public Status Owner;
        public Index index;
        public Team team;

        public bool moveableto(Index To)
        {
            List<Index> idx = GetIndexList();
            foreach (Index item in idx)
            {
                if (item.Equals(To))
                {
                    return true;
                }
            }
            return false;
        }
        public virtual Image GetOwnImage()
        {
            return AppResource.AppImage.PNGChessMan.Tot_Xanh;
        }

        public virtual Quanco GetCopy()
        {
            return new Quanco();
        }
        protected virtual int[] GetMoveArray()
        {
            return new int[0];
        }

        public virtual int Dotot()
        {
            return -1;
        }

        /// <summary>
        /// trả về các vị trí mà quân cờ này có thể đi tới trên bàn cờ mà nó đang đứng
        /// </summary>
        /// <returns></returns>
        public List<Index> GetIndexList()
        {
            int[] Movearr = GetMoveArray();
            List<Index> rtlst = new List<Index>();
            // Ngang
                for (int j = index.J-1, k=0; j >-1 && k<Movearr[0]; j--,k++)
                {
                    if (Owner.Map[index.I,j]!=null)
                    {// có quân cờ ở ô này
                        if (Owner.Map[index.I,j].team == team)
                        {// cùng đội
                            break;
                        }
                        else
                        {// khác đội thì thêm nó vào rồi mới break;
                            rtlst.Add(new Index(index.I, j));
                            break;
                        }
                    }
                    rtlst.Add(new Index(index.I, j));
                 }
                for (int j = index.J + 1, k = 0; j < 8 && k < Movearr[1]; j++, k++)
                {
                    if (Owner.Map[index.I,j]!=null)
                    {// có quân cờ ở ô này
                        if (Owner.Map[index.I,j].team == team)
                        {// cùng đội
                            break;
                        }
                        else
                        {// khác đội thì thêm nó vào rồi mới break;
                            rtlst.Add(new Index(index.I, j));
                            break;
                        }
                    }
                    rtlst.Add(new Index(index.I, j));
                }
            // Dọc
                for (int i = index.I - 1, k = 0; i > -1 && k < Movearr[2]; i--, k++)
                {
                    if (Owner.Map[i,index.J]!=null)
                    {// có quân cờ ở ô này
                        if (Owner.Map[i,index.J].team == team)
                        {// cùng đội
                            break;
                        }
                        else
                        {// khác đội thì thêm nó vào rồi mới break;
                            if (!(this is AllChessman.Tot))
                            {
                                rtlst.Add(new Index(i, index.J));    
                            }
                            break;
                        }
                    }
                    rtlst.Add(new Index(i, index.J));
                }
                for (int i = index.I + 1, k = 0; i < 8 && k < Movearr[3]; i++, k++)
                {
                    if (Owner.Map[i, index.J] != null)
                    {// có quân cờ ở ô này
                        if (Owner.Map[i, index.J].team == team)
                        {// cùng đội
                            break;
                        }
                        else
                        {// khác đội thì thêm nó vào rồi mới break;
                            if (!(this is AllChessman.Tot))
                            {
                                rtlst.Add(new Index(i, index.J));
                            }
                            break;
                        }
                    }
                    rtlst.Add(new Index(i, index.J));
                }
            //Chéo
            // 11h
                for (int j = index.J - 1, i = index.I - 1, k = 0; j > -1 && i > -1 && k < Movearr[4]; j--, i--, k++)
                {
                    if (Owner.Map[i, j] != null)
                    {// có quân cờ ở ô này
                        if (Owner.Map[i, j].team == team)
                        {// cùng đội
                            break;
                        }
                        else
                        {// khác đội thì thêm nó vào rồi mới break;
                            rtlst.Add(new Index(i, j));
                            break;
                        }
                    }
                    else if (this is Tot)
                    {
                        break;
                    }
                    
                    rtlst.Add(new Index(i, j));
                }
            // 5h
                for (int j = index.J + 1, i = index.I + 1, k = 0; j < 8 && i < 8 && k < Movearr[5]; j++, i++, k++)
                {
                    if (Owner.Map[i, j] != null)
                    {// có quân cờ ở ô này
                        if (Owner.Map[i, j].team == team)
                        {// cùng đội
                            break;
                        }
                        else
                        {// khác đội thì thêm nó vào rồi mới break;
                            rtlst.Add(new Index(i, j));
                            break;
                        }
                    }
                    else if (this is Tot)
                    {
                        break;
                    }
                    rtlst.Add(new Index(i, j));
                }
            //1h
                for (int j = index.J + 1, i = index.I - 1, k = 0; j < 8 && i > -1 && k < Movearr[6]; j++, i--, k++)
                {
                    if (Owner.Map[i, j] != null)
                    {// có quân cờ ở ô này
                        if (Owner.Map[i, j].team == team)
                        {// cùng đội
                            break;
                        }
                        else
                        {// khác đội thì thêm nó vào rồi mới break;
                            rtlst.Add(new Index(i, j));
                            break;
                        }
                    }
                    else if (this is Tot)
                    {
                        break;
                    }
                    rtlst.Add(new Index(i, j));
                }
            //7h
                for (int j = index.J - 1, i = index.I + 1, k = 0; j > -1 && i < 8 && k < Movearr[7]; j--, i++, k++)
                {
                    if (Owner.Map[i, j] != null)
                    {// có quân cờ ở ô này
                        if (Owner.Map[i, j].team == team)
                        {// cùng đội
                            break;
                        }
                        else
                        {// khác đội thì thêm nó vào rồi mới break;
                            rtlst.Add(new Index(i, j));
                            break;
                        }
                    }
                    else if (this is Tot)
                    {
                        break;
                    }
                    rtlst.Add(new Index(i, j));
                }
                if (this is Ngua)
                {
                    // làm việc của ngựa
                    Index buff = new Index(index.I - 2, index.J-1);
                    if (Status.InSide(buff)&&(Owner.Map[buff.I,buff.J]==null||Owner.Map[buff.I,buff.J].team!=team))
                    {// vị trí ở trong bàn cờ và (ô đó trống hoặc không trống nhưng không cùng phe)
                        rtlst.Add(buff);
                    }
                    buff = new Index(index.I - 2, index.J+1);
                    if (Status.InSide(buff) && (Owner.Map[buff.I, buff.J] == null || Owner.Map[buff.I, buff.J].team != team))
                    {
                        rtlst.Add(buff);
                    }
                    buff = new Index(index.I + 2, index.J - 1);
                    if (Status.InSide(buff) && (Owner.Map[buff.I, buff.J] == null || Owner.Map[buff.I, buff.J].team != team))
                    {
                        rtlst.Add(buff);
                    }
                    buff = new Index(index.I + 2, index.J + 1);
                    if (Status.InSide(buff) && (Owner.Map[buff.I, buff.J] == null || Owner.Map[buff.I, buff.J].team != team))
                    {
                        rtlst.Add(buff);
                    }
                    buff = new Index(index.I - 1, index.J - 2);
                    if (Status.InSide(buff) && (Owner.Map[buff.I, buff.J] == null || Owner.Map[buff.I, buff.J].team != team))
                    {
                        rtlst.Add(buff);
                    }
                    buff = new Index(index.I + 1, index.J - 2);
                    if (Status.InSide(buff) && (Owner.Map[buff.I, buff.J] == null || Owner.Map[buff.I, buff.J].team != team))
                    {
                        rtlst.Add(buff);
                    }
                    buff = new Index(index.I - 1, index.J + 2);
                    if (Status.InSide(buff) && (Owner.Map[buff.I, buff.J] == null || Owner.Map[buff.I, buff.J].team != team))
                    {
                        rtlst.Add(buff);
                    }
                    buff = new Index(index.I + 1, index.J + 2);
                    if (Status.InSide(buff) && (Owner.Map[buff.I, buff.J] == null || Owner.Map[buff.I, buff.J].team != team))
                    {
                        rtlst.Add(buff);
                    }
                }
                return rtlst;
        }

       

    }
}

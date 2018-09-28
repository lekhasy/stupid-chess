using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covua
{
    [Serializable]
    public class Index
    {
        public int I;
        public int J;
        public Index(int i, int j)
        {
            I = i;
            J = j;
        }
        public override bool Equals(object obj)
        {
            if (I!=((Index)obj).I||J!=((Index)obj).J)
            {
                return false;
            }
            return true;
        }

        public Index GetCopy()
        {
            return new Index(I,J);
        }
    }

    public enum Typeconstructor
    {
        Null,
        Arranged,
    }
}

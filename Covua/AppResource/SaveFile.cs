using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covua.AppResource
{
    [Serializable]
    public class SaveFile
    {
        public object saveobj;
        public SaveFile(object obj)
        {
            saveobj = obj;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Windows.Forms;
namespace Covua.AppResource
{
    public class Objectsaver
    {
        public static void Write(string Filename,object saveobject)
        {
            try
            {
                Stream str = File.Open(Filename, FileMode.Create);
                new BinaryFormatter().Serialize(str, saveobject);
                str.Close();
            }
            catch(Exception e) 
            {
                MessageBox.Show(e.Message);
            }
        }

        public static object Read(string Filename)
        {
            try
            {
                Stream str = File.OpenRead(Filename);
                object rtobj = new BinaryFormatter().Deserialize(str);
                str.Close();
                return rtobj;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return null; 
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covua
{
        public class Node
        {
            /// <summary>
            /// Nút cha trên cây Minimax
            /// </summary>
            public Node Father;

            public Status status;

            public int Value
            {
                get { return _value; }
                set{
                        if (type == Nodetype.Max)
                        {// node này lưu giá trị min
                            if ((_value > value && _value!=5000) || _value == 5000)
                            { // giá trị phù hợp và đã được gán ít nhất 1 lần
                                // hoặc chưa bao h được gán
                                _value = value;
                            }
                        }
                        else
                        {
                            if ((_value < value && _value!=5000) || _value==5000)
                            {
                                _value = value;
                            }
                        }
                }
            }

            /// <summary>
            /// Độ sâu của node này trên cây minimax
            /// </summary>
            public int deep;

            /// <summary>
            ///  Danh sách các node con của nó
            /// </summary>
            public List<Node> Subs = new List<Node>(); 

            /// <summary>
            /// Loại node : Node Max hay Node Min
            /// </summary>
            public Nodetype type;

            /// <summary>
            /// giá trị của node này, 5000 có nghĩa là chưa được gán lần nào bởi vì không bao h giá trị này đạt đến 5000 cả
            /// </summary>
            protected int _value = 5000;
                  
            public enum Nodetype
            {
                Min,
                Max,
            }
        }
}

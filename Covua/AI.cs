using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace Covua
{
    public class AI
    {
       
        public static int Inteligent = 4;
        /// <summary>
        /// Biến Ramdom này dùng để lựa chọn ngẫu nhiên một trong số các bước đi có cùng độ tốt
        /// biến này phải để là static để tránh việc trùng lặp số ngẫu nhiên
        /// </summary>
        protected static Random rdm = new Random();


        /// <summary>
        /// mỗi con của node gốc sẽ mở rộng bằng 1 thread, đây là danh sách các thread đó
        /// </summary>
        public static List<Thread> workerThreads = new List<Thread>();

        public static Status Think(Status input)
        {
            // khởi tạo gốc 
            Node root = new Node();
            root.status = input.Getcopy();
            root.deep = 0;
            root.type = Node.Nodetype.Min;
           // root.Subs = new List<Node>();

            // mở rộng cây với độ sâu giới hạn MaxDeep
            // kĩ thuật xử lí đa luồng được áp dụng để tối ưu thời gian xử lí
            List<Status> rootsubsstatus = getSubStatus(root.status);
            workerThreads = new List<Thread>();
            foreach (Status item in rootsubsstatus)
            {
                  Node buff = new Node();
                  buff.type = Node.Nodetype.Max;
                  buff.status = item;
                  buff.deep = 1;
                  buff.Father = root;
                  root.Subs.Add(buff);
                  Thread thr = new Thread(() =>
                  {
                      if (!buff.status.Finished)
                      {
                          Expand(buff);
                          buff.Value = buff.Subs.Min(tt => tt.Value);
                          buff.Subs.Clear();
                      }
                      else
                      {
                          buff.Value = 1000;
                      }
                      buff.Father.Value = buff.Value;
                  });
                workerThreads.Add(thr);
                thr.IsBackground = true;
                thr.Priority = ThreadPriority.Lowest;
                thr.Start();
            }

            foreach (Thread item in workerThreads)
            {
                item.Join();
            }

           
            List<Status> Randomselectstatuslist = new List<Status>();
            foreach (Node item in root.Subs)
            {
                if (item.Value == root.Value)
                {
                    Randomselectstatuslist.Add(item.status);
                }
            }
            Status rtstatus = Randomselectstatuslist[rdm.Next(Randomselectstatuslist.Count)].Getcopy();
            root.Subs.Clear();
            Randomselectstatuslist.Clear();
            return rtstatus;
        }

        /// <summary>
        /// cách để xóa node cha của nó khi vào một trường hợp trong cắt tỉa alpha beta thì trả về giá trị là 1 nếu đúng và 0 nếu sai.
        /// </summary>
        /// <param name="input">Node cần được mở rộng</param>
        /// <returns>trả về 1 nếu node này không cần thiết nữa, trả về 0 nếu nó cần thiết</returns>
        private static void Expand(Node input)
        {
            List<Status> SubsStatus = AI.getSubStatus(input.status);
            foreach (Status item in SubsStatus)
            {
                Node buff = new Node();
                buff.type = input.type == Node.Nodetype.Max ? Node.Nodetype.Min : Node.Nodetype.Max;
                buff.status = item;
                buff.deep = input.deep + 1;
                buff.Father = input;

                input.Subs.Add(buff);

                if (buff.deep<Inteligent)
                {// chưa bằng độ sâu giới hạn thì cứ mở rộng cây xuống
                    if (!buff.status.Finished)
                    {// Chưa phải là trạng thái kết thúc
                        Expand(buff);
                        if (buff.type == Node.Nodetype.Max)
                        {
                            buff.Value = buff.Subs.Min(tt => tt.Value);
                        }
                        else
                        {
                            buff.Value = buff.Subs.Max(tt => tt.Value);
                        }
                        buff.Subs.Clear();
                    }
                    else
                    {// node này không thể mở rộng được nữa
                        if (buff.status.Luot == Team.Computer)
                        {// nếu đây là lượt đi của máy khiến người ko đi đc nữa thì máy chiếm hoàn toàn lợi thế
                            buff.Value = 1000;
                        }
                        else
                        {// ngược lại, người chiếm hoàn toàn lợi thế
                            buff.Value = -1000;
                        }
                    }
                }
                else
                {// nếu bằng rồi thì định giá trị cho node lá này
                    buff.Value = AI.Danhgiadotot(buff.status);
                }

                // tới đây, buff đã có giá trị cuối cùng của nó
                buff.Father.Value = buff.Value;

               if (checkalphabeta(buff)) // nếu node này rơi vào trường hợp cắt tỉa thì kết thúc việc mở rộng các node khác
                    break;
            }
        }

        private static bool checkalphabeta(Node input)
        {
            if (input.deep > 2)
            {
                if (input.Father.Father.Subs.Count > 1)
                {// ông của nó đã có ít nhất 2 con
                    if (input.type == Node.Nodetype.Max)
                    {
                        if (input.Value > input.Father.Father.Value)
                        { // thỏa điều kiện cắt tỉa alpha beta
                            return true; //để node cha của nó biết là node cha đó ko cần thiết nữa, sẽ hủy việc mở rộng các node con còn lại khác
                        }
                    }
                    else
                    {
                        if (input.Value < input.Father.Father.Value)
                        {
                            return true;
                        }
                    }
                }
            }
            else if (input.Father.Father.Value !=5000)
            { // do không bao giờ node input <2 nên ngầm định, trường hợp này, node sẽ có độ sâu là 2
              // root.value!=5000 để đảm bảo node gốc đã được gán giá trị ít nhất 1 lần
                        if (input.Value < input.Father.Father.Value)
                        {
                            return true;
                        }
            }
            return false; //node cha của nó sẽ tiếp tục mở rộng như ko có chuyện gì xảy ra
        }


        /// <summary>
        /// Lấy danh sách các status con của một status
        /// </summary>
        /// <param name="source">Status cha</param>
        /// <returns>trả về một danh sách các status mà có thể được tạo thành từ status cha, các giá trị bên trong status được gắn hoàn chỉnh</returns>
        private static List<Status> getSubStatus(Status source)
        {
            List<Status> rtlst = new List<Status>();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    //vì status này là do đội Source.Luot tạo nên, vậy, nước đi hiện tại sẽ thuộc về đội kia
                    if (source.Map[i, j] != null && source.Map[i, j].team != source.Luot)
                    {
                        List<Index> buffarr = source.Map[i, j].GetIndexList();
                        foreach (Index item in buffarr)
                        {
                            Status buff = source.Move(new Index(i, j), item);
                            rtlst.Add(buff);
                            if (source.Map[i, j] is AllChessman.Tot)
                            {
                                if (i == 6&&buff.Luot == Team.Computer||i==1&&buff.Luot == Team.Man)
                                {// trường hợp con tốt di chuyển đến hàng cuối cùng
                                    buff = buff.Getcopy();
                                    buff.Map[item.I, item.J] = new AllChessman.Hau(buff.Luot, item.GetCopy(), buff);
                                    rtlst.Add(buff);

                                    buff = buff.Getcopy();
                                    buff.Map[item.I, item.J] = new AllChessman.Ngua(buff.Luot, item.GetCopy(), buff);
                                    rtlst.Add(buff);

                                    buff = buff.Getcopy();
                                    buff.Map[item.I, item.J] = new AllChessman.Xe(buff.Luot, item.GetCopy(), buff);
                                    rtlst.Add(buff);

                                    buff = buff.Getcopy();
                                    buff.Map[item.I, item.J] = new AllChessman.Tuong(buff.Luot, item.GetCopy(), buff);
                                    rtlst.Add(buff);
                                }
                            }
                        }
                    }
                }
            }
            return rtlst;
        }


        public static int Danhgiadotot(Status st)
        {
            int nguoi = 0, may = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (st.Map[i, j] != null)
                    {
                        if (st.Map[i, j].team == Team.Computer)
                        {
                            may += st.Map[i, j].Dotot();
                        }
                        else
                        {
                            nguoi += st.Map[i, j].Dotot();
                        }
                    }
                }
            }
            return may - nguoi;
        }
    }
}
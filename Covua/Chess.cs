using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Threading;
using System.Diagnostics;

namespace Covua
{
    public partial class Chess : Customform
    {
        Status st = new Status(Typeconstructor.Arranged);
        public Index SelectedChessMan;
        public List<Status> History = new List<Status>();
        public List<Status> BackupH = new List<Status>();
        public int BackupC = 0;
        public int CurrentHistoryView = 0;

        private SetupProfile _profile;
        private static object locker = new object();        
        private Thread Workthread = new Thread(() => {});
        private delegate void Invokerefresh();
        private Invokerefresh Irefresh = null;
        private delegate void controlInvokeEnable(Control control, bool enable);
        private controlInvokeEnable Ienable = null;
        private const float timeoutmilisecond = 100;
        public SetupProfile Profile
        {
            get { return _profile; }
            set { _profile = value;
            AI.Inteligent = _profile.Inteligent;
            Status.Bordercolor = _profile.AppBorderColor;
            border.BorderColor = _profile.AppBorderColor;
            border.TitleColor = _profile.AppTitleColor;
            Refresh();
            }
        }
        public Chess()
        {
            InitializeComponent();
        }

        private void Chess_Load(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
            Thread.CurrentThread.Priority = ThreadPriority.Highest;
            Irefresh += this.Refresh;
            saveFileDialog1.InitialDirectory = AppResource.AppPaths.SaveFolderPath;
            openFileDialog1.InitialDirectory = AppResource.AppPaths.SaveFolderPath;
            Ienable += delegate(Control control, bool enable)
            {
                control.Enabled = enable;
            };
            Workthread.IsBackground = true;
            History.Add(st);
            BackupH.Add(st.Getcopy());
            this.Invoke(Irefresh);

            try
            {
                Stream str = File.Open(AppResource.AppPaths.GetProfileFilePath("save000.sav"), FileMode.Open);
                Profile = (SetupProfile)new BinaryFormatter().Deserialize(str);
                str.Close();
            }
            catch(IOException ex)
            {
                MessageBox.Show(ex.ToString());
                Application.Exit();
            }
            new Customcontrol.Swaper(ptb_Setup, AppResource.AppImage.PNGIcons.setup1, AppResource.AppImage.PNGIcons.setup2);
            new Customcontrol.Swaper(ptb_reload, AppResource.AppImage.PNGIcons.reload1, AppResource.AppImage.PNGIcons.reload2);
            new Customcontrol.Swaper(ptb_next, AppResource.AppImage.PNGIcons.next1, AppResource.AppImage.PNGIcons.next2);
            new Customcontrol.Swaper(ptb_prev, AppResource.AppImage.PNGIcons.prev1, AppResource.AppImage.PNGIcons.prev2);
            new Customcontrol.Swaper(ptb_bottom, AppResource.AppImage.PNGIcons.bottom1, AppResource.AppImage.PNGIcons.bottom2);
            new Customcontrol.Swaper(ptb_top, AppResource.AppImage.PNGIcons.Top1, AppResource.AppImage.PNGIcons.Top2);
            new Customcontrol.Swaper(ptb_abort, AppResource.AppImage.PNGIcons.abort1, AppResource.AppImage.PNGIcons.abort2);
            new Customcontrol.Swaper(ptb_save, AppResource.AppImage.PNGIcons.save1, AppResource.AppImage.PNGIcons.save2);
            new Customcontrol.Swaper(ptb_open, AppResource.AppImage.PNGIcons.open1, AppResource.AppImage.PNGIcons.open2);
        }

        private void Chess_Paint(object sender, PaintEventArgs e)
        {
            st.Show(e.Graphics);
            if (SelectedChessMan!=null)
            {
                Status.HightLight(SelectedChessMan, e.Graphics);
                foreach (Index item in st.Map[SelectedChessMan.I,SelectedChessMan.J].GetIndexList())
                {
                    Status.HightLight(item, e.Graphics);
                }
            }
        }

        private void Chess_MouseClick(object sender, MouseEventArgs e)
        {
            DateTime time1 = DateTime.Now;
            Workthread = new Thread(() =>
                  {
                      lock (locker)
                      {
                          TimeSpan span = DateTime.Now - time1;
                          if (span.TotalMilliseconds < timeoutmilisecond &&st.Luot == Team.Computer)
                          {
                              Index ClickedIndex = Status.IndexFromPoint(e.Location);
                              if (!Profile.ISNormnalmode && ClickedIndex != null)
                              {
                                  SelectedChessMan = null;
                                  st.Map[ClickedIndex.I, ClickedIndex.J] = null;
                                  sync_History();
                                  History.Add(st);
                                  CurrentHistoryView++;
                                  st = st.Getcopy();
                                  this.Invoke(Irefresh);
                              }
                              else
                                  if (ClickedIndex != null)
                                  {// click vào bên trong bàn cờ
                                      if (SelectedChessMan != null)
                                      { // đang lựa chọn 1 quân cờ khác
                                          if (!SelectedChessMan.Equals(ClickedIndex))
                                          {// quân cờ khác đó không phải quân đang chọn
                                              Team tbuff = st.Luot;
                                              if (Profile.FreeMove || st.Map[SelectedChessMan.I, SelectedChessMan.J].moveableto(ClickedIndex))
                                              {// nếu có khả năng di chuyển tới vị trí vừa click

                                                  // sao lưu lại history phòng trường hợp người dùng ấn abort khi đang xử lí
                                                  BackupC = CurrentHistoryView;
                                                  BackupH = new List<Status>();
                                                  foreach (var item in History)
                                                  {
                                                      BackupH.Add(item.Getcopy());
                                                  }

                                                  
                                                  st = st.Move(SelectedChessMan, ClickedIndex);
                                                  sync_History();
                                                  History.Add(st);
                                                  CurrentHistoryView++;
                                                  SelectedChessMan = null;
                                                  this.Invoke(Irefresh);
                                                  if (st.Finished)
                                                  {
                                                      MessageBox.Show("Người thắng");
                                                      st = new Status(Typeconstructor.Arranged);
                                                      History.Clear();
                                                      History.Add(st);
                                                      CurrentHistoryView = 1;
                                                      return;
                                                  }
                                                  if (st.Map[ClickedIndex.I, ClickedIndex.J] is AllChessman.Tot && ClickedIndex.I == 0)
                                                  {// nếu người đi 1 con tốt đến cuối bàn cờ
                                                      Phong p = new Phong(Profile);
                                                      p.PhongChoosed += delegate(object sender1, PhongEventArgs e1)
                                                      {
                                                          switch (e1.Chessnumber)
                                                          {
                                                              case 1: st.Map[ClickedIndex.I, ClickedIndex.J] = new AllChessman.Xe(Team.Man, ClickedIndex, st); break;
                                                              case 2: st.Map[ClickedIndex.I, ClickedIndex.J] = new AllChessman.Ngua(Team.Man, ClickedIndex, st); break;
                                                              case 3: st.Map[ClickedIndex.I, ClickedIndex.J] = new AllChessman.Tuong(Team.Man, ClickedIndex, st); break;
                                                              case 4: st.Map[ClickedIndex.I, ClickedIndex.J] = new AllChessman.Hau(Team.Man, ClickedIndex, st); break;
                                                          }
                                                          this.Invoke(Irefresh);
                                                      };
                                                      p.ShowDialog();
                                                  }

                                                  if (!Profile.ConseMove)
                                                  {
                                                      // cho phép người dùng ấn abort, Không cho ấn các nút còn lại trừ setting
                                                      Invoke(Ienable, ptb_abort, true);
                                                      Invoke(Ienable, ptb_bottom, false);
                                                      Invoke(Ienable, ptb_next, false);
                                                      Invoke(Ienable, ptb_open, false);
                                                      Invoke(Ienable, ptb_prev, false);
                                                      Invoke(Ienable, ptb_reload, false);
                                                      Invoke(Ienable, ptb_save, false);
                                                      Invoke(Ienable, ptb_top, false);
                                                      st = AI.Think(st);
                                                      //tắt nút abort cà cho phép các nút khác được ấn
                                                      Invoke(Ienable, ptb_abort, false);
                                                      Invoke(Ienable, ptb_bottom, true);
                                                      Invoke(Ienable, ptb_next, true);
                                                      Invoke(Ienable, ptb_open, true);
                                                      Invoke(Ienable, ptb_prev, true);
                                                      Invoke(Ienable, ptb_reload, true);
                                                      Invoke(Ienable, ptb_save, true);
                                                      Invoke(Ienable, ptb_top, true);
                                                      Invoke(Irefresh);
                                                      sync_History();
                                                      History.Add(st);
                                                      CurrentHistoryView++;
                                                  }
                                                  else
                                                  {
                                                      st.Luot = Team.Computer;
                                                  }
                                                  if (st.Finished)
                                                  {
                                                      MessageBox.Show("Máy thắng");
                                                      st = new Status(Typeconstructor.Arranged);
                                                      History.Clear();
                                                      History.Add(st);
                                                      CurrentHistoryView = 1;
                                                      return;
                                                  }
                                                
                                              }
                                          }
                                          else
                                          {// click vào quân đang chọn
                                              SelectedChessMan = null;
                                              this.Invoke(Irefresh);
                                          }
                                      }
                                      else
                                      { // đang không chọn quân nào cả
                                          if (st.Map[ClickedIndex.I, ClickedIndex.J] != null && (st.Map[ClickedIndex.I, ClickedIndex.J].team == Team.Man || Profile.EnemyMove))
                                          {//click vào một quân cờ 
                                              SelectedChessMan = ClickedIndex;
                                              this.Invoke(Irefresh);
                                          }
                                      }
                                  }
                                  else
                                  {// click ra ngoài bàn cờ
                                      if (SelectedChessMan != null)
                                      {// có 1 quân đang được chọn
                                          SelectedChessMan = null;
                                          this.Invoke(Irefresh);
                                      }
                                  }
                          }
                          
                      }
                  });
            Workthread.IsBackground = true;
            Workthread.Start();
        }

        /// <summary>
        /// Hàm này làm nhiệm vụ đưa biến CurrentHistoryView về giá trị đúng và xóa một vài item của History
        /// nếu người chơi di chuyển 1 quân cờ trong history
        /// </summary>
        public void sync_History()
        {
            if (CurrentHistoryView < History.Count-1)
            {
                while(CurrentHistoryView!=History.Count-1)
                {
                    History.RemoveAt(History.Count - 1);
                }
            }
        }
        

        private void Chess_SizeChanged(object sender, EventArgs e)
        {
            Status.UpdateScreensize(this.Size);
            ptb_reload.Size = new Size(Status.Unitsize.Height / 2, Status.Unitsize.Height / 2);
            ptb_reload.Top = Status.Top + Status.Unitsize.Height/3;
            ptb_reload.Left = Status.Left - Status.Unitsize.Height / 2-5;
            ptb_top.Size = ptb_next.Size = ptb_prev.Size = ptb_bottom.Size = ptb_abort.Size = ptb_reload.Size;
            ptb_top.Left = ptb_next.Left = ptb_prev.Left = ptb_bottom.Left = ptb_abort.Left = ptb_reload.Left;
            ptb_top.Top = ptb_reload.Bottom + 5;
            ptb_next.Top = ptb_top.Bottom + 5;
            ptb_prev.Top = ptb_next.Bottom + 5;
            ptb_bottom.Top = ptb_prev.Bottom + 5;
            ptb_abort.Top = ptb_bottom.Bottom + 5;

            ptb_Setup.Size = ptb_reload.Size;
            ptb_Setup.Top = ptb_reload.Top;
            ptb_Setup.Left = Status.Left + Status.Unitsize.Height * 8+5;
            ptb_save.Size = ptb_Setup.Size;
            ptb_save.Left = ptb_open.Left = ptb_Setup.Left;
            ptb_save.Top = ptb_reload.Bottom + 5;
            ptb_open.Size = ptb_save.Size;
            ptb_open.Left = ptb_save.Left;
            ptb_open.Top = ptb_save.Bottom + 5;
        }
        private void ptb_Setup_Click(object sender, EventArgs e)
        {
            TestTools tool = new TestTools();
            tool.NewSettingChoosed += delegate(object sd1, SetupProfile e1)
            {
                Profile = e1;
            };
            tool.ShowDialog();
        }

        private void ptb_reload_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn đặt lại bàn cờ?" + Environment.NewLine + "Việc này cũng xóa history", "Xác nhận đặt lại bàn cờ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                History.Clear();
                st = new Status(Typeconstructor.Arranged);
                History.Add(st);
                CurrentHistoryView = 1;
                SelectedChessMan = null;
                this.Invoke(Irefresh);
            }
        }

        private void ptb_bottom_Click(object sender, EventArgs e)
        {
            CurrentHistoryView = 0;
            st = History[0];
            SelectedChessMan = null;
            this.Invoke(Irefresh);
        }

        private void ptb_abort_Click(object sender, EventArgs e)
        {
                Workthread.Abort();
                foreach (Thread item in AI.workerThreads)
                {
                    item.Abort();
                }
                History.Clear();
                History = BackupH;
                CurrentHistoryView = BackupC;
                st = History[CurrentHistoryView];
                this.Invoke(Irefresh);
                ptb_abort.Enabled = false;
                ptb_bottom.Enabled = true;
                ptb_next.Enabled = true;
                ptb_open.Enabled = true;
                ptb_prev.Enabled = true;
                ptb_reload.Enabled = true;
                ptb_save.Enabled = true;
                ptb_top.Enabled = true;
        }

        private void ptb_top_Click(object sender, EventArgs e)
        {
            CurrentHistoryView = History.Count - 1;
            st = History[CurrentHistoryView];
            SelectedChessMan = null;
            this.Invoke(Irefresh);
        }

        private void ptb_next_Click(object sender, EventArgs e)
        {
            if (CurrentHistoryView < History.Count - 1)
            {
                CurrentHistoryView++;
                st = History[CurrentHistoryView];
                SelectedChessMan = null;
                this.Invoke(Irefresh);
            }
        }

        private void ptb_prev_Click(object sender, EventArgs e)
        {
            try
            {
                st = History[CurrentHistoryView - 1];
                CurrentHistoryView--;
                SelectedChessMan = null;
                this.Invoke(Irefresh);
            }
            catch
            {
            }
        }

        private void ptb_save_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "save000";
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                AppResource.Objectsaver.Write(saveFileDialog1.FileName, new AppResource.SaveFile(History));
            }
        }

        private void ptb_open_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    History = (List<Status>)((AppResource.SaveFile)AppResource.Objectsaver.Read(openFileDialog1.FileName)).saveobj;
                    SelectedChessMan = null;
                    st = History[History.Count - 1];
                    this.Refresh();
                }
            }
            catch
            {
                MessageBox.Show("File không đúng định dạng");
            }
        }
    }
}

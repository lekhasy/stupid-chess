namespace Covua
{
    partial class Chess
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chess));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ptb_save = new System.Windows.Forms.PictureBox();
            this.ptb_open = new System.Windows.Forms.PictureBox();
            this.ptb_abort = new System.Windows.Forms.PictureBox();
            this.ptb_top = new System.Windows.Forms.PictureBox();
            this.ptb_bottom = new System.Windows.Forms.PictureBox();
            this.ptb_prev = new System.Windows.Forms.PictureBox();
            this.ptb_next = new System.Windows.Forms.PictureBox();
            this.ptb_reload = new System.Windows.Forms.PictureBox();
            this.ptb_Setup = new System.Windows.Forms.PictureBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_save)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_open)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_abort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_top)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_bottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_prev)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_next)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_reload)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_Setup)).BeginInit();
            this.SuspendLayout();
            // 
            // ptb_save
            // 
            this.ptb_save.Location = new System.Drawing.Point(510, 112);
            this.ptb_save.Name = "ptb_save";
            this.ptb_save.Size = new System.Drawing.Size(40, 40);
            this.ptb_save.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptb_save.TabIndex = 22;
            this.ptb_save.TabStop = false;
            this.toolTip1.SetToolTip(this.ptb_save, "lưu lại bàn cờ này");
            this.ptb_save.Click += new System.EventHandler(this.ptb_save_Click);
            // 
            // ptb_open
            // 
            this.ptb_open.Location = new System.Drawing.Point(516, 170);
            this.ptb_open.Name = "ptb_open";
            this.ptb_open.Size = new System.Drawing.Size(40, 40);
            this.ptb_open.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptb_open.TabIndex = 21;
            this.ptb_open.TabStop = false;
            this.toolTip1.SetToolTip(this.ptb_open, "Đọc bàn cờ từ file");
            this.ptb_open.Click += new System.EventHandler(this.ptb_open_Click);
            // 
            // ptb_abort
            // 
            this.ptb_abort.Enabled = false;
            this.ptb_abort.Location = new System.Drawing.Point(6, 279);
            this.ptb_abort.Name = "ptb_abort";
            this.ptb_abort.Size = new System.Drawing.Size(40, 40);
            this.ptb_abort.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptb_abort.TabIndex = 18;
            this.ptb_abort.TabStop = false;
            this.toolTip1.SetToolTip(this.ptb_abort, "Hủy nếu chờ máy quá lâu");
            this.ptb_abort.Click += new System.EventHandler(this.ptb_abort_Click);
            // 
            // ptb_top
            // 
            this.ptb_top.Location = new System.Drawing.Point(12, 98);
            this.ptb_top.Name = "ptb_top";
            this.ptb_top.Size = new System.Drawing.Size(40, 40);
            this.ptb_top.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptb_top.TabIndex = 17;
            this.ptb_top.TabStop = false;
            this.toolTip1.SetToolTip(this.ptb_top, "Xem trạng thái mới nhất");
            this.ptb_top.Click += new System.EventHandler(this.ptb_top_Click);
            // 
            // ptb_bottom
            // 
            this.ptb_bottom.Location = new System.Drawing.Point(6, 233);
            this.ptb_bottom.Name = "ptb_bottom";
            this.ptb_bottom.Size = new System.Drawing.Size(40, 40);
            this.ptb_bottom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptb_bottom.TabIndex = 16;
            this.ptb_bottom.TabStop = false;
            this.toolTip1.SetToolTip(this.ptb_bottom, "Xem trạng thái bắt đầu");
            this.ptb_bottom.Click += new System.EventHandler(this.ptb_bottom_Click);
            // 
            // ptb_prev
            // 
            this.ptb_prev.Location = new System.Drawing.Point(6, 185);
            this.ptb_prev.Name = "ptb_prev";
            this.ptb_prev.Size = new System.Drawing.Size(40, 42);
            this.ptb_prev.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptb_prev.TabIndex = 15;
            this.ptb_prev.TabStop = false;
            this.toolTip1.SetToolTip(this.ptb_prev, "Xem trạng thái trước đó");
            this.ptb_prev.Click += new System.EventHandler(this.ptb_prev_Click);
            // 
            // ptb_next
            // 
            this.ptb_next.Location = new System.Drawing.Point(6, 137);
            this.ptb_next.Name = "ptb_next";
            this.ptb_next.Size = new System.Drawing.Size(40, 42);
            this.ptb_next.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptb_next.TabIndex = 14;
            this.ptb_next.TabStop = false;
            this.toolTip1.SetToolTip(this.ptb_next, "Xem trạng thái kế tiếp");
            this.ptb_next.Click += new System.EventHandler(this.ptb_next_Click);
            // 
            // ptb_reload
            // 
            this.ptb_reload.Location = new System.Drawing.Point(12, 52);
            this.ptb_reload.Name = "ptb_reload";
            this.ptb_reload.Size = new System.Drawing.Size(40, 40);
            this.ptb_reload.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptb_reload.TabIndex = 13;
            this.ptb_reload.TabStop = false;
            this.toolTip1.SetToolTip(this.ptb_reload, "Reload");
            this.ptb_reload.Click += new System.EventHandler(this.ptb_reload_Click);
            // 
            // ptb_Setup
            // 
            this.ptb_Setup.Location = new System.Drawing.Point(516, 58);
            this.ptb_Setup.Name = "ptb_Setup";
            this.ptb_Setup.Size = new System.Drawing.Size(34, 34);
            this.ptb_Setup.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptb_Setup.TabIndex = 12;
            this.ptb_Setup.TabStop = false;
            this.ptb_Setup.Tag = "";
            this.toolTip1.SetToolTip(this.ptb_Setup, "Cài đặt");
            this.ptb_Setup.Click += new System.EventHandler(this.ptb_Setup_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "\"Chess save file|*.csf";
            this.saveFileDialog1.RestoreDirectory = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "\"Chess save file|*.csf";
            this.openFileDialog1.RestoreDirectory = true;
            // 
            // Chess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(743, 477);
            this.Controls.Add(this.ptb_save);
            this.Controls.Add(this.ptb_open);
            this.Controls.Add(this.ptb_abort);
            this.Controls.Add(this.ptb_top);
            this.Controls.Add(this.ptb_bottom);
            this.Controls.Add(this.ptb_prev);
            this.Controls.Add(this.ptb_next);
            this.Controls.Add(this.ptb_reload);
            this.Controls.Add(this.ptb_Setup);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Chess";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chess 2015";
            this.Load += new System.EventHandler(this.Chess_Load);
            this.SizeChanged += new System.EventHandler(this.Chess_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Chess_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Chess_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.ptb_save)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_open)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_abort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_top)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_bottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_prev)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_next)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_reload)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_Setup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ptb_Setup;
        private System.Windows.Forms.PictureBox ptb_reload;
        private System.Windows.Forms.PictureBox ptb_next;
        private System.Windows.Forms.PictureBox ptb_prev;
        private System.Windows.Forms.PictureBox ptb_bottom;
        private System.Windows.Forms.PictureBox ptb_top;
        private System.Windows.Forms.PictureBox ptb_abort;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox ptb_open;
        private System.Windows.Forms.PictureBox ptb_save;



    }
}
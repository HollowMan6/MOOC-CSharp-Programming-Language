namespace 作业_背单词
{
    partial class ReciteWordsForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReciteWordsForm));
            this.tboEnglishWord = new System.Windows.Forms.TextBox();
            this.tboChinese = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.trackBarMoveSpeed = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSaveProgress = new System.Windows.Forms.Button();
            this.btnOpenProgress = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRandom = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMoveSpeed)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tboEnglishWord
            // 
            this.tboEnglishWord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tboEnglishWord.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tboEnglishWord.Font = new System.Drawing.Font("微软雅黑", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tboEnglishWord.ForeColor = System.Drawing.Color.Yellow;
            this.tboEnglishWord.Location = new System.Drawing.Point(24, 25);
            this.tboEnglishWord.Multiline = true;
            this.tboEnglishWord.Name = "tboEnglishWord";
            this.tboEnglishWord.ReadOnly = true;
            this.tboEnglishWord.Size = new System.Drawing.Size(750, 111);
            this.tboEnglishWord.TabIndex = 0;
            // 
            // tboChinese
            // 
            this.tboChinese.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tboChinese.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tboChinese.Font = new System.Drawing.Font("微软雅黑", 22.2F);
            this.tboChinese.Location = new System.Drawing.Point(24, 156);
            this.tboChinese.Multiline = true;
            this.tboChinese.Name = "tboChinese";
            this.tboChinese.ReadOnly = true;
            this.tboChinese.Size = new System.Drawing.Size(750, 78);
            this.tboChinese.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // trackBarMoveSpeed
            // 
            this.trackBarMoveSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarMoveSpeed.AutoSize = false;
            this.trackBarMoveSpeed.LargeChange = 1000;
            this.trackBarMoveSpeed.Location = new System.Drawing.Point(562, 25);
            this.trackBarMoveSpeed.Maximum = 10000;
            this.trackBarMoveSpeed.Minimum = 1000;
            this.trackBarMoveSpeed.Name = "trackBarMoveSpeed";
            this.trackBarMoveSpeed.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.trackBarMoveSpeed.Size = new System.Drawing.Size(169, 31);
            this.trackBarMoveSpeed.TabIndex = 13;
            this.trackBarMoveSpeed.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarMoveSpeed.Value = 3000;
            this.trackBarMoveSpeed.Scroll += new System.EventHandler(this.trackBarMoveSpeed_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(486, 33);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "速度：慢";
            // 
            // btnSaveProgress
            // 
            this.btnSaveProgress.Location = new System.Drawing.Point(3, 20);
            this.btnSaveProgress.Name = "btnSaveProgress";
            this.btnSaveProgress.Size = new System.Drawing.Size(112, 40);
            this.btnSaveProgress.TabIndex = 14;
            this.btnSaveProgress.Text = "保存进度";
            this.btnSaveProgress.UseVisualStyleBackColor = true;
            this.btnSaveProgress.Click += new System.EventHandler(this.btnSaveProgress_Click);
            // 
            // btnOpenProgress
            // 
            this.btnOpenProgress.Location = new System.Drawing.Point(124, 20);
            this.btnOpenProgress.Name = "btnOpenProgress";
            this.btnOpenProgress.Size = new System.Drawing.Size(112, 40);
            this.btnOpenProgress.TabIndex = 14;
            this.btnOpenProgress.Text = "读取进度";
            this.btnOpenProgress.UseVisualStyleBackColor = true;
            this.btnOpenProgress.Click += new System.EventHandler(this.btnOpenProgress_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnOpenProgress);
            this.panel1.Controls.Add(this.btnRandom);
            this.panel1.Controls.Add(this.btnStop);
            this.panel1.Controls.Add(this.btnPause);
            this.panel1.Controls.Add(this.btnSaveProgress);
            this.panel1.Controls.Add(this.trackBarMoveSpeed);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(25, 263);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(749, 76);
            this.panel1.TabIndex = 15;
            // 
            // btnRandom
            // 
            this.btnRandom.Location = new System.Drawing.Point(399, 20);
            this.btnRandom.Name = "btnRandom";
            this.btnRandom.Size = new System.Drawing.Size(82, 40);
            this.btnRandom.TabIndex = 14;
            this.btnRandom.Text = "随机";
            this.btnRandom.UseVisualStyleBackColor = true;
            this.btnRandom.Click += new System.EventHandler(this.btnRandom_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(322, 20);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(68, 40);
            this.btnStop.TabIndex = 14;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(245, 20);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(68, 40);
            this.btnPause.TabIndex = 14;
            this.btnPause.Text = "暂停";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // ReciteWordsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 358);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tboChinese);
            this.Controls.Add(this.tboEnglishWord);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReciteWordsForm";
            this.Text = "背单词：大学四级";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ReciteWordsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMoveSpeed)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tboEnglishWord;
        private System.Windows.Forms.TextBox tboChinese;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TrackBar trackBarMoveSpeed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSaveProgress;
        private System.Windows.Forms.Button btnOpenProgress;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnRandom;


    }
}


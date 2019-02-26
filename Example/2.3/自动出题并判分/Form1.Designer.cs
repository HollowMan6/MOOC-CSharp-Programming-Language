namespace Test
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lblA = new System.Windows.Forms.Label();
            this.txtAnswer = new System.Windows.Forms.TextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnJudge = new System.Windows.Forms.Button();
            this.lblOp = new System.Windows.Forms.Label();
            this.lblB = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lstDisp = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lblA
            // 
            this.lblA.AutoSize = true;
            this.lblA.Location = new System.Drawing.Point(63, 77);
            this.lblA.Name = "lblA";
            this.lblA.Size = new System.Drawing.Size(0, 15);
            this.lblA.TabIndex = 0;
            // 
            // txtAnswer
            // 
            this.txtAnswer.Location = new System.Drawing.Point(279, 74);
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.Size = new System.Drawing.Size(100, 25);
            this.txtAnswer.TabIndex = 1;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(93, 140);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 3;
            this.btnNew.Text = "出题";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnJudge
            // 
            this.btnJudge.Location = new System.Drawing.Point(257, 140);
            this.btnJudge.Name = "btnJudge";
            this.btnJudge.Size = new System.Drawing.Size(75, 23);
            this.btnJudge.TabIndex = 4;
            this.btnJudge.Text = "得分";
            this.btnJudge.UseVisualStyleBackColor = true;
            this.btnJudge.Click += new System.EventHandler(this.BtnJudge_Click_1);
            // 
            // lblOp
            // 
            this.lblOp.AutoSize = true;
            this.lblOp.Location = new System.Drawing.Point(113, 77);
            this.lblOp.Name = "lblOp";
            this.lblOp.Size = new System.Drawing.Size(0, 15);
            this.lblOp.TabIndex = 5;
            // 
            // lblB
            // 
            this.lblB.AutoSize = true;
            this.lblB.Location = new System.Drawing.Point(164, 77);
            this.lblB.Name = "lblB";
            this.lblB.Size = new System.Drawing.Size(0, 15);
            this.lblB.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(235, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "=";
            // 
            // lstDisp
            // 
            this.lstDisp.FormattingEnabled = true;
            this.lstDisp.ItemHeight = 15;
            this.lstDisp.Location = new System.Drawing.Point(40, 191);
            this.lstDisp.Name = "lstDisp";
            this.lstDisp.Size = new System.Drawing.Size(324, 199);
            this.lstDisp.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 450);
            this.Controls.Add(this.lstDisp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblB);
            this.Controls.Add(this.lblOp);
            this.Controls.Add(this.btnJudge);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.txtAnswer);
            this.Controls.Add(this.lblA);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblA;
        private System.Windows.Forms.TextBox txtAnswer;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnJudge;
        private System.Windows.Forms.Label lblOp;
        private System.Windows.Forms.Label lblB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lstDisp;
    }
}


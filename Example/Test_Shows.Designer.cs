namespace Example
{
    partial class Test_Shows
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
            this.Start = new System.Windows.Forms.Button();
            this.pause = new System.Windows.Forms.Button();
            this.resume = new System.Windows.Forms.Button();
            this.stop = new System.Windows.Forms.Button();
            this.displayWindow = new System.Windows.Forms.RichTextBox();
            this.SelectMethod = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SelectMethod)).BeginInit();
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(107, 187);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(112, 44);
            this.Start.TabIndex = 0;
            this.Start.Text = "启动";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // pause
            // 
            this.pause.Location = new System.Drawing.Point(107, 267);
            this.pause.Name = "pause";
            this.pause.Size = new System.Drawing.Size(112, 44);
            this.pause.TabIndex = 1;
            this.pause.Text = "暂停";
            this.pause.UseVisualStyleBackColor = true;
            this.pause.Click += new System.EventHandler(this.pause_Click);
            // 
            // resume
            // 
            this.resume.Location = new System.Drawing.Point(107, 347);
            this.resume.Name = "resume";
            this.resume.Size = new System.Drawing.Size(112, 44);
            this.resume.TabIndex = 2;
            this.resume.Text = "恢复";
            this.resume.UseVisualStyleBackColor = true;
            this.resume.Click += new System.EventHandler(this.resume_Click);
            // 
            // stop
            // 
            this.stop.Location = new System.Drawing.Point(107, 427);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(112, 44);
            this.stop.TabIndex = 3;
            this.stop.Text = "停止";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // displayWindow
            // 
            this.displayWindow.Location = new System.Drawing.Point(292, 66);
            this.displayWindow.Name = "displayWindow";
            this.displayWindow.Size = new System.Drawing.Size(401, 429);
            this.displayWindow.TabIndex = 4;
            this.displayWindow.Text = "";
            this.displayWindow.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.displayWindow_MouseDoubleClick);
            // 
            // SelectMethod
            // 
            this.SelectMethod.Location = new System.Drawing.Point(103, 123);
            this.SelectMethod.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.SelectMethod.Name = "SelectMethod";
            this.SelectMethod.Size = new System.Drawing.Size(120, 28);
            this.SelectMethod.TabIndex = 5;
            this.SelectMethod.ValueChanged += new System.EventHandler(this.SelectMethod_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(110, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "方式选择";
            // 
            // Test_Shows
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 564);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SelectMethod);
            this.Controls.Add(this.displayWindow);
            this.Controls.Add(this.stop);
            this.Controls.Add(this.resume);
            this.Controls.Add(this.pause);
            this.Controls.Add(this.Start);
            this.Name = "Test_Shows";
            this.Text = "Test";
            ((System.ComponentModel.ISupportInitialize)(this.SelectMethod)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button pause;
        private System.Windows.Forms.Button resume;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.RichTextBox displayWindow;
        private System.Windows.Forms.NumericUpDown SelectMethod;
        private System.Windows.Forms.Label label1;
    }
}


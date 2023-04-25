namespace BarrageGrab
{
    partial class MainForm
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
            this.titleLbl = new System.Windows.Forms.Label();
            this.serverLocationLbl = new System.Windows.Forms.Label();
            this.danmuTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // titleLbl
            // 
            this.titleLbl.AutoSize = true;
            this.titleLbl.Location = new System.Drawing.Point(32, 27);
            this.titleLbl.Name = "titleLbl";
            this.titleLbl.Size = new System.Drawing.Size(113, 12);
            this.titleLbl.TabIndex = 0;
            this.titleLbl.Text = "抖音弹幕监听推送：";
            // 
            // serverLocationLbl
            // 
            this.serverLocationLbl.AutoSize = true;
            this.serverLocationLbl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.serverLocationLbl.ForeColor = System.Drawing.Color.Red;
            this.serverLocationLbl.Location = new System.Drawing.Point(137, 27);
            this.serverLocationLbl.Name = "serverLocationLbl";
            this.serverLocationLbl.Size = new System.Drawing.Size(26, 12);
            this.serverLocationLbl.TabIndex = 1;
            this.serverLocationLbl.Text = "123";
            // 
            // danmuTextBox
            // 
            this.danmuTextBox.Location = new System.Drawing.Point(34, 63);
            this.danmuTextBox.Name = "danmuTextBox";
            this.danmuTextBox.ReadOnly = true;
            this.danmuTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.danmuTextBox.Size = new System.Drawing.Size(628, 350);
            this.danmuTextBox.TabIndex = 2;
            this.danmuTextBox.Text = "";

            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.danmuTextBox);
            this.Controls.Add(this.serverLocationLbl);
            this.Controls.Add(this.titleLbl);
            this.Name = "MainForm";
            this.Text = "DY弹幕采集器";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.onMainFormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLbl;
        private System.Windows.Forms.Label serverLocationLbl;
        private System.Windows.Forms.RichTextBox danmuTextBox;
    }
}


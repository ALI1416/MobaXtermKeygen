namespace MobaXtermKeygen
{
    partial class Main
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
            this.titleLabel = new System.Windows.Forms.Label();
            this.licenseGroupBox = new System.Windows.Forms.GroupBox();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.versionTextBox = new System.Windows.Forms.TextBox();
            this.versionLabel = new System.Windows.Forms.Label();
            this.generateBtn = new System.Windows.Forms.Button();
            this.licenseGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold);
            this.titleLabel.Location = new System.Drawing.Point(35, 10);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(315, 27);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "MobaXterm许可证生成器";
            // 
            // licenseGroupBox
            // 
            this.licenseGroupBox.Controls.Add(this.usernameTextBox);
            this.licenseGroupBox.Controls.Add(this.usernameLabel);
            this.licenseGroupBox.Controls.Add(this.versionTextBox);
            this.licenseGroupBox.Controls.Add(this.versionLabel);
            this.licenseGroupBox.Location = new System.Drawing.Point(112, 50);
            this.licenseGroupBox.Name = "licenseGroupBox";
            this.licenseGroupBox.Size = new System.Drawing.Size(160, 80);
            this.licenseGroupBox.TabIndex = 2;
            this.licenseGroupBox.TabStop = false;
            this.licenseGroupBox.Text = "许可证信息";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(55, 20);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(100, 21);
            this.usernameTextBox.TabIndex = 2;
            this.usernameTextBox.Text = "ALI1416";
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(5, 24);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(53, 12);
            this.usernameLabel.TabIndex = 0;
            this.usernameLabel.Text = "用户名：";
            // 
            // versionTextBox
            // 
            this.versionTextBox.Location = new System.Drawing.Point(55, 50);
            this.versionTextBox.Name = "versionTextBox";
            this.versionTextBox.Size = new System.Drawing.Size(100, 21);
            this.versionTextBox.TabIndex = 3;
            this.versionTextBox.Text = "25.2";
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Location = new System.Drawing.Point(5, 54);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(53, 12);
            this.versionLabel.TabIndex = 0;
            this.versionLabel.Text = "版本号：";
            // 
            // generateBtn
            // 
            this.generateBtn.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold);
            this.generateBtn.Location = new System.Drawing.Point(132, 140);
            this.generateBtn.Name = "generateBtn";
            this.generateBtn.Size = new System.Drawing.Size(120, 40);
            this.generateBtn.TabIndex = 1;
            this.generateBtn.Text = "生成";
            this.generateBtn.UseVisualStyleBackColor = true;
            this.generateBtn.Click += new System.EventHandler(this.GenerateBtn_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 191);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.licenseGroupBox);
            this.Controls.Add(this.generateBtn);
            this.Name = "Main";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MobaXtermKeygen";
            this.licenseGroupBox.ResumeLayout(false);
            this.licenseGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        /// <summary>
        /// 标题Label
        /// </summary>
        private System.Windows.Forms.Label titleLabel;
        /// <summary>
        /// 许可证信息GroupBox
        /// </summary>
        private System.Windows.Forms.GroupBox licenseGroupBox;
        /// <summary>
        /// 用户名Label
        /// </summary>
        private System.Windows.Forms.Label usernameLabel;
        /// <summary>
        /// 用户名TextBox
        /// </summary>
        private System.Windows.Forms.TextBox usernameTextBox;
        /// <summary>
        /// 版本号Label
        /// </summary>
        private System.Windows.Forms.Label versionLabel;
        /// <summary>
        /// 版本号TextBox
        /// </summary>
        private System.Windows.Forms.TextBox versionTextBox;
        /// <summary>
        /// 生成Button
        /// </summary>
        private System.Windows.Forms.Button generateBtn;

    }
}

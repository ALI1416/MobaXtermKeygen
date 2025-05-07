using System;
using System.IO;
using System.Windows.Forms;

namespace MobaXtermKeygen
{

    /// <summary>
    /// 主界面
    /// </summary>
    public partial class Main : Form
    {

        /// <summary>
        /// 主程序
        /// </summary>
        public Main()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 点击生成按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenerateBtn_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string version = versionTextBox.Text;
            if (username.Length == 0)
            {
                ShowError("用户名不可为空！");
                return;
            }
            string[] versionSplit = version.Split('.');
            if (versionSplit.Length != 2)
            {
                ShowError("版本号必须为2段！例如25.2");
                return;
            }
            int majorVersion;
            int minorVersion;
            try
            {
                majorVersion = int.Parse(versionSplit[0]);
                minorVersion = int.Parse(versionSplit[1]);
            }
            catch
            {
                ShowError("版本号每段都必须为数字！例如25.2");
                return;
            }
            License.Generate(1, 1, username, majorVersion, minorVersion);
            MessageBox.Show("许可证生成成功！\r\n文件位置 " + Path.GetFullPath("./Custom.mxtpro")
                + "\r\n请将该文件移动到MobaXterm程序根目录", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 显示错误
        /// </summary>
        /// <param name="text"></param>
        public static void ShowError(string text)
        {
            MessageBox.Show(text, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}

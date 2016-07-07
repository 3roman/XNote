using System;
using System.Windows.Forms;

namespace XNote
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 设置标题栏
            // 版本号组成：主版本+次版本+内部版本号+修订号
            var title = string.Format("XNote Ver{0}   『C0der by hangch』", Application.ProductVersion);
            Application.Run(new Form1 { Text = title });
        }


   }
};

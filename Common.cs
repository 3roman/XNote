using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace  XNote
{
    public partial class Form1
    {
        private static DataTable Execute(string sql)
        {
            using (var conn = new SQLiteConnection("Data Source=XNote.db"))
            {
                conn.Open();
                var cmd = new SQLiteDataAdapter(sql, conn);
                var dt = new DataTable();
                cmd.Fill(dt);

                return dt;
            }
        }

        /// <summary>
        ///  选择文件夹
        /// </summary>
        /// <param name="description">选择文件夹对话框说明</param>
        /// <returns></returns>
        public static string SelectPath(string description)
        {
            var fbd = new FolderBrowserDialog { Description = description };
            fbd.ShowDialog();
            return fbd.SelectedPath;
        }

        public static void ReleaseResource(string filePath, string resourceName)
        {
            // 针对所有流文件
            // 获取当前正在执行的程序集
            var assembly = Assembly.GetExecutingAssembly();
            //foreach (var file in assembly.GetManifestResourceNames())
            // // 辅助方法：获取资源在程序集内部的名称
            // MessageBox.Show(file);
            var stream = assembly.GetManifestResourceStream(resourceName);
            // 将流读取到二进制数组中
            if (stream == null) return;
            var buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);
            // 将二进制写入文件
            if (File.Exists(filePath)) return;
            var fs = new FileStream(filePath, FileMode.CreateNew, FileAccess.Write);
            fs.Write(buffer, 0, buffer.Length);
            fs.Flush();
            fs.Close();
        }

        /// <summary>
        /// 遍历目录及其子目录下的所有文件
        /// </summary>
        /// <param name="baseDirectory">起始目录</param>
        /// <param name="files">存放返回值的字典（文件名-文件路径对）</param>
        public static void FindFiles(string baseDirectory, Dictionary<string, string> files)
        {
            //在指定目录及子目录下查找文件
            var directoryInfo = new DirectoryInfo(baseDirectory);

            // 查找子目录
            foreach (var d in directoryInfo.GetDirectories())
            {
                FindFiles(directoryInfo + "\\" + d + "\\", files);
            }

            // 查找文件
            foreach (var f in directoryInfo.GetFiles().Where(f => !files.Keys.Contains(f.Name)))
            {
                files.Add(f.Name, f.FullName);
            }
        }

        public static void Copy2Clipboard(string context)
        {
            Clipboard.Clear();
            Clipboard.SetData(DataFormats.Text, context);
        }
    }

    public class PictureHelper
    {
        public static byte[] ImageToByte(Image image, ImageFormat format)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, format);
                var imageBytes = ms.ToArray();
                return imageBytes;
            }
        }

        public static Image ByteToImage(byte[] imageBytes)
        {
            
            var ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = new Bitmap(ms);
            return image;
        }
    }
}
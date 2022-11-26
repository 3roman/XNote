using Stylet;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using XNote.DAL;
using XNote.Model;
using XNote.Utility;

namespace XNote.ViewModel
{
    public class MainViewModel : Screen
    {
        public BindableCollection<Record> Records { get; set; } = new BindableCollection<Record>();
        public Record CurrentRow { get; set; } = new Record();
        public string Keywords { get; set; }

        public MainViewModel()
        {
            Task.Factory.StartNew(() => Records.AddRange(MySQLAccessor.RetrieveAllRecords()));
            Records.CollectionChanged += Records_CollectionChanged;
        }

        public void Records_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                MySQLAccessor.DeleteRecordById((e.OldItems[0] as Record).Id);
            }
            else if (e.Action == NotifyCollectionChangedAction.Add)
            {
                int lastRecordId = MySQLAccessor.AddEmptyRecord();
                Records[Records.Count - 1].Id = lastRecordId;
            }
        }

        public void Search(KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Records.Clear();
                IEnumerable<Record> result = MySQLAccessor.SearchRecordByContent(Keywords.Split());
                Records.AddRange(result);
            }
            else if (e.Key == Key.Escape)
            {
                Keywords = string.Empty;
                Records.Clear();
                Records.AddRange(MySQLAccessor.RetrieveAllRecords());
            }
        }

        public void Update()
        {
            MySQLAccessor.UpdateRecord(CurrentRow);
        }

        public void SaveImage()
        {
            if (System.Windows.Forms.Clipboard.ContainsImage())
            {
                byte[] buffer = ImageHelper.ImageToBytes(System.Windows.Forms.Clipboard.GetImage(), ImageFormat.Png);
                MySQLAccessor.SaveImage(CurrentRow.Id, buffer);
            }
        }

        public void CleanImage()
        {
            MySQLAccessor.CleanImage(CurrentRow.Id);
        }

        public void ViewImage()
        {
            byte[] buffer = MySQLAccessor.ViewImage(CurrentRow.Id);
            if (buffer.Length > 0)
            {
                string imagePath = Path.Combine(Environment.GetEnvironmentVariable("TEMP"), Guid.NewGuid().ToString());
                imagePath += ".png";
                ImageHelper.BytesToImage(buffer, imagePath);
                Process.Start(imagePath);
            }
        }
    }
}

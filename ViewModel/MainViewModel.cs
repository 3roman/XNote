using Stylet;
using XNote.Model;
using XNote.DAL;
using System.Windows.Input;
using System.Threading;

namespace XNote.ViewModel
{
    class MainViewModel : Screen
    {
        public BindableCollection<Record> Records { get; set; } = new BindableCollection<Record>();
        public string Keywords { get; set; }

        public MainViewModel()
        {
            Thread t = new Thread(() => Records.AddRange(MySQLAccessor.RetrieveAllRecords().Result));
            t.Start();
        }

        public void Search(KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Records.Clear();
                var result = MySQLAccessor.RetrieveSpecificRecords(Keywords.Split());
                Records.AddRange(result);
            }
            else if (e.Key == Key.Escape)
            {
                Keywords = string.Empty;
                Records.Clear();
                Records.AddRange(MySQLAccessor.RetrieveAllRecords().Result);
            }
        }
    }
}

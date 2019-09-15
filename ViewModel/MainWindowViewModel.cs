using Commander;
using PropertyChanged;
using System.Collections.ObjectModel;
using XNote.Model;
using System.Windows;
using Dapper;
using System.Data.SQLite;
using System.Collections.Generic;

namespace XNote.ViewModel
{
    [ImplementPropertyChanged]
    class MainWindowViewModel
    {
        public ObservableCollection<Record> Records { get; set; } = new ObservableCollection<Record>();
        public string KeyWord { get; set; }

        public MainWindowViewModel()
        {
            var Conn = new SQLiteConnection("Data Source=data.db");
            var data = Conn.Query<Record>("SELECT * FROM tb_record");
            ConvertToObservableCollection(data);
        }

        private void ConvertToObservableCollection(IEnumerable<Record> items)
        {
            foreach (var item in items)
            {
                var record = item as Record;
                Records.Add(new Record
                {
                    Id = item.Id,
                    Content = item.Content,
                    Standard = item.Standard,
                    Clause = item.Clause
                });
            }
        }


        [OnCommand("SearchCommand")]
        private void Search(object parameter)
        {
              MessageBox.Show("Test");
            //var query = ds.Retrieve().Where(x => x.Content.Contains(KeyWord));
            //Records = new ObservableCollection<Record>(query);
        }
    }
}

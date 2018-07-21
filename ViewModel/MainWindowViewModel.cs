using Commander;
using PropertyChanged;
using System.Collections.ObjectModel;
using XNote.Model;
using XNote.Service;

namespace XNote.ViewModel
{
    [ImplementPropertyChanged]
    class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            ds = new DataService("data.db");

            var query = ds.Retrieve();
            Records = new ObservableCollection<Record>(query);
        }

        [DoNotNotify]
        public DataService ds { get; set; }
        public ObservableCollection<Record> Records { get; set; }
        public string KeyWord { get; set; }

        [OnCommand("SearchCommand")]
        private void Search(object parameter)
        {
            var query = ds.Retrieve().Where(x => x.Content.Contains(KeyWord));
            Records = new ObservableCollection<Record>(query);
        }
    }
}

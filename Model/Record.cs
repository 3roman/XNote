using PropertyChanged;

namespace XNote.Model
{
    [ImplementPropertyChanged]
    class Record
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Reference { get; set; }
       
    }
}
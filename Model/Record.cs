using Stylet;

namespace XNote.Model
{
    public class Record : PropertyChangedBase
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Code { get; set; }
        public string Clause { get; set; }
        public string Catalog { get; set; }
        public byte[] Image { get; set; }
        public bool ImageFlag => Image != null;
    }
}
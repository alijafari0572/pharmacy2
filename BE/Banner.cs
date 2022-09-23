using System;

namespace BE
{
    public class Banner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool State { get; set; }
        public string H4 { get; set; }//قسمت فونت کوچک روی بنر
        public string H3 { get; set; }//قسمت فونت بزرگ روی بنر
        public string Image { get; set; }
        public int DragId { get; set; }
    }
}
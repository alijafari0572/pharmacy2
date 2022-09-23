namespace pharmacy2.Models.Order
{
    public class OrderDetail_Model
    {
        public string UserName { get; set; }
        public int OrderId { get; set; }
        public int DragId { get; set; }
        public string DragName { get; set; }
        public string DragPic { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public int TotalPrice { get; set; }
    }
}

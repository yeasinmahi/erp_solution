namespace Model
{
    public class FactoryReceiveMRRItemDetail
    {
        public int MrrId { get; set; }
        public int ItemId { get; set; }
        public decimal PoQuantity { get; set; }
        public decimal ReceiveQuantity { get; set; }
        public decimal FcRate { get; set; }
        public decimal FcTotal { get; set; }
        public decimal BdtTotal { get; set; }
        public int LocationId { get; set; }
        public int PoId { get; set; }
        public string ReceiveRemarks { get; set; }
        public decimal VatAmount { get; set; }
        public decimal AitAmount { get; set; }

    }
}

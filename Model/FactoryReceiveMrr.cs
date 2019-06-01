namespace Model
{
    public class FactoryReceiveMrr
    {
        public int MrrId { get; set; }
        public int PoId { get; set; }
        public int SupplierId { get; set; }
        public int ShipmentSl { get; set; }
        public int LastActionBy { get; set; }
        public int UnitId { get; set; }
        public string ExternalRef { get; set; }
        public string ChallanDate { get; set; }
        public string MrrCode { get; set; }
        public int WhId { get; set; }
        public string VatChallan { get; set; }
        public decimal TotalVat { get; set; }
        public decimal TotalAit { get; set; }
        public decimal PvAmount { get; set; }
        public int ShipmentId { get; set; }
        public bool IsInventoryInserted { get; set; }
    }
}

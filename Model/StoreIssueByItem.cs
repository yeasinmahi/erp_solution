namespace Model
{
    public class StoreIssueByItem
    {
        public int ItemId { get; set; }
        public decimal IssueQuantity { get; set; }
        public decimal IssueValue { get; set; }
        public decimal StockQuantity { get; set; }
        public int LocationId { get; set; }
        public string Remarks { get; set; }
    }
}

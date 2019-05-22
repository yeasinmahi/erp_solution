namespace Model
{
    public class StoreIssue
    {
        public int WhId { get; set; }
        public int RequsitionId { get; set; }
        public string RequsitionCode { get; set; }
        public string RequsitionDate { get; set; }
        public int DepartmentId { get; set; }
        public string Section { get; set; }
        public int InsertBy { get; set; }
        public string ReceiveBy { get; set; }
        public int CostCenterId { get; set; }
    }
}

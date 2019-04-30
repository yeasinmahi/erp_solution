using System;

namespace Model
{
    public class ApiSmsModel
    {
        public int UnitId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string MaskingClient { get; set; }
        public string PhoneNo { get; set; }
        public string Message { get; set; }
        public DateTime InsertDate { get; set; }
    }
}

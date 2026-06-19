namespace flightManagement.Data
{
    public class Flight
    {
        public int Id { get; set; }
        public string flightdestination { get; set; } = string.Empty;
        public string OriginCode { get; set; } = "MNL";
        public string DestinationCode { get; set; } = string.Empty;
        public TimeOnly time { get; set; }
        public decimal price { get; set; }
    }
}
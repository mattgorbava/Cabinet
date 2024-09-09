namespace Cabinet.Model.Entities
{
    internal class Price
    {
        public int PriceId { get; set; }
        public decimal Value { get; set; }
        public bool IsActive { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}

namespace VidlyMoshNet8.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public short SignUpFree { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
    }
}

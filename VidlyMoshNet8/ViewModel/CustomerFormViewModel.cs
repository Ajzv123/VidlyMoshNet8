using VidlyMoshNet8.Models;

namespace VidlyMoshNet8.ViewModel
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customers Customers { get; set; }

        public CustomerFormViewModel()
        {
            Customers = new Customers();
        }

        public bool IsNew
        {
            get
            {
                return Customers != null && Customers.Id == 0;
            }
        }
    }
}

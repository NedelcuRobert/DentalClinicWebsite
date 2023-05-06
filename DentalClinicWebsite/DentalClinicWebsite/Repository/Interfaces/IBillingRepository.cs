using DentalClinicWebsite.Models;

namespace DentalClinicWebsite.Repository.Interfaces
{
    public interface IBillingRepository
    {
        Billing GetBillingById(int id);
        IEnumerable<Billing> GetAllBillings();
        void AddBilling(Billing billing);
        void UpdateBilling(Billing billing);
        void DeleteBilling(Billing billing);
    }
}

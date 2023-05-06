using DentalClinicWebsite.Models;

namespace DentalClinicWebsite.Services.Interfaces
{
    public interface IBillingService
    {
        Billing GetBillingById(int id);
        IEnumerable<Billing> GetAllBillings();
        void AddBilling(Billing billing);
        void UpdateBilling(Billing billing);
        void DeleteBilling(Billing billing);
    }
}

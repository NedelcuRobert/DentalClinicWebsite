using DentalClinicWebsite.Models;
using DentalClinicWebsite.Repository.Interfaces;
using DentalClinicWebsite.Services.Interfaces;

namespace DentalClinicWebsite.Services
{
    public class BillingService : IBillingService
    {
        private readonly IBillingRepository _billingRepository;

        public BillingService(IBillingRepository billingRepository)
        {
            _billingRepository = billingRepository;
        }

        public Billing GetBillingById(int id)
        {
            return _billingRepository.GetBillingById(id);
        }

        public IEnumerable<Billing> GetAllBillings()
        {
            return _billingRepository.GetAllBillings();
        }

        public void AddBilling(Billing billing)
        {
            if (billing == null)
            {
                throw new ArgumentNullException(nameof(billing), "Billing cannot be null");
            }

            _billingRepository.AddBilling(billing);
        }

        public void UpdateBilling(Billing billing)
        {
            if (billing == null)
            {
                throw new ArgumentNullException(nameof(billing), "Billing cannot be null");
            }

            _billingRepository.UpdateBilling(billing);
        }

        public void DeleteBilling(Billing billing)
        {
            if (billing == null)
            {
                throw new ArgumentNullException(nameof(billing), "Billing cannot be null");
            }

            _billingRepository.DeleteBilling(billing);
        }
    }
}

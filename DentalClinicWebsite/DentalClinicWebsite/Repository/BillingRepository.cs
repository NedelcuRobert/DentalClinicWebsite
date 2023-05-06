using DentalClinicWebsite.Models;
using DentalClinicWebsite.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DentalClinicWebsite.Repository
{
    public class BillingRepository : IBillingRepository
    {
        private readonly DentalClinicContext _context;

        public BillingRepository(DentalClinicContext context)
        {
            _context = context;
        }

        public Billing GetBillingById(int id)
        {
            return _context.Billings.FirstOrDefault(b => b.ID == id);
        }

        public IEnumerable<Billing> GetAllBillings()
        {
            return _context.Billings.ToList();
        }

        public void AddBilling(Billing billing)
        {
            if (billing == null)
            {
                throw new ArgumentNullException(nameof(billing), "Billing cannot be null");
            }

            _context.Billings.Add(billing);
            _context.SaveChanges();
        }

        public void UpdateBilling(Billing billing)
        {
            if (billing == null)
            {
                throw new ArgumentNullException(nameof(billing), "Billing cannot be null");
            }

            _context.Entry(billing).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteBilling(Billing billing)
        {
            if (billing == null)
            {
                throw new ArgumentNullException(nameof(billing), "Billing cannot be null");
            }

            _context.Billings.Remove(billing);
            _context.SaveChanges();
        }
    }
}

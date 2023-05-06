using DentalClinicWebsite.Models;
using DentalClinicWebsite.Repository.Interfaces;

namespace DentalClinicWebsite.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DentalClinicContext _context;

        public RoleRepository(DentalClinicContext context)
        {
            _context = context;
        }

        public IEnumerable<Role> GetAllRoles()
        {
            return _context.Roles.ToList();
        }

        public Role GetRoleById(int id)
        {
            return _context.Roles.FirstOrDefault(r => r.ID == id);
        }

        public void AddRole(Role role)
        {
            _context.Roles.Add(role);
            _context.SaveChanges();
        }

        public void UpdateRole(Role role)
        {
            _context.Roles.Update(role);
            _context.SaveChanges();
        }

        public void DeleteRole(int id)
        {
            var role = _context.Roles.FirstOrDefault(r => r.ID == id);
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role), "Role not found");
            }

            _context.Roles.Remove(role);
            _context.SaveChanges();
        }
    }
}

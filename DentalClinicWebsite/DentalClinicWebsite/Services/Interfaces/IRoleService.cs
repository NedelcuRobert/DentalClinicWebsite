using DentalClinicWebsite.Models;

namespace DentalClinicWebsite.Services.Interfaces
{
    public interface IRoleService
    {
        IEnumerable<Role> GetAllRoles();
        Role GetRoleById(int id);
        void AddRole(Role role);
        void UpdateRole(Role role);
        void DeleteRole(int id);
    }
}

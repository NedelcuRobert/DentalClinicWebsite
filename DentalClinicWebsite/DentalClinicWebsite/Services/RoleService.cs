using DentalClinicWebsite.Models;
using DentalClinicWebsite.Repository.Interfaces;
using DentalClinicWebsite.Services.Interfaces;

namespace DentalClinicWebsite.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public IEnumerable<Role> GetAllRoles()
        {
            return _roleRepository.GetAllRoles();
        }

        public Role GetRoleById(int id)
        {
            return _roleRepository.GetRoleById(id);
        }

        public void AddRole(Role role)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role), "Role cannot be null");
            }

            if (string.IsNullOrEmpty(role.Name))
            {
                throw new ArgumentException("Role name is required");
            }

            _roleRepository.AddRole(role);
        }

        public void UpdateRole(Role role)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role), "Role cannot be null");
            }

            if (string.IsNullOrEmpty(role.Name))
            {
                throw new ArgumentException("Role name is required");
            }

            _roleRepository.UpdateRole(role);
        }

        public void DeleteRole(int id)
        {
            _roleRepository.DeleteRole(id);
        }
    }
}

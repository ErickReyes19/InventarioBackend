using Inventario.models.Rol;

namespace Inventario.interfaces.Rol
{
    public interface IRolesService
    {
        Task<IEnumerable<RolDto>> GetRoles();
        Task<IEnumerable<RolDto>> GetRolesActivos();
        Task<RolDto> GetRolById(string id);
        Task<RolDto> PostRol(Role rol);
        Task<RolDto> PutRol(Role rol, string id);
        Task AssignPermissionsToRole(string roleId, List<string> ids);
    }
}

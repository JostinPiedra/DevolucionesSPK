using System.Collections.Generic;

namespace Model.Custom
{
    public class UsuarioViewModel
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Rol { get; set; }
        public List<RoleViewModel> RolesList { get; set; }
        public string Email { get; set; }
    }

    public class RoleViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}

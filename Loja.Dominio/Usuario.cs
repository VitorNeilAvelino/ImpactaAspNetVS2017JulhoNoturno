using Microsoft.AspNet.Identity.EntityFramework;

namespace Loja.Dominio
{
    //http://www.eduardopires.net.br/2015/09/desacoplando-o-asp-net-identity-do-mvc-e-dominio/
    public class Usuario : IdentityUser
    {
        public string Nome { get; set; }
    }
}
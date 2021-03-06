﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Loja.Dominio
{
    //http://www.eduardopires.net.br/2015/09/desacoplando-o-asp-net-identity-do-mvc-e-dominio/
    public class Usuario : IdentityUser
    {
        public string Nome { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Usuario> manager)
        {
            // Observe que o authenticationType deve corresponder àquele definido em CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Adicionar declarações de usuário personalizado aqui
            userIdentity.AddClaim(new Claim("Nome", Nome));

            return userIdentity;
        }
    }
}
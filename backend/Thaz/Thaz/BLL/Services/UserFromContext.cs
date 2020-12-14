using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Thaz.BLL.Model;

namespace Thaz.BLL.Services
{
    public class UserFromContext : User
    {
        public UserFromContext(IHttpContextAccessor context)
        {
            Name = context.HttpContext.User.Claims
                .First(c => c.Type == nameof(User.Name)).Value;
            Email = context.HttpContext.User.Claims
                .First(c => c.Type == nameof(User.Email)).Value;
            Id = Int32.Parse(context.HttpContext.User.Claims
                .First(c => c.Type == nameof(User.Id)).Value);
        }

    }
}
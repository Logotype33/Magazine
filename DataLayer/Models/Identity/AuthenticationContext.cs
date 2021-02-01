using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models.Identity
{
    public class AuthenticationContext: IdentityDbContext<IdentityUser>
    {
        public AuthenticationContext(DbContextOptions<AuthenticationContext> opt): base(opt)
        {

        }
    }
}

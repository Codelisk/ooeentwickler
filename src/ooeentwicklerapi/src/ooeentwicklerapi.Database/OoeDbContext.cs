using Codelisk.GeneratorAttributes.WebAttributes.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooeentwicklerapi.Database
{
    [BaseContext]
    public partial class OoeDbContext : Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext<UserDto, Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>, System.Guid>
    {
        public OoeDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}

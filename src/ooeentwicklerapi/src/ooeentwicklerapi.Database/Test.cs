using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Restservice.Database
{
    [Codelisk.GeneratorAttributes.GeneratorAttributes.GeneratedDbContextAttribute]
    public partial class BaseDbContext : Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext<UserDto, Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>, System.Guid>
    {
        public BaseDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}

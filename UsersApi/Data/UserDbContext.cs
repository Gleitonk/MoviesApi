using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace UsersApi.Data;

public class UserDbContext : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
{

    public UserDbContext(DbContextOptions<UserDbContext> opts): base(opts)
    {

    }


}

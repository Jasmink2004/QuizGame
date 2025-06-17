using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace QuizGame.Data
{
    public class QuizGameContext : IdentityDbContext<IdentityUser>
    {
        public QuizGameContext(DbContextOptions<QuizGameContext> options)
            : base(options)
        {
        }
        // Your DbSets here if needed
    }
}

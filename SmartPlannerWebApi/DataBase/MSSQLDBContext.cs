
using Microsoft.EntityFrameworkCore;
using SmartPlannerWebApi.Models;

namespace SmartPlannerWebApi.DataBase
{
    public class MSSQLDBContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }

        public MSSQLDBContext(DbContextOptions<MSSQLDBContext> options) : base(options) 
        {
            
        }
    }
}

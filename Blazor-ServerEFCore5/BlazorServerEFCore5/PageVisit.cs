using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerEFCore5
{
    public class PageVisit
    {
        public Guid Id { get; set; }
        public DateTime TimeOfVisit { get; set; }
    }
    public class VisitContext : DbContext
    {
        public DbSet<PageVisit> PageVisits { get; set; }
        public VisitContext(DbContextOptions opt) : base(opt)
        {

        }
    }
}

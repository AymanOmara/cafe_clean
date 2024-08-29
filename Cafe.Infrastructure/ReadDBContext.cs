using Microsoft.EntityFrameworkCore;

namespace Cafe.Infrastructure
{
	public class ReadDBContext : DbContext
    {
        public ReadDBContext(DbContextOptions<ReadDBContext> options) : base(options)
        {

        }
    }
}


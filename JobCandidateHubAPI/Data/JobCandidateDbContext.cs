using Microsoft.EntityFrameworkCore;
using JobCandidateHubAPI.Model;

namespace JobCandidateHubAPI.Data
{
    public class JobCandidateDbContext : DbContext
	{
		public JobCandidateDbContext(DbContextOptions<JobCandidateDbContext> options) :base (options)
		{
		}

        public DbSet<Candidate> Candidates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(15);
                entity.Property(e => e.LinkedInProfileUrl)
                    .HasMaxLength(100);
                entity.Property(e => e.GitHubProfileUrl)
                    .HasMaxLength(100);
                entity.Property(e => e.Comments)
                    .HasMaxLength(500);
            });
        }
    }
   
}




using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Data;
namespace SocialMedia.Models;

public class PostingContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
{
    public DbSet<Comment> Comments { get; set; }

    public DbSet<Reply> Replies { get; set; }

    public DbSet<ApplicationUser> Users { get; set; }

    public DbSet<Post> Posts { get; set; }

    public PostingContext(DbContextOptions<PostingContext> options) : base(options) {}

    protected override void OnConfiguring(DbContextOptionsBuilder contextOptionsBuilder) {
        base.OnConfiguring(contextOptionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Post>()
                                   .HasOne(p => p.User)
                                   .WithMany(u => u.Posts)
                                   .HasForeignKey(p => p.UserID);

        modelBuilder.Entity<Comment>()
                                    .HasOne(c => c.User)
                                    .WithMany(u => u.Comments)
                                    .HasForeignKey(c => c.UserID);

        modelBuilder.Entity<Reply>()
                                    .HasOne(r => r.User)
                                    .WithMany(u => u.Replies)
                                    .HasForeignKey(r => r.UserID);

        modelBuilder.Entity<Post>()
                                   .HasMany(p => p.Comments)
                                   .WithOne(c => c.Post)
                                   .OnDelete(DeleteBehavior.Restrict);


        modelBuilder.Entity<Comment>()
                                    .HasMany(c => c.Replies)
                                    .WithOne(r => r.Comment)
                                    .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Category>()
                                     .HasMany(c => c.Posts)
                                     .WithOne(p => p.Category);

        modelBuilder.ApplyConfiguration(new CategorySeed());
    }
}
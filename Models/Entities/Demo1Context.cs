using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.EntityFrameworkCore.Extensions;

namespace web_net9_mongodb.Models.Entities
{
    public class Demo1Context : DbContext
    {
        //press ctrl+ .
        public DbSet<Tbl_khachhang> tbl_Khachhangs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMongoDB("mongodb://localhost:27017/", "demo1");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Tbl_khachhang>().ToCollection("tbl_khachhang");
        }
        public static Demo1Context Create(IMongoDatabase database) =>
        new(new DbContextOptionsBuilder<Demo1Context>()
            .UseMongoDB(database.Client, database.DatabaseNamespace.DatabaseName)
            .Options);
        public Demo1Context(DbContextOptions options)
            : base(options)
        {
        }
    }
}

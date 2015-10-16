using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FoodSocial.Models
{
    public class DataContext:DbContext
    {
        public DbSet<BaiChiaSe> BaiChiaSes { set; get; }
        public DbSet<Comment> Comments { set; get; }
        public DataContext()
            : base("mydata")
        {
            Database.SetInitializer<DataContext>(new DataInitializer());
        }

        public class DataInitializer : CreateDatabaseIfNotExists<DataContext>
        {
            protected override void Seed(DataContext context)
            {
                //context.SaveChanges();
                base.Seed(context);
            }
        }
    }
}
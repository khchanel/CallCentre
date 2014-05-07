using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CallCentre.Models
{
    public class CallCentreContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public CallCentreContext() : base("name=CallCentreContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CallCentreContext, CallCentre.Migrations.Configuration>());
        }

        public System.Data.Entity.DbSet<CallCentre.Models.Contact> Contacts { get; set; }
        public System.Data.Entity.DbSet<CallCentre.Models.CallLog> CallLogs { get; set; }
    }
}

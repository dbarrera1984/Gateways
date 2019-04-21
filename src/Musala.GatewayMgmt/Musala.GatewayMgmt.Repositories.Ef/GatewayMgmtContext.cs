using Musala.GatewayMgmt.Model;
using Musala.GatewayMgmt.Model.Entities;
using Musala.GatewayMgmt.Repositories.Ef.Configuration;
using Musala.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;

namespace Musala.GatewayMgmt.Repositories.Ef
{
    /// <summary>
    /// This is the main DbContext to work with data in the database.
    /// </summary>
    public class GatewayMgmtContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the MtrCenterContext class.
        /// </summary>
        public GatewayMgmtContext() : base("GatewayMgmtContext")
        {
            Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<Gateway> Gateways { get; set; }
        public DbSet<Device> Devices { get; set; }

        /// <summary>
        /// Hooks into the Save process to get a last-minute chance to look at the entities and change them. Also intercepts exceptions and 
        /// wraps them in a new Exception type.
        /// </summary>
        /// <returns>The number of affected rows.</returns>
        public override int SaveChanges()
        {
            // Need to manually delete all "owned objects" that have been removed from their owner, otherwise they'll be orphaned.
            var orphanedObjects = ChangeTracker.Entries().Where(
                e => (e.State == EntityState.Modified || e.State == EntityState.Added) &&
                e.Entity.GetType().GetInterfaces().Any(x => x.IsGenericType &&
                x.GetGenericTypeDefinition() == typeof(IHasOwner<>)) &&
                e.Reference("Owner").CurrentValue == null);

            foreach (var orphanedObject in orphanedObjects)
            {
                orphanedObject.State = EntityState.Deleted;
            }

            try
            {
                var modified = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified || e.State == EntityState.Added);
                foreach (DbEntityEntry item in modified)
                {
                    var changedOrAddedItem = item.Entity as IDateTracking;
                    if (changedOrAddedItem != null)
                    {
                        if (item.State == EntityState.Added)
                        {
                            // Set automatically Current Date and time in case this field has not been filled.
                            if(changedOrAddedItem.DateCreated == DateTime.MinValue)
                                changedOrAddedItem.DateCreated = DateTime.Now;
                        }
                        //changedOrAddedItem.DateModified = DateTime.Now;
                    }
                }
                return base.SaveChanges();
            }
            catch (DbEntityValidationException entityException)
            {
                var errors = entityException.EntityValidationErrors;
                var result = new StringBuilder();
                var allErrors = new List<ValidationResult>();
                foreach (var error in errors)
                {
                    foreach (var validationError in error.ValidationErrors)
                    {
                        result.AppendFormat("\r\n  Entity of type {0} has validation error \"{1}\" for property {2}.\r\n", error.Entry.Entity.GetType(), validationError.ErrorMessage, validationError.PropertyName);
                        var entity = error.Entry.Entity as MusalaEntity<int>;
                        if (entity != null)
                        {
                            result.Append(entity.IsTransient()
                                ? "  This entity was added in this session.\r\n"
                                : $"  The Id of the entity is {entity.Id}.\r\n");
                        }
                        allErrors.Add(new ValidationResult(validationError.ErrorMessage, new[] { validationError.PropertyName }));
                    }
                }
                throw new ModelValidationException(result.ToString(), entityException, allErrors);
            }
        }

        /// <summary>
        /// Configures the EF context.
        /// </summary>
        /// <param name="modelBuilder">The model builder that needs to be configured.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new GatewayConfiguration());
            modelBuilder.Configurations.Add(new DeviceConfiguration());
        }
    }
}
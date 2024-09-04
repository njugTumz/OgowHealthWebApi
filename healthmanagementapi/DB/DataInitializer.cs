using healthmanagementapi.Entities;
using Microsoft.EntityFrameworkCore;

namespace healthmanagementapi.DB
{
    public class DataInitializer
    {
        private readonly ModelBuilder _modelBuilder;

        public DataInitializer(ModelBuilder modelBuilder)
        {
            this._modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            _modelBuilder.Entity<Role>().HasData
            (
                SeedRoles()
            );
        }

        private Role[] SeedRoles()
        {
            var roles = new[]
            {
                new Role() { Name = "Super Admin" },
                new Role() { Name = "Admin" }
            };
            return roles;
        }
     }
}

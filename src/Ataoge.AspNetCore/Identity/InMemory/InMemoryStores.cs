using System.Collections.Generic;
using Ataoge.AspNetCore.Identity.Entities;

namespace Ataoge.AspNetCore.Identity.InMemory
{
    public static class InMemoryStores
    {
        static InMemoryStores()
        {
            roles = new List<IntIdentityRole>()
                {
                    new IntIdentityRole() { Id = 0, Name = "administrators", NormalizedName="ADMINISTRATORS" }
                };
            users = new List<IntIdentityUser>()
                {
                    new IntIdentityUser() { Id = 0, UserName = "admin", NormalizedUserName = "ADMIN", Email = "admin@ataoge.com", NormalizedEmail = "ADMIN@ATAOGE.COM", PasswordHash = "AQAAAAEAACcQAAAAELO1bRjVx4aSgfz5mIRbJnrgl829AhqBa2Nsav157IpWfOHh6Zs6fYIQv8/9ZobpfQ==" }
                };

            userRoles = new  List<IntIdentityUserRole>()
            {
                new IntIdentityUserRole() {UserId = 0, RoleId = 0}
            };

        }

        private static IList<IntIdentityUser> users = null;

        private static IList<IntIdentityRole> roles = null;

        private static IList<IntIdentityUserRole> userRoles = null;

        public static IList<IntIdentityUser> Users
        {
            get { return users;}
        }

        public static IList<IntIdentityRole> Roles
        {
            get { return roles;}
        }

        public static IList<IntIdentityUserRole> UserRoles
        {
            get { return userRoles;}
        }

        public static void AddRole(IntIdentityRole role)
        {
            if (role.Id == 0)
                role.Id = roles.Count;
            roles.Add(role);
        }

         public static void AddUser(IntIdentityUser user)
        {
            if (user.Id == 0)
                user.Id = roles.Count;
            users.Add(user);
        }

    }   
}
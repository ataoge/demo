using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Ataoge.AspNetCore.Identity.Entities;
using Microsoft.AspNetCore.Identity;

namespace Ataoge.AspNetCore.Identity.InMemory
{
    public class InMemoryUserStore :
        IUserLoginStore<IntIdentityUser>,
        IUserRoleStore<IntIdentityUser>,
        IUserClaimStore<IntIdentityUser>,
        IUserPasswordStore<IntIdentityUser>,
        IUserSecurityStampStore<IntIdentityUser>,
        IUserEmailStore<IntIdentityUser>,
        IUserLockoutStore<IntIdentityUser>,
        IUserPhoneNumberStore<IntIdentityUser>,
        IQueryableUserStore<IntIdentityUser>,
        IUserTwoFactorStore<IntIdentityUser>,
        IUserAuthenticationTokenStore<IntIdentityUser>
    {

        public IQueryable<IntIdentityUser> Users
        {
            get
            {
                return InMemoryStores.Users.AsQueryable();
            }
        }

        public Task AddClaimsAsync(IntIdentityUser user, IEnumerable<Claim> claims, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task AddLoginAsync(IntIdentityUser user, UserLoginInfo login, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task AddToRoleAsync(IntIdentityUser user, string roleName, CancellationToken cancellationToken)
        {
            IntIdentityRole role = InMemoryStores.Roles.SingleOrDefault(r => r.NormalizedName == roleName);
            if (role != null)
            {
                IntIdentityUserRole userRole = new IntIdentityUserRole() { RoleId = role.Id, UserId = user.Id };
                InMemoryStores.UserRoles.Add(userRole);
            }
            return Task.FromResult(0);
        }

        public Task<IdentityResult> CreateAsync(IntIdentityUser user, CancellationToken cancellationToken)
        {
            InMemoryStores.AddUser(user);
            return Task.FromResult(IdentityResult.Success);
        }

        public Task<IdentityResult> DeleteAsync(IntIdentityUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {

        }

        public Task<IntIdentityUser> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
        {
            var user = InMemoryStores.Users.FirstOrDefault(u => u.NormalizedEmail == normalizedEmail);
            return Task.FromResult(user);
        }

        public Task<IntIdentityUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            int id = int.Parse(userId);
            var user = InMemoryStores.Users.FirstOrDefault(u => u.Id.Equals(id));
            return Task.FromResult(user);
        }

        public Task<IntIdentityUser> FindByLoginAsync(string loginProvider, string providerKey, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IntIdentityUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            var user = Users.FirstOrDefault(u => u.NormalizedUserName == normalizedUserName);
            return Task.FromResult(user);
        }

        public Task<int> GetAccessFailedCountAsync(IntIdentityUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.AccessFailedCount);
        }

        public Task<IList<Claim>> GetClaimsAsync(IntIdentityUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetEmailAsync(IntIdentityUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Email);
        }

        public Task<bool> GetEmailConfirmedAsync(IntIdentityUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.EmailConfirmed);
        }

        public Task<bool> GetLockoutEnabledAsync(IntIdentityUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.LockoutEnabled);
        }

        public Task<DateTimeOffset?> GetLockoutEndDateAsync(IntIdentityUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.LockoutEnd);
        }

        public Task<IList<UserLoginInfo>> GetLoginsAsync(IntIdentityUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetNormalizedEmailAsync(IntIdentityUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.NormalizedEmail);
        }

        public Task<string> GetNormalizedUserNameAsync(IntIdentityUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.NormalizedUserName);
        }

        public Task<string> GetPasswordHashAsync(IntIdentityUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.PasswordHash);
        }

        public Task<string> GetPhoneNumberAsync(IntIdentityUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.PhoneNumber);
        }

        public Task<bool> GetPhoneNumberConfirmedAsync(IntIdentityUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.PhoneNumberConfirmed);
        }

        public Task<IList<string>> GetRolesAsync(IntIdentityUser user, CancellationToken cancellationToken)
        {
            var userId = user.Id;
            var query = from userRole in InMemoryStores.UserRoles
                        join role in InMemoryStores.Roles on userRole.RoleId equals role.Id
                        where userRole.UserId.Equals(userId)
                        select role.Name;
            IList<string> result = query.ToList();
            return Task.FromResult(result);
        }

        public Task<string> GetSecurityStampAsync(IntIdentityUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.SecurityStamp);
        }

        public Task<string> GetTokenAsync(IntIdentityUser user, string loginProvider, string name, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetTwoFactorEnabledAsync(IntIdentityUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUserIdAsync(IntIdentityUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Id.ToString());
        }

        public Task<string> GetUserNameAsync(IntIdentityUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.UserName);
        }

        public Task<IList<IntIdentityUser>> GetUsersForClaimAsync(Claim claim, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IList<IntIdentityUser>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            IList<IntIdentityUser> result = null;
            var role = InMemoryStores.Roles.First(r => r.NormalizedName == roleName);
            if (role != null)
            {
                var query = from userrole in InMemoryStores.UserRoles
                            join user in InMemoryStores.Users on userrole.UserId equals user.Id
                            where userrole.RoleId.Equals(role.Id)
                            select user;
                result = query.ToList();
                return Task.FromResult(result);
            }
            result = new List<IntIdentityUser>();
            return Task.FromResult(result);
        }

        public Task<bool> HasPasswordAsync(IntIdentityUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.PasswordHash != null);
        }

        public Task<int> IncrementAccessFailedCountAsync(IntIdentityUser user, CancellationToken cancellationToken)
        {
            user.AccessFailedCount++;
            return Task.FromResult(user.AccessFailedCount);
        }

        public Task<bool> IsInRoleAsync(IntIdentityUser user, string roleName, CancellationToken cancellationToken)
        {
            var role = InMemoryStores.Roles.SingleOrDefault(r => r.NormalizedName == roleName);
            if (role != null)
            {
                var userRole = InMemoryStores.UserRoles.First(ur => ur.UserId == user.Id && ur.RoleId == role.Id);
                return Task.FromResult(userRole != null);
            }
            return Task.FromResult(false);
        }

        public Task RemoveClaimsAsync(IntIdentityUser user, IEnumerable<Claim> claims, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromRoleAsync(IntIdentityUser user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task RemoveLoginAsync(IntIdentityUser user, string loginProvider, string providerKey, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task RemoveTokenAsync(IntIdentityUser user, string loginProvider, string name, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task ReplaceClaimAsync(IntIdentityUser user, Claim claim, Claim newClaim, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task ResetAccessFailedCountAsync(IntIdentityUser user, CancellationToken cancellationToken)
        {
            user.AccessFailedCount = 0;
            return Task.CompletedTask;
        }

        public Task SetEmailAsync(IntIdentityUser user, string email, CancellationToken cancellationToken)
        {
            user.Email = email;
            return Task.CompletedTask;
        }

        public Task SetEmailConfirmedAsync(IntIdentityUser user, bool confirmed, CancellationToken cancellationToken)
        {
            user.EmailConfirmed = confirmed;
            return Task.CompletedTask;
        }

        public Task SetLockoutEnabledAsync(IntIdentityUser user, bool enabled, CancellationToken cancellationToken)
        {
            user.LockoutEnabled = enabled;
            return Task.CompletedTask;
        }

        public Task SetLockoutEndDateAsync(IntIdentityUser user, DateTimeOffset? lockoutEnd, CancellationToken cancellationToken)
        {
            user.LockoutEnd = lockoutEnd;
            return Task.CompletedTask;
        }

        public Task SetNormalizedEmailAsync(IntIdentityUser user, string normalizedEmail, CancellationToken cancellationToken)
        {
            user.NormalizedEmail = normalizedEmail;
            return Task.CompletedTask;
        }

        public Task SetNormalizedUserNameAsync(IntIdentityUser user, string normalizedName, CancellationToken cancellationToken)
        {
            user.NormalizedUserName = normalizedName;
            return Task.CompletedTask;
        }

        public Task SetPasswordHashAsync(IntIdentityUser user, string passwordHash, CancellationToken cancellationToken)
        {
            user.PasswordHash = passwordHash;
            return Task.CompletedTask;
        }

        public Task SetPhoneNumberAsync(IntIdentityUser user, string phoneNumber, CancellationToken cancellationToken)
        {
            user.PhoneNumber = phoneNumber;
            return Task.CompletedTask;
        }

        public Task SetPhoneNumberConfirmedAsync(IntIdentityUser user, bool confirmed, CancellationToken cancellationToken)
        {
            user.PhoneNumberConfirmed = confirmed;
            return Task.CompletedTask;
        }

        public Task SetSecurityStampAsync(IntIdentityUser user, string stamp, CancellationToken cancellationToken)
        {
            user.SecurityStamp = stamp;
            return Task.CompletedTask;
        }

        public Task SetTokenAsync(IntIdentityUser user, string loginProvider, string name, string value, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetTwoFactorEnabledAsync(IntIdentityUser user, bool enabled, CancellationToken cancellationToken)
        {
            user.TwoFactorEnabled = enabled;
            return Task.CompletedTask;
        }

        public Task SetUserNameAsync(IntIdentityUser user, string userName, CancellationToken cancellationToken)
        {
            user.UserName = userName;
            return Task.CompletedTask;
        }

        public Task<IdentityResult> UpdateAsync(IntIdentityUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
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
    public class InMemoryRoleStore :
        IQueryableRoleStore<IntIdentityRole>,
        IRoleClaimStore<IntIdentityRole>
    {
        public InMemoryRoleStore()
        {
            
        }

        public IQueryable<IntIdentityRole> Roles
        {
            get
            {
                return InMemoryStores.Roles.ToList().AsQueryable();
            }
        }

        public Task AddClaimAsync(IntIdentityRole role, Claim claim, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> CreateAsync(IntIdentityRole role, CancellationToken cancellationToken)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }
            InMemoryStores.AddRole(role);
            return Task.FromResult(IdentityResult.Success);
           
        }

        public Task<IdentityResult> DeleteAsync(IntIdentityRole role, CancellationToken cancellationToken)
        {
            //
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            
        }

        public Task<IntIdentityRole> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            var id = int.Parse(roleId);
            var role = InMemoryStores.Roles.FirstOrDefault(r => r.Id.Equals(id));
            return Task.FromResult(role);
        }

        public Task<IntIdentityRole> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            var role = InMemoryStores.Roles.FirstOrDefault(r => r.NormalizedName == normalizedRoleName);
            return Task.FromResult(role);
        }

        public Task<IList<Claim>> GetClaimsAsync(IntIdentityRole role, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<string> GetNormalizedRoleNameAsync(IntIdentityRole role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.NormalizedName);
        }

        public Task<string> GetRoleIdAsync(IntIdentityRole role, CancellationToken cancellationToken)
        {
            string value  = role.Id.ToString();
            return Task.FromResult(value);
        }

        public Task<string> GetRoleNameAsync(IntIdentityRole role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.Name);
        }

        public Task RemoveClaimAsync(IntIdentityRole role, Claim claim, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedRoleNameAsync(IntIdentityRole role, string normalizedName, CancellationToken cancellationToken)
        {
            role.NormalizedName = normalizedName;
            return Task.FromResult(0);
        }

        public Task SetRoleNameAsync(IntIdentityRole role, string roleName, CancellationToken cancellationToken)
        {
            role.Name = roleName;
			return Task.FromResult(0);
        }

        public Task<IdentityResult> UpdateAsync(IntIdentityRole role, CancellationToken cancellationToken)
        {
            //return Task.FromResult(IdentityResult.Success);
            throw new NotImplementedException();
        }
    }
}
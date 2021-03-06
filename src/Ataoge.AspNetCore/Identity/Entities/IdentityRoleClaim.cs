using System;
using System.Security.Claims;

namespace Ataoge.AspNetCore.Identity.Entities
{
    /// <summary>
	/// Represents a claim that is granted to all users within a role.
	/// </summary>
	/// <typeparam name="TKey">The type of the primary key of the role associated with this claim.</typeparam>
	public class IdentityRoleClaim<TKey> 
        where TKey : IEquatable<TKey>
	{
		/// <summary>
		/// Gets or sets the identifier for this role claim.
		/// </summary>
		public virtual TKey Id
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the of the primary key of the role associated with this claim.
		/// </summary>
		public virtual TKey RoleId
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the claim type for this claim.
		/// </summary>
		public virtual string ClaimType
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the claim value for this claim.
		/// </summary>
		public virtual string ClaimValue
		{
			get;
			set;
		}
		public virtual Claim ToClaim()
		{
			return new Claim(this.ClaimType, this.ClaimValue);
		}
		public virtual void InitializeFromClaim(Claim other)
		{
			ClaimType = other?.Type;
            ClaimValue = other?.Value;
		}
	}
}
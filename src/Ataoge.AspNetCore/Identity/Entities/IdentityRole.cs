using System;

namespace  Ataoge.AspNetCore.Identity.Entities
{
    /// <summary>
    ///     Represents a Role entity
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public class IdentityRole<TKey, TUserRole, TRoleClaim> 
        where TKey : IEquatable<TKey> 
        where TUserRole : IdentityUserRole<TKey> 
        where TRoleClaim : IdentityRoleClaim<TKey>
    {
        public virtual TKey Id
		{
			get;
			set;
		}

		public virtual TKey Pid
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the name for this role.
		/// </summary>
		public virtual string Name
		{
			get;
			set;
		}

		
		/// <summary>
		/// Gets or sets the normalized name for this role.
		/// </summary>
		public virtual string NormalizedName
		{
			get;
			set;
		}

		/// <summary>
		/// A random value that should change whenever a role is persisted to the store
		/// </summary>
		public virtual string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();


        public virtual int Type
        {
            get;
            set;
        }

        public virtual int SIndex
        {
            get;
            set;
        }
		/// <summary>
		/// Initializes a new instance of <see cref="T:Ataoge.AspNetCore.Identity.Entities.IdentityRole`1" />.
		/// </summary>
		public IdentityRole()
		{
        }

		/// <summary>
		/// Initializes a new instance of <see cref="T:Ataoge.AspNetCore.Identity.Entities.IdentityRole`1" />.
		/// </summary>
		/// <param name="roleName">The role name.</param>
		public IdentityRole(string roleName) : this()
		{
			this.Name = roleName;
		}
		/// <summary>
		/// Returns the name of the role.
		/// </summary>
		/// <returns>The name of the role.</returns>
		public override string ToString()
		{
			return this.Name;
		}
    }

	 /// <summary>
    /// Represents a role in the identity system
    /// </summary>
    /// <typeparam name="TKey">The type used for the primary key for the role.</typeparam>
    public class IdentityRole<TKey> : IdentityRole<TKey, IdentityUserRole<TKey>, IdentityRoleClaim<TKey>>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="IdentityRole{TKey}"/>.
        /// </summary>
        public IdentityRole() { }

        /// <summary>
        /// Initializes a new instance of <see cref="IdentityRole{TKey}"/>.
        /// </summary>
        /// <param name="roleName">The role name.</param>
        public IdentityRole(string roleName) : this()
        {
            Name = roleName;
        }
    }

	/// <summary>
    /// The default implementation of <see cref="IdentityRole{TKey}"/> which uses a string as the primary key.
    /// </summary>
    public class IdentityRole : IdentityRole<string>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="IdentityRole"/>.
        /// </summary>
        /// <remarks>
        /// The Id property is initialized to from a new GUID string value.
        /// </remarks>
        public IdentityRole()
        {
            //Id = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Initializes a new instance of <see cref="IdentityRole"/>.
        /// </summary>
        /// <param name="roleName">The role name.</param>
        /// <remarks>
        /// The Id property is initialized to from a new GUID string value.
        /// </remarks>
        public IdentityRole(string roleName) : this()
        {
            Name = roleName;
        }
    }

	public class IntIdentityRole : IdentityRole<int>
    {
		public IntIdentityRole()
		{
		}

		public IntIdentityRole(string roleName)
		{
			Name = roleName;
		}
	}
}
﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Madhuvan.Datalayer
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MadhuvanMVCEntities : DbContext
    {
        public MadhuvanMVCEntities()
            : base("name=MadhuvanMVCEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CategoryMaster> CategoryMasters { get; set; }
        public virtual DbSet<CustomerMaster> CustomerMasters { get; set; }
        public virtual DbSet<OfferMaster> OfferMasters { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<ProductMaster> ProductMasters { get; set; }
        public virtual DbSet<ProductSliderImage> ProductSliderImages { get; set; }
        public virtual DbSet<SubCategoryMaster> SubCategoryMasters { get; set; }
        public virtual DbSet<AdminUserMaster> AdminUserMasters { get; set; }
        public virtual DbSet<UserType> UserTypes { get; set; }
    }
}

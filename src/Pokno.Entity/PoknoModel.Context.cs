﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pokno.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PoknoEntities : DbContext
    {
        public PoknoEntities()
            : base("name=PoknoEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<APPLICATION_MODE> APPLICATION_MODE { get; set; }
        public virtual DbSet<BANK> BANK { get; set; }
        public virtual DbSet<CASH> CASH { get; set; }
        public virtual DbSet<CHEQUE> CHEQUE { get; set; }
        public virtual DbSet<COMPANY> COMPANY { get; set; }
        public virtual DbSet<CURRENT_ESNECIL> CURRENT_ESNECIL { get; set; }
        public virtual DbSet<CURRENT_STOCK_PACKAGE> CURRENT_STOCK_PACKAGE { get; set; }
        public virtual DbSet<CURRENT_STOCK_PACKAGE_RELATIONSHIP> CURRENT_STOCK_PACKAGE_RELATIONSHIP { get; set; }
        public virtual DbSet<CURRENT_STOCK_PRICE> CURRENT_STOCK_PRICE { get; set; }
        public virtual DbSet<DELETED_SHELF_STOCK> DELETED_SHELF_STOCK { get; set; }
        public virtual DbSet<DELETED_SOLD_STOCK> DELETED_SOLD_STOCK { get; set; }
        public virtual DbSet<DELETED_SOLD_STOCK_BATCH> DELETED_SOLD_STOCK_BATCH { get; set; }
        public virtual DbSet<ESNECIL> ESNECIL { get; set; }
        public virtual DbSet<EXPENSES> EXPENSES { get; set; }
        public virtual DbSet<EXPENSES_CATEGORY> EXPENSES_CATEGORY { get; set; }
        public virtual DbSet<EXPENSES_DETAIL> EXPENSES_DETAIL { get; set; }
        public virtual DbSet<LOCATION> LOCATION { get; set; }
        public virtual DbSet<PACKAGE> PACKAGE { get; set; }
        public virtual DbSet<PACKAGE_RELATIONSHIP> PACKAGE_RELATIONSHIP { get; set; }
        public virtual DbSet<PART> PART { get; set; }
        public virtual DbSet<PAYMENT> PAYMENT { get; set; }
        public virtual DbSet<PAYMENT_DETAIL> PAYMENT_DETAIL { get; set; }
        public virtual DbSet<PAYMENT_TYPE> PAYMENT_TYPE { get; set; }
        public virtual DbSet<PERSON> PERSON { get; set; }
        public virtual DbSet<PERSON_COMPANY> PERSON_COMPANY { get; set; }
        public virtual DbSet<PERSON_LOGIN> PERSON_LOGIN { get; set; }
        public virtual DbSet<PERSON_TYPE> PERSON_TYPE { get; set; }
        public virtual DbSet<REPLACED_STOCK_ACTION> REPLACED_STOCK_ACTION { get; set; }
        public virtual DbSet<RETURNED_STOCK> RETURNED_STOCK { get; set; }
        public virtual DbSet<RETURNED_STOCK_DETAIL> RETURNED_STOCK_DETAIL { get; set; }
        public virtual DbSet<RETURNED_STOCK_REPLACEMENT> RETURNED_STOCK_REPLACEMENT { get; set; }
        public virtual DbSet<RIGHT> RIGHT { get; set; }
        public virtual DbSet<ROLE> ROLE { get; set; }
        public virtual DbSet<ROLE_RIGHT> ROLE_RIGHT { get; set; }
        public virtual DbSet<SETTING> SETTING { get; set; }
        public virtual DbSet<SHELF> SHELF { get; set; }
        public virtual DbSet<SHELF_STOCK_REPLACEMENT> SHELF_STOCK_REPLACEMENT { get; set; }
        public virtual DbSet<SOLD_STOCK> SOLD_STOCK { get; set; }
        public virtual DbSet<SOLD_STOCK_BATCH> SOLD_STOCK_BATCH { get; set; }
        public virtual DbSet<SOLD_STOCK_RETURN> SOLD_STOCK_RETURN { get; set; }
        public virtual DbSet<SOLD_STOCK_RETURN_REFUND> SOLD_STOCK_RETURN_REFUND { get; set; }
        public virtual DbSet<STOCK> STOCK { get; set; }
        public virtual DbSet<STOCK_BARCODE> STOCK_BARCODE { get; set; }
        public virtual DbSet<STOCK_CATEGORY> STOCK_CATEGORY { get; set; }
        public virtual DbSet<STOCK_PACKAGE> STOCK_PACKAGE { get; set; }
        public virtual DbSet<STOCK_PACKAGE_RELATIONSHIP> STOCK_PACKAGE_RELATIONSHIP { get; set; }
        public virtual DbSet<STOCK_PRICE> STOCK_PRICE { get; set; }
        public virtual DbSet<STOCK_PURCHASE_BATCH> STOCK_PURCHASE_BATCH { get; set; }
        public virtual DbSet<STOCK_PURCHASE_BATCH_TYPE> STOCK_PURCHASE_BATCH_TYPE { get; set; }
        public virtual DbSet<STOCK_PURCHASED> STOCK_PURCHASED { get; set; }
        public virtual DbSet<STOCK_PURCHASED_POOL> STOCK_PURCHASED_POOL { get; set; }
        public virtual DbSet<STOCK_PURCHASED_POOL_DETAIL> STOCK_PURCHASED_POOL_DETAIL { get; set; }
        public virtual DbSet<STOCK_PURCHASED_RETURN> STOCK_PURCHASED_RETURN { get; set; }
        public virtual DbSet<STOCK_REPLACEMENT> STOCK_REPLACEMENT { get; set; }
        public virtual DbSet<STOCK_RETURN_ACTION> STOCK_RETURN_ACTION { get; set; }
        public virtual DbSet<STOCK_RETURN_TYPE> STOCK_RETURN_TYPE { get; set; }
        public virtual DbSet<STOCK_REVIEW> STOCK_REVIEW { get; set; }
        public virtual DbSet<STOCK_REVIEW_DETAIL> STOCK_REVIEW_DETAIL { get; set; }
        public virtual DbSet<STOCK_STATE> STOCK_STATE { get; set; }
        public virtual DbSet<STOCK_TYPE> STOCK_TYPE { get; set; }
        public virtual DbSet<STORE> STORE { get; set; }
        public virtual DbSet<TRANSACTION_TYPE> TRANSACTION_TYPE { get; set; }
    }
}

﻿//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuerSyst.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class USEntities : DbContext
    {
        public USEntities()
            : base("name=USEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<T_ANSR_DATA> T_ANSR_DATA { get; set; }
        public virtual DbSet<T_ANSR_FILE> T_ANSR_FILE { get; set; }
        public virtual DbSet<T_CASE_BASE> T_CASE_BASE { get; set; }
        public virtual DbSet<T_QUER_DATA> T_QUER_DATA { get; set; }
        public virtual DbSet<T_QUER_FILE> T_QUER_FILE { get; set; }
        public virtual DbSet<T_SYST_CLAS> T_SYST_CLAS { get; set; }
        public virtual DbSet<T_SYST_QADB> T_SYST_QADB { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Dehyari
{
    public partial class DehyariContext : DbContext
    {
        public DehyariContext()
            : base("name=DehyariContext3")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AbBaha> AbBahas { get; set; }
        public virtual DbSet<BedNo> BedNoes { get; set; }
        public virtual DbSet<Bime> Bimes { get; set; }
        public virtual DbSet<Daryaft> Daryafts { get; set; }
        public virtual DbSet<DehyariHesab> DehyariHesabs { get; set; }
        public virtual DbSet<Delivery> Deliveries { get; set; }
        public virtual DbSet<Hazine> Hazines { get; set; }
        public virtual DbSet<IsKhanedar> IsKhanedars { get; set; }
        public virtual DbSet<IsMarried> IsMarrieds { get; set; }
        public virtual DbSet<IsSarparastKhanevar> IsSarparastKhanevars { get; set; }
        public virtual DbSet<JaygahZamin> JaygahZamins { get; set; }
        public virtual DbSet<NameSadere> NameSaderes { get; set; }
        public virtual DbSet<NameVarede> NameVaredes { get; set; }
        public virtual DbSet<NoDaryaft> NoDaryafts { get; set; }
        public virtual DbSet<NoHazine> NoHazines { get; set; }
        public virtual DbSet<NoZamin> NoZamins { get; set; }
        public virtual DbSet<OnvanName> OnvanNames { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<PersonHesab> PersonHesabs { get; set; }
        public virtual DbSet<Sex> Sexes { get; set; }
        public virtual DbSet<SM> SMS { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Tahsilatt> Tahsilatts { get; set; }
        public virtual DbSet<Zamin> Zamins { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Delivery>()
                .HasMany(e => e.SMS)
                .WithOptional(e => e.Delivery)
                .HasForeignKey(e => e.DeliveryID);

            modelBuilder.Entity<NoDaryaft>()
                .HasOptional(e => e.Daryaft)
                .WithRequired(e => e.NoDaryaft);
        }
    }
}

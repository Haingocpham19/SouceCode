using Microsoft.EntityFrameworkCore;
using iChiba.DC.Model;
using System.Linq.Expressions;
using System;

namespace iChiba.DC.DbContext
{
    public partial class DATA_COMMONContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DATA_COMMONContext()
        {
        }

        public DATA_COMMONContext(DbContextOptions<DATA_COMMONContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BidConfig> BidConfig { get; set; }
        public virtual DbSet<BidExternalConfig> BidExternalConfig { get; set; }
        public virtual DbSet<BuyerConfig> BuyerConfig { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Ddimport> Ddimport { get; set; }
        public virtual DbSet<Exchangerates> Exchangerates { get; set; }
        public virtual DbSet<Languages> Languages { get; set; }
        public virtual DbSet<Localeresources> Localeresources { get; set; }
        public virtual DbSet<Localizedproperties> Localizedproperties { get; set; }
        public virtual DbSet<Locations> Locations { get; set; }
        public virtual DbSet<OrderType> OrderType { get; set; }
        public virtual DbSet<ProductOrigin> ProductOrigin { get; set; }
        public virtual DbSet<ProductType> ProductType { get; set; }
        public virtual DbSet<ProductTypeGroup> ProductTypeGroup { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<BidConfig>(entity =>
            {
                entity.ToTable("BID_CONFIG");

                entity.HasIndex(e => e.Username, "UQ__BID_CONF__536C85E42E3ADEDF")
                    .IsUnique();

                entity.Property(e => e.Alias)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Buyer).HasMaxLength(255);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.GroupKey).HasMaxLength(255);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<BidExternalConfig>(entity =>
            {
                entity.ToTable("BID_EXTERNAL_CONFIG");

                entity.HasIndex(e => e.YauserName, "UQ__BID_EXTE__34B280C46932A20B")
                    .IsUnique();

                entity.Property(e => e.AccountId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Status);

                entity.Property(e => e.YauserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("YAUserName");
            });

            modelBuilder.Entity<BuyerConfig>(entity =>
            {
                entity.ToTable("BUYER_CONFIG");

                entity.Property(e => e.Buyer).HasMaxLength(1000);

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.OrderType)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("COUNTRY");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Ddimport>(entity =>
            {
                entity.ToTable("DDIMPORT");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Currency).HasMaxLength(255);

                entity.Property(e => e.Ddtype)
                    .HasMaxLength(255)
                    .HasColumnName("DDType");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.HelpLink).HasMaxLength(500);

                entity.Property(e => e.Ord).HasDefaultValueSql("((0))");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Exchangerates>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("EXCHANGERATES");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Languages>(entity =>
            {
                entity.ToTable("LANGUAGES");

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Localeresources>(entity =>
            {
                entity.ToTable("LOCALERESOURCES");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Key).HasMaxLength(255);

                entity.Property(e => e.LanguageId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("LanguageID");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.Localeresources)
                    .HasForeignKey(d => d.LanguageId)
                    .HasConstraintName("FK_LocaleResources_Languages");
            });

            modelBuilder.Entity<Localizedproperties>(entity =>
            {
                entity.ToTable("LOCALIZEDPROPERTIES");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EntityId).HasColumnName("EntityID");

                entity.Property(e => e.LanguageId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("LanguageID");

                entity.Property(e => e.LocaleGroup).HasMaxLength(255);

                entity.Property(e => e.LocaleKey).HasMaxLength(255);

                entity.Property(e => e.LocaleValue).HasColumnType("ntext");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.Localizedproperties)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LocalizedProperties_Languages1");
            });

            modelBuilder.Entity<Locations>(entity =>
            {
                entity.ToTable("LOCATIONS");

                entity.Property(e => e.Area).HasMaxLength(50);

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.Contry).HasMaxLength(50);

                entity.Property(e => e.Emskey)
                    .HasMaxLength(50)
                    .HasColumnName("EMSKey");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.Property(e => e.Vnpkey)
                    .HasMaxLength(50)
                    .HasColumnName("VNPKey");

                entity.Property(e => e.Vtkey)
                    .HasMaxLength(50)
                    .HasColumnName("VTKey");
            });

            modelBuilder.Entity<OrderType>(entity =>
            {
                entity.ToTable("ORDER_TYPE");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<ProductOrigin>(entity =>
            {
                entity.ToTable("PRODUCT_ORIGIN");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Title).HasMaxLength(255);
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.ToTable("PRODUCT_TYPE");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Title).HasMaxLength(255);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.ProductType)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_PRODUCT_TYPE_PRODUCT_TYPE_GROUP");
            });

            modelBuilder.Entity<ProductTypeGroup>(entity =>
            {
                entity.ToTable("PRODUCT_TYPE_GROUP");

                entity.Property(e => e.Code).HasMaxLength(255);

                entity.Property(e => e.PriceAu).HasColumnName("PriceAU");

                entity.Property(e => e.PriceJp).HasColumnName("PriceJP");

                entity.Property(e => e.PriceKr).HasColumnName("PriceKR");

                entity.Property(e => e.PriceUs).HasColumnName("PriceUS");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
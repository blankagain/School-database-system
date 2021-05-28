using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace School_1
{
    public partial class School_dataContext : DbContext
    {
        public School_dataContext()
        {
        }

        public School_dataContext(DbContextOptions<School_dataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Schooltable1> Schooltable1s { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=School_data");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Schooltable1>(entity =>
            {
                entity.HasKey(e => e.SchoolId);

                entity.ToTable("schooltable_1");

                entity.Property(e => e.SchoolId)
                    .ValueGeneratedNever()
                    .HasColumnName("School_Id");

                entity.Property(e => e.Class).HasColumnName("class");

                entity.Property(e => e.FatherName)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Father_name");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.MotherName)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("mother_name");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.RollNumber)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("roll_number");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

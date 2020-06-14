using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace c11.Models{
    public partial class s18911Context : DbContext{
        public s18911Context(){
        }

        public s18911Context(DbContextOptions<s18911Context> options) : base(options) {
        }

        public virtual DbSet<Doctor> Doctor { get; set; }
        public virtual DbSet<Medicament> Medicament { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<Prescription> Prescription { get; set; }
        public virtual DbSet<PrescriptionMedicament> PrescriptionMedicament { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder){


            modelBuilder.Entity<Doctor>(entity =>{
                entity.HasKey(e => e.IdDoctor);
            });

            modelBuilder.Entity<Medicament>(entity =>{
                entity.HasKey(e => e.IdMedicament);
            });

            modelBuilder.Entity<Patient>(entity =>{
                entity.HasKey(e => e.IdPatient);
            });

            modelBuilder.Entity<Prescription>(entity =>{
                entity.HasKey(e => e.IdPrescription);
            });

            modelBuilder.Entity<PrescriptionMedicament>(entity => {
                entity.HasKey(e => new { e.IdMedicament, e.IdPrescription });

                entity.ToTable("Prescription_Medicament");
            });
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

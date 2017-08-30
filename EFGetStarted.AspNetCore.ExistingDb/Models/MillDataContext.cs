using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MillData.Models
{
    public partial class MillDataContext : DbContext
    {
        public virtual DbSet<Epasubcat> Epasubcat { get; set; }
        public virtual DbSet<FiberType> FiberType { get; set; }
        public virtual DbSet<FlowData> FlowData { get; set; }
        public virtual DbSet<FlowType> FlowType { get; set; }
        public virtual DbSet<HistoricalMillInfo> HistoricalMillInfo { get; set; }
        public virtual DbSet<MillCodeLinks> MillCodeLinks { get; set; }
        public virtual DbSet<MillCodischarger> MillCodischarger { get; set; }
        public virtual DbSet<MillContactInfo> MillContactInfo { get; set; }
        public virtual DbSet<MillInformation> MillInformation { get; set; }
        public virtual DbSet<MillNarrative> MillNarrative { get; set; }
        public virtual DbSet<MillParentRelationship> MillParentRelationship { get; set; }
        public virtual DbSet<MillSiccodes> MillSiccodes { get; set; }
        public virtual DbSet<MillType> MillType { get; set; }
        public virtual DbSet<NcasiprodCat> NcasiprodCat { get; set; }
        public virtual DbSet<Ncasiregion> Ncasiregion { get; set; }
        public virtual DbSet<Npdes> Npdes { get; set; }
        public virtual DbSet<NpdesdocType> NpdesdocType { get; set; }
        public virtual DbSet<Npdesdocs> Npdesdocs { get; set; }
        public virtual DbSet<ParentCompany> ParentCompany { get; set; }
        public virtual DbSet<ProductionData> ProductionData { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<Siccode> Siccode { get; set; }
        public virtual DbSet<SludgeData> SludgeData { get; set; }
        public virtual DbSet<Source> Source { get; set; }
        public virtual DbSet<WaterTreatmentData> WaterTreatmentData { get; set; }
        
        //ENV Database
        public virtual DbSet<Env_WoodThickness> Env_WoodThickness { get; set; }
        public virtual DbSet<Env_ProductionData> Env_ProductionData { get; set; }
        public virtual DbSet<Env_Facility> Env_Facility { get; set; }

        public MillDataContext(DbContextOptions<MillDataContext> options)
            : base(options)
        { }
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-9I6CKCV\SQLEXPRESS;Database=MillData;Trusted_Connection=True;");
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Epasubcat>(entity =>
            {
                entity.HasKey(e => e.PkSubcatId)
                    .HasName("PK_EPASubcats");

                entity.ToTable("EPASubcat");

                entity.Property(e => e.PkSubcatId).HasColumnName("PK_SubcatID");

                entity.Property(e => e.Fiber).HasColumnType("varchar(100)");

                entity.Property(e => e.Subcat)
                    .IsRequired()
                    .HasColumnType("varchar(2)");

                entity.Property(e => e.SubcatDescription).HasColumnType("varchar(max)");
            });

            modelBuilder.Entity<FiberType>(entity =>
            {
                entity.HasKey(e => e.PkFiberTypeId)
                    .HasName("PK_FiberType");

                entity.Property(e => e.PkFiberTypeId).HasColumnName("PK_FiberTypeID");

                entity.Property(e => e.FiberGroup).HasColumnType("varchar(50)");

                entity.Property(e => e.FiberSource).HasColumnType("varchar(50)");

                entity.Property(e => e.FiberType1)
                    .HasColumnName("FiberType")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<FlowData>(entity =>
            {
                entity.HasKey(e => e.PkFlowId)
                    .HasName("PK_FlowData");

                entity.Property(e => e.PkFlowId).HasColumnName("PK_FlowID");

                entity.Property(e => e.Comments).HasColumnType("varchar(max)");

                entity.Property(e => e.FkFlowType).HasColumnName("FK_FlowType");

                entity.Property(e => e.FkMillKey).HasColumnName("FK_MillKey");

                entity.Property(e => e.FkSourceId).HasColumnName("FK_SourceID");

                entity.Property(e => e.FlowDescription).HasColumnType("varchar(50)");

                entity.Property(e => e.FlowMmgd).HasColumnName("FlowMMGD");

                entity.Property(e => e.WaterBodyName).HasColumnType("varchar(50)");

                entity.Property(e => e.WaterBodyType).HasColumnType("varchar(50)");

                entity.HasOne(d => d.FkFlowTypeNavigation)
                    .WithMany(p => p.FlowData)
                    .HasForeignKey(d => d.FkFlowType)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_FlowData_FlowType");

                entity.HasOne(d => d.FkMillKeyNavigation)
                    .WithMany(p => p.FlowData)
                    .HasForeignKey(d => d.FkMillKey)
                    .HasConstraintName("FK_FlowData_MillInformation");

                entity.HasOne(d => d.FkSource)
                    .WithMany(p => p.FlowData)
                    .HasForeignKey(d => d.FkSourceId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_FlowData_Source");
            });

            modelBuilder.Entity<FlowType>(entity =>
            {
                entity.HasKey(e => e.PkFlowTypeId)
                    .HasName("PK_FlowType");

                entity.Property(e => e.PkFlowTypeId).HasColumnName("PK_FlowTypeID");

                entity.Property(e => e.FlowTypeName).HasColumnType("varchar(15)");
            });

            modelBuilder.Entity<HistoricalMillInfo>(entity =>
            {
                entity.HasKey(e => e.PkInfoId)
                    .HasName("PK_HIstoricalMillInfo");

                entity.Property(e => e.PkInfoId).HasColumnName("PK_InfoID");

                entity.Property(e => e.ChangeDate).HasColumnType("date");

                entity.Property(e => e.Comments).HasColumnType("varchar(max)");

                entity.Property(e => e.Company).HasColumnType("varchar(max)");

                entity.Property(e => e.FkMillKey).HasColumnName("FK_MillKey");

                entity.Property(e => e.WhatChanged).HasColumnType("varchar(max)");

                entity.HasOne(d => d.FkMillKeyNavigation)
                    .WithMany(p => p.HistoricalMillInfo)
                    .HasForeignKey(d => d.FkMillKey)
                    .HasConstraintName("FK_HistoricalMillInfo_MillInformation");

                entity.HasOne(d => d.ProdCategory2Navigation)
                    .WithMany(p => p.HistoricalMillInfo)
                    .HasForeignKey(d => d.ProdCategory2)
                    .HasConstraintName("FK_HistoricalMillInfo_NCASIProdCat2");
            });

            modelBuilder.Entity<MillCodeLinks>(entity =>
            {
                entity.HasKey(e => e.MillCodeLinkId)
                    .HasName("PK_MillCodeLinks");

                entity.Property(e => e.MillCodeLinkId).HasColumnName("MillCodeLinkID");

                entity.Property(e => e.Fisher).HasColumnType("varchar(10)");

                entity.Property(e => e.FkMillKey).HasColumnName("FK_MillKey");

                entity.Property(e => e.Fpac).HasColumnName("FPAC");

                entity.Property(e => e.Lwp).HasColumnName("LWP");

                entity.HasOne(d => d.FkMillKeyNavigation)
                    .WithMany(p => p.MillCodeLinks)
                    .HasForeignKey(d => d.FkMillKey)
                    .HasConstraintName("FK_MillCodeLinks_MillInformation");
            });

            modelBuilder.Entity<MillCodischarger>(entity =>
            {
                entity.HasKey(e => e.PkCodischargeId)
                    .HasName("PK_MillCoDischarger");

                entity.Property(e => e.PkCodischargeId).HasColumnName("PK_CodischargeID");

                entity.Property(e => e.FkMillKey1).HasColumnName("FK_MillKey1");

                entity.Property(e => e.FkMillKey2).HasColumnName("FK_MillKey2");

                entity.HasOne(d => d.FkMillKey1Navigation)
                    .WithMany(p => p.MillCodischargerFkMillKey1Navigation)
                    .HasForeignKey(d => d.FkMillKey1)
                    .HasConstraintName("FK_MillCodischarger_MillInformation");

                entity.HasOne(d => d.FkMillKey2Navigation)
                    .WithMany(p => p.MillCodischargerFkMillKey2Navigation)
                    .HasForeignKey(d => d.FkMillKey2)
                    .HasConstraintName("FK_MillCodischarger_MillInformation1");
            });

            modelBuilder.Entity<MillContactInfo>(entity =>
            {
                entity.HasKey(e => e.PkMillContactId)
                    .HasName("PK_MillContactID");

                entity.Property(e => e.PkMillContactId).HasColumnName("PK_MillContactID");

                entity.Property(e => e.Address1).HasColumnType("varchar(10)");

                entity.Property(e => e.Address2).HasColumnType("varchar(10)");

                entity.Property(e => e.AddressPrefix).HasColumnType("varchar(20)");

                entity.Property(e => e.AddressSuffix).HasColumnType("varchar(10)");

                entity.Property(e => e.AreaCode).HasColumnType("varchar(10)");

                entity.Property(e => e.Assistant).HasColumnType("varchar(15)");

                entity.Property(e => e.AssistantContactInfo).HasColumnType("varchar(15)");

                entity.Property(e => e.Bog).HasColumnName("BOG");

                entity.Property(e => e.Cc).HasColumnName("CC");

                entity.Property(e => e.ChangeDate).HasColumnType("date");

                entity.Property(e => e.Comments).HasColumnType("varchar(max)");

                entity.Property(e => e.Department).HasColumnType("varchar(50)");

                entity.Property(e => e.Email).HasColumnType("varchar(100)");

                entity.Property(e => e.ExpirationDate).HasColumnType("varchar(10)");

                entity.Property(e => e.Ext).HasColumnType("varchar(5)");

                entity.Property(e => e.Fax).HasColumnType("varchar(15)");

                entity.Property(e => e.FirstName).HasColumnType("varchar(50)");

                entity.Property(e => e.FkMillKey).HasColumnName("FK_MillKey");

                entity.Property(e => e.JobTitle).HasColumnType("varchar(100)");

                entity.Property(e => e.LastName).HasColumnType("varchar(50)");

                entity.Property(e => e.Mi)
                    .HasColumnName("MI")
                    .HasColumnType("varchar(2)");

                entity.Property(e => e.Oc).HasColumnName("OC");

                entity.Property(e => e.Phone).HasColumnType("varchar(15)");

                entity.Property(e => e.Prefix).HasColumnType("varchar(10)");

                entity.Property(e => e.Rc).HasColumnName("RC");

                entity.HasOne(d => d.FkMillKeyNavigation)
                    .WithMany(p => p.MillContactInfo)
                    .HasForeignKey(d => d.FkMillKey)
                    .HasConstraintName("FK_MillContactInfo_MillInformation");
            });

            modelBuilder.Entity<MillInformation>(entity =>
            {
                entity.HasKey(e => e.PkMillKey)
                    .HasName("PK_MillInformation");

                entity.Property(e => e.PkMillKey).HasColumnName("PK_MillKey");

                entity.Property(e => e.Comments).HasColumnType("varchar(max)");

                entity.Property(e => e.Company).HasColumnType("varchar(75)");

                entity.Property(e => e.Eparegion).HasColumnName("EPARegion");

                entity.Property(e => e.FkEpasubcatId).HasColumnName("FK_EPASubcatID");

                entity.Property(e => e.FkMillTypeId).HasColumnName("FK_MillTypeID");

                entity.Property(e => e.Latitude).HasColumnType("varchar(50)");

                entity.Property(e => e.Longitude).HasColumnType("varchar(50)");

                entity.Property(e => e.MillId).HasColumnName("MillID");

                entity.Property(e => e.MillStatus).HasColumnType("varchar(50)");

                entity.Property(e => e.Naprodcat)
                    .HasColumnName("NAProdcat")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.PostalAddress).HasColumnType("varchar(50)");

                entity.Property(e => e.PostalAddress2).HasColumnType("varchar(50)");

                entity.Property(e => e.PostalCity).HasColumnType("varchar(50)");

                entity.Property(e => e.PostalCountry).HasColumnType("varchar(50)");

                entity.Property(e => e.PostalPostcode).HasColumnType("varchar(50)");

                entity.Property(e => e.PostalState).HasColumnType("varchar(50)");

                entity.Property(e => e.ProdCat1).HasColumnType("varchar(50)");

                entity.Property(e => e.ProdCat2).HasColumnType("varchar(50)");

                entity.Property(e => e.ShippingAddress).HasColumnType("varchar(50)");

                entity.Property(e => e.ShippingAddress2).HasColumnType("varchar(50)");

                entity.Property(e => e.ShippingCity).HasColumnType("varchar(50)");

                entity.Property(e => e.ShippingCountry).HasColumnType("varchar(50)");

                entity.Property(e => e.ShippingPostcode).HasColumnType("varchar(50)");

                entity.Property(e => e.ShippingState).HasColumnType("varchar(50)");

                entity.Property(e => e.StatusDate).HasColumnType("date");

                entity.Property(e => e.Website).HasColumnType("varchar(max)");

                entity.HasOne(d => d.FkEpasubcat)
                    .WithMany(p => p.MillInformation)
                    .HasForeignKey(d => d.FkEpasubcatId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_MillInformation_EPASubcat");

                entity.HasOne(d => d.FkMillType)
                    .WithMany(p => p.MillInformation)
                    .HasForeignKey(d => d.FkMillTypeId)
                    .HasConstraintName("FK_MillInformation_MillType");
            });

            modelBuilder.Entity<MillNarrative>(entity =>
            {
                entity.HasKey(e => e.PkNarrativeId)
                    .HasName("PK_MillNarrative");

                entity.Property(e => e.PkNarrativeId).HasColumnName("PK_NarrativeID");

                entity.Property(e => e.FkMillKey).HasColumnName("FK_MillKey");

                entity.Property(e => e.MillNarrative1)
                    .HasColumnName("MillNarrative")
                    .HasColumnType("varchar(max)");

                entity.HasOne(d => d.FkMillKeyNavigation)
                    .WithMany(p => p.MillNarrative)
                    .HasForeignKey(d => d.FkMillKey)
                    .HasConstraintName("FK_MillNarrative_MillInformation");
            });

            modelBuilder.Entity<MillParentRelationship>(entity =>
            {
                entity.HasKey(e => e.PkRelationshipId)
                    .HasName("PK_MillParentRelationship_1");

                entity.Property(e => e.PkRelationshipId).HasColumnName("PK_RelationshipID");

                entity.Property(e => e.FkMillKey).HasColumnName("FK_MillKey");

                entity.Property(e => e.FkParentCompanyId).HasColumnName("FK_ParentCompanyID");

                entity.Property(e => e.Ncasimember).HasColumnName("NCASIMember");

                entity.Property(e => e.Relationship).HasColumnType("varchar(50)");

                entity.HasOne(d => d.FkMillKeyNavigation)
                    .WithMany(p => p.MillParentRelationship)
                    .HasForeignKey(d => d.FkMillKey)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_MillParentRelationship_MillInformation");

                entity.HasOne(d => d.FkParentCompany)
                    .WithMany(p => p.MillParentRelationship)
                    .HasForeignKey(d => d.FkParentCompanyId)
                    .HasConstraintName("FK_MillParentRelationship_ParentCompany");
            });

            modelBuilder.Entity<MillSiccodes>(entity =>
            {
                entity.HasKey(e => e.PkMillSicid)
                    .HasName("PK_MillSICCodes_1");

                entity.ToTable("MillSICCodes");

                entity.Property(e => e.PkMillSicid).HasColumnName("PK_MillSICID");

                entity.Property(e => e.FkMillKey).HasColumnName("FK_MillKey");

                entity.Property(e => e.FkSiccodeId).HasColumnName("FK_SICCodeID");

                entity.HasOne(d => d.FkMillKeyNavigation)
                    .WithMany(p => p.MillSiccodes)
                    .HasForeignKey(d => d.FkMillKey)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_MillSICCodes_MillInformation");

                entity.HasOne(d => d.FkSiccode)
                    .WithMany(p => p.MillSiccodes)
                    .HasForeignKey(d => d.FkSiccodeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_MillSICCodes_SICCodes");
            });

            modelBuilder.Entity<MillType>(entity =>
            {
                entity.HasKey(e => e.PkTypeId)
                    .HasName("PK_MillType");

                entity.Property(e => e.PkTypeId).HasColumnName("PK_TypeID");

                entity.Property(e => e.TypeName).HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<NcasiprodCat>(entity =>
            {
                entity.HasKey(e => e.PkProdCatId)
                    .HasName("PK_NCASIProdCats");

                entity.ToTable("NCASIProdCat");

                entity.Property(e => e.PkProdCatId).HasColumnName("PK_ProdCatID");

                entity.Property(e => e.Category).HasColumnType("varchar(50)");

                entity.Property(e => e.Comments).HasColumnType("varchar(max)");

                entity.Property(e => e.FacType).HasColumnType("varchar(25)");

                entity.Property(e => e.FiberSource).HasColumnType("varchar(50)");

                entity.Property(e => e.FkEpasubcatId).HasColumnName("FK_EPASubcatID");

                entity.Property(e => e.ProdCatDescription).HasColumnType("varchar(max)");

                entity.Property(e => e.ProdType).HasColumnType("varchar(50)");

                entity.HasOne(d => d.FkEpasubcat)
                    .WithMany(p => p.NcasiprodCat)
                    .HasForeignKey(d => d.FkEpasubcatId)
                    .HasConstraintName("FK_NCASIProdCat_EPASubcat");
            });

            modelBuilder.Entity<Ncasiregion>(entity =>
            {
                entity.HasKey(e => e.PkRegionCodeId)
                    .HasName("PK_NCASIRegion");

                entity.ToTable("NCASIRegion");

                entity.Property(e => e.PkRegionCodeId).HasColumnName("PK_RegionCodeID");

                entity.Property(e => e.RegionCode).HasColumnType("char(1)");

                entity.Property(e => e.RegionName).HasColumnType("varchar(10)");
            });

            modelBuilder.Entity<Npdes>(entity =>
            {
                entity.HasKey(e => e.PkNpdeskey)
                    .HasName("PK_NPDES");

                entity.ToTable("NPDES");

                entity.Property(e => e.PkNpdeskey).HasColumnName("PK_NPDESKey");

                entity.Property(e => e.Comments).HasColumnType("varchar(max)");

                entity.Property(e => e.FkMillKey).HasColumnName("FK_MillKey");

                entity.Property(e => e.Npdesid)
                    .HasColumnName("NPDESID")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.PermitLatitude).HasColumnType("varchar(50)");

                entity.Property(e => e.PermitLongitude).HasColumnType("varchar(50)");

                entity.HasOne(d => d.FkMillKeyNavigation)
                    .WithMany(p => p.Npdes)
                    .HasForeignKey(d => d.FkMillKey)
                    .HasConstraintName("FK_NPDES_MillInformation");
            });

            modelBuilder.Entity<NpdesdocType>(entity =>
            {
                entity.HasKey(e => e.PkDocTypeId)
                    .HasName("PK_NPDESDocType");

                entity.ToTable("NPDESDocType");

                entity.Property(e => e.PkDocTypeId).HasColumnName("PK_DocTypeID");

                entity.Property(e => e.DocType).HasColumnType("varchar(25)");
            });

            modelBuilder.Entity<Npdesdocs>(entity =>
            {
                entity.HasKey(e => e.PkDocId)
                    .HasName("PK_NPDESDocs");

                entity.ToTable("NPDESDocs");

                entity.Property(e => e.PkDocId).HasColumnName("PK_DocID");

                entity.Property(e => e.DocPath).HasColumnType("varchar(max)");

                entity.Property(e => e.FkDocTypeId).HasColumnName("FK_DocTypeID");

                entity.Property(e => e.FkNpdeskey).HasColumnName("FK_NPDESKey");

                entity.HasOne(d => d.FkDocType)
                    .WithMany(p => p.Npdesdocs)
                    .HasForeignKey(d => d.FkDocTypeId)
                    .HasConstraintName("FK_NPDESDocs_NPDESDocType");

                entity.HasOne(d => d.FkNpdeskeyNavigation)
                    .WithMany(p => p.Npdesdocs)
                    .HasForeignKey(d => d.FkNpdeskey)
                    .HasConstraintName("FK_NPDESDocs_NPDES");
            });

            modelBuilder.Entity<ParentCompany>(entity =>
            {
                entity.HasKey(e => e.PkParentCompanyKey)
                    .HasName("PK_ParentCompany");

                entity.Property(e => e.PkParentCompanyKey).HasColumnName("PK_ParentCompanyKey");

                entity.Property(e => e.Afpamember).HasColumnName("AFPAMember");

                entity.Property(e => e.Comment).HasColumnType("varchar(max)");

                entity.Property(e => e.CorpId).HasColumnName("CorpID");

                entity.Property(e => e.MergeSplitStatus).HasColumnType("char(1)");

                entity.Property(e => e.ParentCompany1)
                    .HasColumnName("ParentCompany")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ParentCompanyId).HasColumnName("ParentCompanyID");
            });

            modelBuilder.Entity<ProductionData>(entity =>
            {
                entity.HasKey(e => e.PkProductionId)
                    .HasName("PK_ProductionData");

                entity.Property(e => e.PkProductionId).HasColumnName("PK_ProductionID");

                entity.Property(e => e.Comments).HasColumnType("varchar(max)");

                entity.Property(e => e.FkMillKey).HasColumnName("FK_MillKey");

                entity.Property(e => e.FkProdCatId).HasColumnName("FK_ProdCatID");

                entity.Property(e => e.FkSourceId).HasColumnName("FK_SourceID");

                entity.Property(e => e.Units).HasColumnType("varchar(10)");

                entity.HasOne(d => d.FkMillKeyNavigation)
                    .WithMany(p => p.ProductionData)
                    .HasForeignKey(d => d.FkMillKey)
                    .HasConstraintName("FK_ProductionData_MillInformation");

                entity.HasOne(d => d.FkProdCat)
                    .WithMany(p => p.ProductionData)
                    .HasForeignKey(d => d.FkProdCatId)
                    .HasConstraintName("FK_ProductionData_NCASIProdCat");

                entity.HasOne(d => d.FkSource)
                    .WithMany(p => p.ProductionData)
                    .HasForeignKey(d => d.FkSourceId)
                    .HasConstraintName("FK_ProductionData_Source");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.HasKey(e => e.PkRegionId)
                    .HasName("PK_Region");

                entity.Property(e => e.PkRegionId).HasColumnName("PK_RegionID");

                entity.Property(e => e.Eparegion).HasColumnName("EPARegion");

                entity.Property(e => e.FkNcasiregionId).HasColumnName("FK_NCASIRegionID");

                entity.Property(e => e.OldNcasiregion)
                    .HasColumnName("OldNCASIRegion")
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.State).HasColumnType("varchar(10)");

                entity.Property(e => e.Subregion).HasColumnType("varchar(10)");

                entity.HasOne(d => d.FkNcasiregion)
                    .WithMany(p => p.Region)
                    .HasForeignKey(d => d.FkNcasiregionId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Region_NCASIRegion");
            });

            modelBuilder.Entity<Siccode>(entity =>
            {
                entity.HasKey(e => e.PkSiccodeId)
                    .HasName("PK_SICCodes");

                entity.ToTable("SICCode");

                entity.Property(e => e.PkSiccodeId).HasColumnName("PK_SICCodeID");

                entity.Property(e => e.Siccode1).HasColumnName("SICCode");
            });

            modelBuilder.Entity<SludgeData>(entity =>
            {
                entity.HasKey(e => e.PkSludgeId)
                    .HasName("PK_SludgeData");

                entity.Property(e => e.PkSludgeId).HasColumnName("PK_SludgeID");

                entity.Property(e => e.Comments).HasColumnType("varchar(max)");

                entity.Property(e => e.DisposalOpt).HasColumnType("varchar(50)");

                entity.Property(e => e.FkMillKey).HasColumnName("FK_MillKey");

                entity.Property(e => e.FkSourceId).HasColumnName("FK_SourceID");

                entity.Property(e => e.SludgeType).HasColumnType("varchar(50)");

                entity.Property(e => e.Tpy).HasColumnName("TPY");

                entity.HasOne(d => d.FkMillKeyNavigation)
                    .WithMany(p => p.SludgeData)
                    .HasForeignKey(d => d.FkMillKey)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SludgeData_MillInformation");

                entity.HasOne(d => d.FkSource)
                    .WithMany(p => p.SludgeData)
                    .HasForeignKey(d => d.FkSourceId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_SludgeData_Source");
            });

            modelBuilder.Entity<Source>(entity =>
            {
                entity.HasKey(e => e.PkSourceId)
                    .HasName("PK_Source");

                entity.Property(e => e.PkSourceId).HasColumnName("PK_SourceID");

                entity.Property(e => e.DataSource)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.SourceComments).HasColumnType("varchar(max)");

                entity.Property(e => e.SourceDescription)
                    .IsRequired()
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.UpdateDate).HasColumnType("date");
            });

            modelBuilder.Entity<WaterTreatmentData>(entity =>
            {
                entity.HasKey(e => e.PkWaterTreatmentId)
                    .HasName("PK_WaterTreatmentData");

                entity.Property(e => e.PkWaterTreatmentId).HasColumnName("PK_WaterTreatmentID");

                entity.Property(e => e.Comments).HasColumnType("varchar(max)");

                entity.Property(e => e.Description).HasColumnType("varchar(100)");

                entity.Property(e => e.FkFlowType).HasColumnName("FK_FlowType");

                entity.Property(e => e.FkMillKey).HasColumnName("FK_MillKey");

                entity.Property(e => e.FkSourceId).HasColumnName("FK_SourceID");

                entity.Property(e => e.Stage).HasColumnType("varchar(10)");

                entity.Property(e => e.Type).HasColumnType("varchar(25)");

                entity.HasOne(d => d.FkFlowTypeNavigation)
                    .WithMany(p => p.WaterTreatmentData)
                    .HasForeignKey(d => d.FkFlowType)
                    .HasConstraintName("FK_WaterTreatmentData_FlowType");

                entity.HasOne(d => d.FkMillKeyNavigation)
                    .WithMany(p => p.WaterTreatmentData)
                    .HasForeignKey(d => d.FkMillKey)
                    .HasConstraintName("FK_WaterTreatmentData_MillInformation");

                entity.HasOne(d => d.FkSource)
                    .WithMany(p => p.WaterTreatmentData)
                    .HasForeignKey(d => d.FkSourceId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_WaterTreatmentData_Source");
            });



            /**************************************************************
             * ENV DATABASE CONTEXT STARTS HERE
             * ***********************************************************/

            modelBuilder.Entity<Env_Facility>(entity =>
            {
                entity.HasKey(e => e.PkEnvFacilityKey)
                    .HasName("PK_Env_Facility");

                entity.ToTable("ENV_Facility");

                entity.Property(e => e.PkEnvFacilityKey).HasColumnName("PK_FacilityKey");

                entity.Property(e => e.FkMillkey).HasColumnName("FK_MillKey");

                entity.Property(e => e.NotAfpa).HasColumnName("NotAFPA");

                entity.Property(e => e.FkParentKey).HasColumnName("FK_ParentKey");

                entity.Property(e => e.Company).HasColumnType("varchar(75)");

                entity.Property(e => e.CoBod).HasColumnName("CoBOD");

                entity.Property(e => e.CoTss).HasColumnName("CoTSS");

                entity.Property(e => e.CoAllSw).HasColumnName("CoALL_SW");

                entity.Property(e => e.CoTri).HasColumnName("CoTRI");

                entity.Property(e => e.FkProdCatId).HasColumnName("FK_ProdCatID");

                entity.Property(e => e.Eprodcat).HasColumnType("varchar(5)");

                entity.Property(e => e.PrimaryProd).HasColumnType("varchar(50)");

                entity.Property(e => e.SecondaryProd).HasColumnType("varchar(50)");

                entity.Property(e => e.SpillComments).HasColumnType("varchar(max)");

                entity.Property(e => e.PenaltyComments).HasColumnType("varchar(max)");

                entity.Property(e => e.GenComments).HasColumnType("varchar(max)");

                entity.Property(e => e.FossilFuelComments).HasColumnType("varchar(max)");

                entity.Property(e => e.BiomassComments).HasColumnType("varchar(max)");

                entity.Property(e => e.EnergyComments).HasColumnType("varchar(max)");

                entity.Property(e => e.NtProducts).HasColumnType("varchar(max)");

                entity.Property(e => e.NtProducts).HasColumnName("NT_Products");

                entity.HasOne(d => d.FkMillInformation)
                    .WithMany(p => p.Env_Facility)
                    .HasForeignKey(d => d.FkMillkey)
                    .HasConstraintName("FK_ENV_Facility_MillInformation");

                entity.HasOne(d => d.FkNcasiProdcat)
                    .WithMany(p => p.Env_Facility)
                    .HasForeignKey(d => d.FkProdCatId)
                    .HasConstraintName("FK_ENV_Facility_NCASIProdCat");

            });

            modelBuilder.Entity<Env_WoodThickness>(entity =>
            {
                entity.HasKey(e => e.PkWoodKey)
                    .HasName("PK_Env_WoodThickness");

                entity.ToTable("ENV_WoodThickness");

                entity.Property(e => e.PkWoodKey).HasColumnName("PK_WoodKey");

                entity.Property(e => e.WoodId).HasColumnName("WoodID");

                entity.Property(e => e.Units).HasColumnType("varchar(50)");

            });

            modelBuilder.Entity<Env_ProductionData>(entity =>
            {
                entity.HasKey(e => e.PkEnvProdId)
                    .HasName("PK_Env_ProductionData");

                entity.ToTable("ENV_ProductionData");

                entity.Property(e => e.PkEnvProdId).HasColumnName("PK_ENVProdID");

                entity.Property(e => e.ProdType).HasColumnType("varchar(50)");

                entity.Property(e => e.Category).HasColumnType("varchar(50)");

                entity.Property(e => e.Units).HasColumnType("varchar(50)");

                entity.Property(e => e.Comments).HasColumnType("varchar(max)");

                entity.HasOne(d => d.FkFacility)
                    .WithMany(p => p.Env_ProductionData)
                    .HasForeignKey(d => d.FkFacilityKey)
                    .HasConstraintName("FK_ENV_ProductionData_ENV_Facility");

                entity.HasOne(d => d.FkWoodThickness)
                    .WithMany(p => p.Env_ProductionData)
                    .HasForeignKey(d => d.FkWoodThicknessId)
                    .HasConstraintName("FK_ENV_ProductionData_ENV_WoodThickness");
            });

            
        }
    }
}
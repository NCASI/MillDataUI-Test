using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MillDataUI.Models;

namespace MillDataUI.Migrations
{
    [DbContext(typeof(MillDataContext))]
    [Migration("20170714185453_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MillDataUI.Models.Epasubcat", b =>
                {
                    b.Property<int>("SubcatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("SubcatID");

                    b.Property<string>("Fiber")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Subcat")
                        .IsRequired()
                        .HasColumnType("varchar(2)");

                    b.Property<string>("SubcatDescription")
                        .HasColumnType("varchar(max)");

                    b.HasKey("SubcatId")
                        .HasName("PK_EPASubcats");

                    b.ToTable("EPASubcat");
                });

            modelBuilder.Entity("MillDataUI.Models.FlowData", b =>
                {
                    b.Property<int>("FlowId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("FlowID");

                    b.Property<string>("Comments")
                        .HasColumnType("varchar(max)");

                    b.Property<int?>("FkFlowType")
                        .HasColumnName("FK_FlowType");

                    b.Property<int?>("FkMillKey")
                        .HasColumnName("FK_MillKey");

                    b.Property<int?>("FkSourceId")
                        .HasColumnName("FK_SourceID");

                    b.Property<string>("FlowDescription")
                        .HasColumnType("varchar(50)");

                    b.Property<float?>("FlowMmgd")
                        .HasColumnName("FlowMMGD");

                    b.Property<float?>("RetDays");

                    b.Property<int?>("SourceYear");

                    b.Property<int?>("WaterBodyMile");

                    b.Property<string>("WaterBodyName")
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("WaterBodySegment");

                    b.Property<string>("WaterBodyType")
                        .HasColumnType("varchar(50)");

                    b.HasKey("FlowId")
                        .HasName("PK_FlowData");

                    b.HasIndex("FkFlowType");

                    b.HasIndex("FkMillKey");

                    b.HasIndex("FkSourceId");

                    b.ToTable("FlowData");
                });

            modelBuilder.Entity("MillDataUI.Models.FlowType", b =>
                {
                    b.Property<int>("FlowTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("FlowTypeID");

                    b.Property<string>("FlowTypeName")
                        .HasColumnType("varchar(15)");

                    b.HasKey("FlowTypeId");

                    b.ToTable("FlowType");
                });

            modelBuilder.Entity("MillDataUI.Models.HistoricalMillInfo", b =>
                {
                    b.Property<int>("InfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("InfoID");

                    b.Property<DateTime?>("ChangeDate")
                        .HasColumnType("date");

                    b.Property<string>("Comments")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Company")
                        .HasColumnType("varchar(max)");

                    b.Property<int?>("FkMillId")
                        .HasColumnName("FK_MillID");

                    b.Property<int?>("ProdCategory1");

                    b.Property<int?>("ProdCategory2");

                    b.Property<string>("WhatChanged")
                        .HasColumnType("varchar(max)");

                    b.HasKey("InfoId")
                        .HasName("PK_HIstoricalMillInfo");

                    b.HasIndex("FkMillId");

                    b.HasIndex("ProdCategory2");

                    b.ToTable("HistoricalMillInfo");
                });

            modelBuilder.Entity("MillDataUI.Models.MillCodeLinks", b =>
                {
                    b.Property<int>("MillCodeLinkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("MillCodeLinkID");

                    b.Property<string>("Fisher")
                        .HasColumnType("varchar(10)");

                    b.Property<int?>("Fpac")
                        .HasColumnName("FPAC");

                    b.Property<int?>("Lwp")
                        .HasColumnName("LWP");

                    b.Property<int?>("Nims")
                        .HasColumnName("NIMS");

                    b.HasKey("MillCodeLinkId")
                        .HasName("PK_MillCodeLinks");

                    b.ToTable("MillCodeLinks");
                });

            modelBuilder.Entity("MillDataUI.Models.MillCodischarger", b =>
                {
                    b.Property<int>("CodischargeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CodischargeID");

                    b.Property<int?>("MillKey1");

                    b.Property<int?>("MillKey2");

                    b.HasKey("CodischargeId")
                        .HasName("PK_MillCoDischarger");

                    b.HasIndex("MillKey1");

                    b.HasIndex("MillKey2");

                    b.ToTable("MillCodischarger");
                });

            modelBuilder.Entity("MillDataUI.Models.MillInformation", b =>
                {
                    b.Property<int>("PkMillKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("PK_MillKey");

                    b.Property<string>("Comments")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Company")
                        .HasColumnType("varchar(75)");

                    b.Property<int?>("Eparegion")
                        .HasColumnName("EPARegion");

                    b.Property<int?>("FkEpasubcatId")
                        .HasColumnName("FK_EPASubcatID");

                    b.Property<int?>("FkMillTypeId")
                        .HasColumnName("FK_MillTypeID");

                    b.Property<string>("Latitude")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Longitude")
                        .HasColumnType("varchar(50)");

                    b.Property<int>("MillId")
                        .HasColumnName("MillID");

                    b.Property<string>("MillStatus")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Naprodcat")
                        .HasColumnName("NAProdcat")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PostalAddress")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PostalAddress2")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PostalCity")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PostalCountry")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PostalPostcode")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PostalState")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ProdCat1")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ProdCat2")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ShippingAddress")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ShippingAddress2")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ShippingCity")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ShippingCountry")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ShippingPostcode")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ShippingState")
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("StatusDate")
                        .HasColumnType("date");

                    b.Property<string>("Website")
                        .HasColumnType("varchar(max)");

                    b.HasKey("PkMillKey")
                        .HasName("PK_MillInformation");

                    b.HasIndex("FkEpasubcatId");

                    b.HasIndex("FkMillTypeId");

                    b.ToTable("MillInformation");
                });

            modelBuilder.Entity("MillDataUI.Models.MillNarrative", b =>
                {
                    b.Property<int>("NarrativeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("NarrativeID");

                    b.Property<int?>("FkMillId")
                        .HasColumnName("FK_MillID");

                    b.Property<string>("MillNarrative1")
                        .HasColumnName("MillNarrative")
                        .HasColumnType("varchar(max)");

                    b.HasKey("NarrativeId")
                        .HasName("PK_MillNarrative");

                    b.HasIndex("FkMillId");

                    b.ToTable("MillNarrative");
                });

            modelBuilder.Entity("MillDataUI.Models.MillParentRelationship", b =>
                {
                    b.Property<int>("RelationshipId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("RelationshipID");

                    b.Property<int?>("FkMillId")
                        .HasColumnName("FK_MillID");

                    b.Property<int?>("FkParentCompanyId")
                        .HasColumnName("FK_ParentCompanyID");

                    b.Property<bool?>("Ncasimember")
                        .HasColumnName("NCASIMember");

                    b.Property<int?>("PercentOwned");

                    b.Property<string>("Relationship")
                        .HasColumnType("varchar(50)");

                    b.HasKey("RelationshipId")
                        .HasName("PK_MillParentRelationship_1");

                    b.HasIndex("FkMillId");

                    b.HasIndex("FkParentCompanyId");

                    b.ToTable("MillParentRelationship");
                });

            modelBuilder.Entity("MillDataUI.Models.MillSiccodes", b =>
                {
                    b.Property<int>("MillSicid")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("MillSICID");

                    b.Property<int?>("FkMillKey")
                        .HasColumnName("FK_MillKey");

                    b.Property<int>("FkSiccodeId")
                        .HasColumnName("FK_SICCodeID");

                    b.HasKey("MillSicid")
                        .HasName("PK_MillSICCodes_1");

                    b.HasIndex("FkMillKey");

                    b.HasIndex("FkSiccodeId");

                    b.ToTable("MillSICCodes");
                });

            modelBuilder.Entity("MillDataUI.Models.MillType", b =>
                {
                    b.Property<int>("TypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("TypeID");

                    b.Property<string>("TypeName")
                        .HasColumnType("varchar(50)");

                    b.HasKey("TypeId")
                        .HasName("PK_MillType");

                    b.ToTable("MillType");
                });

            modelBuilder.Entity("MillDataUI.Models.NcasiprodCat", b =>
                {
                    b.Property<int>("ProdCatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ProdCatID");

                    b.Property<string>("Category")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Comments")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("FacType")
                        .HasColumnType("varchar(25)");

                    b.Property<string>("FiberSource")
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("FkEpasubcatId")
                        .HasColumnName("FK_EPASubcatID");

                    b.Property<string>("ProdCatDescription")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("ProdType")
                        .HasColumnType("varchar(50)");

                    b.HasKey("ProdCatId")
                        .HasName("PK_NCASIProdCats");

                    b.HasIndex("FkEpasubcatId");

                    b.ToTable("NCASIProdCat");
                });

            modelBuilder.Entity("MillDataUI.Models.Ncasiregion", b =>
                {
                    b.Property<int>("RegionCodeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("RegionCodeID");

                    b.Property<string>("RegionCode")
                        .HasColumnType("char(1)");

                    b.Property<string>("RegionName")
                        .HasColumnType("varchar(10)");

                    b.HasKey("RegionCodeId")
                        .HasName("PK_NCASIRegion");

                    b.ToTable("NCASIRegion");
                });

            modelBuilder.Entity("MillDataUI.Models.Npdes", b =>
                {
                    b.Property<int>("PkNpdeskey")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("PK_NPDESKey");

                    b.Property<string>("Comments")
                        .HasColumnType("varchar(max)");

                    b.Property<int?>("FkMillKey")
                        .HasColumnName("FK_MillKey");

                    b.Property<bool?>("NotProcess");

                    b.Property<string>("Npdesid")
                        .HasColumnName("NPDESID")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PermitLatitude")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PermitLongitude")
                        .HasColumnType("varchar(50)");

                    b.HasKey("PkNpdeskey")
                        .HasName("PK_NPDES");

                    b.HasIndex("FkMillKey");

                    b.ToTable("NPDES");
                });

            modelBuilder.Entity("MillDataUI.Models.Npdesdocs", b =>
                {
                    b.Property<int>("DocId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("DocID");

                    b.Property<string>("DocPath")
                        .HasColumnType("varchar(max)");

                    b.Property<int?>("FkDocTypeId")
                        .HasColumnName("FK_DocTypeID");

                    b.Property<int?>("FkNpdesid")
                        .HasColumnName("FK_NPDESID");

                    b.HasKey("DocId")
                        .HasName("PK_NPDESDocs");

                    b.HasIndex("FkDocTypeId");

                    b.HasIndex("FkNpdesid");

                    b.ToTable("NPDESDocs");
                });

            modelBuilder.Entity("MillDataUI.Models.NpdesdocType", b =>
                {
                    b.Property<int>("DocTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("DocTypeID");

                    b.Property<string>("DocType")
                        .HasColumnType("varchar(25)");

                    b.HasKey("DocTypeId")
                        .HasName("PK_NPDESDocType");

                    b.ToTable("NPDESDocType");
                });

            modelBuilder.Entity("MillDataUI.Models.ParentCompany", b =>
                {
                    b.Property<int>("PkParentCompanyKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("PK_ParentCompanyKey");

                    b.Property<bool?>("Afpamember")
                        .HasColumnName("AFPAMember");

                    b.Property<string>("Comment")
                        .HasColumnType("varchar(max)");

                    b.Property<int?>("CorpId")
                        .HasColumnName("CorpID");

                    b.Property<string>("MergeSplitStatus")
                        .HasColumnType("char(1)");

                    b.Property<string>("ParentCompany1")
                        .HasColumnName("ParentCompany")
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("ParentCompanyId")
                        .HasColumnName("ParentCompanyID");

                    b.HasKey("PkParentCompanyKey")
                        .HasName("PK_ParentCompany");

                    b.ToTable("ParentCompany");
                });

            modelBuilder.Entity("MillDataUI.Models.ProductionData", b =>
                {
                    b.Property<int>("ProductionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ProductionID");

                    b.Property<string>("Comments")
                        .HasColumnType("varchar(max)");

                    b.Property<int?>("FkMillKey")
                        .HasColumnName("FK_MillKey");

                    b.Property<int?>("FkProdCatId")
                        .HasColumnName("FK_ProdCatID");

                    b.Property<int?>("FkSourceId")
                        .HasColumnName("FK_SourceID");

                    b.Property<float?>("Quantity");

                    b.Property<int?>("SourceYear");

                    b.Property<string>("Units")
                        .HasColumnType("varchar(10)");

                    b.HasKey("ProductionId")
                        .HasName("PK_ProductionData");

                    b.HasIndex("FkMillKey");

                    b.HasIndex("FkProdCatId");

                    b.HasIndex("FkSourceId");

                    b.ToTable("ProductionData");
                });

            modelBuilder.Entity("MillDataUI.Models.Region", b =>
                {
                    b.Property<int>("RegionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("RegionID");

                    b.Property<int?>("Eparegion")
                        .HasColumnName("EPARegion");

                    b.Property<int>("FkNcasiregionId")
                        .HasColumnName("FK_NCASIRegionID");

                    b.Property<string>("OldNcasiregion")
                        .HasColumnName("OldNCASIRegion")
                        .HasColumnType("varchar(5)");

                    b.Property<string>("State")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Subregion")
                        .HasColumnType("varchar(10)");

                    b.HasKey("RegionId");

                    b.HasIndex("FkNcasiregionId");

                    b.ToTable("Region");
                });

            modelBuilder.Entity("MillDataUI.Models.Siccode", b =>
                {
                    b.Property<int>("SiccodeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("SICCodeID");

                    b.Property<int?>("Siccode1")
                        .HasColumnName("SICCode");

                    b.HasKey("SiccodeId");

                    b.ToTable("SICCode");
                });

            modelBuilder.Entity("MillDataUI.Models.SludgeData", b =>
                {
                    b.Property<int>("SludgeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("SludgeID");

                    b.Property<string>("Comments")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("DisposalOpt")
                        .HasColumnType("varchar(50)");

                    b.Property<int>("FkMillKey")
                        .HasColumnName("FK_MillKey");

                    b.Property<int?>("FkSourceId")
                        .HasColumnName("FK_SourceID");

                    b.Property<string>("SludgeType")
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("SourceYear");

                    b.Property<float?>("Tpy")
                        .HasColumnName("TPY");

                    b.HasKey("SludgeId")
                        .HasName("PK_SludgeData");

                    b.HasIndex("FkMillKey");

                    b.HasIndex("FkSourceId");

                    b.ToTable("SludgeData");
                });

            modelBuilder.Entity("MillDataUI.Models.Source", b =>
                {
                    b.Property<int>("SourceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("SourceID");

                    b.Property<string>("DataSource")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("SourceComments")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("SourceDescription")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("date");

                    b.HasKey("SourceId");

                    b.ToTable("Source");
                });

            modelBuilder.Entity("MillDataUI.Models.WaterTreatmentData", b =>
                {
                    b.Property<int>("WaterTreatmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("WaterTreatmentID");

                    b.Property<string>("Comments")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("FkFlowType")
                        .HasColumnName("FK_FlowType");

                    b.Property<int?>("FkMillKey")
                        .HasColumnName("FK_MillKey");

                    b.Property<int?>("FkSourceId")
                        .HasColumnName("FK_SourceID");

                    b.Property<int?>("SourceYear");

                    b.Property<string>("Stage")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Type")
                        .HasColumnType("varchar(25)");

                    b.HasKey("WaterTreatmentId")
                        .HasName("PK_WaterTreatmentData");

                    b.HasIndex("FkFlowType");

                    b.HasIndex("FkMillKey");

                    b.HasIndex("FkSourceId");

                    b.ToTable("WaterTreatmentData");
                });

            modelBuilder.Entity("MillDataUI.Models.FlowData", b =>
                {
                    b.HasOne("MillDataUI.Models.FlowType", "FkFlowTypeNavigation")
                        .WithMany("FlowData")
                        .HasForeignKey("FkFlowType")
                        .HasConstraintName("FK_FlowData_FlowType")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("MillDataUI.Models.MillInformation", "FkMillKeyNavigation")
                        .WithMany("FlowData")
                        .HasForeignKey("FkMillKey");

                    b.HasOne("MillDataUI.Models.Source", "FkSource")
                        .WithMany("FlowData")
                        .HasForeignKey("FkSourceId")
                        .HasConstraintName("FK_FlowData_Source")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("MillDataUI.Models.HistoricalMillInfo", b =>
                {
                    b.HasOne("MillDataUI.Models.MillInformation", "FkMill")
                        .WithMany("HistoricalMillInfo")
                        .HasForeignKey("FkMillId");

                    b.HasOne("MillDataUI.Models.NcasiprodCat", "ProdCategory2Navigation")
                        .WithMany("HistoricalMillInfo")
                        .HasForeignKey("ProdCategory2");
                });

            modelBuilder.Entity("MillDataUI.Models.MillCodischarger", b =>
                {
                    b.HasOne("MillDataUI.Models.MillInformation", "MillKey1Navigation")
                        .WithMany("MillCodischargerMillKey1Navigation")
                        .HasForeignKey("MillKey1");

                    b.HasOne("MillDataUI.Models.MillInformation", "MillKey2Navigation")
                        .WithMany("MillCodischargerMillKey2Navigation")
                        .HasForeignKey("MillKey2");
                });

            modelBuilder.Entity("MillDataUI.Models.MillInformation", b =>
                {
                    b.HasOne("MillDataUI.Models.Epasubcat", "FkEpasubcat")
                        .WithMany("MillInformation")
                        .HasForeignKey("FkEpasubcatId")
                        .HasConstraintName("FK_MillInformation_EPASubcat")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("MillDataUI.Models.MillType", "FkMillType")
                        .WithMany("MillInformation")
                        .HasForeignKey("FkMillTypeId");
                });

            modelBuilder.Entity("MillDataUI.Models.MillNarrative", b =>
                {
                    b.HasOne("MillDataUI.Models.MillInformation", "FkMill")
                        .WithMany("MillNarrative")
                        .HasForeignKey("FkMillId")
                        .HasConstraintName("FK_MillNarrative_MillInformation");
                });

            modelBuilder.Entity("MillDataUI.Models.MillParentRelationship", b =>
                {
                    b.HasOne("MillDataUI.Models.MillInformation", "FkMill")
                        .WithMany("MillParentRelationship")
                        .HasForeignKey("FkMillId")
                        .HasConstraintName("FK_MillParentRelationship_MillInformation")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MillDataUI.Models.ParentCompany", "FkParentCompany")
                        .WithMany("MillParentRelationship")
                        .HasForeignKey("FkParentCompanyId");
                });

            modelBuilder.Entity("MillDataUI.Models.MillSiccodes", b =>
                {
                    b.HasOne("MillDataUI.Models.MillInformation", "FkMillKeyNavigation")
                        .WithMany("MillSiccodes")
                        .HasForeignKey("FkMillKey")
                        .HasConstraintName("FK_MillSICCodes_MillInformation")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MillDataUI.Models.Siccode", "FkSiccode")
                        .WithMany("MillSiccodes")
                        .HasForeignKey("FkSiccodeId")
                        .HasConstraintName("FK_MillSICCodes_SICCodes");
                });

            modelBuilder.Entity("MillDataUI.Models.NcasiprodCat", b =>
                {
                    b.HasOne("MillDataUI.Models.Epasubcat", "FkEpasubcat")
                        .WithMany("NcasiprodCat")
                        .HasForeignKey("FkEpasubcatId")
                        .HasConstraintName("FK_NCASIProdCat_EPASubcat");
                });

            modelBuilder.Entity("MillDataUI.Models.Npdes", b =>
                {
                    b.HasOne("MillDataUI.Models.MillInformation", "FkMillKeyNavigation")
                        .WithMany("Npdes")
                        .HasForeignKey("FkMillKey")
                        .HasConstraintName("FK_NPDES_MillInformation");
                });

            modelBuilder.Entity("MillDataUI.Models.Npdesdocs", b =>
                {
                    b.HasOne("MillDataUI.Models.NpdesdocType", "FkDocType")
                        .WithMany("Npdesdocs")
                        .HasForeignKey("FkDocTypeId")
                        .HasConstraintName("FK_NPDESDocs_NPDESDocType");

                    b.HasOne("MillDataUI.Models.Npdes", "FkNpdes")
                        .WithMany("Npdesdocs")
                        .HasForeignKey("FkNpdesid")
                        .HasConstraintName("FK_NPDESDocs_NPDES");
                });

            modelBuilder.Entity("MillDataUI.Models.ProductionData", b =>
                {
                    b.HasOne("MillDataUI.Models.MillInformation", "FkMillKeyNavigation")
                        .WithMany("ProductionData")
                        .HasForeignKey("FkMillKey")
                        .HasConstraintName("FK_ProductionData_MillInformation");

                    b.HasOne("MillDataUI.Models.NcasiprodCat", "FkProdCat")
                        .WithMany("ProductionData")
                        .HasForeignKey("FkProdCatId")
                        .HasConstraintName("FK_ProductionData_NCASIProdCat");

                    b.HasOne("MillDataUI.Models.Source", "FkSource")
                        .WithMany("ProductionData")
                        .HasForeignKey("FkSourceId")
                        .HasConstraintName("FK_ProductionData_Source");
                });

            modelBuilder.Entity("MillDataUI.Models.Region", b =>
                {
                    b.HasOne("MillDataUI.Models.Ncasiregion", "FkNcasiregion")
                        .WithMany("Region")
                        .HasForeignKey("FkNcasiregionId")
                        .HasConstraintName("FK_Region_NCASIRegion");
                });

            modelBuilder.Entity("MillDataUI.Models.SludgeData", b =>
                {
                    b.HasOne("MillDataUI.Models.MillInformation", "FkMillKeyNavigation")
                        .WithMany("SludgeData")
                        .HasForeignKey("FkMillKey")
                        .HasConstraintName("FK_SludgeData_MillInformation");

                    b.HasOne("MillDataUI.Models.Source", "FkSource")
                        .WithMany("SludgeData")
                        .HasForeignKey("FkSourceId")
                        .HasConstraintName("FK_SludgeData_Source")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("MillDataUI.Models.WaterTreatmentData", b =>
                {
                    b.HasOne("MillDataUI.Models.FlowType", "FkFlowTypeNavigation")
                        .WithMany("WaterTreatmentData")
                        .HasForeignKey("FkFlowType")
                        .HasConstraintName("FK_WaterTreatmentData_FlowType");

                    b.HasOne("MillDataUI.Models.MillInformation", "FkMillKeyNavigation")
                        .WithMany("WaterTreatmentData")
                        .HasForeignKey("FkMillKey")
                        .HasConstraintName("FK_WaterTreatmentData_MillInformation");

                    b.HasOne("MillDataUI.Models.Source", "FkSource")
                        .WithMany("WaterTreatmentData")
                        .HasForeignKey("FkSourceId")
                        .HasConstraintName("FK_WaterTreatmentData_Source")
                        .OnDelete(DeleteBehavior.SetNull);
                });
        }
    }
}

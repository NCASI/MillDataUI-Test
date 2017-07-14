using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MillDataUI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EPASubcat",
                columns: table => new
                {
                    SubcatID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fiber = table.Column<string>(type: "varchar(100)", nullable: true),
                    Subcat = table.Column<string>(type: "varchar(2)", nullable: false),
                    SubcatDescription = table.Column<string>(type: "varchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EPASubcats", x => x.SubcatID);
                });

            migrationBuilder.CreateTable(
                name: "FlowType",
                columns: table => new
                {
                    FlowTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FlowTypeName = table.Column<string>(type: "varchar(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowType", x => x.FlowTypeID);
                });

            migrationBuilder.CreateTable(
                name: "MillCodeLinks",
                columns: table => new
                {
                    MillCodeLinkID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fisher = table.Column<string>(type: "varchar(10)", nullable: true),
                    FPAC = table.Column<int>(nullable: true),
                    LWP = table.Column<int>(nullable: true),
                    NIMS = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MillCodeLinks", x => x.MillCodeLinkID);
                });

            migrationBuilder.CreateTable(
                name: "MillType",
                columns: table => new
                {
                    TypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TypeName = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MillType", x => x.TypeID);
                });

            migrationBuilder.CreateTable(
                name: "NCASIRegion",
                columns: table => new
                {
                    RegionCodeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RegionCode = table.Column<string>(type: "char(1)", nullable: true),
                    RegionName = table.Column<string>(type: "varchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NCASIRegion", x => x.RegionCodeID);
                });

            migrationBuilder.CreateTable(
                name: "NPDESDocType",
                columns: table => new
                {
                    DocTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DocType = table.Column<string>(type: "varchar(25)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NPDESDocType", x => x.DocTypeID);
                });

            migrationBuilder.CreateTable(
                name: "ParentCompany",
                columns: table => new
                {
                    PK_ParentCompanyKey = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AFPAMember = table.Column<bool>(nullable: true),
                    Comment = table.Column<string>(type: "varchar(max)", nullable: true),
                    CorpID = table.Column<int>(nullable: true),
                    MergeSplitStatus = table.Column<string>(type: "char(1)", nullable: true),
                    ParentCompany = table.Column<string>(type: "varchar(50)", nullable: true),
                    ParentCompanyID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentCompany", x => x.PK_ParentCompanyKey);
                });

            migrationBuilder.CreateTable(
                name: "SICCode",
                columns: table => new
                {
                    SICCodeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SICCode = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SICCode", x => x.SICCodeID);
                });

            migrationBuilder.CreateTable(
                name: "Source",
                columns: table => new
                {
                    SourceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataSource = table.Column<string>(type: "varchar(50)", nullable: false),
                    SourceComments = table.Column<string>(type: "varchar(max)", nullable: true),
                    SourceDescription = table.Column<string>(type: "varchar(max)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Source", x => x.SourceID);
                });

            migrationBuilder.CreateTable(
                name: "NCASIProdCat",
                columns: table => new
                {
                    ProdCatID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Category = table.Column<string>(type: "varchar(50)", nullable: true),
                    Comments = table.Column<string>(type: "varchar(max)", nullable: true),
                    FacType = table.Column<string>(type: "varchar(25)", nullable: true),
                    FiberSource = table.Column<string>(type: "varchar(50)", nullable: true),
                    FK_EPASubcatID = table.Column<int>(nullable: true),
                    ProdCatDescription = table.Column<string>(type: "varchar(max)", nullable: true),
                    ProdType = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NCASIProdCats", x => x.ProdCatID);
                    table.ForeignKey(
                        name: "FK_NCASIProdCat_EPASubcat",
                        column: x => x.FK_EPASubcatID,
                        principalTable: "EPASubcat",
                        principalColumn: "SubcatID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MillInformation",
                columns: table => new
                {
                    PK_MillKey = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Comments = table.Column<string>(type: "varchar(max)", nullable: true),
                    Company = table.Column<string>(type: "varchar(75)", nullable: true),
                    EPARegion = table.Column<int>(nullable: true),
                    FK_EPASubcatID = table.Column<int>(nullable: true),
                    FK_MillTypeID = table.Column<int>(nullable: true),
                    Latitude = table.Column<string>(type: "varchar(50)", nullable: true),
                    Longitude = table.Column<string>(type: "varchar(50)", nullable: true),
                    MillID = table.Column<int>(nullable: false),
                    MillStatus = table.Column<string>(type: "varchar(50)", nullable: true),
                    NAProdcat = table.Column<string>(type: "varchar(50)", nullable: true),
                    PostalAddress = table.Column<string>(type: "varchar(50)", nullable: true),
                    PostalAddress2 = table.Column<string>(type: "varchar(50)", nullable: true),
                    PostalCity = table.Column<string>(type: "varchar(50)", nullable: true),
                    PostalCountry = table.Column<string>(type: "varchar(50)", nullable: true),
                    PostalPostcode = table.Column<string>(type: "varchar(50)", nullable: true),
                    PostalState = table.Column<string>(type: "varchar(50)", nullable: true),
                    ProdCat1 = table.Column<string>(type: "varchar(50)", nullable: true),
                    ProdCat2 = table.Column<string>(type: "varchar(50)", nullable: true),
                    ShippingAddress = table.Column<string>(type: "varchar(50)", nullable: true),
                    ShippingAddress2 = table.Column<string>(type: "varchar(50)", nullable: true),
                    ShippingCity = table.Column<string>(type: "varchar(50)", nullable: true),
                    ShippingCountry = table.Column<string>(type: "varchar(50)", nullable: true),
                    ShippingPostcode = table.Column<string>(type: "varchar(50)", nullable: true),
                    ShippingState = table.Column<string>(type: "varchar(50)", nullable: true),
                    StatusDate = table.Column<DateTime>(type: "date", nullable: true),
                    Website = table.Column<string>(type: "varchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MillInformation", x => x.PK_MillKey);
                    table.ForeignKey(
                        name: "FK_MillInformation_EPASubcat",
                        column: x => x.FK_EPASubcatID,
                        principalTable: "EPASubcat",
                        principalColumn: "SubcatID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_MillInformation_MillType_FK_MillTypeID",
                        column: x => x.FK_MillTypeID,
                        principalTable: "MillType",
                        principalColumn: "TypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    RegionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EPARegion = table.Column<int>(nullable: true),
                    FK_NCASIRegionID = table.Column<int>(nullable: false),
                    OldNCASIRegion = table.Column<string>(type: "varchar(5)", nullable: true),
                    State = table.Column<string>(type: "varchar(10)", nullable: true),
                    Subregion = table.Column<string>(type: "varchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.RegionID);
                    table.ForeignKey(
                        name: "FK_Region_NCASIRegion",
                        column: x => x.FK_NCASIRegionID,
                        principalTable: "NCASIRegion",
                        principalColumn: "RegionCodeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FlowData",
                columns: table => new
                {
                    FlowID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Comments = table.Column<string>(type: "varchar(max)", nullable: true),
                    FK_FlowType = table.Column<int>(nullable: true),
                    FK_MillKey = table.Column<int>(nullable: true),
                    FK_SourceID = table.Column<int>(nullable: true),
                    FlowDescription = table.Column<string>(type: "varchar(50)", nullable: true),
                    FlowMMGD = table.Column<float>(nullable: true),
                    RetDays = table.Column<float>(nullable: true),
                    SourceYear = table.Column<int>(nullable: true),
                    WaterBodyMile = table.Column<int>(nullable: true),
                    WaterBodyName = table.Column<string>(type: "varchar(50)", nullable: true),
                    WaterBodySegment = table.Column<int>(nullable: true),
                    WaterBodyType = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowData", x => x.FlowID);
                    table.ForeignKey(
                        name: "FK_FlowData_FlowType",
                        column: x => x.FK_FlowType,
                        principalTable: "FlowType",
                        principalColumn: "FlowTypeID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_FlowData_MillInformation_FK_MillKey",
                        column: x => x.FK_MillKey,
                        principalTable: "MillInformation",
                        principalColumn: "PK_MillKey",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FlowData_Source",
                        column: x => x.FK_SourceID,
                        principalTable: "Source",
                        principalColumn: "SourceID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "HistoricalMillInfo",
                columns: table => new
                {
                    InfoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ChangeDate = table.Column<DateTime>(type: "date", nullable: true),
                    Comments = table.Column<string>(type: "varchar(max)", nullable: true),
                    Company = table.Column<string>(type: "varchar(max)", nullable: true),
                    FK_MillID = table.Column<int>(nullable: true),
                    ProdCategory1 = table.Column<int>(nullable: true),
                    ProdCategory2 = table.Column<int>(nullable: true),
                    WhatChanged = table.Column<string>(type: "varchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HIstoricalMillInfo", x => x.InfoID);
                    table.ForeignKey(
                        name: "FK_HistoricalMillInfo_MillInformation_FK_MillID",
                        column: x => x.FK_MillID,
                        principalTable: "MillInformation",
                        principalColumn: "PK_MillKey",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoricalMillInfo_NCASIProdCat_ProdCategory2",
                        column: x => x.ProdCategory2,
                        principalTable: "NCASIProdCat",
                        principalColumn: "ProdCatID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MillCodischarger",
                columns: table => new
                {
                    CodischargeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MillKey1 = table.Column<int>(nullable: true),
                    MillKey2 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MillCoDischarger", x => x.CodischargeID);
                    table.ForeignKey(
                        name: "FK_MillCodischarger_MillInformation_MillKey1",
                        column: x => x.MillKey1,
                        principalTable: "MillInformation",
                        principalColumn: "PK_MillKey",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MillCodischarger_MillInformation_MillKey2",
                        column: x => x.MillKey2,
                        principalTable: "MillInformation",
                        principalColumn: "PK_MillKey",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MillNarrative",
                columns: table => new
                {
                    NarrativeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FK_MillID = table.Column<int>(nullable: true),
                    MillNarrative = table.Column<string>(type: "varchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MillNarrative", x => x.NarrativeID);
                    table.ForeignKey(
                        name: "FK_MillNarrative_MillInformation",
                        column: x => x.FK_MillID,
                        principalTable: "MillInformation",
                        principalColumn: "PK_MillKey",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MillParentRelationship",
                columns: table => new
                {
                    RelationshipID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FK_MillID = table.Column<int>(nullable: true),
                    FK_ParentCompanyID = table.Column<int>(nullable: true),
                    NCASIMember = table.Column<bool>(nullable: true),
                    PercentOwned = table.Column<int>(nullable: true),
                    Relationship = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MillParentRelationship_1", x => x.RelationshipID);
                    table.ForeignKey(
                        name: "FK_MillParentRelationship_MillInformation",
                        column: x => x.FK_MillID,
                        principalTable: "MillInformation",
                        principalColumn: "PK_MillKey",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MillParentRelationship_ParentCompany_FK_ParentCompanyID",
                        column: x => x.FK_ParentCompanyID,
                        principalTable: "ParentCompany",
                        principalColumn: "PK_ParentCompanyKey",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MillSICCodes",
                columns: table => new
                {
                    MillSICID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FK_MillKey = table.Column<int>(nullable: true),
                    FK_SICCodeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MillSICCodes_1", x => x.MillSICID);
                    table.ForeignKey(
                        name: "FK_MillSICCodes_MillInformation",
                        column: x => x.FK_MillKey,
                        principalTable: "MillInformation",
                        principalColumn: "PK_MillKey",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MillSICCodes_SICCodes",
                        column: x => x.FK_SICCodeID,
                        principalTable: "SICCode",
                        principalColumn: "SICCodeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NPDES",
                columns: table => new
                {
                    PK_NPDESKey = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Comments = table.Column<string>(type: "varchar(max)", nullable: true),
                    FK_MillKey = table.Column<int>(nullable: true),
                    NotProcess = table.Column<bool>(nullable: true),
                    NPDESID = table.Column<string>(type: "varchar(50)", nullable: true),
                    PermitLatitude = table.Column<string>(type: "varchar(50)", nullable: true),
                    PermitLongitude = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NPDES", x => x.PK_NPDESKey);
                    table.ForeignKey(
                        name: "FK_NPDES_MillInformation",
                        column: x => x.FK_MillKey,
                        principalTable: "MillInformation",
                        principalColumn: "PK_MillKey",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductionData",
                columns: table => new
                {
                    ProductionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Comments = table.Column<string>(type: "varchar(max)", nullable: true),
                    FK_MillKey = table.Column<int>(nullable: true),
                    FK_ProdCatID = table.Column<int>(nullable: true),
                    FK_SourceID = table.Column<int>(nullable: true),
                    Quantity = table.Column<float>(nullable: true),
                    SourceYear = table.Column<int>(nullable: true),
                    Units = table.Column<string>(type: "varchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionData", x => x.ProductionID);
                    table.ForeignKey(
                        name: "FK_ProductionData_MillInformation",
                        column: x => x.FK_MillKey,
                        principalTable: "MillInformation",
                        principalColumn: "PK_MillKey",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductionData_NCASIProdCat",
                        column: x => x.FK_ProdCatID,
                        principalTable: "NCASIProdCat",
                        principalColumn: "ProdCatID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductionData_Source",
                        column: x => x.FK_SourceID,
                        principalTable: "Source",
                        principalColumn: "SourceID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SludgeData",
                columns: table => new
                {
                    SludgeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Comments = table.Column<string>(type: "varchar(max)", nullable: true),
                    DisposalOpt = table.Column<string>(type: "varchar(50)", nullable: true),
                    FK_MillKey = table.Column<int>(nullable: false),
                    FK_SourceID = table.Column<int>(nullable: true),
                    SludgeType = table.Column<string>(type: "varchar(50)", nullable: true),
                    SourceYear = table.Column<int>(nullable: true),
                    TPY = table.Column<float>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SludgeData", x => x.SludgeID);
                    table.ForeignKey(
                        name: "FK_SludgeData_MillInformation",
                        column: x => x.FK_MillKey,
                        principalTable: "MillInformation",
                        principalColumn: "PK_MillKey",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SludgeData_Source",
                        column: x => x.FK_SourceID,
                        principalTable: "Source",
                        principalColumn: "SourceID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "WaterTreatmentData",
                columns: table => new
                {
                    WaterTreatmentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Comments = table.Column<string>(type: "varchar(max)", nullable: true),
                    Description = table.Column<string>(type: "varchar(100)", nullable: true),
                    FK_FlowType = table.Column<int>(nullable: true),
                    FK_MillKey = table.Column<int>(nullable: true),
                    FK_SourceID = table.Column<int>(nullable: true),
                    SourceYear = table.Column<int>(nullable: true),
                    Stage = table.Column<string>(type: "varchar(10)", nullable: true),
                    Type = table.Column<string>(type: "varchar(25)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterTreatmentData", x => x.WaterTreatmentID);
                    table.ForeignKey(
                        name: "FK_WaterTreatmentData_FlowType",
                        column: x => x.FK_FlowType,
                        principalTable: "FlowType",
                        principalColumn: "FlowTypeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WaterTreatmentData_MillInformation",
                        column: x => x.FK_MillKey,
                        principalTable: "MillInformation",
                        principalColumn: "PK_MillKey",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WaterTreatmentData_Source",
                        column: x => x.FK_SourceID,
                        principalTable: "Source",
                        principalColumn: "SourceID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "NPDESDocs",
                columns: table => new
                {
                    DocID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DocPath = table.Column<string>(type: "varchar(max)", nullable: true),
                    FK_DocTypeID = table.Column<int>(nullable: true),
                    FK_NPDESID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NPDESDocs", x => x.DocID);
                    table.ForeignKey(
                        name: "FK_NPDESDocs_NPDESDocType",
                        column: x => x.FK_DocTypeID,
                        principalTable: "NPDESDocType",
                        principalColumn: "DocTypeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NPDESDocs_NPDES",
                        column: x => x.FK_NPDESID,
                        principalTable: "NPDES",
                        principalColumn: "PK_NPDESKey",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlowData_FK_FlowType",
                table: "FlowData",
                column: "FK_FlowType");

            migrationBuilder.CreateIndex(
                name: "IX_FlowData_FK_MillKey",
                table: "FlowData",
                column: "FK_MillKey");

            migrationBuilder.CreateIndex(
                name: "IX_FlowData_FK_SourceID",
                table: "FlowData",
                column: "FK_SourceID");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricalMillInfo_FK_MillID",
                table: "HistoricalMillInfo",
                column: "FK_MillID");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricalMillInfo_ProdCategory2",
                table: "HistoricalMillInfo",
                column: "ProdCategory2");

            migrationBuilder.CreateIndex(
                name: "IX_MillCodischarger_MillKey1",
                table: "MillCodischarger",
                column: "MillKey1");

            migrationBuilder.CreateIndex(
                name: "IX_MillCodischarger_MillKey2",
                table: "MillCodischarger",
                column: "MillKey2");

            migrationBuilder.CreateIndex(
                name: "IX_MillInformation_FK_EPASubcatID",
                table: "MillInformation",
                column: "FK_EPASubcatID");

            migrationBuilder.CreateIndex(
                name: "IX_MillInformation_FK_MillTypeID",
                table: "MillInformation",
                column: "FK_MillTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_MillNarrative_FK_MillID",
                table: "MillNarrative",
                column: "FK_MillID");

            migrationBuilder.CreateIndex(
                name: "IX_MillParentRelationship_FK_MillID",
                table: "MillParentRelationship",
                column: "FK_MillID");

            migrationBuilder.CreateIndex(
                name: "IX_MillParentRelationship_FK_ParentCompanyID",
                table: "MillParentRelationship",
                column: "FK_ParentCompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_MillSICCodes_FK_MillKey",
                table: "MillSICCodes",
                column: "FK_MillKey");

            migrationBuilder.CreateIndex(
                name: "IX_MillSICCodes_FK_SICCodeID",
                table: "MillSICCodes",
                column: "FK_SICCodeID");

            migrationBuilder.CreateIndex(
                name: "IX_NCASIProdCat_FK_EPASubcatID",
                table: "NCASIProdCat",
                column: "FK_EPASubcatID");

            migrationBuilder.CreateIndex(
                name: "IX_NPDES_FK_MillKey",
                table: "NPDES",
                column: "FK_MillKey");

            migrationBuilder.CreateIndex(
                name: "IX_NPDESDocs_FK_DocTypeID",
                table: "NPDESDocs",
                column: "FK_DocTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_NPDESDocs_FK_NPDESID",
                table: "NPDESDocs",
                column: "FK_NPDESID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionData_FK_MillKey",
                table: "ProductionData",
                column: "FK_MillKey");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionData_FK_ProdCatID",
                table: "ProductionData",
                column: "FK_ProdCatID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionData_FK_SourceID",
                table: "ProductionData",
                column: "FK_SourceID");

            migrationBuilder.CreateIndex(
                name: "IX_Region_FK_NCASIRegionID",
                table: "Region",
                column: "FK_NCASIRegionID");

            migrationBuilder.CreateIndex(
                name: "IX_SludgeData_FK_MillKey",
                table: "SludgeData",
                column: "FK_MillKey");

            migrationBuilder.CreateIndex(
                name: "IX_SludgeData_FK_SourceID",
                table: "SludgeData",
                column: "FK_SourceID");

            migrationBuilder.CreateIndex(
                name: "IX_WaterTreatmentData_FK_FlowType",
                table: "WaterTreatmentData",
                column: "FK_FlowType");

            migrationBuilder.CreateIndex(
                name: "IX_WaterTreatmentData_FK_MillKey",
                table: "WaterTreatmentData",
                column: "FK_MillKey");

            migrationBuilder.CreateIndex(
                name: "IX_WaterTreatmentData_FK_SourceID",
                table: "WaterTreatmentData",
                column: "FK_SourceID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlowData");

            migrationBuilder.DropTable(
                name: "HistoricalMillInfo");

            migrationBuilder.DropTable(
                name: "MillCodeLinks");

            migrationBuilder.DropTable(
                name: "MillCodischarger");

            migrationBuilder.DropTable(
                name: "MillNarrative");

            migrationBuilder.DropTable(
                name: "MillParentRelationship");

            migrationBuilder.DropTable(
                name: "MillSICCodes");

            migrationBuilder.DropTable(
                name: "NPDESDocs");

            migrationBuilder.DropTable(
                name: "ProductionData");

            migrationBuilder.DropTable(
                name: "Region");

            migrationBuilder.DropTable(
                name: "SludgeData");

            migrationBuilder.DropTable(
                name: "WaterTreatmentData");

            migrationBuilder.DropTable(
                name: "ParentCompany");

            migrationBuilder.DropTable(
                name: "SICCode");

            migrationBuilder.DropTable(
                name: "NPDESDocType");

            migrationBuilder.DropTable(
                name: "NPDES");

            migrationBuilder.DropTable(
                name: "NCASIProdCat");

            migrationBuilder.DropTable(
                name: "NCASIRegion");

            migrationBuilder.DropTable(
                name: "FlowType");

            migrationBuilder.DropTable(
                name: "Source");

            migrationBuilder.DropTable(
                name: "MillInformation");

            migrationBuilder.DropTable(
                name: "EPASubcat");

            migrationBuilder.DropTable(
                name: "MillType");
        }
    }
}

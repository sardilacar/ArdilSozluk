using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ardil.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Subject = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Topics_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Entries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    TopicId = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entries_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Entries_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedDate", "Name", "NormalizedName", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("91c1fb49-864b-49ff-ad01-b77fdddfe28c"), null, new DateTime(2023, 10, 9, 18, 11, 8, 498, DateTimeKind.Utc).AddTicks(1824), "Yazar", "YAZAR", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9ed7f5dd-5015-48fb-8659-bdb96284f467"), null, new DateTime(2023, 10, 9, 18, 11, 8, 498, DateTimeKind.Utc).AddTicks(1747), "Admin", "ADMİN", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b5f9613f-9a7f-4ed3-a6d0-4c392a948412"), null, new DateTime(2023, 10, 9, 18, 11, 8, 498, DateTimeKind.Utc).AddTicks(1826), "Çaylak", "ÇAYLAK", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedDate", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleId", "SecurityStamp", "Surname", "TwoFactorEnabled", "UpdatedDate", "UserName" },
                values: new object[,]
                {
                    { new Guid("010c3422-b809-4a46-9888-984800662f1d"), 0, "2ddb134b-d18b-4ca9-951e-ca2ba11ad264", new DateTime(2023, 10, 9, 18, 11, 8, 498, DateTimeKind.Utc).AddTicks(2088), "şahinalp.koyuncu@outlook.com", false, false, null, "Şahinalp", "ŞAHİNALP.KOYUNCU@OUTLOOK.COM", "FİNCAN", null, null, false, new Guid("b5f9613f-9a7f-4ed3-a6d0-4c392a948412"), null, "Koyuncu", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "fincan" },
                    { new Guid("112dea31-e7cb-4a10-b320-280b8774bdcf"), 0, "7700bfba-11dc-4735-838a-6b5e94fd6908", new DateTime(2023, 10, 9, 18, 11, 8, 498, DateTimeKind.Utc).AddTicks(2206), "rahime.arıcan@outlook.com", false, false, null, "Rahime", "RAHİME.ARICAN@OUTLOOK.COM", "CUPRAC", null, null, false, new Guid("9ed7f5dd-5015-48fb-8659-bdb96284f467"), null, "Arıcan", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cuprac" },
                    { new Guid("131c64f8-9d2f-45a8-af06-3b915428a18a"), 0, "bf9a2921-202a-4109-b2de-b7241f719253", new DateTime(2023, 10, 9, 18, 11, 8, 498, DateTimeKind.Utc).AddTicks(2016), "admin.admin@outlook.com", false, false, null, "Admin", "ADMİN.ADMİN@OUTLOOK.COM", "ADMİN", "AQAAAAIAAYagAAAAEM6GE5EimxT5q9IZX2RLf6Xy7z1vt2OYV5gVLz6KSsCUb6C4oQkz6L1ekrdI3qm3gw==", null, false, new Guid("91c1fb49-864b-49ff-ad01-b77fdddfe28c"), null, "Admin", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin" },
                    { new Guid("2200d79c-b62d-4812-b7f1-94009b8840d9"), 0, "6f77e3c0-17ef-41a4-b0e8-b59b9cded644", new DateTime(2023, 10, 9, 18, 11, 8, 498, DateTimeKind.Utc).AddTicks(2245), "necdet.tahincioğlu@hotmail.com", false, false, null, "Necdet", "NECDET.TAHİNCİOĞLU@HOTMAİL.COM", "GOLGEBEYİ", null, null, false, new Guid("9ed7f5dd-5015-48fb-8659-bdb96284f467"), null, "Tahincioğlu", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "golgebeyi" },
                    { new Guid("2b2a4c9e-136e-4f18-8348-503c64f12768"), 0, "0d4b7b6b-90ab-4cee-9938-015035774216", new DateTime(2023, 10, 9, 18, 11, 8, 498, DateTimeKind.Utc).AddTicks(2067), "berkan.çörekçi@hotmail.com", false, false, null, "Berkan", "BERKAN.ÇÖREKÇİ@HOTMAİL.COM", "ARDİL123", null, null, false, new Guid("9ed7f5dd-5015-48fb-8659-bdb96284f467"), null, "Çörekçi", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ardil123" },
                    { new Guid("3b45bb5e-c3c4-45f1-b409-6ae7eddea969"), 0, "8c429c74-3b7e-4478-97f8-9b785f35c4c0", new DateTime(2023, 10, 9, 18, 11, 8, 498, DateTimeKind.Utc).AddTicks(2197), "serdar.okumus@gmail.com", false, false, null, "Serdar", "SERDAR.OKUMUS@GMAİL.COM", "SERDARSL 06", null, null, false, new Guid("b5f9613f-9a7f-4ed3-a6d0-4c392a948412"), null, "Okumus", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "serdarsl 06" },
                    { new Guid("4b66dda4-7087-4afc-90b3-39f3cce98919"), 0, "3acc3e98-f164-4563-ae59-12e2e8d47bfd", new DateTime(2023, 10, 9, 18, 11, 8, 498, DateTimeKind.Utc).AddTicks(2138), "öykü.kuday@outlook.com", false, false, null, "Öykü", "ÖYKÜ.KUDAY@OUTLOOK.COM", "TAİSSA FARMİGA", null, null, false, new Guid("9ed7f5dd-5015-48fb-8659-bdb96284f467"), null, "Kuday", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "taissa farmiga" },
                    { new Guid("643d903c-d6ea-4018-9960-39ae8f091b18"), 0, "488039e5-d6be-44e8-b10c-ff6537f85eca", new DateTime(2023, 10, 9, 18, 11, 8, 498, DateTimeKind.Utc).AddTicks(2106), "selçuk.erbulak@hotmail.com", false, false, null, "Selçuk", "SELÇUK.ERBULAK@HOTMAİL.COM", "KUTUP AYİSİNİN ARKADASİ", null, null, false, new Guid("9ed7f5dd-5015-48fb-8659-bdb96284f467"), null, "Erbulak", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "kutup ayisinin arkadasi" },
                    { new Guid("69f5536e-84ad-4e8c-bda4-e585c53ef75b"), 0, "94c6dd0e-7612-4234-9400-19aa6ecabdd8", new DateTime(2023, 10, 9, 18, 11, 8, 498, DateTimeKind.Utc).AddTicks(2128), "lütfi.çetiner@gmail.com", false, false, null, "Lütfi", "LÜTFİ.ÇETİNER@GMAİL.COM", "CUMHURİYET HALK PARTİSİ", null, null, false, new Guid("b5f9613f-9a7f-4ed3-a6d0-4c392a948412"), null, "Çetiner", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cumhuriyet halk partisi" },
                    { new Guid("6fa6a26e-afa2-4cb5-92fd-6abb2a4a2dc1"), 0, "67e74b48-a863-46f6-8ec3-6b838be1f61f", new DateTime(2023, 10, 9, 18, 11, 8, 498, DateTimeKind.Utc).AddTicks(2077), "lütfi.erez@gmail.com", false, false, null, "Lütfi", "LÜTFİ.EREZ@GMAİL.COM", "WHATYOUGETİSWHATYOUDİD", null, null, false, new Guid("91c1fb49-864b-49ff-ad01-b77fdddfe28c"), null, "Erez", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "whatyougetiswhatyoudid" },
                    { new Guid("74b8f6f8-2487-4f15-a096-5a86d34923fb"), 0, "8ee5b071-a257-4795-873c-b6124cb67416", new DateTime(2023, 10, 9, 18, 11, 8, 498, DateTimeKind.Utc).AddTicks(2056), "ender.özkara@gmail.com", false, false, null, "Ender", "ENDER.ÖZKARA@GMAİL.COM", "NOOTROPİL", null, null, false, new Guid("b5f9613f-9a7f-4ed3-a6d0-4c392a948412"), null, "Özkara", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "nootropil" },
                    { new Guid("9096c647-0cf1-4cd8-abe2-dd966b5cf660"), 0, "3c8807f0-ca54-4fe1-9cdd-f13da144bb74", new DateTime(2023, 10, 9, 18, 11, 8, 498, DateTimeKind.Utc).AddTicks(2047), "emre.sualp@outlook.com", false, false, null, "Emre", "EMRE.SUALP@OUTLOOK.COM", "EMRE123", "AQAAAAIAAYagAAAAED69bFd5ZGArM70UFlgUszldWnjcBEy4e2cmy6tRDg29cAqYPxOS4VF/LvGglROB4w==", null, false, new Guid("9ed7f5dd-5015-48fb-8659-bdb96284f467"), null, "Sualp", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "emre123" },
                    { new Guid("917eead8-d8ab-4cb6-8032-ce19435f419a"), 0, "38811d77-bac8-4074-b969-82c866155e00", new DateTime(2023, 10, 9, 18, 11, 8, 498, DateTimeKind.Utc).AddTicks(2118), "zekeriya.karabulut@hotmail.com", false, false, null, "Zekeriya", "ZEKERİYA.KARABULUT@HOTMAİL.COM", "TOMBALAKTOBE", null, null, false, new Guid("9ed7f5dd-5015-48fb-8659-bdb96284f467"), null, "Karabulut", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "tombalaktobe" },
                    { new Guid("91ac31a2-fea4-4f32-a8a8-a881f4e191fb"), 0, "cd5d9fd5-dfc5-4398-90e8-5d11159a64da", new DateTime(2023, 10, 9, 18, 11, 8, 498, DateTimeKind.Utc).AddTicks(2254), "ışılay.orban@gmail.com", false, false, null, "Işılay", "IŞILAY.ORBAN@GMAİL.COM", "WARONE", null, null, false, new Guid("b5f9613f-9a7f-4ed3-a6d0-4c392a948412"), null, "Orban", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "warone" },
                    { new Guid("a2d224e7-2491-4acf-aad1-68ee85065a9b"), 0, "cea692c6-e53c-4744-82b1-29df4a54e065", new DateTime(2023, 10, 9, 18, 11, 8, 498, DateTimeKind.Utc).AddTicks(2235), "habil.karaduman@hotmail.com", false, false, null, "Habil", "HABİL.KARADUMAN@HOTMAİL.COM", "İNOMNİAPARATUS", null, null, false, new Guid("b5f9613f-9a7f-4ed3-a6d0-4c392a948412"), null, "Karaduman", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "inomniaparatus" },
                    { new Guid("af36a7b8-0558-4235-9569-240ce49fb6e5"), 0, "503615e6-0379-415b-9319-d4e5728496de", new DateTime(2023, 10, 9, 18, 11, 8, 498, DateTimeKind.Utc).AddTicks(2214), "günay.egeli@gmail.com", false, false, null, "Günay", "GÜNAY.EGELİ@GMAİL.COM", "VİDANJORGİLLERDEN", null, null, false, new Guid("b5f9613f-9a7f-4ed3-a6d0-4c392a948412"), null, "Egeli", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "vidanjorgillerden" },
                    { new Guid("b2faa273-bce7-4851-94c2-34bb6a3aea71"), 0, "1b73373e-5e97-47c5-9c0c-1e178d994f32", new DateTime(2023, 10, 9, 18, 11, 8, 498, DateTimeKind.Utc).AddTicks(2033), "sevtap.alpuğan@hotmail.com", false, false, null, "Sevtap", "SEVTAP.ALPUĞAN@HOTMAİL.COM", "GOK YELELİ BOZKURTUN AVUKATİ", "AQAAAAIAAYagAAAAELpS+DOdmmJfscDiB1V822NIY5gorLWlEy3ZzodeyaJOu6Mq0sTn7XuVFAH3sx1Cgw==", null, false, new Guid("9ed7f5dd-5015-48fb-8659-bdb96284f467"), null, "Alpuğan", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "gok yeleli bozkurtun avukati" },
                    { new Guid("cc5964b5-e989-4bdc-8d9a-b26d910153ed"), 0, "d53d5cc3-1ebd-4d14-81a2-e24dcbc8e12f", new DateTime(2023, 10, 9, 18, 11, 8, 498, DateTimeKind.Utc).AddTicks(2174), "haşim.özdenak@hotmail.com", false, false, null, "Haşim", "HAŞİM.ÖZDENAK@HOTMAİL.COM", "SİMGESELKEDİ", null, null, false, new Guid("91c1fb49-864b-49ff-ad01-b77fdddfe28c"), null, "Özdenak", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "simgeselkedi" },
                    { new Guid("d1138261-333e-4e62-9d6f-a03a68fa740a"), 0, "f10dcbb3-ce84-4a80-9bce-5db22e6ad43d", new DateTime(2023, 10, 9, 18, 11, 8, 498, DateTimeKind.Utc).AddTicks(2224), "talib.kaplangı@hotmail.com", false, false, null, "Talib", "TALİB.KAPLANGI@HOTMAİL.COM", "İ AM COOKİE MONSTERS NİPPLE", null, null, false, new Guid("b5f9613f-9a7f-4ed3-a6d0-4c392a948412"), null, "Kaplangı", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "i am cookie monsters nipple" },
                    { new Guid("d40c554e-261e-450f-b52d-97066a7bc649"), 0, "12e26142-e33e-481b-8fc8-5967f0a21159", new DateTime(2023, 10, 9, 18, 11, 8, 498, DateTimeKind.Utc).AddTicks(2098), "rengin.yalçın@gmail.com", false, false, null, "Rengin", "RENGİN.YALÇIN@GMAİL.COM", "KMC", null, null, false, new Guid("91c1fb49-864b-49ff-ad01-b77fdddfe28c"), null, "Yalçın", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "kmc" },
                    { new Guid("e695a304-c426-47bd-9a9d-7abdc17758d7"), 0, "a81c1981-5b08-40aa-8d37-4257e8670f14", new DateTime(2023, 10, 9, 18, 11, 8, 498, DateTimeKind.Utc).AddTicks(2185), "alparslan.ağaoğlu@hotmail.com", false, false, null, "Alparslan", "ALPARSLAN.AĞAOĞLU@HOTMAİL.COM", "ORTALAMA İNSAN DUSUNCESİNE SAHİP İNSAN", null, null, false, new Guid("9ed7f5dd-5015-48fb-8659-bdb96284f467"), null, "Ağaoğlu", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ortalama insan dusuncesine sahip insan" },
                    { new Guid("fb1c316c-2692-4e05-9394-4bc0263b7aa1"), 0, "ce19ca5e-f4da-4e70-968e-df4264b51b2d", new DateTime(2023, 10, 9, 18, 11, 8, 498, DateTimeKind.Utc).AddTicks(2262), "lerzan.özbir@gmail.com", false, false, null, "Lerzan", "LERZAN.ÖZBİR@GMAİL.COM", "COLİFACT", null, null, false, new Guid("b5f9613f-9a7f-4ed3-a6d0-4c392a948412"), null, "Özbir", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "colifact" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId", "Discriminator" },
                values: new object[,]
                {
                    { new Guid("b5f9613f-9a7f-4ed3-a6d0-4c392a948412"), new Guid("010c3422-b809-4a46-9888-984800662f1d"), "AppUserRole" },
                    { new Guid("9ed7f5dd-5015-48fb-8659-bdb96284f467"), new Guid("112dea31-e7cb-4a10-b320-280b8774bdcf"), "AppUserRole" },
                    { new Guid("91c1fb49-864b-49ff-ad01-b77fdddfe28c"), new Guid("131c64f8-9d2f-45a8-af06-3b915428a18a"), "AppUserRole" },
                    { new Guid("9ed7f5dd-5015-48fb-8659-bdb96284f467"), new Guid("2200d79c-b62d-4812-b7f1-94009b8840d9"), "AppUserRole" },
                    { new Guid("9ed7f5dd-5015-48fb-8659-bdb96284f467"), new Guid("2b2a4c9e-136e-4f18-8348-503c64f12768"), "AppUserRole" },
                    { new Guid("b5f9613f-9a7f-4ed3-a6d0-4c392a948412"), new Guid("3b45bb5e-c3c4-45f1-b409-6ae7eddea969"), "AppUserRole" },
                    { new Guid("9ed7f5dd-5015-48fb-8659-bdb96284f467"), new Guid("4b66dda4-7087-4afc-90b3-39f3cce98919"), "AppUserRole" },
                    { new Guid("9ed7f5dd-5015-48fb-8659-bdb96284f467"), new Guid("643d903c-d6ea-4018-9960-39ae8f091b18"), "AppUserRole" },
                    { new Guid("b5f9613f-9a7f-4ed3-a6d0-4c392a948412"), new Guid("69f5536e-84ad-4e8c-bda4-e585c53ef75b"), "AppUserRole" },
                    { new Guid("91c1fb49-864b-49ff-ad01-b77fdddfe28c"), new Guid("6fa6a26e-afa2-4cb5-92fd-6abb2a4a2dc1"), "AppUserRole" },
                    { new Guid("b5f9613f-9a7f-4ed3-a6d0-4c392a948412"), new Guid("74b8f6f8-2487-4f15-a096-5a86d34923fb"), "AppUserRole" },
                    { new Guid("9ed7f5dd-5015-48fb-8659-bdb96284f467"), new Guid("9096c647-0cf1-4cd8-abe2-dd966b5cf660"), "AppUserRole" },
                    { new Guid("9ed7f5dd-5015-48fb-8659-bdb96284f467"), new Guid("917eead8-d8ab-4cb6-8032-ce19435f419a"), "AppUserRole" },
                    { new Guid("b5f9613f-9a7f-4ed3-a6d0-4c392a948412"), new Guid("91ac31a2-fea4-4f32-a8a8-a881f4e191fb"), "AppUserRole" },
                    { new Guid("b5f9613f-9a7f-4ed3-a6d0-4c392a948412"), new Guid("a2d224e7-2491-4acf-aad1-68ee85065a9b"), "AppUserRole" },
                    { new Guid("b5f9613f-9a7f-4ed3-a6d0-4c392a948412"), new Guid("af36a7b8-0558-4235-9569-240ce49fb6e5"), "AppUserRole" },
                    { new Guid("9ed7f5dd-5015-48fb-8659-bdb96284f467"), new Guid("b2faa273-bce7-4851-94c2-34bb6a3aea71"), "AppUserRole" },
                    { new Guid("91c1fb49-864b-49ff-ad01-b77fdddfe28c"), new Guid("cc5964b5-e989-4bdc-8d9a-b26d910153ed"), "AppUserRole" },
                    { new Guid("b5f9613f-9a7f-4ed3-a6d0-4c392a948412"), new Guid("d1138261-333e-4e62-9d6f-a03a68fa740a"), "AppUserRole" },
                    { new Guid("91c1fb49-864b-49ff-ad01-b77fdddfe28c"), new Guid("d40c554e-261e-450f-b52d-97066a7bc649"), "AppUserRole" },
                    { new Guid("9ed7f5dd-5015-48fb-8659-bdb96284f467"), new Guid("e695a304-c426-47bd-9a9d-7abdc17758d7"), "AppUserRole" },
                    { new Guid("b5f9613f-9a7f-4ed3-a6d0-4c392a948412"), new Guid("fb1c316c-2692-4e05-9394-4bc0263b7aa1"), "AppUserRole" }
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "CreatedDate", "Subject", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("08d43dcd-4e9e-41be-8446-d2280f6d5054"), new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2025), "türk solunun en iyi yaptığı şey", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e695a304-c426-47bd-9a9d-7abdc17758d7") },
                    { new Guid("2b8a91a2-8a25-40fc-a24f-a647434e8092"), new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2016), "ingilizce rusça arapça bilmek", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("cc5964b5-e989-4bdc-8d9a-b26d910153ed") },
                    { new Guid("2e38f249-1862-4d42-968c-a263ec68e732"), new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2031), "anın fotoğrafı", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4b66dda4-7087-4afc-90b3-39f3cce98919") },
                    { new Guid("312545b9-3012-4864-9519-1d2ffea23202"), new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2042), "naber dergi", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2200d79c-b62d-4812-b7f1-94009b8840d9") },
                    { new Guid("3b9a544e-d93f-44bc-ba30-3f531d4b0b92"), new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2029), "ülkemde yahudi mülteci istemiyorum", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("9096c647-0cf1-4cd8-abe2-dd966b5cf660") },
                    { new Guid("3d893ea5-346e-4cbd-8243-71d9d6d29993"), new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2030), "akif emin soyyiğit", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("112dea31-e7cb-4a10-b320-280b8774bdcf") },
                    { new Guid("4288ae57-8f64-402c-9613-21701dde2156"), new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2039), "kutsal motor", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("917eead8-d8ab-4cb6-8032-ce19435f419a") },
                    { new Guid("4d61b4da-08c2-480e-a17b-d4d765e746de"), new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2036), "zamanın çok hızlı geçmesi", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("643d903c-d6ea-4018-9960-39ae8f091b18") },
                    { new Guid("5494819c-8c2f-4da2-b151-b8954c07b60d"), new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2024), "bir kadının erkeğe yürümesi", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("112dea31-e7cb-4a10-b320-280b8774bdcf") },
                    { new Guid("748a78e3-0c21-4336-a892-2b0bd363240c"), new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2031), "mahmut orhan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e695a304-c426-47bd-9a9d-7abdc17758d7") },
                    { new Guid("76d5968c-10a7-4941-a69b-b94a358eeffb"), new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2021), "gent vs brudge", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("643d903c-d6ea-4018-9960-39ae8f091b18") },
                    { new Guid("7f9d5990-6ff1-46e8-aaa8-8b0603d34264"), new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2028), "ekşi sözlük dertleşecek insan veritabanı", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6fa6a26e-afa2-4cb5-92fd-6abb2a4a2dc1") },
                    { new Guid("80558e80-efb3-4b5c-a3d3-24ccf421ed9c"), new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2038), "dijital vergi dairesi", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("643d903c-d6ea-4018-9960-39ae8f091b18") },
                    { new Guid("8488e808-35f7-4b37-a733-f09eccc7d5dd"), new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2023), "hesabı erkek öder bu bir görgü kuralıdır", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("643d903c-d6ea-4018-9960-39ae8f091b18") },
                    { new Guid("8691928a-935c-4e75-8a2e-79b71d6defb3"), new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2035), "aylık geliri 100 bin lira olan biri çalışmalı mı", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("917eead8-d8ab-4cb6-8032-ce19435f419a") },
                    { new Guid("ac3fa156-f91a-4c42-8b40-97ce80c73565"), new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2034), "sözlükteki filistin düşmanları", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2b2a4c9e-136e-4f18-8348-503c64f12768") },
                    { new Guid("b1b09001-8759-4d2b-9022-19a5d54a6f87"), new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2037), "viskiyle iyi giden şeyler", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("643d903c-d6ea-4018-9960-39ae8f091b18") },
                    { new Guid("d9a2c44d-ec3a-43d7-9578-034b46072de4"), new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2029), "temizliğe gelen kadına öğlen yemeği verilir mi", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b2faa273-bce7-4851-94c2-34bb6a3aea71") },
                    { new Guid("e91e29a2-ca44-46dd-a014-6754fea03755"), new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2032), "israil-filistin savaşı", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6fa6a26e-afa2-4cb5-92fd-6abb2a4a2dc1") },
                    { new Guid("ee8f9347-7c61-4601-9157-7eecda85ed74"), new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2022), "gece 02.30'a mr randevusu vermek", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6fa6a26e-afa2-4cb5-92fd-6abb2a4a2dc1") },
                    { new Guid("ef1270f7-eab7-4c9e-af26-1b7bdcb6f91c"), new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2023), "ekşi itiraf", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2200d79c-b62d-4812-b7f1-94009b8840d9") },
                    { new Guid("f6108647-b547-4723-9369-ea4e544e17d8"), new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2036), "gömercin kuşları", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6fa6a26e-afa2-4cb5-92fd-6abb2a4a2dc1") },
                    { new Guid("f7c9649d-890c-4abb-86b3-5728aef3895f"), new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2039), "temizlik yaparken gelen iç hesaplaşma yapma isteği", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e695a304-c426-47bd-9a9d-7abdc17758d7") },
                    { new Guid("fb6e8b92-64b3-4532-a20e-2c634ecc89e5"), new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2027), "9 ekim 2023 israilin topyekün savaşı", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("112dea31-e7cb-4a10-b320-280b8774bdcf") }
                });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "Content", "CreatedDate", "Status", "TopicId", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("00eb1469-2878-44b4-b24c-6e3898f9d8e2"), "ulan izmire de gelin ya, gerçi anders olmadan tadı olmaz da neyse.\r\n", new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2166), false, new Guid("5494819c-8c2f-4da2-b151-b8954c07b60d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d40c554e-261e-450f-b52d-97066a7bc649") },
                    { new Guid("014c9ba6-efde-48fa-911f-6becdcde45fe"), "1 hafta her iki şehir için de çok uzun bir süre. ayrı ayrı her ikisi de gezilecekse tamam fakat 1 haftanın tamamı yalnızca bir tanesine ayrılacaksa yazık olur. zaten hem çok küçük hem de birbirlerine çok yakın şehirler.\r\n\r\nama illa birinden birini tercih edeyim derseniz ben olsam brugge'ü seçerdim. güzelliğinin brüksel'le veya gent'le kıyaslanabileceğini dahi sanmıyorum.\r\n", new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2148), false, new Guid("b1b09001-8759-4d2b-9022-19a5d54a6f87"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("112dea31-e7cb-4a10-b320-280b8774bdcf") },
                    { new Guid("01850b1b-968c-4cda-8d19-b4fa7aa67266"), "ne oldu da bütün gruplar türkiye'ye gelmeye başladı\r\n", new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2165), false, new Guid("f7c9649d-890c-4abb-86b3-5728aef3895f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6fa6a26e-afa2-4cb5-92fd-6abb2a4a2dc1") },
                    { new Guid("081cd40b-0ce3-474e-ae56-2aa96504d87a"), "eğer saat üzerinde wifi'yi kapatırsanız şarjı bir gün ekstra fazla gidebiliyor. zaten telefonunuza bluetooth ile bağlandığı için de tam randımanlı kullanabilirsiniz bu şekilde de.\r\n", new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2147), false, new Guid("e91e29a2-ca44-46dd-a014-6754fea03755"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d40c554e-261e-450f-b52d-97066a7bc649") },
                    { new Guid("288b633f-2172-4eb1-ab42-78ecfb20a6d8"), "bunu anlayamiyorum, adamin 32 suc kaydi varsa neden hala disarda dolasabiliyor? el bebek gul bebek buyuttugumuz cocuklarin hayatlarini alabiliyor?\r\n", new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2171), false, new Guid("08d43dcd-4e9e-41be-8446-d2280f6d5054"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2200d79c-b62d-4812-b7f1-94009b8840d9") },
                    { new Guid("37eab918-7686-4f98-ba79-03602f618acc"), "\" halk olarak filistin'in yanında olduk \"\r\n\r\nolmamışsın. bak burada entry giriyorsun. o halk dediğin hangi halk bilmiyorum ama, boş boş gevezelik yapacağına al halkını, gidin filistin'i savunun.", new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2144), false, new Guid("d9a2c44d-ec3a-43d7-9578-034b46072de4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("74b8f6f8-2487-4f15-a096-5a86d34923fb") },
                    { new Guid("3da40254-0701-484c-96c2-313ef7f8c9b1"), "donmuş gıdaları :) diğer markalara göre gayet uygun tadı da güzel\r\n", new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2182), false, new Guid("312545b9-3012-4864-9519-1d2ffea23202"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("74b8f6f8-2487-4f15-a096-5a86d34923fb") },
                    { new Guid("3f61dc8d-614e-4eb0-bfa4-b2c5204469c0"), "dost markalı bütün ürünler. diğer markalara göre en sevdiğim o :)\r\n", new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2181), false, new Guid("ee8f9347-7c61-4601-9157-7eecda85ed74"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b2faa273-bce7-4851-94c2-34bb6a3aea71") },
                    { new Guid("3fd7ce90-425d-4a63-9a9e-5b73972ce1a3"), "bu cinayetin sorumlusu o suçluyu dışarı salan, dışarıda tutan kişilerdir. bu salma hastalığı cinayet gibi ciddi sonuçlara yol açıyor ama kimin umrunda. bu olay da birkaç saat konuşulup unutulacak, serbest bırakma hastalığı devam edecek.\r\n", new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2179), false, new Guid("312545b9-3012-4864-9519-1d2ffea23202"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2b2a4c9e-136e-4f18-8348-503c64f12768") },
                    { new Guid("406d6089-c1f1-47d8-8cd3-527675c61209"), "arkasında sağlam huzursuzluk olduğunu düşündüğüm karar.\r\n\r\nadam devletin yapamadığı şeyleri yaptı yangında, ünlüler aradı, parasal destek verdi. bizim iktidar parayı başkasının yönetmesinden hoşlanmaz. isterler ki 10 lira bağış gelsin. 8'ini yiyip kalan 2 lirasını kendilerine biat edenlere dağıtsınlar.", new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2140), false, new Guid("2e38f249-1862-4d42-968c-a263ec68e732"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("131c64f8-9d2f-45a8-af06-3b915428a18a") },
                    { new Guid("43e2437a-1043-4242-acb6-8696867f794b"), "arap saksocularının her daim hayali olmuş, ancak ortamı tamamen ele geçirince dillendirmeye cesaret edebildikleri cümle.\r\n\r\nayrıca burada ağlayan, atarlanan ekşicilere bakmayın. kurusıkı tabanca gibi bam bam ötüyorsunuz; herifler 20 küsür senedir \"atı alıp üsküdarı geçiyor\" göt gibi bakıyorsunuz. sizin gibi boş heriflerle o kadar çok muhatap oldum ki ben artık ümidi kestim.\r\n\r\nokuyup \"aa bak hala direnen, cumhuriyet aşığı gençler var ümidim var\" diyecekler de fazla ümitlenmesinler. böyle yarak kürek atarlanmak dışında 20 senedir başka faaliyet göstermeyen, klasik gazoz türk gençliğinden bir cacık olmaz.", new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2161), false, new Guid("b1b09001-8759-4d2b-9022-19a5d54a6f87"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2b2a4c9e-136e-4f18-8348-503c64f12768") },
                    { new Guid("484b531e-f354-4e9a-b02f-14ddfe02c62e"), "sözcü tv röportajında kenan komutandan bahsetmesi enteresan,anlaşılan böyle saçma sapan işleri ve sosyal medya jargonunu zaman zaman takip etmekte,ama hoşuma gitti,tebessüm ettirdi:)", new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2195), false, new Guid("8691928a-935c-4e75-8a2e-79b71d6defb3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b2faa273-bce7-4851-94c2-34bb6a3aea71") },
                    { new Guid("4a29d720-11e2-4202-9839-c27fe0227c30"), "istemek serbest. içinden dilediğin kadar iste. ama atatürkçü gençlik olduğu sürece laiklik de baki olacaktır.", new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2155), false, new Guid("b1b09001-8759-4d2b-9022-19a5d54a6f87"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fb1c316c-2692-4e05-9394-4bc0263b7aa1") },
                    { new Guid("4c5dcb14-d8e1-4890-9ef5-7f4081d4be16"), "niye etkisiz hale getirmemişler ki.\r\nkeşke tamamen etkisiz olsaymış aq evladı.\r\n", new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2176), false, new Guid("8691928a-935c-4e75-8a2e-79b71d6defb3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e695a304-c426-47bd-9a9d-7abdc17758d7") },
                    { new Guid("4cc5d28a-3fe9-48dc-9ff7-9c8a5b26a5ff"), "güzel. biz zaten biliyorduk \"özgürlükçü\" adı altında istediğiniz anayasayla neyi amaçladığınızı, o güruhtan iyi ya da kötü adı bilinen biri tarafından da teyit edilmiş oldu.\r\n\r\naçık sözlülüğünü tebrik ediyorum arkadaşın. dostumuz düşmanımız netleşsin iyice.", new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2159), false, new Guid("fb6e8b92-64b3-4532-a20e-2c634ecc89e5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d40c554e-261e-450f-b52d-97066a7bc649") },
                    { new Guid("54f501d5-8b2e-496e-b689-91f6d806e37b"), "ne zamandır içimden geçiyordu, süper oldu. konserin ayakta olması da çok iyi. oturarak metal konseri olmuyor.", new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2170), false, new Guid("76d5968c-10a7-4941-a69b-b94a358eeffb"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3b45bb5e-c3c4-45f1-b409-6ae7eddea969") },
                    { new Guid("5781a515-e8b7-4609-964d-6f5306dc1231"), "ahmet nur çebi maçası yetiyosa istediği tv'de karşıma çıksın demiş.\r\nlink\r\ndön başkan dön artık, özledik.", new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2196), false, new Guid("f7c9649d-890c-4abb-86b3-5728aef3895f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d40c554e-261e-450f-b52d-97066a7bc649") },
                    { new Guid("5d14f09d-4d80-42bf-b929-d8b29dc4378d"), "akit gazetesi yazarı ali karahasanoğlu tarafından, hodri meydan minvalinde yazılan köşe yazısının anafikri ve başlığıdır..\r\n\r\nbunlar iyice cüretkâr hâle geldiler.\r\n\r\nirticanın, bölücü terörden bile daha amansız ve sinsi bir düşman olduğunu ve bu ülkeyi korkunç bir felakete sürükleyebileceği gerçeğini her gün biraz daha yaşayarak müşahede ediyoruz.\r\n\r\ndini esaslara göre yönetilen ortadoğu ülkelerinde cehalet, yobazlık, kan ve gözyaşı durmuyorken ve suudi arabistan bile modernleşme yolunda ıslahatlar yapma arefesinde iken, şu arapperest tayfanın derdine bakın hele !\r\n\r\nbu ülke, şu anda görece olarak ortadoğu ülkelerinden daha müreffeh, güçlü ve modern bir ülke ise, bunun için yiyin için ve ebedi lider mustafa kemal atatürk'e dua edin. yoksa afganistan'dan farkımız kalmazdı. bombalı eylemler, iç savaş manzaraları, tecavüz ve terör eksik olmazdı.\r\n\r\n--- spoiler ---\r\n\r\nevet laikliği değiştirmek istiyoruz, var mı diyeceğiniz?\r\n\r\n“darbecilerin yaptığı anayasa, türkiye’ye yakışmıyor, değiştirelim” denildiğinde chp susuyor, iyi parti konuşuyor, iyi parti susuyor baro başkanları konuşuyor, baro başkanları susuyor anayasa hukuku profesörü olduğunu iddia eden darbeseverler konuşmaya başlıyor..\r\n\r\nhemen hepsinin iddiası şu:\r\n\r\n“bugünkü mevcut millet meclisi’nin anayasayı değiştirme yetkisi yoktur.”\r\n\r\nbuna ilaveten şunu da öne sürüyorlar:\r\n\r\n“darbe anayasasının değişmeyen maddesi mi kaldı ki?”\r\n\r\nson olarak saadet partisi genel başkanı temel karamollaoğlu bile tartışmaya katıldı.\r\n\r\no da, anayasanın, yapılan değişikliklerle yamalı bohçaya döndüğünü, artık anayasayı değiştirmeye gerek kalmadığını söyledi.\r\n\r\n“yamalı bohça” olduğunu kendileri söylüyor ama, yenisinin sıfırdan yazılmasını da istemiyorlar..\r\n\r\nyani “yamalı bohça, yenisinden iyidir” diyorlar..\r\n\r\nonlarca yaması olan bir pantolonu, yamasız bir pantolona tercih ediyorlar..\r\n\r\nyok yok “israf olmasın” diye değil, “yeni bir pantolon almaya paramız olmadığı için” değil, darbecilerin anayasasının, bir madde ile de olsa, yürürlükte olması için.\r\n\r\nyoksa yeni pantolon almak için, yani yeni anayasa için para harcamayacağız ki, milletvekilleri zaten maaşlarını alıyorlar..\r\n\r\nsadece kanunları yapsalar da aynı maaşı alacaklar, birkaç saat daha fazla çalışıp anayasayı da değiştirmiş olsalar aynı maaşı alacaklar.\r\n\r\nne yani “anayasayı değiştirdiler” diye, milletvekillerine “fazla çalışma parası” mı vereceğiz?\r\n\r\nanayasayı değiştirme girişimi, geliyor geliyor, “sizin derdiniz, darbecilerin anayasasını değiştirmek değil, laikliği değiştirmek” noktasında tıkanıyor..\r\n\r\niki yüze yakın maddesi olan anayasayı değiştirmek istiyorsunuz, adamların gözü hiçbir şey görmüyor, laikliğe takılıp kalıyorlar.\r\n\r\no zaman muhataplarımızı da rahatlatalım, biz de rahatlayalım..\r\n\r\nhodri meydan diyelim..\r\n\r\nmeclis yeni anayasayı yapar, halk da onaylarsa..\r\n\r\nbu şartla laikliği de değiştirelim..\r\n\r\nvar mısınız?\r\n\r\nyok öyle, “atatürk, halka şöyle önem verdi, böyle önem verdi” deyip…\r\n\r\n“atatürk saltanatı kaldırarak, yönetimi bir ailenin elinden alıp halka verdi” deyip..\r\n\r\n“demokrasi halk yönetimidir” deyip..\r\n\r\nsonra halkoyuna sunulacak bir anayasa değişikliğine, “olmaz, olamaz.. nayır! asla ve kata değiştirilemez, değiştirilmesi teklif dahi edilemez” demek..\r\n\r\nlaikliği yeniden yazalım..\r\n\r\nbiliyorum, kemalistler bu ifademi okuyunca, hop oturup, hop kalkacaklar.\r\n\r\nçok heyecanlanmasınlar, biraz sakin olsunlar.\r\n\r\n“laikliği değiştirelim, anayasayı yeniden düzenleyelim” dediysem, şunu önermedim:\r\n\r\n“türkiye cumhuriyeti vatandaşlarının tamamı, isteseler de istemeseler de müslüman’dırlar. beş vakit namaz kılmak zorundadırlar, kadınlar başlarını örtmek zorundadır.”\r\n\r\nböyle bir şey söyleyen yok, isteyen de yok.\r\n\r\ninancımızda temel ilke şudur: “dinde zorlama yoktur.”\r\n\r\nbu çerçevede “laikliği anayasada tekrar düzenleyelim” derken şunu öneriyoruz:\r\n\r\nhani bize laikliği özgürlük olarak öğretiyordunuz ya..\r\n\r\nşimdi, laikliği öyle tanımlayarak anayasaya koyalım.\r\n\r\n“laiklik özgürlüktür” diyelim.\r\n\r\n“laiklik, kimsenin inancına, kıyafetine, ibadetine, ibadetsizliğine karışmamaktır” diyerek laikliğin tanımına devam edelim.\r\n\r\nhodri meydan!\r\n\r\n“anayasanın değişmeyen sadece dört maddesi kaldı. bunların derdi de, darbe anayasasını değiştirmek değil, dört maddeyi değiştirmek” diyerek, laikliği korumak istediklerini söyleyenlere hodri meydan!\r\n\r\nlaikliği, özgürlük şeklinde tanımlayan sizsiniz.\r\n\r\nseçim öncesinde “laiklik özgürlüktür” diye tanımlarsınız ama seçim sonrasında, “dini semboller kamuda kullanılamaz. laiklik gereği başörtü yasaktır” diye yan çizersiniz.\r\n\r\nyan çizmemeniz için, anayasada laikliğin tam tanımını yapalım.\r\n\r\nkimsenin inancına da, ibadetine de karışılamayacağını yazalım.\r\n\r\nböylece dindarlar da rahat etsin dinsizler de rahat etsin.\r\n\r\nkemalistlerin yeni anayasa konusunda bu kadar açık bir şekilde riyakarlık yaptıkları ortadayken, saadet partisi’nin de onların dümen suyuna girip “anayasa zaten yamalı bohça, neyini değiştireceksiniz” açıklaması yapmaları, yarın bir iktidar değişikliğinde, yeniden hortlatılacak 28 şubat‘ın vebalini de, onların üzerine yıkacaktır.\r\n\r\n“tbmm, cumhurbaşkanlığı sisteminde bypass ediliyor” söyleminin peşinde koşanların, son günlerde aynı tbmm’ye, anayasayı değiştirme konusunda “yetkisi yok” eleştirisi getirmeleri, “halktan yetki almadılar” mavalı ile tbmm’yi bypass etme girişimleri de ayrı bir handikaptır.\r\n\r\nvarsın onlar, darbecilerin anayasasına razı olsunlar..\r\n\r\nmilletin seçtikleri, milletin anayasasını bir an önce yapıp, yürürlüğe koysunlar!\r\n\r\ngerekiyorsa laiklik ile ilgili maddeyi de değiştirsinler, en azından laikliğin tanımını yapıp, yanlış yorumlanmasını da önlesinler.\r\n\r\n--- spoiler ---\r\n\r\nkaynak burada", new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2154), false, new Guid("4288ae57-8f64-402c-9613-21701dde2156"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3b45bb5e-c3c4-45f1-b409-6ae7eddea969") },
                    { new Guid("61db8f8b-d54c-4b8a-a3a3-bcb8614116d0"), "hayırlı forumlar. az turist olsun kafa dinleyim ama en az brugge kadar güzel olsun deniliyorsa gent. çok turist çok sosyalleşme daha fazla hareket deniliyorsa brugge.", new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2153), false, new Guid("2b8a91a2-8a25-40fc-a24f-a647434e8092"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("010c3422-b809-4a46-9888-984800662f1d") },
                    { new Guid("638bf927-ee8b-4d32-bccc-341f56e533ed"), "allah rahmet eylesin. kaybedecek bir şeyi olmayan kişilerle çatışmaya giriyorlar. sonrası bir kör kurşunla hayata gözlerini yumuyorlar. çok üzücü ne diyelim başka.\r\n", new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2177), false, new Guid("fb6e8b92-64b3-4532-a20e-2c634ecc89e5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("69f5536e-84ad-4e8c-bda4-e585c53ef75b") },
                    { new Guid("6842728c-7ff6-4bec-8019-418f1ce74bc7"), "malum partiyi 20 küsür senedir iktidarda tutmak.\r\n\r\nbakın şu ekonomik buhranda, ülkedeki milyonlarca başıboş mültecinin olduğu durumda, alım gücünün eksilere indiği halde bile bu adamlardan yönetimi alamamak için bildiğin ho sığırı olmak gerekli. seçim zamanı mecburen oy verdik lakin benden üçün birini alırlar, ilk seçimde malum partiye oy atacam sizi daha harder faster ziksin diye.", new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2192), false, new Guid("748a78e3-0c21-4336-a892-2b0bd363240c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a2d224e7-2491-4acf-aad1-68ee85065a9b") },
                    { new Guid("699a9d55-d62e-4043-9b56-7fe0b4744144"), "muazzam haber! sürpriz oldu. görsel\r\ngelmelerine neden olan entry: (bkz: #152545673)", new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2169), false, new Guid("3b9a544e-d93f-44bc-ba30-3f531d4b0b92"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("643d903c-d6ea-4018-9960-39ae8f091b18") },
                    { new Guid("6ba4ae88-5078-46dc-bacb-c11ffef077c2"), "kadıköy rıhtımda halay çekmek\r\n", new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2188), false, new Guid("8488e808-35f7-4b37-a733-f09eccc7d5dd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("643d903c-d6ea-4018-9960-39ae8f091b18") },
                    { new Guid("6d11546d-38ea-4a50-8479-2f16cf3315c4"), "iki seçenekli sorularda her zaman yanlış seçeneği işaretlemek\r\n", new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2190), false, new Guid("d9a2c44d-ec3a-43d7-9578-034b46072de4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d40c554e-261e-450f-b52d-97066a7bc649") },
                    { new Guid("6ea7371d-1fc0-44ad-afaa-754c15bc3d74"), "daha önce hiç görmediğimiz adi suçluların polis ve jandarma şehit etmesi hızla tırmanıyor. bu son 4 ayda 4. vaka sanırım, yanlış hatırlamıyorsam...\r\n\r\nbu tipler 32 sabıka ve tabancayla geziyorlar, polisi şehit edene kadar da hala içimizde yaşıyorlardı. onun için siz de bireysel silahlanmayı destekleyin.", new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2178), false, new Guid("312545b9-3012-4864-9519-1d2ffea23202"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6fa6a26e-afa2-4cb5-92fd-6abb2a4a2dc1") },
                    { new Guid("70b10c5a-f288-4b01-8b36-beab1eb132cd"), "röportajından anladığım kadarıyla aday olmayacak fakat tevfik yamantürk'e ve hasan arat'a açık destek attı.", new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2194), false, new Guid("312545b9-3012-4864-9519-1d2ffea23202"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3b45bb5e-c3c4-45f1-b409-6ae7eddea969") },
                    { new Guid("7116baa1-cee3-4229-a49f-73b68d324c70"), "teatone ice tea şeftali 1 lt. bu lezzeti seveceksiniz !\r\ntükenmeden alın.\r\ne hadi !", new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2181), false, new Guid("fb6e8b92-64b3-4532-a20e-2c634ecc89e5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("af36a7b8-0558-4235-9569-240ce49fb6e5") },
                    { new Guid("753809dd-2d68-449a-960c-813504e38954"), "muhtemelen son filistin-israil çekişmesi hasebiyle 22 ekimdeki konserini ertelemiş müzik grubu.\r\n", new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2185), false, new Guid("3b9a544e-d93f-44bc-ba30-3f531d4b0b92"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("69f5536e-84ad-4e8c-bda4-e585c53ef75b") },
                    { new Guid("7b1e4b4f-eb5a-4166-bcd1-eaef09eadd58"), "suçları arasında tweet atmak olmadığı için dışarıda gezebilen katil tarafından gerçekleştirilen cinayet.\r\n", new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2174), false, new Guid("e91e29a2-ca44-46dd-a014-6754fea03755"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("af36a7b8-0558-4235-9569-240ce49fb6e5") },
                    { new Guid("83ce4d86-5970-43c6-a93d-b23fb160cf24"), "uzun zamandır çok sevdiğim bir müzisyenin/grubun konserine gidemiyorum. sebep olarak ise tabii türkiye konser kıtlığı diyebiliriz. katatonia, çok sevrek takip ettiğim ama son albümlerinden ve gidişatlarından pek keyif almadığım, yine de çok sevdiğim isveç'li gothic-progressive rock/metal grubu.\r\n\r\nsanırım en son 7 ekim'de vienna konseri gerçekleşmiş. 7 ekim vienna setlist'ine bakacak olursak eski şarkılara epey yer verilmiş. bu biraz sevindirici bi görüntü.\r\n\r\nen son 23 şubat 2013 katatonia epica istanbul konserinde izlemiştim. hasret sona ersin bari.\r\n\r\nbu arada konsere beylikdüzü/avcılar/bahçeşehir taraflarından gidecek olan varsa gece geri nası dönülür falan bi haber etsin. bu taraflara yeni taşındım ve pek bilmiyorum. gece etkinliklerinde geri dönüş sıkıntı oluyor", new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2167), false, new Guid("e91e29a2-ca44-46dd-a014-6754fea03755"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d1138261-333e-4e62-9d6f-a03a68fa740a") },
                    { new Guid("83e92447-a3fb-4206-8cd9-2ff22c626cf9"), "2,5 üst", new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2152), false, new Guid("312545b9-3012-4864-9519-1d2ffea23202"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b2faa273-bce7-4851-94c2-34bb6a3aea71") },
                    { new Guid("86587545-e6e5-47fa-86f8-e80aec6fd495"), "en çok da şöyle daha küçük bebesi olan görev şehitlerine üzülüyorum.\r\n\r\nşimdi karşı tarafa gelince... daha 20 yaşında bir piçsin sen kimsin de düşmanların olacak orospunun eniği. eğer öyle bir düşman biriktirecek hayatın varsa en az müebbetlik suçların olmuştur. herkes yılmaz güney, herkes kabadayı herkes mafya aq.\r\n", new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2172), false, new Guid("fb6e8b92-64b3-4532-a20e-2c634ecc89e5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2b2a4c9e-136e-4f18-8348-503c64f12768") },
                    { new Guid("8ca9912f-f2a3-4e2d-bef1-7de3b1b72e86"), "oğlum siz çatal bıçak kullanmayı bile 21.yüzyılda öğrenmiş adamlarsınız. bir şeyleri değiştirmek size çok ağır gelir.\r\n\r\n(bkz: aynen kanzi)", new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2157), false, new Guid("2e38f249-1862-4d42-968c-a263ec68e732"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4b66dda4-7087-4afc-90b3-39f3cce98919") },
                    { new Guid("a44949a1-f7b5-4df1-baa8-31fd1ef73b26"), "müzik", new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2187), false, new Guid("d9a2c44d-ec3a-43d7-9578-034b46072de4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("69f5536e-84ad-4e8c-bda4-e585c53ef75b") },
                    { new Guid("a468800c-0eea-404b-9128-5a5cf4e60a7c"), "inanmıyorsanız da saygı duyun. haşa “sözde tanrı” falan ayıp oluyor.\r\n açılmasını beklerken, uzakta duran bu abimize \"ismail abiiii?\" diye bağırılmış, karşılığında \"huooop!\" diye cevap alınmıştır. samimiyeti, sempatikliği oyunculuğu kadar takdire şayan.", new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2138), false, new Guid("ac3fa156-f91a-4c42-8b40-97ce80c73565"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("917eead8-d8ab-4cb6-8032-ce19435f419a") },
                    { new Guid("ad3b1806-6f05-4a5a-aaf3-0e0e91d42afb"), "solcu olmadıkları bölümü hariç, her zaman yanlış karar vermeleridir. hkp var biraz o kurtarıyor solu. türkiye'de sol hkp gibi olur. gerisi amerikan emperyalizminin kendilerine tanımladığı alanda takılan sol liberaller.", new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2189), false, new Guid("8488e808-35f7-4b37-a733-f09eccc7d5dd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("917eead8-d8ab-4cb6-8032-ce19435f419a") },
                    { new Guid("ad6ff6dd-3364-4c80-b3c9-10ebbcae12ae"), "anasının amına geri sokulması gereken bir varlığın gerçekleştirdiği üzücü olay. geçenlerde şunu yazmıştım:\r\n\r\n(bkz: #156970995)\r\n\r\ncidden ne oluyor?\r\n\r\nedit: bir de bu vardı. malezya mı oluruz iran mı oluruz pakistan mı oluruz derken guatemala olma yolundayız sanki. asrın liderimiz sağolsun.\r\n\r\n(bkz: #156024789)", new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2174), false, new Guid("e91e29a2-ca44-46dd-a014-6754fea03755"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("af36a7b8-0558-4235-9569-240ce49fb6e5") },
                    { new Guid("adcf7c68-25fc-43c2-8bc1-b6362e95f603"), "geçen yıl şef bıçağı aldım (hani şu satıra benzeyen) piyasası, min:300 olan bir ürünü\r\n100 küsüre kapatmıştım. gayet de ergonomik\r\nkullanırken korkmuyorum. tefal.", new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2184), false, new Guid("5494819c-8c2f-4da2-b151-b8954c07b60d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b2faa273-bce7-4851-94c2-34bb6a3aea71") },
                    { new Guid("b454b3d1-7c9e-4315-b92a-b2b5ee800590"), "sağlamak.\r\n", new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2192), false, new Guid("2e38f249-1862-4d42-968c-a263ec68e732"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6fa6a26e-afa2-4cb5-92fd-6abb2a4a2dc1") },
                    { new Guid("b71225bf-392c-4be0-af4a-388dd2be942f"), "açıklama yapacağım diye kendi dininde ahiretliğini yakan kişi. şirk koşmuştur.\r\n\r\n’’islam'ın şartı 5, altıncısı haddini bilmek.’’\r\n\r\nkaynak: sözcü", new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2199), false, new Guid("312545b9-3012-4864-9519-1d2ffea23202"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fb1c316c-2692-4e05-9394-4bc0263b7aa1") },
                    { new Guid("b9c0dac0-a920-46eb-8950-eba9a054852a"), "kendisine saallayarak başkan olan anç'nin kulübü getirdiği hale bakarak anç' ye sallaması haksız olmayan eski beşiktaş başkanı.\r\n\r\nben doğuştan beşiktaşlıyım, çakma beşiktaşlı değilim gibi sözlerinin anç'ye gönderme olduğu düşünülürse sen şimdi çakma beşiktaşlı olduğunu düşündüğün birini 2. başkan yapıp 6.5 sene de yönetiminde tutup başkan olmasının önünü mü açtın o zaman diye de sorulması gerek ama.", new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2197), false, new Guid("3b9a544e-d93f-44bc-ba30-3f531d4b0b92"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2200d79c-b62d-4812-b7f1-94009b8840d9") },
                    { new Guid("bd07f7a1-4b5e-422e-9b68-92ce885dcb81"), "aktürk gofret\r\n\r\npaketine bakıp dandik birşey sandım, güzelmiş :)", new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2180), false, new Guid("76d5968c-10a7-4941-a69b-b94a358eeffb"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("74b8f6f8-2487-4f15-a096-5a86d34923fb") },
                    { new Guid("c0dd5254-e0a6-4bed-8484-9d68b9ea73f7"), "brugge en çok gitmek istediğim ve içimde kalan tek avrupa şehridir. bu versusta ben brugge'dan yanayım:)", new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2149), false, new Guid("2b8a91a2-8a25-40fc-a24f-a647434e8092"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a2d224e7-2491-4acf-aad1-68ee85065a9b") },
                    { new Guid("c18892d3-53e1-4aae-a3ea-549b5d309c79"), "pos bıyık bırakıp israil götü yalamak.\r\n", new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2186), false, new Guid("7f9d5990-6ff1-46e8-aaa8-8b0603d34264"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b2faa273-bce7-4851-94c2-34bb6a3aea71") },
                    { new Guid("c87f3bdd-3329-4cc5-b637-1cef3b9f4dea"), "üniversitede öğretim görevlisi olan muhammet ali çağlar da şeriat şeriat diye bi tarafını parçalıyodu, umrede taciz olayından sonra laik ve demokratik türkiye cumhuriyeti'nden yardım istemişti hatırlarsanız. bunun gibi pezevenkleri en az 6 ay süreyle ortadoğunun herhangi bir yerine bıraksak aslında türkiye daha rahat bi nefes alır\r\n", new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2158), false, new Guid("d9a2c44d-ec3a-43d7-9578-034b46072de4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("917eead8-d8ab-4cb6-8032-ce19435f419a") },
                    { new Guid("c8835f2d-57fe-44af-a68e-751baff6bbdf"), "\"suça sürüklenen çocuk\" diye bir dangalaklık çıkardılar ve infaz rejimini de buna göre düzenlediler. böyle bir saçmalık olmasaydı şehit polisimiz hayatta olacaktı...", new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2173), false, new Guid("ac3fa156-f91a-4c42-8b40-97ce80c73565"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("af36a7b8-0558-4235-9569-240ce49fb6e5") },
                    { new Guid("cd4680ef-ed9d-4edd-8aab-a03f372b12d5"), "(bkz: dolce far niente)", new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2193), false, new Guid("2b8a91a2-8a25-40fc-a24f-a647434e8092"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4b66dda4-7087-4afc-90b3-39f3cce98919") },
                    { new Guid("d34fa59c-9127-4663-8afa-034ab96108ea"), "wowowowow. alırım bi dal.\r\n", new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2164), false, new Guid("4d61b4da-08c2-480e-a17b-d4d765e746de"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("91ac31a2-fea4-4f32-a8a8-a881f4e191fb") },
                    { new Guid("d5c354f6-0c53-4f89-b2b9-8b3fba4890c0"), "(bkz: laf ebeliği)", new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2188), false, new Guid("4288ae57-8f64-402c-9613-21701dde2156"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2b2a4c9e-136e-4f18-8348-503c64f12768") },
                    { new Guid("d6a7624e-b599-4da1-8cd6-b53408f09858"), "sağı daha çok birleştirecek söylemlerde ve eylemlerde bulunmak. normal şartlar altında sağ partiler dönemin yaşananlar, herhangi bir sol parti döneminde yaşansa diyemiyorum çünkü bu yaşananların binde biri yaşansa zaten hükümet on defa düşer seçime gidilirdi vs. ama sağ tarafta bunca şeye rağmen yaprak kımıldamıyorsa bunun tek sebebi solun yaptığı seçimler, eylemler ve söylemlerdir.", new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2194), false, new Guid("e91e29a2-ca44-46dd-a014-6754fea03755"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a2d224e7-2491-4acf-aad1-68ee85065a9b") },
                    { new Guid("dce369d4-65bf-4303-ae27-0cad930452a9"), "dogrudur zira herkes baska dns ve vpn'leri kullaniyor.\r\nben misal 1 haftadir almanya'dan atiyorum.\r\nama aslinda istanbul'da ikamet etmekteyim.\r\nannemler de karadenizli.\r\n\r\noyle.", new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2139), false, new Guid("d9a2c44d-ec3a-43d7-9578-034b46072de4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6fa6a26e-afa2-4cb5-92fd-6abb2a4a2dc1") },
                    { new Guid("ddb8d9ea-f8c5-4394-991a-6d3667d787a9"), "katatonia'nın “sky void of stars tour” kapsamında 20 ocak cumartesi günü zorlu psm ana sahnede vereceği konser.\r\n\r\nbiletler çarşamba (11.10.2023) günü 11:00'den itibaren hammer müzik, passo ve biletix'te.", new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2162), false, new Guid("748a78e3-0c21-4336-a892-2b0bd363240c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3b45bb5e-c3c4-45f1-b409-6ae7eddea969") },
                    { new Guid("df37f701-2b9b-4b56-9d26-5202ab238916"), "byükçekmecede vukü bulan olay\r\n\r\nyapılan açıklamanın bir kısmını buraya bırakıyorum\r\n\r\nolay sonrası saldırıyı gerçekleştirdiği belirlenen m.b.ç. (2003 doğumlu- 32 suç kaydı var) saldırıyı gerçekleştirdiği silahla birlikte yakalanarak gözaltına alınmıştır.\r\n\r\nbu it yaşından çok suç işlemiş ama dışarda\r\n\r\nkaynak", new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2170), false, new Guid("3b9a544e-d93f-44bc-ba30-3f531d4b0b92"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a2d224e7-2491-4acf-aad1-68ee85065a9b") },
                    { new Guid("e3068892-e95e-4ce6-8416-d6b1e5ec1445"), "siktir edin klişe şehirleri. sizi, belçika’nın keşfedilmemiş cenneti (bkz: charleroi)’ya davet ediyorum. swh.", new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2150), false, new Guid("76d5968c-10a7-4941-a69b-b94a358eeffb"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("112dea31-e7cb-4a10-b320-280b8774bdcf") },
                    { new Guid("e975e26f-4779-4d1f-90e3-8debb1e548d7"), "var böyle bir durum özellikle son dönemde hortlamış durumda tek tek isimlerini yazmaya gerek yok filistinle ilgili bir başlığa girin bütün yahudiler türkiye'de toplanmış sanabilirsiniz\r\n\r\nhalk olarak her zaman filistin'in yanında olduk olmaya devam edeceğiz\r\nbiz her zaman mazlumların yanında olacağız haberiniz ola\r\npkk ne kadar hakliysa israil de o kadar hakli\r\ndünyayı zulüm çukuruna dönüştüren yahudi emperyalizmi eninde sonunda sonlanacak kapitalizmin başını cektigi insanların canlarını, mallarını sömüren onları kolelestiren bu köhne zihniyetin bitmesi çok yakın hem de her zamankinden daha yakın..", new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2141), false, new Guid("7f9d5990-6ff1-46e8-aaa8-8b0603d34264"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b2faa273-bce7-4851-94c2-34bb6a3aea71") },
                    { new Guid("eb0f8712-6763-4bef-bcab-3220425cc5ae"), "şahane bir doğum günü hediyesi olacak.\r\n", new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2163), false, new Guid("b1b09001-8759-4d2b-9022-19a5d54a6f87"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3b45bb5e-c3c4-45f1-b409-6ae7eddea969") },
                    { new Guid("ed7fe6a5-9c94-4995-ad71-de7dd6a2c24a"), "abi bizim taraftarın şu eskiye dönme çabasını hiçbir zaman anlamayacağım. 2023 yılında bazı konulara quaresma geri gelsin yazanı bile var. sergen gittiğinde herkes şenol hoca gelsin dedi, şimdi tekrar sergen diyorlar. tepkiler arşa çıkıp yolladığımız, hatta \"paralar nerede?\" gibi ağır şekilde itham ettiğimiz adamı şu anda yana yakına geri isteyen bir grup var. bir kere de kan değişikliği olsun, bir kere de yeni bir şey sunun abi. 2023 biterken hala talisca hayali kurmayalım mesela, nedir bu geçmiş sevdası?\r\n\r\nkulübün kapısından asla girmemesi gereken eski başkan. diğer eskiler için de aynısını düşünüyorum.", new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2200), false, new Guid("2b8a91a2-8a25-40fc-a24f-a647434e8092"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("643d903c-d6ea-4018-9960-39ae8f091b18") },
                    { new Guid("f3a198d9-3a03-4c50-975f-3f6becd2a4ab"), "laikliğin ne demek olduğunu dahi bilmeyen siyasal islamcı yazarımsı şahsın bir garip hezeyanı.\r\n", new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2162), false, new Guid("3d893ea5-346e-4cbd-8243-71d9d6d29993"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("112dea31-e7cb-4a10-b320-280b8774bdcf") },
                    { new Guid("f47a9816-7d3a-4a5c-b6c8-c3f512d2d379"), "yıllarca israilin filistinde yaptıkları nasıl kabul edilemez ise, filistin militanlarının israile girip kadın çocuk demeden herkesi katletmesi de kabul edilemez. türkiye'nin kendinden başka dostu yoktur. kimsenin götünü yalamasına da ihtiyacı yoktur. siktir git şimdi yeni bir başlık aç “arap sevicileri ve vatanı arap mülteciler ile bölmek istiyenler bu başlık altında toplanıyor” diye. ya da git filistine, katıl arap kardeşlerinin haklı davasına götün yiyorsa. mehmetçiği bulaştırma!", new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2146), false, new Guid("312545b9-3012-4864-9519-1d2ffea23202"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4b66dda4-7087-4afc-90b3-39f3cce98919") },
                    { new Guid("f5646c32-07a0-4a13-9d89-a12c471c9206"), "kaybedenler kulübü'nü izlemek için sinema salonunun açılmasını beklerken, uzakta duran bu abimize \"ismail abiiii?\" diye bağırılmış, karşılığında \"huooop!\" diye cevap alınmıştır. samimiyeti, sempatikliği oyunculuğu kadar takdire şayan.", new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2136), false, new Guid("3b9a544e-d93f-44bc-ba30-3f531d4b0b92"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("010c3422-b809-4a46-9888-984800662f1d") },
                    { new Guid("f57d8382-9cac-43dd-a6af-baf26dfaf0c0"), "filistin ve kudüs tatavalarıyla her türlü takiyeciliği yapıp cihad çağrısında bulunan ama kendisi ve çocukları ise dua desteğinde bulunmaktan başka bir sik yapmayan islamcı iki yüzlüleri deşifre eden düşmanlardır.", new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2145), false, new Guid("e91e29a2-ca44-46dd-a014-6754fea03755"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6fa6a26e-afa2-4cb5-92fd-6abb2a4a2dc1") },
                    { new Guid("f6aa6561-2ba3-4cc5-b19a-18dd0442810b"), "deme lann essah mı diyin....???\r\nşok geçiriyorum...\r\nakit gazetesi yazarı demiş...\r\nulen şunu dese \" robbespierre'i hiç affetmiyoruz devrim çok farklı olabilirdi\" yeminle kalpten giderdim...\r\nbu şekli ile haber değeri yoktur...\r\n\r\ntanım : malumun ilanı olan beyan...", new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2156), false, new Guid("748a78e3-0c21-4336-a892-2b0bd363240c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fb1c316c-2692-4e05-9394-4bc0263b7aa1") },
                    { new Guid("f745c4e8-5684-45cd-8dfa-d43caffd53b1"), "gent'in şehir mimarisine hayran olmamak elde değil. ancak \"off çok türk var burada\" diyen tiplerdenseniz önermem. özellikle türk mahallesine girerseniz bağcılar mı gent mi belli değil. ayrıca küçük şehir 2 güne gent'i gezebilirsiniz. sonra da brugge'e gidersiniz. zaten arabayla 1 saatlik yol.", new DateTime(2023, 10, 9, 18, 11, 8, 632, DateTimeKind.Utc).AddTicks(2148), false, new Guid("8488e808-35f7-4b37-a733-f09eccc7d5dd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("643d903c-d6ea-4018-9960-39ae8f091b18") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RoleId",
                table: "AspNetUsers",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Entries_TopicId",
                table: "Entries",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_UserId",
                table: "Entries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_UserId",
                table: "Topics",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Entries");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");
        }
    }
}

using System;
using Bogus;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;
using WebApplication1.Models;

namespace WebApplication1.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articles", x => x.Id);
                });
            //Insert data 
            Bogus.Randomizer.Seed = new Random(8675309);
            var fakerArticles = new Faker<Article>();
            fakerArticles.RuleFor(a => a.Title, f => f.Lorem.Sentence(5, 5));
            fakerArticles.RuleFor(a => a.Created, f => f.Date.Between(new DateTime(2021,1,1),new DateTime(2022,6,25)));
            fakerArticles.RuleFor(a => a.Title, f => f.Lorem.Paragraphs(1,4));
            for (int i = 0; i < 150; i++)
            {
                Article article = fakerArticles.Generate();
                migrationBuilder.InsertData(
                    table: "articles",
                    columns: new[] { "Title", "Created", "Content" },
                    values: new Object[]{
                    article.Title,
                    article.Created,
                    article.Content
                    }
                    );
            }
            
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "articles");
        }
    }
}

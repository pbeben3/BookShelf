using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookShelf.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Library");

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "Library",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                schema: "Library",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Author = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Library",
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Library",
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Fiction" },
                    { 2, "NonFiction" },
                    { 3, "ScienceFiction" },
                    { 4, "Biography" },
                    { 5, "Mystery" },
                    { 6, "Fantasy" },
                    { 7, "Romance" },
                    { 8, "Thriller" }
                });

            migrationBuilder.InsertData(
                schema: "Library",
                table: "Books",
                columns: new[] { "Id", "Author", "CategoryId", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "F. Scott Fitzgerald", 1, "Set during the Jazz Age on Long Island, this novel follows the mysterious Jay Gatsby and his obsessive pursuit of Daisy Buchanan, a woman he cannot have. The narrative explores the darker side of the American Dream, examining themes of love, wealth, and societal decay, with tragic consequences that ultimately reveal the emptiness behind materialism and ambition.", "The Great Gatsby" },
                    { 2, "George Orwell", 1, "In George Orwell's dystopian vision, the Party's omnipresent surveillance and control over the masses create a society where truth is manipulated and free will is eliminated. Winston Smith, a worker in the Ministry of Truth, dares to question the totalitarian regime, leading him into a desperate search for freedom and the rediscovery of human integrity in a world where reality is distorted.", "1984" },
                    { 3, "Jane Austen", 1, "Set in early 19th-century England, this novel tells the story of Elizabeth Bennet, an independent and sharp-witted woman who must navigate societal expectations and family pressures while grappling with her growing feelings for the proud Mr. Darcy. The book explores the complexities of love, marriage, and social class, illustrating how first impressions can be misleading and personal growth leads to understanding and acceptance.", "Pride and Prejudice" },
                    { 4, "Yuval Noah Harari", 2, "Harari’s thought-provoking exploration of human history traces the evolution of Homo sapiens from hunter-gatherers to the rulers of the modern world. He examines how our species’ ability to create and share complex ideas has shaped societies, economies, and religions. With sharp insight, Harari challenges conventional views on progress, culture, and the future of humanity in the face of technological advancements.", "Sapiens: A Brief History of Humankind" },
                    { 5, "Sun Tzu", 2, "An ancient Chinese military treatise, 'The Art of War' offers timeless principles of strategy and tactics that have influenced warfare, business, and leadership for centuries. Sun Tzu emphasizes the importance of preparation, adaptability, and psychological warfare in achieving victory. His teachings focus on the necessity of understanding both the enemy and oneself in order to outmaneuver adversaries and secure lasting success.", "The Art of War" },
                    { 6, "Michelle Obama", 2, "In this deeply personal memoir, Michelle Obama shares the story of her life—from her childhood on the South Side of Chicago to becoming the First Lady of the United States. 'Becoming' explores her journey of self-discovery, tackling the complexities of identity, race, and motherhood. Through her candid reflections, she inspires readers to find their voice, face challenges, and believe in their potential to create change.", "Becoming" },
                    { 7, "Frank Herbert", 3, "Set in a distant future, 'Dune' tells the story of Paul Atreides, a young nobleman who must navigate political intrigue, religious zealotry, and ecological challenges on the desert planet of Arrakis. As he struggles to claim his birthright and control the valuable spice melange, Paul is forced to confront the harsh realities of power, destiny, and survival in a world where loyalty and betrayal are never certain.", "Dune" },
                    { 8, "William Gibson", 3, "'Neuromancer' follows Case, a washed-up hacker, as he is hired by a mysterious employer to commit an illegal job that takes him deep into cyberspace. The novel, which helped define the cyberpunk genre, explores themes of artificial intelligence, virtual reality, and the blurred lines between the digital world and reality. As Case navigates a dangerous underworld of hackers, he faces the possibility of unlocking secrets that could reshape the future of humanity.", "Neuromancer" },
                    { 9, "Dan Simmons", 3, "In 'Hyperion,' seven pilgrims journey to the distant world of Hyperion, each with their own story to tell. Their tales are rich with themes of love, war, religion, and existentialism, set against the backdrop of an epic interstellar conflict. The novel combines elements of classic science fiction with philosophical and theological explorations, weaving a complex narrative that examines humanity's search for meaning and the consequences of time and choice in a universe on the brink of destruction.", "Hyperion" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                schema: "Library",
                table: "Books",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books",
                schema: "Library");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "Library");
        }
    }
}

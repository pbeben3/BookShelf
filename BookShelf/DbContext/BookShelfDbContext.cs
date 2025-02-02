using BookShelf.Models;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;


namespace BookShelf.DbContext
{
    public class BookShelfDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        private IConfiguration _configuration { get; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }

        public BookShelfDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            options.UseSqlite(connectionString); 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                Enum.GetValues(typeof(BookCategory))
                .Cast<BookCategory>()
                .Select(e => new Category
                {
                    Id = (int)e,
                    Name = e.ToString()
                })
            );

            modelBuilder.Entity<Book>().HasData(
                 new Book
                 {
                     Id = 1,
                     Title = "The Great Gatsby",
                     Author = "F. Scott Fitzgerald",
                     Description = "Set during the Jazz Age on Long Island, this novel follows the mysterious Jay Gatsby and his obsessive pursuit of Daisy Buchanan, a woman he cannot have. The narrative explores the darker side of the American Dream, examining themes of love, wealth, and societal decay, with tragic consequences that ultimately reveal the emptiness behind materialism and ambition.",
                     CategoryId = (int)BookCategory.Fiction
                 },

                 new Book
                 {
                     Id = 2,
                     Title = "1984",
                     Author = "George Orwell",
                     Description = "In George Orwell's dystopian vision, the Party's omnipresent surveillance and control over the masses create a society where truth is manipulated and free will is eliminated. Winston Smith, a worker in the Ministry of Truth, dares to question the totalitarian regime, leading him into a desperate search for freedom and the rediscovery of human integrity in a world where reality is distorted.",
                     CategoryId = (int)BookCategory.Fiction
                 },

                 new Book
                 {
                     Id = 3,
                     Title = "Pride and Prejudice",
                     Author = "Jane Austen",
                     Description = "Set in early 19th-century England, this novel tells the story of Elizabeth Bennet, an independent and sharp-witted woman who must navigate societal expectations and family pressures while grappling with her growing feelings for the proud Mr. Darcy. The book explores the complexities of love, marriage, and social class, illustrating how first impressions can be misleading and personal growth leads to understanding and acceptance.",
                     CategoryId = (int)BookCategory.Fiction
                 },

                 new Book
                 {
                     Id = 4,
                     Title = "Sapiens: A Brief History of Humankind",
                     Author = "Yuval Noah Harari",
                     Description = "Harari’s thought-provoking exploration of human history traces the evolution of Homo sapiens from hunter-gatherers to the rulers of the modern world. He examines how our species’ ability to create and share complex ideas has shaped societies, economies, and religions. With sharp insight, Harari challenges conventional views on progress, culture, and the future of humanity in the face of technological advancements.",
                     CategoryId = (int)BookCategory.NonFiction
                 },

                 new Book
                 {
                     Id = 5,
                     Title = "The Art of War",
                     Author = "Sun Tzu",
                     Description = "An ancient Chinese military treatise, 'The Art of War' offers timeless principles of strategy and tactics that have influenced warfare, business, and leadership for centuries. Sun Tzu emphasizes the importance of preparation, adaptability, and psychological warfare in achieving victory. His teachings focus on the necessity of understanding both the enemy and oneself in order to outmaneuver adversaries and secure lasting success.",
                     CategoryId = (int)BookCategory.NonFiction
                 },

                 new Book
                 {
                     Id = 6,
                     Title = "Becoming",
                     Author = "Michelle Obama",
                     Description = "In this deeply personal memoir, Michelle Obama shares the story of her life—from her childhood on the South Side of Chicago to becoming the First Lady of the United States. 'Becoming' explores her journey of self-discovery, tackling the complexities of identity, race, and motherhood. Through her candid reflections, she inspires readers to find their voice, face challenges, and believe in their potential to create change.",
                     CategoryId = (int)BookCategory.NonFiction
                 },

                 new Book
                 {
                     Id = 7,
                     Title = "Dune",
                     Author = "Frank Herbert",
                     Description = "Set in a distant future, 'Dune' tells the story of Paul Atreides, a young nobleman who must navigate political intrigue, religious zealotry, and ecological challenges on the desert planet of Arrakis. As he struggles to claim his birthright and control the valuable spice melange, Paul is forced to confront the harsh realities of power, destiny, and survival in a world where loyalty and betrayal are never certain.",
                     CategoryId = (int)BookCategory.ScienceFiction
                 },

                 new Book
                 {
                     Id = 8,
                     Title = "Neuromancer",
                     Author = "William Gibson",
                     Description = "'Neuromancer' follows Case, a washed-up hacker, as he is hired by a mysterious employer to commit an illegal job that takes him deep into cyberspace. The novel, which helped define the cyberpunk genre, explores themes of artificial intelligence, virtual reality, and the blurred lines between the digital world and reality. As Case navigates a dangerous underworld of hackers, he faces the possibility of unlocking secrets that could reshape the future of humanity.",
                     CategoryId = (int)BookCategory.ScienceFiction
                 },

                 new Book
                 {
                     Id = 9,
                     Title = "Hyperion",
                     Author = "Dan Simmons",
                     Description = "In 'Hyperion,' seven pilgrims journey to the distant world of Hyperion, each with their own story to tell. Their tales are rich with themes of love, war, religion, and existentialism, set against the backdrop of an epic interstellar conflict. The novel combines elements of classic science fiction with philosophical and theological explorations, weaving a complex narrative that examines humanity's search for meaning and the consequences of time and choice in a universe on the brink of destruction.",
                     CategoryId = (int)BookCategory.ScienceFiction
                 }
             );


        }

    }
}

namespace Domain_Models
{
    public class DataSet
    {
        public enum Genre
        {
            Fiction,
            NonFiction,
            Mystery,
            ScienceFiction,
            Romance,
            Fantasy,
            SelfDevelopment,
            History,
            EpicPoetry,
            Novel,
            Tragedy
        }

        public enum Language
        {
            English
        }

        public void Book()
        {
            Book[] books = new Book[10];

            books[0] = new Book
            {
                Id = 1,
                Title = "Cosmos",
                Author = "Carl Sagan",
                Pages = 365,
                Year = 1980,
                Language = Language.English,
                Genre = Genre.ScienceFiction,
                Description = "Carl Sagan's classic explores the wonders of the universe, blending science, philosophy, and history to provide a comprehensive and awe-inspiring journey through space and time.",
                Price = 140
            };
            books[1] = new Book
            {
                Id = 2,
                Title = "The Odyssey",
                Author = "Homer",
                Pages = 416,
                Year = 2009,
                Language = Language.English,
                Genre = Genre.EpicPoetry,
                Description = "\"The Odyssey\" is one of the greatest epic poems of ancient Greek literature, attributed to the legendary poet Homer. The narrative follows the hero Odysseus as he embarks on a perilous and transformative journey back home to Ithaca after the Trojan War",
                Price = 205
            };
            books[2] = new Book
            {
                Id = 3,
                Title = "The Adventures of Huckleberry Finn",
                Author = "Mark Twain",
                Pages = 480,
                Year = 2008,
                Language = Language.English,
                Genre = Genre.Novel,
                Description = "A nineteenth-century boy from a Mississippi River town recounts his adventures as he travels down the river with a runaway slave, encountering a family involved in a feud, two scoundrels pretending to be royalty, and Tom Sawyer's aunt who mistakes him for Tom.",
                Price = 80
            };
            books[3] = new Book
            {
                Id = 4,
                Title = "Sapiens: A Brief History of Humankind",
                Author = "Yuval Noah Harari",
                Pages = 512,
                Year = 2015,
                Language = Language.English,
                Genre = Genre.History,
                Description = "Yuval Noah Harari takes readers on a journey through the history of Homo sapiens, exploring key events and developments that have shaped the course of human evolution.",
                Price = 90
            };
            books[4] = new Book
            {
                Id = 5,
                Title = "Sprint: How to Solve Big Problems and Test New Ideas in Just Five Days",
                Author = "Jake Knapp ",
                Pages = 228,
                Year = 2016,
                Language = Language.English,
                Genre = Genre.SelfDevelopment,
                Description = "Jake Knapp, John Zeratsky, and Braden Kowitz present a practical guide to running successful sprints for product development and problem-solving, drawing on their experiences at Google Ventures.",
                Price = 150
            };
            books[5] = new Book
            {
                Id = 6,
                Title = "The Art of Computer Programming",
                Author = "Donald Knuth",
                Pages = 672,
                Year = 2011,
                Language = Language.English,
                Genre = Genre.NonFiction,
                Description = "Authored by Donald E. Knuth, this multi-volume series is a comprehensive and timeless exploration of computer programming and algorithms.",
                Price = 400
            };
            books[6] = new Book
            {
                Id = 7,
                Title = "The Shadow of the Wind",
                Author = "Carlos Ruiz Zafón",
                Pages = 565,
                Year = 2011,
                Language = Language.English,   
                Genre = Genre.Mystery,
                Description = "Carlos Ruiz Zafón's atmospheric novel is set in post-World War II Barcelona and follows a young boy who discovers a mysterious book that leads him into a complex and dark mystery.",
                Price = 150
            };
            books[7] = new Book
            {
                Id = 8,
                Title = "The Great Gatsby",
                Author = "F. Scott Fitzgerald",
                Pages = 192,
                Year = 2013,
                Language = Language.English,
                Genre = Genre.Tragedy,
                Description = "\"The Great Gatsby\" is a classic novel written by F. Scott Fitzgerald, published in 1925. Set against the backdrop of the Roaring Twenties, the story provides a vivid portrait of the American Jazz Age, exploring themes of wealth, love, and the elusive American Dream.",
                Price = 80
            };
            books[8] = new Book
            {
                Id = 9,
                Title = "The Martian",
                Author = "Andy Weir",
                Pages = 369,
                Year = 2011,
                Language = Language.English,
                Genre = Genre.ScienceFiction,
                Description = "Join astronaut Mark Watney in Andy Weir's gripping sci-fi novel as he fights for survival on Mars after being stranded by his crew. Packed with humor, suspense, and science, it's a thrilling adventure.",
                Price = 110
            };
            books[9] = new Book
            {
                Id = 10,
                Title = "The Tragedie of Romeo and Juliet",
                Author = "William Shakespeare",
                Pages = 281,
                Year = 2002,
                Language = Language.English,
                Genre = Genre.Tragedy,
                Description = "\"Romeo and Juliet\" is a tragedy written by William Shakespeare early in his career about the romance between two Italian youths from feuding families.",
                Price = 140
            };


        }

        public void BoardGame()
        {
            BoardGame[] boardGames = new BoardGame[10];

            boardGames[0] = new BoardGame
            {
                Id = 11,
                Title = "Monopoly",
                Developer = "Hasbro Gaming",
                PlayerCount = "2-6",
                Age = "8+",
                PlayTime = 90,
                Description = "Monopoly is a classic real estate trading game where players buy, sell, and trade properties to build wealth. The goal is to bankrupt opponents by collecting rent on properties.",
                Price = 150

            };
            boardGames[1] = new BoardGame
            {
                Id = 12,
                Title = "Scrabble",
                Developer = "Mattel Games",
                PlayerCount = "2-4",
                Age = "10+",
                PlayTime = 60,
                Description = "Scrabble is a word game where players use letter tiles to create words on a game board. Each letter has a point value, and the goal is to maximize points by creating high-scoring words.",
                Price = 250

            };
            boardGames[2] = new BoardGame
            {
                Id = 13,
                Title = "Chess",
                Developer = "AMEROUS",
                PlayerCount = "2",
                Age = "6+",
                PlayTime = 20,
                Description = "Chess is a strategic two-player game played on an 8x8 grid. Each player commands an army with different types of pieces, and the objective is to checkmate the opponent's king.",
                Price = 115

            };
            boardGames[3] = new BoardGame
            {
                Id = 14,
                Title = "Risk",
                Developer = "HASBRO GAMING",
                PlayerCount = "2-5",
                Age = "10+",
                PlayTime = 60,
                Description = "Risk is a classic game of global conquest. Players use armies to control territories and continents, engaging in strategic battles to eliminate opponents and achieve world domination.",
                Price = 200

            };
            boardGames[4] = new BoardGame
            {
                Id = 15,
                Title = "Settlers of Catan",
                Developer = "Klaus Teuber",
                PlayerCount = "3-4",
                Age = "10+",
                PlayTime = 75,
                Description = "Settlers of Catan is a resource management and strategy game. Players collect resources to build roads, settlements, and cities on the island of Catan, competing for victory points.",
                Price = 200

            };
            boardGames[5] = new BoardGame
            {
                Id = 16,
                Title = "Ticket to Ride",
                Developer = "Days of wonder",
                PlayerCount = "2-5",
                Age = "8+",
                PlayTime = 60,
                Description = "Ticket to Ride is a railway-themed board game where players collect train cards to claim routes between cities. The goal is to complete destination tickets and build the longest continuous route.",
                Price = 250

            };
            boardGames[6] = new BoardGame
            {
                Id = 17,
                Title = "Carcassonne",
                Developer = "Klaus Furgen Wrede",
                PlayerCount = "2-5",
                Age = "7+",
                PlayTime = 45,
                Description = "Carcassonne is a tile-laying game where players construct landscapes with cities, roads, and fields. Players deploy followers strategically to claim features and earn points.",
                Price = 150

            };
            boardGames[7] = new BoardGame
            {
                Id = 18,
                Title = "Pandemic",
                Developer = "Matt Leacock",
                PlayerCount = "2-4",
                Age = "10+",
                PlayTime = 0,
                Description = "60",
                Price = 150

            };
            boardGames[8] = new BoardGame
            {
                Id = 19,
                Title = "Codenames",
                Developer = "Vlaada Chvatil",
                PlayerCount = "2-8",
                Age = "14+",
                PlayTime = 15,
                Description = "Codenames is a word-based party game where teams compete to uncover their agents based on clues given by a spymaster. The challenge is to avoid the opponent's agents while making accurate guesses.",
                Price = 99

            };
            boardGames[9] = new BoardGame
            {
                Id = 20,
                Title = "7 Wonders",
                Developer = "Repos",
                PlayerCount = "2-7",
                Age = "7+",
                PlayTime = 60,
                Description = "In 7 Wonders, players lead ancient civilizations by developing cities and wonders through drafting cards. The game combines resource management, strategy, and building elements. ",
                Price = 189

            };





        }
    }  
    
}

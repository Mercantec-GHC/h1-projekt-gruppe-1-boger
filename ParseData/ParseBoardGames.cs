using Domain_Models.Webshop.Medias;
using Domain_Models.Webshop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseData
{
    
        public class ParseBoardGames
        {
            public List<BoardGame> ParseBoardGame(string path)
            {
                var boardGames = new List<BoardGame>();
                var lines = ReadFile(path);

                lines.ForEach(line =>
                {

                    var boardGameLines = SplitLine(line);
                    var boardGame = Creator(boardGameLines);
                    boardGames.Add(boardGame);
                });

                return boardGames;
            }
            public List<string> ReadFile(string fileName)
            {
                return File.ReadLines(fileName).ToList();
            }

            private List<string> SplitLine(string line, char sep = '\t')
            {
                return line.Split(sep).ToList();
            }
            
            private BoardGame Creator(List<string> columns)
            {
                


                var boardGame = new BoardGame();
                boardGame.Title = columns[0];
                boardGame.Developer = columns[1];
                boardGame.MinPlayerCount = int.Parse(columns[2]);
                boardGame.MaxPlayerCount = int.Parse(columns[3]);
                boardGame.MinAge = int.Parse(columns[4]);
                boardGame.PlayTime = int.Parse(columns[5]);
                boardGame.Description = columns[6];
                boardGame.Price = float.Parse(columns[7]);


                return boardGame;
            }
        }
    
}

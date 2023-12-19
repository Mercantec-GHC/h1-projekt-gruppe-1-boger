using ParseData;
using Domain_Models.Database;

DatabaseHandler.Create();

ParseBoardGames parseDB = new ParseBoardGames();
var boardGame = parseDB.ParseBoardGame("./BoardGames.tsv");


foreach (var item in boardGame)
{
    

    item.AddDBEntry();

}


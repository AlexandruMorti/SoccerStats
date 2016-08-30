using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SoccerStats
{
    class Program
    {
        static void Main(string[] args)
        {
            string curentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(curentDirectory);
            var fileName = Path.Combine(directory.FullName, "SoccerGameResults.csv");
            var fileContent = readSoccerResult(fileName);          
        }

        public static string ReadFile(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                return reader.ReadToEnd();
            }
        }

        public static List<GameResult> readSoccerResult(string fileName)
            {
            var soccerResult = new List<GameResult>();
            using (var reader = new StreamReader(fileName))
            {
               string line = "";
                reader.ReadLine();
               while((line = reader.ReadLine()) != null)
                {
                    var GameResult = new GameResult();
                    string[] values = line.Split(',');
                    DateTime gameDate;
                    if(DateTime.TryParse(values[0], out gameDate ))
                    {
                        GameResult.GameDate = gameDate;
                    }
                    GameResult.TeamName = values[1];
                    HomeOrAway homeOrAway;
                    if(Enum.TryParse(values[2], out homeOrAway))
                    {
                        GameResult.HomeOrAway = homeOrAway;
                    }
                    int parseInt;
                    if (int.TryParse(values[3], out parseInt))
                    {
                        GameResult.Goals = parseInt;  
                    }
                    if (int.TryParse(values[4], out parseInt))
                    {
                        GameResult.GoalAttempts = parseInt;
                    }
                    if (int.TryParse(values[5], out parseInt))
                    {
                        GameResult.ShotsOnGoal = parseInt;
                    }
                    if (int.TryParse(values[6], out parseInt))
                    {
                        GameResult.Goals = parseInt;
                    }
                    if (int.TryParse(values[7], out parseInt))
                    {
                        GameResult.ShotsOffGoal = parseInt;
                    }

                    double possessionPercent;
                    if (double.TryParse(values[8], out possessionPercent))
                    {
                        GameResult.PossessionPercent = possessionPercent;
                    }
                    soccerResult.Add(GameResult);
                }
            }
            return soccerResult;
            }
    }
}

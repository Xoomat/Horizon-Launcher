using System;
using System.Diagnostics;
using System.IO;

namespace HorizonN7
{
    public class GameManager
    {
        private string[] gamePaths;
        private string[] commandLines;

        public GameManager(string[] gamePaths, string[] commandLines)
        {
            this.gamePaths = gamePaths;
            this.commandLines = commandLines;
        }

        public void LaunchGame(int gameIndex, string language)
        {
            if (gameIndex < 0 || gameIndex >= gamePaths.Length)
            {
                throw new ArgumentOutOfRangeException("Некорректный индекс игры");
            }

            string fullPath = Path.Combine(AppContext.BaseDirectory, gamePaths[gameIndex]);
            if (!File.Exists(fullPath))
            {
                throw new FileNotFoundException("Игра не найдена!");
            }

            string languageCode = GetLanguageCode(language, gameIndex);
            string arguments = commandLines[gameIndex].Replace("{language}", languageCode);

            Process.Start(new ProcessStartInfo
            {
                FileName = fullPath,
                Arguments = arguments,
                WorkingDirectory = Path.GetDirectoryName(fullPath)
            });
        }

        public string GetLanguageCode(string language, int gameIndex)
        {
            switch (language)
            {
                case "English": return "INT";
                case "French": return gameIndex == 0 ? "FR" : "FRA";
                case "German": return gameIndex == 0 ? "DE" : "DEU";
                case "Spanish": return gameIndex == 0 ? "ES" : "ESN";
                case "Italian": return gameIndex == 0 ? "IT" : "ITA";
                case "Russian": return gameIndex == 0 ? "RA" : "RUS";
                case "Polish": return gameIndex == 0 ? "PLPC" : "POL";
                case "Japanese": return gameIndex == 0 ? "JA" : "JPN";
                default: return "INT";
            }
        }
    }
}
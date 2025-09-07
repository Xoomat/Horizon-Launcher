using System;
using System.Diagnostics;
using System.IO;

namespace HorizonN7
{
    public class Launcher
    {
        private GameManager gameManager;
        private SettingsManager settingsManager;

        public Launcher(string[] gamePaths, string[] commandLines)
        {
            gameManager = new GameManager(gamePaths, commandLines);
            settingsManager = new SettingsManager();
        }

        public void LaunchGame(int gameIndex, string language)
        {
            gameManager.LaunchGame(gameIndex, language);
        }

        public void SaveSetting(string key, string value)
        {
            settingsManager.SaveSetting(key, value);
        }

        public string LoadSetting(string key)
        {
            return settingsManager.LoadSetting(key);
        }

        public int LoadLastGameIndex()
        {
            string value = settingsManager.LoadSetting("LastGameIndex");
            return int.TryParse(value, out int index) ? index : 0;
        }

        public void SaveLastGameIndex(int index)
        {
            settingsManager.SaveSetting("LastGameIndex", index.ToString());
        }

        // Метод для сохранения языка
        public void SaveLanguage(string language)
        {
            settingsManager.SaveLanguage(language);
        }

        // Метод для загрузки языка
        public string LoadLanguage()
        {
            return settingsManager.LoadLanguage();
        }

        public void SaveDiscordRPCEnabled(bool enabled)
        {
            settingsManager.SaveDiscordRPCEnabled(enabled);
        }

        public bool LoadDiscordRPCEnabled()
        {
            return settingsManager.LoadDiscordRPCEnabled();
        }

        public string GetLanguageCode(string language, int gameIndex)
        {
            return gameManager.GetLanguageCode(language, gameIndex);
        }
    }
}
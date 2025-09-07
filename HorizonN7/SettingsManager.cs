using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HorizonN7
{
    public class SettingsManager
    {
        private readonly string settingsFilePath;

        public SettingsManager()
        {
            settingsFilePath = Path.Combine(AppContext.BaseDirectory, "settings.ini");
        }

        public void SaveSetting(string key, string value)
        {
            var lines = File.Exists(settingsFilePath) ? File.ReadAllLines(settingsFilePath).ToList() : new List<string>();
            bool keyExists = false;

            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].StartsWith($"[{key}]="))
                {
                    lines[i] = $"[{key}]={value}";
                    keyExists = true;
                    break;
                }
            }

            if (!keyExists)
            {
                lines.Add($"[{key}]={value}");
            }

            File.WriteAllLines(settingsFilePath, lines);
        }

        public string LoadSetting(string key)
        {
            if (File.Exists(settingsFilePath))
            {
                foreach (var line in File.ReadAllLines(settingsFilePath))
                {
                    if (line.StartsWith($"[{key}]="))
                    {
                        return line.Split('=')[1];
                    }
                }
            }
            return null;
        }

        // Метод для сохранения языка
        public void SaveLanguage(string language)
        {
            SaveSetting("Language", language);
        }

        // Метод для загрузки языка
        public string LoadLanguage()
        {
            return LoadSetting("Language") ?? "English"; // По умолчанию English
        }

        public void SaveDiscordRPCEnabled(bool enabled)
        {
            SaveSetting("DiscordRPCEnabled", enabled.ToString());
        }

        public bool LoadDiscordRPCEnabled()
        {
            string value = LoadSetting("DiscordRPCEnabled");
            return string.IsNullOrEmpty(value) ? true : bool.Parse(value); // По умолчанию включено
        }
    }
}
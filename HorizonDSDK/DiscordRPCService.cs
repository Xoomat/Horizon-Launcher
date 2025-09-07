using DiscordRPC;
using System;

namespace HorizonDSDK
{
    public class DiscordRPCService : IDisposable
    {
        private DiscordRpcClient discordRpcClient;
        private RichPresence presence;

        public DiscordRPCService(string clientId)
        {
            // Инициализация Discord RPC
            discordRpcClient = new DiscordRpcClient(clientId);
            discordRpcClient.Initialize();

            // Инициализация объекта RichPresence
            presence = new RichPresence
            {
                Timestamps = Timestamps.Now,
                Assets = new Assets
                {
                    SmallImageKey = "launcher_icon",
                    SmallImageText = "Horion Launcher"
                }
            };

            // Устанавливаем начальный статус
            discordRpcClient.SetPresence(presence);
        }

        public void UpdatePresence(string state, string largeImageKey, string largeImageText)
        {
            // Обновляем только нужные поля
            presence.State = state;
            presence.Assets.LargeImageKey = largeImageKey;
            presence.Assets.LargeImageText = largeImageText;

            // Устанавливаем обновленный статус
            discordRpcClient.SetPresence(presence);
        }

        public void ClearPresence()
        {
            discordRpcClient.ClearPresence();
        }

        public void Dispose()
        {
            discordRpcClient.Dispose();
        }

        public void Update()
        {
            discordRpcClient.Invoke();
        }
    }
}
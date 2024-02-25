using System;
using CommandSystem;
using Exiled.API.Enums;
using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.API.Features.Roles;
using Exiled.Permissions.Extensions;
using MEC;
using Narkomania;
using RemoteAdmin;
using Exiled.CustomRoles;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;
using Respawning;
using UnityEngine;

namespace Commands.Command
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class SpawnNarko : ICommand
    {
        public string Command { get; } = "spawnnarko";

        public string[] Aliases { get; } = new string[]
        {
            "scpnarko",
            "spawnnarko"
        };

        public string Description { get; } = "Смена класса на ЧВК Вагнер!";
        
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get(((CommandSender)sender).SenderId);
            
            
            if (!Permissions.CheckPermission((CommandSender)sender, "narko.spawn"))
            {
                response = "У вас не достаточно прав!";
                return false;
            }
            int count = arguments.Count;
            if (count != 0)
            {
                if (count != 1)
                {
                    response = "Usage: spawnnarko";
                    return false;
                }
                if (player == null)
                {
                    response = $"Чек {Player.Get(player.Sender).Nickname} инвалид";
                    return false;
                }
                Timing.CallDelayed(1f, delegate()
                {
                    EventHandlers.spawnNarko(player);
                });
                response = "Он уже Наркоман";
                return true;
            }
            {
                if (count != 0)
                {
                    response = "Уже есть Наркоман!";
                    return false;
                }
                
                player.Broadcast(6, "Вы использовали шприц со странным веществом.");
                player.CustomInfo = "Использовал странный шприц";
                player.RankColor = "green";
                player.RankName = "Неадекват...";
                player.EnableEffect(EffectType.Stained);
                player.EnableEffect(EffectType.Burned);
                player.Broadcast(10, "У вас начались приступы!");
                player.Scale = new Vector3(2f, 0.7f, 2f);
                Timing.CallDelayed(1f, delegate()
                {
                    EventHandlers.spawnNarko(player);
                });
                
                response = "Вы стали Пьяным";
                return true;
            }
        }
    }
}
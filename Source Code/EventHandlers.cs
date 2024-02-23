using System;
using System.Collections.Generic;
using System.Linq;
using Exiled.API.Enums;
using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.API.Features.Roles;
using Exiled.Events.EventArgs;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;
using MEC;
using Exiled.CustomRoles;
using PluginAPI.Commands;
using PluginAPI.Events;
using UnityEngine;

namespace Narkomania
{
    public class EventHandlers
    {
        public void OnUsingItem(UsingItemEventArgs ev)
        {
            if (ev.Item.Type == ItemType.Adrenaline)
            {
                ev.Player.Broadcast(6, "Вы использовали шприц со странным веществом.");
                ev.Player.CustomInfo = "Использовал странный шприц";
                ev.Player.RankColor = "green";
                ev.Player.RankName = "Неадекват...";
                ev.Player.EnableEffect(EffectType.Stained, 1, 60);
                ev.Player.EnableEffect(EffectType.Burned);
                ev.Player.Broadcast(4, "У вас начались приступы!");
                ev.Player.Scale = new Vector3(2f, 0.7f, 2f);
                ev.Player.MaxHealth = 200;
                ev.Player.Health = 200;
            }
            if (ev.Item.Type == ItemType.SCP500 && ev.Player.CustomInfo == "Использовал странный шприц")
            {
                ev.Player.Broadcast(6, "Вы использовали таблетки от запора.");
                ev.Player.CustomInfo = "Вылечил болезнь!";
                ev.Player.RankColor = "orange";
                ev.Player.RankName = "Четкий пацан!";
                ev.Player.EnableEffect(EffectType.Scp207, 1);
                ev.Player.Broadcast(4, "Вы стали Четким Пацаном!");
                ev.Player.Scale = new Vector3(1f, 1f, 1f);
                ev.Player.MaxHealth = 100;
                ev.Player.Health = 100;
            }
        }

        public void OnPickUpItem(PickingUpItemEventArgs ev)
        {
            if (ev.Pickup.Type == ItemType.Adrenaline)
            {
                ev.Player.Broadcast(2, "Вы подобрали шприц со странным веществом. На обороте написанно .......");
            }
            if (ev.Pickup.Type == ItemType.SCP500)
            {
                ev.Player.Broadcast(2, "Вы подобрали таблетки от запора...");
            }
        }
        
        public static void spawnNarko(Player p)
        {
            p.MaxHealth = Main.Singleton.Config.healthPercent;
            p.Health = Main.Singleton.Config.healthPercent;
        }
    }
}
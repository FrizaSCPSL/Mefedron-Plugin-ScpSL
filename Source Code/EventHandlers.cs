using System;
using System.Collections.Generic;
using System.Linq;
using Exiled.API.Enums;
using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.API.Features.Core.Generic;
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
                ev.Player.ShowHint(Main.Singleton.Config.hintUseAd, 1.5f);
                ev.Player.CustomInfo = "Использовал странный шприц";
                ev.Player.RankColor = "green";
                ev.Player.RankName = Main.Singleton.Config.rankNm1;
                ev.Player.EnableEffect(EffectType.Stained, 1, 60);
                ev.Player.EnableEffect(EffectType.Burned);
                ev.Player.Broadcast(4, Main.Singleton.Config.bc1);
                ev.Player.Scale = new Vector3(2f, 0.7f, 2f);
                ev.Player.MaxHealth = Main.Singleton.Config.healthPercent;
                ev.Player.Health = Main.Singleton.Config.healthPercent;
            }
            if (ev.Item.Type == ItemType.SCP500 && ev.Player.CustomInfo == "Использовал странный шприц")
            {
                ev.Player.ShowHint(Main.Singleton.Config.hintUseScp500, 1.5f);
                ev.Player.CustomInfo = "Вылечил болезнь!";
                ev.Player.RankColor = "orange";
                ev.Player.RankName = Main.Singleton.Config.rankNm2;
                ev.Player.EnableEffect(EffectType.Scp207, 1);
                ev.Player.Broadcast(4, Main.Singleton.Config.bc2);
                ev.Player.Scale = new Vector3(1f, 1f, 1f);
                ev.Player.MaxHealth = 100;
                ev.Player.Health = 100;
            }
        }

        public void OnPickUpItem(PickingUpItemEventArgs ev)
        {
            if (ev.Pickup.Type == ItemType.Adrenaline)
            {
                ev.Player.ShowHint(Main.Singleton.Config.hintPickUpAd, 1.5f);
            }
            if (ev.Pickup.Type == ItemType.SCP500)
            {
                ev.Player.ShowHint(Main.Singleton.Config.hintPickUpScp500, 1.5f);
            }
        }
        
        public static void spawnNarko(Player p)
        {
            p.MaxHealth = Main.Singleton.Config.healthPercent;
            p.Health = Main.Singleton.Config.healthPercent;
        }
    }
}
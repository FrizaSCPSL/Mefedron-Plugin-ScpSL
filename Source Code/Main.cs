using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Exiled.Events.EventArgs.Player;

using Server = Exiled.Events.Handlers.Server;
using Player = Exiled.Events.Handlers.Player;

namespace Narkomania
{
    public class Main : Plugin<Config>
    
    {
        
        public override string Author { get; } = "Friza";

        public override string Name { get; } = "Narko";

        public override string Prefix { get; } = "Narko";

        public override Version Version { get; } = new Version(8, 8, 0);

        public override Version RequiredExiledVersion { get; } = new Version(8, 8, 0);

        internal EventHandlers EventHandlers { get; set; }
        
        
        public override void OnEnabled()
        {
            Main.Singleton = this;
            EventHandlers = new();
            
            Player.UsingItem += EventHandlers.OnUsingItem;
            Player.PickingUpItem += EventHandlers.OnPickUpItem;
        }

        public override void OnDisabled()
        {
            Player.UsingItem -= EventHandlers.OnUsingItem;
            Player.PickingUpItem -= EventHandlers.OnPickUpItem;
            
            this.EventHandlers = null;
        }
        
        public static Main Singleton;
    }
}
using Dalamud.Game;
using Dalamud.Game.ClientState;
using Dalamud.Game.ClientState.Conditions;
using Dalamud.Plugin.Services;
using FFXIVClientStructs.FFXIV.Client.System.Framework;
using Lumina.Excel.GeneratedSheets;
using SamplePlugin;

namespace SamplePlugin
{
    internal static class Service
    {
        internal static IClientState ClientState;
        internal static Framework Framework;
        internal static Configuration Config;
        internal static Condition Condition;

    }
   
}

using System;
using System.Numerics;
using Dalamud.Interface.Windowing;
using Dalamud.Logging;
using Dalamud.Plugin.Services;
using ImGuiNET;
using Dalamud.Game.ClientState;
using Dalamud.Game.ClientState.Conditions;
using Dalamud.Game.ClientState.Objects.Enums;
using SamplePlugin.ClassConfigurations;
using SamplePlugin.Helpers;

namespace SamplePlugin.Windows;

public class ConfigWindow : Window, IDisposable
{
    private Configuration Configuration;
    private BasicClass currentClass;
    
    
    public ConfigWindow(Plugin plugin) : base(
        "A Wonderful Configuration Window",
        ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoScrollbar |
        ImGuiWindowFlags.NoScrollWithMouse)

    {

        currentClass = new Warrior();
        

        this.SizeConstraints = new WindowSizeConstraints()
        {
            //Min Size of window
            MinimumSize = new Vector2(375, 330),
            //Max size of the window
            MaximumSize = new Vector2(float.MaxValue, float.MaxValue)
        };
        
        this.SizeCondition = ImGuiCond.Always;

        this.Configuration = plugin.Configuration;
    }

    public void Dispose() { }
    public override void Draw()
    {
        // can't ref a property, so use a local copy
        var configValue = this.Configuration.SomePropertyToBeSavedAndWithADefault;
        var localPlayer = Service.ClientState.LocalPlayer;
        
        if (ImGui.Checkbox("Random Config Bool", ref configValue))
        {
            this.Configuration.SomePropertyToBeSavedAndWithADefault = configValue;
            // can save immediately on change, if you don't want to provide a "Save and Close" button
            this.Configuration.Save();
        }
        
        
        if (ImGui.Button("Test Something"))
        {
            PluginLog.Log(localPlayer?.ClassJob.GameData?.Name ?? "Cant find class");
            PluginLog.Log("Hello");
            SoundEngine.PlaySound(Plugin.soundPath);
        }


        if (ImGui.Button("Get Current Buffs"))
        {
            foreach (var buff in localPlayer?.StatusList)
            {
                PluginLog.Log(buff.GameData.Name ?? "No Buff");
            }
        }
        
        
        ImGui.Spacing();
        ImGui.Text($"{Service.ClientState.LocalPlayer.ClassJob.GameData.Name}'s options");

        foreach (var option in currentClass.options)
        {
            var keyValuePair = option;
            var boolValue = keyValuePair.Value.test;
            if (ImGui.Checkbox(keyValuePair.Value.boxDescription, ref boolValue))
            {
                keyValuePair.Value.test = boolValue;
                
                
            }
        }
    }
}

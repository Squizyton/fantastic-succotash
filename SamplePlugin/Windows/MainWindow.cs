using System;
using System.Numerics;
using Dalamud.Interface.Internal;
using Dalamud.Interface.Windowing;
using ImGuiNET;

namespace SamplePlugin.Windows;

//The main window, This what pops when you type in a command
public class MainWindow : Window, IDisposable
{
    
    //Reference to Goat Image
    private IDalamudTextureWrap GoatImage;
    
    //Reference to the plugin script
    private Plugin Plugin;

    //Constructor
    public MainWindow(Plugin plugin, IDalamudTextureWrap goatImage) : base(
        "Need More Slopeh", ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoScrollWithMouse)
    {
        this.SizeConstraints = new WindowSizeConstraints
        {
            //Min Size of window
            MinimumSize = new Vector2(375, 330),
            //Max size of the window
            MaximumSize = new Vector2(float.MaxValue, float.MaxValue)
        };

        this.GoatImage = goatImage;
        this.Plugin = plugin;
    }

    public void Dispose()
    {
        this.GoatImage.Dispose();
    }

    
    //Main window Drawing
    public override void Draw()
    {
        
        //Access the Plugin Configuration Class
        ImGui.Text($"The random config bool is {this.Plugin.Configuration.SomePropertyToBeSavedAndWithADefault}");

        
        if (ImGui.Button("Show Settings"))
        {
            this.Plugin.DrawConfigUI();
        }

        ImGui.Spacing();
        //text
        ImGui.Text("Have a goat:");
        //Indent
        ImGui.Indent(55);
        //If you want to use images you need to use IDalamudTextureWrap
        ImGui.Image(this.GoatImage.ImGuiHandle, new Vector2(this.GoatImage.Width, this.GoatImage.Height));
        //Forcing an unindent
        ImGui.Unindent(55);
    }
}

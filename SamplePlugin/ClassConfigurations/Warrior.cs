using System;
using System.Collections.Generic;

namespace SamplePlugin.ClassConfigurations;

public class Warrior :BasicClass ,IDisposable
{

    public static bool SurgingTempest = true;
    public static bool HolmGang = true;
    public static bool PrimalRend = true;


    public Warrior()
    {
        options = new Dictionary<string, TickBoxes>()
        {
            {"Surging Tempest", new TickBoxes("Check to see if you fail at upkeeping Surging Tempest", SurgingTempest)},
            {"Holmgang", new TickBoxes("Man Did you really HolmGang? YOU ARE WARRIOR FOR CHRIST SAKE", HolmGang)},
            {"PrimalRend", new TickBoxes("Dude, you forget to PrimalRend", HolmGang)},
        };
    }


    public void Dispose() { }
    
    
    
    
    
}

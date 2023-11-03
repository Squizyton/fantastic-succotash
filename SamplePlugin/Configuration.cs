using Dalamud.Configuration;
using Dalamud.Plugin;
using System;
using Dalamud.Game.ClientState;
namespace SamplePlugin
{
    [Serializable]
    public class Configuration : IPluginConfiguration
    {
        public int Version { get; set; } = 0;

        #region Sound
        
        public int SoundDeviceId { get; set; } = -1;
        public bool PlayInBackground { get; set; } = false;
        #endregion
        public bool SomePropertyToBeSavedAndWithADefault { get; set; } = true;
        

        // the below exist just to make saving less cumbersome
        [NonSerialized]
        private DalamudPluginInterface? PluginInterface;

        public void Initialize(DalamudPluginInterface pluginInterface)
        {
            
            
            
            
            
            this.PluginInterface = pluginInterface;
        }

        public void Save()
        {
            this.PluginInterface!.SavePluginConfig(this);
        }
    }
}

using Dalamud.Utility;
using NAudio.Wave;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Dalamud.Logging;
using Dalamud.Plugin;
using Dalamud.Plugin.Services;

namespace SamplePlugin;

public static class SoundEngine
{
    public static void PlaySound(string path, float volume = .5f)
    {
        PluginLog.Log("Checking File");
        PluginLog.Log(path);
        if (path.IsNullOrEmpty() || !File.Exists(path)) return;
       

        PluginLog.Log("Found Sound");

   

        //Check to is if the current process in Windows is XIV
        if (Process.GetCurrentProcess().Id != ProcessUtils.GetForegroundProcessId()) return;



        var soundDevice = Service.Config.SoundDeviceId;



        if (soundDevice < -1 || soundDevice > WaveOut.DeviceCount)
        {
            soundDevice = -1;
        }


        var thread = new Thread(() =>
        {
            WaveStream reader;
            try
            {
                reader = new AudioFileReader(path);

            }
            catch (Exception e)
            {
               
                return;
            }

            volume = Math.Max(0, Math.Min(volume, 1));

            using WaveChannel32 channel = new(reader)
            {
                Volume = 1 - (float)Math.Sqrt(1 - (volume * volume)),
                PadWithZeroes = false
            };


            using (reader)
            {
                using var output = new WaveOutEvent
                {
                    DeviceNumber =soundDevice,
                };
                
                output.Init(channel);
                output.Play();

                while (output.PlaybackState == PlaybackState.Playing)
                {
                    Thread.Sleep(500);
                }
            }
        });
        
        thread.Start();
    }
    
    


}

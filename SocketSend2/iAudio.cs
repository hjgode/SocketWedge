using System;
using System.Collections.Generic;
using System.Text;
//using Intermec.Device.Audio;
using System.Runtime.InteropServices;

namespace SocketSend2
{
    //using a class with try...catch we avoid possible problems with missing runtimes
    class iAudio
    {
        public const int ITC_TONE_VOLUME_CURRENT = 32;

        [DllImport("itc50.dll", CharSet = CharSet.Unicode)]
        public static extern int ITCIsAudioToneSupported();

        [DllImport("itc50.dll", CharSet = CharSet.Unicode)]
        public static extern UInt32 ITCAudioPlayTone(uint nPitch, uint nDuration, uint nVolume);
        
        [DllImport("itc50.dll", CharSet = CharSet.Unicode)]
        public static extern uint ITC_ToneVolumeCurrent();

        public void playBad(){
            try
            {
                ITCAudioPlayTone(250, 100, ITC_ToneVolumeCurrent());
                //Tone soundBad = new Tone(250, 100, Intermec.Device.Audio.Tone.VOLUME.CURRENT_CFG_VOL);
                //soundBad.Play();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception in playBad " + ex.Message + ". \r\nRUNTIME missing?");
            }
        }
        public void playGood()
        {
            try
            {
                ITCAudioPlayTone(1000, 50, ITC_ToneVolumeCurrent());
                //Tone soundGood = new Tone(1000, 50, Intermec.Device.Audio.Tone.VOLUME.CURRENT_CFG_VOL);
                //soundGood.Play();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception in playGood " + ex.Message + ". \r\nRUNTIME missing?");
            }
        }
    }
}

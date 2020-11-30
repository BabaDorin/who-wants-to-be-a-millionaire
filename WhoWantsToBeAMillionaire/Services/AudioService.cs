using System;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Text;
using System.Windows;

namespace WhoWantsToBeAMillionaire.Services
{
    class AudioService
    {
        public bool AudioOn { get; set; }

        public SoundPlayer MainTheme { get; set; }
        public SoundPlayer LetsPlay { get; set; }
        public SoundPlayer Music1001000 { get; set; }
        public SoundPlayer Music2k32k { get; set; }
        public SoundPlayer Music64k500k { get; set; }
        public SoundPlayer Music500k1kk { get; set; }
        public SoundPlayer FinalAnswer { get; set; }
        public SoundPlayer CorrectAnswer { get; set; }
        public SoundPlayer PhoneAFriend { get; set; }
        public SoundPlayer WrongAnswer { get; set; }
        private SoundPlayer LastSound { get; set; }

        private string audioDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\", @"Resources\Audio\"));

        // Implementarea pattern-ului Singleton
        private static AudioService instance;
        private AudioService()
        {
            AudioOn = true;

            MainTheme = new SoundPlayer(Path.Combine(audioDirectory, "maintheme.wav"));
            LetsPlay = new SoundPlayer(Path.Combine(audioDirectory, "letsplay.wav"));
            Music1001000 = new SoundPlayer(Path.Combine(audioDirectory, "1001000.wav"));
            Music2k32k = new SoundPlayer(Path.Combine(audioDirectory, "2k32k.wav"));
            Music64k500k = new SoundPlayer(Path.Combine(audioDirectory, "64k500k.wav"));
            Music500k1kk = new SoundPlayer(Path.Combine(audioDirectory, "500k1kk.wav"));
            FinalAnswer = new SoundPlayer(Path.Combine(audioDirectory, "finalanswer.wav"));
            CorrectAnswer = new SoundPlayer(Path.Combine(audioDirectory, "correctanswer.wav"));
            WrongAnswer = new SoundPlayer(Path.Combine(audioDirectory, "wronganswer.wav"));
            PhoneAFriend = new SoundPlayer(Path.Combine(audioDirectory, "phoneafriend.wav"));
        }
        public static AudioService GetInstace()
        {
            if (instance == null)
                instance = new AudioService();

            return instance;
        }

        public void PlayAudio(SoundPlayer soundPlayer)
        {
            LastSound = soundPlayer;

            if (!AudioOn)
                return;

            StopPlaying();
            if(soundPlayer == LetsPlay || soundPlayer == FinalAnswer || soundPlayer == CorrectAnswer || soundPlayer == WrongAnswer)
            {
                soundPlayer.Play();
            }
            else
            {
                soundPlayer.PlayLooping();
            }
        }

        public void PlayAudioAccordingToPriceRange(int questionId)
        {
            if(questionId <= 4)
            {
                PlayAudio(Music1001000);
                return;
            }

            if(questionId <= 9)
            {
                PlayAudio(Music2k32k);
                return;
            }

            if (questionId <= 12)
            {
                PlayAudio(Music64k500k);
                return;
            }

            PlayAudio(Music500k1kk);
        }

        public void StopPlaying()
        {
            if(LastSound != null && LastSound != FinalAnswer && LastSound != CorrectAnswer)
                LastSound.Stop();
        }

        public void ToggleVolume()
        {
            AudioOn = !AudioOn;

            if (!AudioOn)
                StopPlaying();
            else
                LastSound.PlayLooping();
        }
    }
}

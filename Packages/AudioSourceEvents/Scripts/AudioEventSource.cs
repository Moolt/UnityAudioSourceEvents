using System;

namespace AudioSourceEvents
{
    public class AudioEventSource : AudioSourceObserver, IAudioEventSource
    {
        public event EventHandler AudioStarted;
        public event EventHandler AudioResumed;
        public event EventHandler AudioPaused;
        public event EventHandler AudioStopped;
        public event EventHandler<AudioState> Changed;

        protected override void OnAudioStart()
        {
            AudioStarted?.Invoke(this, EventArgs.Empty);
            Changed?.Invoke(this, AudioState.Started);
        }

        protected override void OnAudioResume()
        {
            AudioResumed?.Invoke(this, EventArgs.Empty);
            Changed?.Invoke(this, AudioState.Resumed);
        }

        protected override void OnAudioPaused()
        {
            AudioPaused?.Invoke(this, EventArgs.Empty);
            Changed?.Invoke(this, AudioState.Paused);
        }

        protected override void OnAudioStopped()
        {
            AudioStopped?.Invoke(this, EventArgs.Empty);
            Changed?.Invoke(this, AudioState.Stopped);
        }
    }
}
using System;

namespace AudioSourceEvents.Scripts
{
    public interface IAudioEventSource
    {
        event EventHandler AudioStarted;
        event EventHandler AudioResumed;
        event EventHandler AudioPaused;
        event EventHandler AudioStopped;
        event EventHandler<AudioState> Changed;
    }
}
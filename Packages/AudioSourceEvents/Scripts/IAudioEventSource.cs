using System;

namespace AudioSourceEvents
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
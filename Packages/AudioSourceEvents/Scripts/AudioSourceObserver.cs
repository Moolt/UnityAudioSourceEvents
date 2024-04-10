using System;
using UnityEngine;

namespace AudioSourceEvents
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioSourceObserver : MonoBehaviour
    {
        private AudioSource _audioSource;
        private bool _previousState;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _audioSource.ignoreListenerPause = true;

            HandleState();
        }

        private void Update()
        {
            HandleState();
        }

        private void HandleState()
        {
            if (_audioSource.isPlaying)
            {
                HandlePlaying();
            }
            else
            {
                HandleStopped();
            }

            _previousState = _audioSource.isPlaying;
        }

        private void HandlePlaying()
        {
            if (_previousState)
            {
                return;
            }

            if (AlmostEqual(_audioSource.time, 0f))
            {
                OnAudioStart();
            }
            else
            {
                OnAudioResume();
            }
        }

        private void HandleStopped()
        {
            if (!_previousState)
            {
                return;
            }

            if (AlmostEqual(_audioSource.time, _audioSource.clip.length) || AlmostEqual(_audioSource.time, 0f))
            {
                OnAudioStopped();
            }
            else
            {
                OnAudioPaused();
            }
        }

        protected virtual void OnAudioStart()
        {
            OnAudioChanged(AudioState.Started);
        }

        protected virtual void OnAudioResume()
        {
            OnAudioChanged(AudioState.Resumed);
        }

        protected virtual void OnAudioPaused()
        {
            OnAudioChanged(AudioState.Paused);
        }

        protected virtual void OnAudioStopped()
        {
            OnAudioChanged(AudioState.Stopped);
        }

        protected virtual void OnAudioChanged(AudioState state)
        {
        }

        private bool AlmostEqual(float a, float b)
        {
            return Math.Abs(a - b) < float.Epsilon;
        }
    }
}
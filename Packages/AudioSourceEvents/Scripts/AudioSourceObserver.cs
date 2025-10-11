using System;
using UnityEngine;
using UnityEngine.Audio;

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

            if (IsRandomAudioContainer() || HasNoProgress())
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
            
            if (IsRandomAudioContainer() || HasPlayedToCompletion())
            {
                OnAudioStopped();
            }
            else
            {
                OnAudioPaused();
            }
        }
        
        private static bool AlmostEqual(float a, float b)
        {
            return Math.Abs(a - b) < float.Epsilon;
        }

        private bool IsRandomAudioContainer()
        {
            return _audioSource.clip is null && _audioSource.resource is not null;
        }

        private bool HasNoProgress()
        {
            return AlmostEqual(_audioSource.time, 0f);
        }
        
        private bool HasPlayedToCompletion()
        {
            return AlmostEqual(_audioSource.time, _audioSource.clip.length) || HasNoProgress();
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
    }
}
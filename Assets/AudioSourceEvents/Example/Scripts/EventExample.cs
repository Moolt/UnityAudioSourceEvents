using AudioSourceEvents.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace AudioSourceEvents.Example.Scripts
{
    [RequireComponent(typeof(AudioSource))]
    public class EventExample : MonoBehaviour
    {
        [SerializeField] private Text text;

        private AudioSource _audioSource;
        private IAudioEventSource _eventSource;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            _eventSource = _audioSource.RequestEventHandlers();

            _eventSource.Changed += OnAudioSourceChanged;
        }

        private void OnDestroy()
        {
            _eventSource.Changed -= OnAudioSourceChanged;
        }

        private void OnAudioSourceChanged(object sender, AudioState state)
        {
            text.text = state.ToString();
        }
    }
}
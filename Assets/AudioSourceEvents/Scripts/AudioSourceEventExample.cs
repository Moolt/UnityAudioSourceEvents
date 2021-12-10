using UnityEngine;

namespace AudioSourceEvents.Scripts
{
    public class AudioSourceEventExample : MonoBehaviour
    {
        private void Awake()
        {
            var audioSource = GetComponent<AudioSource>();
            var events = audioSource.RequestEventHandlers();
        
            events.Changed += EventsOnChanged;
        
            audioSource.Play();
        }

        private void EventsOnChanged(object sender, AudioState e)
        {
            Debug.Log(e);
        }
    }
}
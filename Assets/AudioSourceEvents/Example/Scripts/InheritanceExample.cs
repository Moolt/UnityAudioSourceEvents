using AudioSourceEvents.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace AudioSourceEvents.Example.Scripts
{
    public class InheritanceExample : AudioSourceObserver
    {
        [SerializeField] private Text text;

        protected override void OnAudioChanged(AudioState state)
        {
            base.OnAudioChanged(state);

            text.text = state.ToString();
        }
    }
}
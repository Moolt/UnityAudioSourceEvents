using UnityEngine;

public class ExampleButton : MonoBehaviour
{
    private AudioSource _audioSource;
    private Animator _animator;

    private void Start()
    {
        _audioSource = FindObjectOfType<AudioSource>();
        _animator = GetComponent<Animator>();
    }
    
    private void OnMouseDown(){
        _animator.Play("Button");
        
        if (_audioSource.isPlaying)
        {
            _audioSource.Pause();
            return;
        }
        
        _audioSource.Play();
    }   
}

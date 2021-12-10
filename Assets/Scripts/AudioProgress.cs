using UnityEngine;
using UnityEngine.UI;

public class AudioProgress : MonoBehaviour
{
    [SerializeField] private Image progressImage;

    private AudioSource _audioSource;
    private RectTransform _progressTransform;

    private void Start()
    {
        _audioSource = FindObjectOfType<AudioSource>();
        _progressTransform = progressImage.GetComponent<RectTransform>();
    }


    private void Update()
    {
        var progress = _audioSource.time / _audioSource.clip.length;
        SetProgress(progress);
    }

    private void SetProgress(float value)
    {
        _progressTransform.localScale = new Vector3(value, 1f, 1f);
    }
}
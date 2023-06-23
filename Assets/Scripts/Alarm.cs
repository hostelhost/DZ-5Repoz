using System.Collections;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _speedChange;

    private Coroutine _current;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0.0f;
        _speedChange = 0.1f;
    }

    public void EnlargeSound()
    {
        if (_audioSource.isPlaying == false)
            _audioSource.Play();

        if (_current != null)
            StopCoroutine(_current);

        _current = StartCoroutine(ChangingVolume(1.0f));
    }

    public void EeduceSound()
    {
        StopCoroutine(_current);
        _current = StartCoroutine(ChangingVolume(0.0f));

        if (_audioSource.volume == 0.0f)
            _audioSource.Stop();
    }

    private IEnumerator ChangingVolume(float volume)
    {
        while (_audioSource.volume != volume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, volume, _speedChange * Time.deltaTime);
            yield return null;
        }
    }
}

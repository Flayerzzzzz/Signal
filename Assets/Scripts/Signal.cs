using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signal : MonoBehaviour
{
    [SerializeField] private AudioSource _signal;

    private float _maxVolume = 1;
    private float _minVolume = 0;
    private float _volumeChangePerFrame = 0.0005f;

    public void Start()
    {
        StartCoroutine(VolumeChange());
    }

    private IEnumerator VolumeChange()
    {
        if (House.IsSignal == true)
        {
            _signal.Play();
        }

        while (true)
        {
            if (House.IsSignal == true)
            {
                TurnUpVolume(_signal);
            }
            else
            {
                TurnDownVolume(_signal);
            }
            yield return null;
        }
    }

    private void TurnUpVolume(AudioSource audioSource)
    {
        audioSource.volume = Mathf.MoveTowards(_signal.volume, _maxVolume, _volumeChangePerFrame);
    }

    private void TurnDownVolume(AudioSource audioSource)
    {
        audioSource.volume = Mathf.MoveTowards(_signal.volume, _minVolume, _volumeChangePerFrame);
    }
}

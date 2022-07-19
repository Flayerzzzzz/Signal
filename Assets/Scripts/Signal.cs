using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signal : MonoBehaviour
{
    [SerializeField] private AudioSource _signal;

    private float _maxVolume = 1f;
    private float _minVolume = 0f;
    private float _volumeChangePerFrame = 0.0005f;

    public void Start()
    {
        StartCoroutine(VolumeChanger());
    }

    private IEnumerator VolumeChanger()
    {
        while (true)
        {
            if (House.IsInside == true)
            {
                ChangeVolume(_maxVolume);
            }
            else
            {
                ChangeVolume(_minVolume);
            }
            yield return null;
        }

    }

    private void ChangeVolume(float target)
    {
        _signal.volume = Mathf.MoveTowards(_signal.volume, target, _volumeChangePerFrame);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signal : MonoBehaviour
{
    [SerializeField] private AudioSource _signal;
    [SerializeField] private House _house;

    private float _volumeChangePerFrame = 0.0005f;

    private void OnEnable()
    {
        _house._playerEntered += VolumeChanger;
    }

    private void OnDisable()
    {
        _house._playerEntered -= VolumeChanger;
    }

    private void VolumeChanger(bool isInside)
    {
        StopAllCoroutines();

        if (isInside == true)
        {
            StartCoroutine(IncreaseVolume());
        }
        else
        {
            StartCoroutine(DecreaseVolume());
        }
    }

    private IEnumerator IncreaseVolume()
    {
        float maxVolume = 1f;

        while (_signal.volume < maxVolume)
        {
            _signal.volume = Mathf.MoveTowards(_signal.volume, maxVolume, _volumeChangePerFrame);
            yield return null;
        }
    }

    private IEnumerator DecreaseVolume()
    {
        float minVolume = 0f;

        while (_signal.volume > minVolume)
        {
            _signal.volume = Mathf.MoveTowards(_signal.volume, minVolume, _volumeChangePerFrame);
            yield return null;
        }
    }
}

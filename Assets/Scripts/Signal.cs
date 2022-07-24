using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signal : MonoBehaviour
{
    [SerializeField] private AudioSource _signal;
    [SerializeField] private House _house;

    private float _maxVolume = 1f;
    private float _minVolume = 0f;
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

        if (isInside)
            StartCoroutine(ChangeVolume(_maxVolume));
        else
            StartCoroutine(ChangeVolume(_minVolume));
    }

    private IEnumerator ChangeVolume(float target)
    {
        while (_signal.volume != target)
        {
            _signal.volume = Mathf.MoveTowards(_signal.volume, target, _volumeChangePerFrame);
            yield return null;
        }
    }
}

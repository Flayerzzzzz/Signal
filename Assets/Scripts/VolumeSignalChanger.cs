using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeSignalChanger : MonoBehaviour
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
        while (true)
        {
            if (Signal.IsSignal == true)
            {
                _signal.volume = Mathf.MoveTowards(_signal.volume, _maxVolume, _volumeChangePerFrame);
            }
            else
            {
                _signal.volume = Mathf.MoveTowards(_signal.volume, _minVolume, _volumeChangePerFrame);
            }
            yield return null;
        }
    }
}

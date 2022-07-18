using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signal : MonoBehaviour
{
    [SerializeField] private AudioSource _signal;

    private float _target;
    private float _volumeChangePerFrame = 0.0005f;

    public void Start()
    {
        StartCoroutine(VolumeChanger());
    }

    private IEnumerator VolumeChanger()
    {
        while (true)
        {
            if (House.IsSignal == true)
            {
                TurnUpVolume();
            }
            else
            {
                TurnDownVolume();
            }
            yield return null;
        }
    }

    private void TurnUpVolume()
    {
        _target = 1;
        _signal.volume = Mathf.MoveTowards(_signal.volume, _target, _volumeChangePerFrame);
    }

    private void TurnDownVolume()
    {
        _target = 0;
        _signal.volume = Mathf.MoveTowards(_signal.volume, _target, _volumeChangePerFrame);
    }
}

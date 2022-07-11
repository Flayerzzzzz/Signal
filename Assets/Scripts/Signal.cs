using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signal : MonoBehaviour
{
    [SerializeField] private AudioSource _signal;

    private bool _isSignalPlaying;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _signal.Play();
            _isSignalPlaying = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _isSignalPlaying = false;
        }
    }

    public void Update()
    {
        if (_isSignalPlaying == true)
        {
            _signal.volume = Mathf.MoveTowards(_signal.volume, 1, 0.0005f);
        }
        else
        {
            _signal.volume = Mathf.MoveTowards(_signal.volume, 0, 0.0005f);
        }
        if (_signal.volume == 0)
        {
            _signal.Stop();
        }
    }
}

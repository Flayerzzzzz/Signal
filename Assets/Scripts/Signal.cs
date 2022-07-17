using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signal : MonoBehaviour
{
    [SerializeField] private AudioSource _signal;

    public static bool IsSignal { get; private set; }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _signal.Play();
            IsSignal = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        IsSignal = false;
    }
}

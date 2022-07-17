using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{

    public static bool IsSignal { get; private set; }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerMovement>(out PlayerMovement player))
        {
            IsSignal = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        IsSignal = false;
    }
}

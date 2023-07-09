using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class LeaveZone : MonoBehaviour
{
    public UnityEvent OnPlayerEnter;
    public UnityEvent OnPlayerExit;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Character>() == null)
            return;
        OnPlayerEnter.Invoke();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Character>() == null)
            return;

        OnPlayerExit.Invoke();
    }
}

using System;
using UnityEngine;

public class CheckInaction : MonoBehaviour
{
    [SerializeField] private float maxInactionTime;
    private float currentTime = 0;

    public event Action UserIsInactive;

    void Update()
    {
        if (Input.anyKeyDown || Input.touchCount > 0)
        {
            currentTime = 0;
        }
        else
        {
            currentTime += Time.deltaTime;
            if (currentTime >= maxInactionTime)
            {
                UserIsInactive?.Invoke();
                currentTime = 0;
                enabled = false;
            }
        }
    }

    public void ActivateChecking()
    {
        enabled = true;
    }
}

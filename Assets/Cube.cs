using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    float destroyDelay;
    public float DestroyDelay
    {
        set
        {
            destroyDelay = value;
        }
    }
    public void StartDelay()
    {
        Invoke(nameof(Destroy), destroyDelay);
    }
    private void Destroy()
    {
        GameObject.Destroy(gameObject);
    }
}

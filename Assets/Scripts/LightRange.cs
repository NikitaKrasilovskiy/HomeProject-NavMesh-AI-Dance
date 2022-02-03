using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRange : MonoBehaviour
{
    Light lt;
    float duration = 5f;
    void Start()
    {
        lt = GetComponent<Light>();
    }
    void Update()
    {
        var amplitude = Mathf.PingPong(Time.time, duration);
        lt.range = 250 * amplitude;
        if (lt.range < 300)
            amplitude = amplitude / duration * 5f + 1f;
        
        if (lt.range > 300)
            amplitude = amplitude / duration * 5f - 1f;
        
    }
}

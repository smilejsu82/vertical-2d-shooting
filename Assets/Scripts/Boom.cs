using System;
using System.Collections;
using UnityEngine;

public class Boom : MonoBehaviour
{
    public Action onFinishBoom;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(0.25f);
        
        // if (onFinishBoom != null)
        // {
        //     onFinishBoom();
        // }
        onFinishBoom?.Invoke();
    }
}

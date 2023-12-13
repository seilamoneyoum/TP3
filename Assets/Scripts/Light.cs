using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Light : MonoBehaviour
{
    new GameObject light;
    private void Start()
    {
        Transform lightTransform = transform.Find("Light");

        if (lightTransform != null)
        {
            light = lightTransform.gameObject;
            light.SetActive(false);
        }
    }
    public void ChangeLightState()
    {
        if (light.activeSelf == false)
        {
            light.SetActive(true);
        }
        else
        {
            light.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ChangeLight : MonoBehaviour
{
    Light light;
    private void Start()
    {
        Transform lightTransform = transform.Find("Light");

        if (lightTransform != null)
        {
            GameObject lightGameObject = lightTransform.gameObject;
            light = lightGameObject.GetComponent<Light>();
        }
    }
    public void ChangeLightState()
    {
        if (light.isActiveAndEnabled)
        {
            light.enabled = false;
        }
        else
        {
            light.enabled = true;
        }
    }
}

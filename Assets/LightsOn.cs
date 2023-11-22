using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class LightsOn : MonoBehaviour
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CharacterController>() != null)
        {
            light.SetActive(true);
        }
    }
}

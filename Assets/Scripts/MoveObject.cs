using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [SerializeField] private float AddXToMove;
    [SerializeField] private float AddYToMove;
    [SerializeField] private float AddZToMove;
    private bool isInInitialPlace;
    private AudioSource audioSource;

    void Start()
    {
        isInInitialPlace = true; 
        audioSource = GetComponent<AudioSource>();
    }

    public void Move()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();

            if (isInInitialPlace)
            {
                isInInitialPlace = false;
                transform.position = new Vector3(transform.position.x + AddXToMove, transform.position.y + AddYToMove, transform.position.z + AddZToMove);
            }
            else
            {
                isInInitialPlace = true;
                transform.position = new Vector3(transform.position.x - AddXToMove, transform.position.y - AddYToMove, transform.position.z - AddZToMove);
            }
        }
            
    }
}

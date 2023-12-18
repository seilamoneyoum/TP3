using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectEffect : MonoBehaviour
{
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Collect()
    {
        if (!audioSource.isPlaying) StartCoroutine(SoundPlay());

    }

    private IEnumerator SoundPlay()
    {
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        gameObject.SetActive(false);

    }
}

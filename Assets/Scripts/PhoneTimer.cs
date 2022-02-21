using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneTimer : MonoBehaviour
{
    private AudioSource phoneAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        phoneAudioSource = GetComponent<AudioSource>();
        StartCoroutine(DelayedPhone());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DelayedPhone()
    {
        phoneAudioSource.Play();
        yield return new WaitForSeconds(8);
        phoneAudioSource.Stop();
        yield return new WaitForSeconds(15);
        StartCoroutine(DelayedPhone());
    }
}

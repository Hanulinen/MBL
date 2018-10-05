using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {

    [SerializeField]
    AudioSource musicSource;


    void Awake()
    {
        musicSource.Play();
        musicSource.Pause();
    }

    IEnumerator OnTriggerEnter2D(Collider2D target)
    {
        if (target.transform.CompareTag("Player"))
        {
            yield return new WaitForSeconds(0.3f);

            musicSource.Play();
        }
    }
    void OnTriggerExit2D(Collider2D target)
    {
        if (target.transform.CompareTag("Player"))
        {

            musicSource.Pause();
        }
    }
}

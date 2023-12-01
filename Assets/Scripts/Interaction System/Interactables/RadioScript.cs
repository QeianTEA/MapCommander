using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioScript : MonoBehaviour , IAction
{

    private bool activated;

    private AudioSource radio;

    [SerializeField]
    private AudioClip[] songsToPlay;
    [SerializeField]
    private AudioClip clickon;
    [SerializeField]
    private AudioClip[] radioStatic;

    private int n;

    void Start()
    {
        radio = GetComponent<AudioSource>();

        n = Random.Range(0, songsToPlay.Length);
    }

    public void Activate()
    {
        activated = !activated;

        if (activated)
        {
            StartCoroutine(RadioPlay());
        }
        else
        {
            radio.clip = clickon;
            radio.loop = false;
            radio.Play();
        }
    }

    IEnumerator RadioPlay()
    {
        radio.clip = clickon;
        radio.Play();

        yield return new WaitForSeconds(0.02f);

        int m = Random.Range(0, radioStatic.Length);
        radio.clip = radioStatic[m];
        radio.Play();


        float b  = Random.Range(0.1f, 1f);
        yield return new WaitForSeconds(b);

        n++;
        if (n == songsToPlay.Length)
            n = 0;

        radio.clip = songsToPlay[n];

        radio.loop = true;
        radio.Play();
    }
}

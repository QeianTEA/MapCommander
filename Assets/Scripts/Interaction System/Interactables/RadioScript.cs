using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioScript : MonoBehaviour , IAction
{

    private bool activated;

    private AudioSource radio;

    [SerializeField]
    private AudioClip[] songsToPlay;

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
            n++;
            if (n == songsToPlay.Length)
                n = 0;

            radio.clip = songsToPlay[n];

            radio.Play();
        }
        else
        {
            radio.Stop();
        }
    }
}

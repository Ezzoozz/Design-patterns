using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    Queue<int> audioTracks = new Queue<int>();

    CollisionHandler collisionHandler;

    AudioSource audioSource;

    [SerializeField] AudioClip auddioClip1;

    [SerializeField] AudioClip auddioClip2;

    [SerializeField] AudioClip auddioClip3;

    int count = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        collisionHandler = FindObjectOfType<CollisionHandler>();

        collisionHandler.Collided += CollisionHandler_Collided;
    }

    private void OnDisable()
    {
        collisionHandler.Collided -= CollisionHandler_Collided;
    }
    private void CollisionHandler_Collided(int obj)
    {
       int random =  Random.Range(1, 3);

        audioTracks.Enqueue(random);

    }

     void PlayAudio(int random)
    {

        if (random == 1)
            audioSource.PlayOneShot(auddioClip1);

        else if (random == 2)
            audioSource.PlayOneShot(auddioClip2);

        else if (random == 3)
            audioSource.PlayOneShot(auddioClip3);

        count++;
        Debug.Log(count + "Audio hs been played");
    }

    private void Update()
    {
        ProcessAudioSources();

        
    }

     void ProcessAudioSources()
    {
        if (audioTracks.Count < 1) return;

        if (audioSource.isPlaying) return;

        PlayAudio(audioTracks.Dequeue());

    }


}

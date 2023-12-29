using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance {  get; private set; }
    private void Awake()
    {
        instance = this;
    }

    public AudioClip birdCollision;
    public AudioClip birdSelect;
    public AudioClip birdFlying;
    public AudioClip[] pigCollisions;
    public AudioClip woodCollision;
    public AudioClip woodDestoryed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayBirdCollision(Vector3 position)
    {
        AudioSource.PlayClipAtPoint(birdCollision, position,1f);
    }
    public void PlayBirdSelect(Vector3 position)
    {
        AudioSource.PlayClipAtPoint(birdSelect, position, 1f);
    }
    public void PlayBirdFlying(Vector3 position)
    {
        AudioSource.PlayClipAtPoint(birdFlying, position, 1f);
    }
    public void PlayPigCollision(Vector3 position)
    {
        int index = Random.Range(0, pigCollisions.Length);
        AudioClip ac = pigCollisions[index];
        AudioSource.PlayClipAtPoint(ac, position, 1f);
    }
    public void PlayWoodCollision(Vector3 position)
    {
        AudioSource.PlayClipAtPoint(woodCollision, position, .6f);
    }
    public void PlayWoodDestoryed(Vector3 position)
    {
        AudioSource.PlayClipAtPoint(woodDestoryed, position, .3f);
    }
}

using UnityEngine;

public class Musicsounds : MonoBehaviour
{
    [Header("audio source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("audio clip")]
    public AudioClip background;
    public AudioClip JumpingSoundEffect;
    public AudioClip DeathSoundEffect;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }


}

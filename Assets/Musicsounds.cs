using UnityEngine;

public class Musicsounds : MonoBehaviour
{
    [Header("audio source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("audio clip")]
    public AudioClip background;
    public AudioClip Jumpingsound;
    public AudioClip Deathsound;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

}

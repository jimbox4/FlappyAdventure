using UnityEngine;

public class AudioSourceCreater : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;
    [SerializeField, Range(0,1)] private float _volume;

    public void Create()
    {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.clip = _clip;
        audioSource.playOnAwake = false;
        audioSource.volume = _volume;

        audioSource.Play();

        Destroy(audioSource, _clip.length);
    }
}

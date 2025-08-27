using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newAudioPack", menuName = "ScriptableObject/AudioPack")]
public class AudioPack : ScriptableObject
{
    // Start is called before the first frame update
    [SerializeField] private AudioClip[] m_clips;
    public AudioClip[] g_clips { get { return m_clips; } }

    [Range(0.0f, 2.0f)]
    public float minPitch = 0.8f;

    [Range(0.0f, 2.0f)]
    public float maxPitch = 1.2f;

    [Range(0.0f, 1.0f)]
    public float volume = 1f;

    public void PlayOn(AudioSource audio)
    {
        audio.clip = m_clips[Random.Range(0, m_clips.Length)];
        audio.pitch = Random.Range(minPitch, maxPitch);
        audio.volume = volume;
        audio.Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
namespace Survival.Demo
{
    public class RandomAudioPlayer : MonoBehaviour
    {
        public AudioClip[] audioClips;

        public void playRandomClip()
        {
            AudioClip clipToPlay = audioClips[Random.Range(0, audioClips.Length)];
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.clip = clipToPlay;
            audioSource.Play();
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace Survival.Demo
{
    public class AudioPlayer : MonoBehaviour
    {
        private AudioSource audioSource;
        private string audioTimeKey = "AudioTime";

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
            if (PlayerPrefs.HasKey(audioTimeKey))
            {
                audioSource.time = PlayerPrefs.GetFloat(audioTimeKey);
            }
            audioSource.Play();
        }

        private void OnApplicationQuit()
        {
            PlayerPrefs.SetFloat(audioTimeKey, audioSource.time);
        }



    }
}
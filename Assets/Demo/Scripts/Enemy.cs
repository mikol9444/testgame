using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Survival.Demo
{
    public class Enemy : MonoBehaviour
    {

        public float maxhealth = 100f;
        public float currenthealth = 0f;


        public Slider slider;
        public GameObject canvas;
        public RandomAudioPlayer audioPlayer;
        private void OnEnable()
        {
            currenthealth = maxhealth;
            slider.value = 1f;
            canvas.SetActive(false);
        }
        public void TakeDamage(float dmg)
        {
            audioPlayer.playRandomClip();
            canvas.SetActive(true);
            StopCoroutine(nameof(TurnOffCanver));
            currenthealth -= dmg;
            slider.value = currenthealth / maxhealth;
            if (currenthealth <= 0)
            {
                gameObject.SetActive(false);
                return;

            }
            StartCoroutine(nameof(TurnOffCanver));
        }
        private IEnumerator TurnOffCanver()
        {
            yield return new WaitForSeconds(5.0f);
            canvas.SetActive(false);
        }
    }
}
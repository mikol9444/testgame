using System;
using System.Collections;
using System.Collections.Generic;
using Survival.Demo;
using UnityEngine;
namespace Survival.Demo
{
    public class Player : MonoBehaviour
    {
        public static Player Instance;
        public FloatingJoystick joystick;
        public PlayerCollider coll;
        public Transform tr;
        public AnimationController anim;
        public RandomAudioPlayer audioPlayer;

        private void Awake()
        {

            if (Instance != null)
            {
                Destroy(this);
                return;
            }
            Instance = this;
            if (coll == null)
            {
                coll = GetComponentInChildren<PlayerCollider>();
            }
            if (joystick == null)
            {
                joystick = FindObjectOfType<FloatingJoystick>();
            }
            if (anim == null)
            {
                anim = GetComponentInChildren<AnimationController>();
            }

            tr = transform;
        }
        private void Start()
        {
            coll.enemyCollision += collide;
        }
        private void collide(bool collided)
        {
            audioPlayer.playRandomClip();
            Debug.Log("Collision detected!");
        }


    }
}
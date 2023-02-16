using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
namespace Survival.Demo
{
    public class PlayerCollider : MonoBehaviour
    {
        public Action<bool> enemyCollision;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                enemyCollision?.Invoke(true);
            }
        }
    }
}


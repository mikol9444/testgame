using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Survival.Demo
{
    public class Shooter : MonoBehaviour
    {
        public float scanRadius = 5f;
        public LayerMask enemyMask;
        public float detectionFrequency = 1f;

        private float lastDetectionTime;
        public GameObject projectilePrefab;
        public RandomAudioPlayer audioPlayer;
        private void Update()
        {
            if (Time.time - lastDetectionTime >= detectionFrequency)
            {
                lastDetectionTime = Time.time;
                Transform enemy = GetClosestEnemy();
                if (enemy != null)
                {
                    GameObject obj = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                    obj.GetComponent<Projectile>().target = enemy;
                    audioPlayer.playRandomClip();
                }
            }
        }
        public Transform GetClosestEnemy()
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, scanRadius, enemyMask);

            if (hitColliders.Length == 0)
            {
                return null;
            }

            Transform closestEnemy = hitColliders[0].transform;
            float shortestDistance = Vector3.Distance(transform.position, closestEnemy.position);

            for (int i = 1; i < hitColliders.Length; i++)
            {
                Transform enemy = hitColliders[i].transform;
                float distance = Vector3.Distance(transform.position, enemy.position);

                if (distance < shortestDistance)
                {
                    closestEnemy = enemy;
                    shortestDistance = distance;
                }
            }

            return closestEnemy;
        }

        private Transform ScanForEnemies()
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, scanRadius, enemyMask);

            foreach (Collider collider in hitColliders)
            {
                return collider.transform;
            }
            return null;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, scanRadius);
        }
    }
}
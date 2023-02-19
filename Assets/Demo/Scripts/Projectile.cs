using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Survival.Demo
{
    public class Projectile : MonoBehaviour
    {
        public float speed = 10f;
        public float damage = 50f;
        public Transform target;
        public AnimationCurve movementCurve;
        public bool condition = false;
        public float distanceThreshold = 0.25f;
        public Vector3 adjustheight = new Vector3(0, 1, 0);
        private void Start()
        {
            StartCoroutine(nameof(MyCoroutine), 1.0f);
        }
        private void startRoutine()
        {

        }
        private IEnumerator MyCoroutine()
        {
            transform.LookAt(target);
            while (!condition)
            {
                //Debug.Log("Coroutine running...");

                if (target == null)
                {
                    //Destroy(gameObject);
                    yield return new WaitForSeconds(0.25f);
                }

                Vector3 direction = (target.position - transform.position).normalized;
                float distanceThisFrame = speed * Time.deltaTime;
                float curveEvaluation = movementCurve.Evaluate(distanceThisFrame / direction.magnitude);

                if (Vector3.Distance(transform.position, target.position + adjustheight) <= distanceThreshold)
                {
                    HitTarget();
                    condition = true;
                    Destroy(gameObject);
                }
                transform.position = Vector3.Lerp(transform.position, target.position + adjustheight, curveEvaluation);

                yield return new WaitForEndOfFrame();
            }

            //Debug.Log("Coroutine ended");
        }
        private void HitTarget()
        {
            target.GetComponent<Enemy>().TakeDamage(damage);

        }
    }
}
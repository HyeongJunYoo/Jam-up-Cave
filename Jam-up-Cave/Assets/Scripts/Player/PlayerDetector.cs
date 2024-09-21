using System;
using UnityEngine;

namespace Player
{
    public class PlayerDetector : MonoBehaviour
    {
        private LayerMask _enemyLayer;
        private Collider[] EnemiesCollider { get; set; }

        public float AttackRange { get; private set; }

        private void Awake()
        {
            EnemiesCollider = new Collider[10];
            _enemyLayer = LayerMask.GetMask("Enemy");
            AttackRange = 5.0f;
        }
        
        public bool IsEnemyDetected()
        {
            return Physics.OverlapSphereNonAlloc(transform.position, AttackRange, EnemiesCollider, _enemyLayer) > 0;
        }
        
        public GameObject GetClosestEnemy()
        {
            Collider closestEnemy = null;
            var minDistanceSqr = float.MaxValue;
            
            var enemyCount = Physics.OverlapSphereNonAlloc(transform.position, AttackRange, EnemiesCollider, _enemyLayer);
            
            for (var i = 0; i < enemyCount; i++)
            {
                var col = EnemiesCollider[i];
                if (col == null) continue;

                var directionToEnemy = col.transform.position - transform.position;
                var distanceSqr = directionToEnemy.sqrMagnitude;

                if (distanceSqr < minDistanceSqr)
                {
                    minDistanceSqr = distanceSqr;
                    closestEnemy = col;
                }
            }

            return closestEnemy?.gameObject;
        }
        

#if UNITY_EDITOR
        public void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;   
            Gizmos.DrawWireSphere(transform.position, AttackRange);
        }
#endif
    }
}

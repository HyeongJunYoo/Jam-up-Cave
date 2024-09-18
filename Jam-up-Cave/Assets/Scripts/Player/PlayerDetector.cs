using System;
using UnityEngine;

namespace Player
{
    public class PlayerDetector : MonoBehaviour
    {
        private LayerMask _enemyLayer;
        public Collider[] EnemiesCollider { get; private set; }

        public float AttackRange { get; private set; }

        private void Awake()
        {
            EnemiesCollider = new Collider[10];
            _enemyLayer = LayerMask.GetMask("Enemy");
            AttackRange = 5.0f;
        }

        public bool IsEnemyDetected()
        {
            var enemyCount = Physics.OverlapSphereNonAlloc(transform.position, AttackRange, EnemiesCollider, _enemyLayer);
            
            return enemyCount > 0;
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

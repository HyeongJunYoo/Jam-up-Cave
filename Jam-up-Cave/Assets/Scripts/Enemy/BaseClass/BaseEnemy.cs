using Enemy.Data;
using UnityEngine;

namespace Enemy.BaseClass
{
    public abstract class BaseEnemy : MonoBehaviour
    { 
        public abstract EnemyData EnemyData { get; set; }
    }
}

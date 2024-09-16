using Enemy.BaseClass;
using Enemy.Interface;

namespace Enemy
{
    public class EnemySmallSpider : BaseEnemy, IMovable, IDamageable
    {
        public override string Name { get; set; }
        
        public float MoveSpeed { get; set; }
        public float Health { get; set; }
        
        public void TakeDamage(float damage)
        {
            
        }
    }
}

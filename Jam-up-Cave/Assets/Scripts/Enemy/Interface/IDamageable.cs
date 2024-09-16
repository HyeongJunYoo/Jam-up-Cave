namespace Enemy.Interface
{
    public interface IDamageable
    {
        public float Health { get; set; }
        
        public void TakeDamage(float damage);
    }
}

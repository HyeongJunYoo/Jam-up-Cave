namespace Enemy.Interface
{
    public interface IDamageable
    {
        public int CurrentHp { get; set; }
        public bool IsDamaged { get; set; }

        public void TakeDamage(int damage);
        public void Die(); 
    }
}

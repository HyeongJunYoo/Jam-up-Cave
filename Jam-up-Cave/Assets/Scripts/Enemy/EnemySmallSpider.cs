using System.Threading;
using Cysharp.Threading.Tasks;
using Enemy.BaseClass;
using Enemy.Data;
using Enemy.Interface;
using UnityEngine;

namespace Enemy
{
    public class EnemySmallSpider : BaseEnemy, IMovable, IDamageable
    {
        [SerializeField] private EnemyData enemyData;
        public override EnemyData EnemyData
        {
            get => enemyData;
            set => enemyData = value;
        }

        public override string Name { get; set; }
        public float MoveSpeed { get; set; }
        public float Health { get; set; }
        
        
        ////Test Code : Hit 시각적으로 보여주기 위한 색
        public Renderer enemyRenderer;
        private CancellationTokenSource _colorChangeCts;  // 취소 토큰 소스 추가

        private async UniTask ChangeColor(Color color, CancellationToken token = default)
        {
            enemyRenderer.material.color = color;
            await UniTask.WaitForSeconds(0.1f, cancellationToken: token);
            enemyRenderer.material.color = Color.white;
        }
        private void Awake()
        {
            Name = EnemyData.enemyName;
            MoveSpeed = EnemyData.speed;
            Health = EnemyData.health;
            _colorChangeCts = new CancellationTokenSource();
        }
        
        public void TakeDamage(float damage)
        {
            Health -= damage;
           
            _colorChangeCts.Cancel();  // 이전에 실행 중인 작업을 취소
            _colorChangeCts = new CancellationTokenSource();  // 새로운 취소 토큰 소스 생성
            
            ChangeColor(Color.red, _colorChangeCts.Token).Forget();  // Forget 메서드로 예외 처리
            Debug.Log(name + " took " + damage + " damage. Remaining Health: " + Health);
            
            if (Health <= 0)
            {
                _colorChangeCts.Cancel();
                Die();
            }
        }
        
        public void Move()
        {
            Debug.Log("Moving...");
        }
        
        private void Die()
        {
            Debug.Log("Dying...");
            Destroy(gameObject);
        }
    }
}

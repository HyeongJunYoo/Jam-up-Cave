using System.Threading;
using Cysharp.Threading.Tasks;
using Enemy.BaseClass;
using Enemy.Data;
using Enemy.Interface;
using StateMachine.EnemyState.SmallSpider;
using UnityEngine;

namespace Enemy.SmallSpider
{
    public class EnemySmallSpiderController : BaseEnemy, IMovable, IDamageable
    {
        public EnemySmallSpiderStateMachine StateMachine { get; private set; }
        
        [SerializeField] private EnemyData enemyData;
        public override EnemyData EnemyData
        {
            get => enemyData;
            set => enemyData = value;
        }

        public int CurrentHp { get; set; }
        public bool IsDamaged { get; set; }

        
        ////Test Code : Hit 시각적으로 보여주기 위한 색
        public Renderer enemyRenderer;
        private CancellationTokenSource _colorChangeCts;  // 취소 토큰 소스 추가
        private async UniTask ChangeColorAsync(Color color, CancellationToken token = default)
        {
            enemyRenderer.material.color = color;
            await UniTask.WaitForSeconds(0.1f, cancellationToken: token);
            enemyRenderer.material.color = Color.white;
        }
        
        public void ChangeColor(Color color)
        {
            enemyRenderer.material.color = color;
        }

        public void Awake()
        { 
            StateMachine = new EnemySmallSpiderStateMachine(this);
            _colorChangeCts = new CancellationTokenSource();
            
            CurrentHp = EnemyData.health;
            IsDamaged = false;
        }
        
        public void Start()
        {
            StateMachine.Initialize(StateMachine.SmallSpiderIdleState);
        }
        
        public void Update()
        {
            StateMachine.Update();
        }
        
        public void FixedUpdate()
        {
            StateMachine.FixedUpdate();
        }

        public void TakeDamage(int damage)
        {
            CurrentHp -= damage;
           
            IsDamaged = true;
            _colorChangeCts.Cancel();  // 이전에 실행 중인 작업을 취소
            _colorChangeCts = new CancellationTokenSource();  // 새로운 취소 토큰 소스 생성
            
            ChangeColorAsync(Color.red,  _colorChangeCts.Token).Forget();  // Forget 메서드로 예외 처리
            Debug.Log(name + " took " + damage + " damage. Remaining Health: " + CurrentHp);

            if (!(CurrentHp <= 0)) return;
            
            _colorChangeCts.Cancel();
            Die();
        }
        
        public void Move()
        {
            Debug.Log("Moving...");
        }
        
        public void Die()
        {
            Debug.Log("Dying...");
            Destroy(gameObject);
        }
    }
}

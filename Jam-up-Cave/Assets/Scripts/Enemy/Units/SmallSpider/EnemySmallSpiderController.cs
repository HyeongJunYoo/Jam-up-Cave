using Enemy.BaseClass;
using Enemy.Data;
using StateMachine.EnemyState.SmallSpider;
using UnityEngine;

namespace Enemy.Units.SmallSpider
{
    public class EnemySmallSpiderController : BaseEnemy
    {
        public EnemySmallSpiderMovement movement;
        public EnemySmallSpiderDamaged damaged;
        
        public EnemySmallSpiderStateMachine StateMachine { get; private set; }
        
        [SerializeField] private EnemyData enemyData;
        public override EnemyData EnemyData
        {
            get => enemyData;
            set => enemyData = value;
        }

        public void Awake()
        { 
            StateMachine = new EnemySmallSpiderStateMachine(this);
        }
        
        public void Start()
        {
            movement = GetComponent<EnemySmallSpiderMovement>();
            damaged = GetComponent<EnemySmallSpiderDamaged>();

            Initialize();
        }
        
        private void Initialize()
        {
            movement.SetSpeed(EnemyData.speed);
            damaged.CurrentHp = EnemyData.health;
            
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
    }
}

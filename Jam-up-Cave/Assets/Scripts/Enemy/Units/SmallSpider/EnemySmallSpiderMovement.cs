using Enemy.Interface;
using Manager;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy.Units.SmallSpider
{
    public class EnemySmallSpiderMovement : MonoBehaviour, IMovable
    {
        private NavMeshAgent _agent;    // NavMeshAgent 컴포넌트
        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
        }
        
        public void SetSpeed(float speed)
        {
            _agent.speed = speed;
        }

        public void Move()
        {
            _agent.SetDestination(transform.position + transform.forward * 5f);  // 현재 위치에서 앞으로 5만큼 이동
        }
        
        public void Flee()
        {
            var playerTransform = PlayerManager.Instance.PlayerTransform;
            
            // 플레이어로부터 도망치기 위한 방향 계산
            var directionAwayFromPlayer = transform.position - playerTransform.position;
    
            // 방향 벡터를 정규화 (길이를 1로 만듦)
            directionAwayFromPlayer.Normalize();
    
            // 현재 위치에서 플레이어로부터 멀어지는 방향으로 일정 거리 이동 (예: 10 유닛)
            var fleePosition = transform.position + directionAwayFromPlayer;
            
            // NavMeshAgent를 사용하여 도망칠 위치로 이동
            _agent.SetDestination(fleePosition);
        }
    }
}

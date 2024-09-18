using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Player
{
    public class PlayerAttack : MonoBehaviour
    {
        public float AttackCoolDown { get; private set; }
        public float ReloadTime { get; private set; }
        public float Damage { get; private set; }
        
        public int TotalBullet { get; private set; }
        public int BulletsRemaining { get; private set; }

        public bool IsAttacking { get; private set; }
        public bool IsReloading { get; private set; }
       
        
        private void Awake()
        {
            AttackCoolDown = 1f;
            ReloadTime = 1.5f;
            Damage = 10;
            TotalBullet = 10;
            BulletsRemaining = TotalBullet;
            
            IsAttacking = false;
            IsReloading = false;
        }
        
        public async UniTask Attack()
        {
            IsAttacking = true;
            
            BulletsRemaining--;
            Debug.Log("Attacking - Bullets Remaining: " + BulletsRemaining + " / " + TotalBullet);
            
            await UniTask.Delay(TimeSpan.FromSeconds(AttackCoolDown)); // 발사 간의 딜레이
            
            if (BulletsRemaining <= 0)
            {
                await Reload();
            }
            else
            {
                IsAttacking = false;
            }
        }

        public async UniTask Reload()
        {
            Debug.Log("Reloading...");
            IsAttacking = false;
            IsReloading = true;

            await UniTask.Delay(TimeSpan.FromSeconds(ReloadTime)); // 장전 시간 대기
            BulletsRemaining = TotalBullet; // 총알 재장전

            Debug.Log("Reloading Complete!");
            IsReloading = false;
        }
        
    }
}

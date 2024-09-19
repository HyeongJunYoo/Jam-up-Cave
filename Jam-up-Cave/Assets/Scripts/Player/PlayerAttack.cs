using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Player
{
    public class PlayerAttack : MonoBehaviour
    {
        public float AttackCooldown { get; private set; }
        public float ReloadTime { get; private set; }
        public float Damage { get; private set; }
        
        public int TotalAmmo { get; private set; }
        public int CurrentAmmo { get; private set; }

        public bool IsAttacking { get; private set; }
        public bool IsReloading { get; private set; }
       
        
        private void Awake()
        {
            AttackCooldown = 1f;
            ReloadTime = 1.5f;
            Damage = 10;
            TotalAmmo = 10;
            CurrentAmmo = TotalAmmo;
            
            IsAttacking = false;
            IsReloading = false;
        }
        
        private async UniTask AttackAsync()
        {
            IsAttacking = true;
            CurrentAmmo--;
            Debug.Log($"Attacking - Ammo Remaining: {CurrentAmmo} / {TotalAmmo}");

            // 발사 후 쿨다운 대기
            await UniTask.Delay(TimeSpan.FromSeconds(AttackCooldown));
            IsAttacking = false;

            if (CurrentAmmo <= 0)
            {
                await ReloadAsync();
            }
        }

        private async UniTask ReloadAsync()
        {
            IsReloading = true;
            Debug.Log("Reloading...");

            // 장전 시간 대기
            await UniTask.Delay(TimeSpan.FromSeconds(ReloadTime));

            // 총알 재장전
            CurrentAmmo = TotalAmmo;
            Debug.Log("Reload Complete!");
            IsReloading = false;
        }
        
        private async UniTask AttackOrReloadAsync()
        {
            if (CurrentAmmo > 0)
            {
                await AttackAsync();
            }
            else
            {
                await ReloadAsync();
            }
        }
        
        public void Attack()
        {
            if (IsAttacking || IsReloading) return;
            
            AttackOrReloadAsync().Forget();
        }
    }
}

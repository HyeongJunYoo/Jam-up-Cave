using UnityEngine;

namespace Manager
{
    public class PlayerManager : SingletonBehaviour<PlayerManager>
    {
        [SerializeField] private Transform playerTransform;

        public Transform PlayerTransform
        {
            get => playerTransform;
            private set => playerTransform = value;
        }
    }
}

using StateMachine.PlayerState;
using UnityEngine;

namespace StateMachine
{
    public class Player : MonoBehaviour
    {
        public CharacterController CharacterController { get; private set; }
        public PlayerStateMachine StateMachine { get; private set; }

        private void Awake()
        {
            CharacterController = GetComponent<CharacterController>();
            StateMachine = new PlayerStateMachine(this);
        }
    }
}

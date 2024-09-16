using System;
using StateMachine.PlayerState;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerInput), typeof(PlayerMovement))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private PlayerMovement playerMovement;
        
        public CharacterController CharacterController { get; private set; }
        public PlayerStateMachine StateMachine { get; private set; }
        

        private void Awake()
        {
            StateMachine = new PlayerStateMachine(this);
        }
        
        private void Start()
        {
            CharacterController = GetComponent<CharacterController>();            
            playerInput = GetComponent<PlayerInput>();
            playerMovement = GetComponent<PlayerMovement>();
            
            StateMachine.Initialize();
        }
        
        private void Update()
        {
            StateMachine.Update();
            playerMovement.MoveCharacter();
        }

        private void FixedUpdate()
        {
            playerMovement.CalculateNextFixedPosition(playerInput.MoveInput);
        }
    }
}

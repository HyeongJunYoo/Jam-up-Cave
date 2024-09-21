using StateMachine.PlayerState;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(PlayerMovement))]
    [RequireComponent(typeof(PlayerAttack))]
    [RequireComponent(typeof(PlayerDetector))]
    public class PlayerManager : MonoBehaviour
    {
        public PlayerInput playerInput;
        public PlayerMovement playerMovement;
        public PlayerAttack playerAttack;
        public PlayerDetector playerDetector;
        
        public CharacterController CharacterController { get; private set; }
        public PlayerStateMachine StateMachine { get; private set; }
        
        //Test Code : State 변경 시각적으로 보여주기 위한 색
        public Renderer playerRenderer;
        public void ChangeColor(Color color)
        {
            playerRenderer.material.color = color;
        }
        
        private void Awake()
        {
            StateMachine = new PlayerStateMachine(this);
        }
        
        private void Start()
        {
            CharacterController = GetComponent<CharacterController>();            
            playerInput = GetComponent<PlayerInput>();
            playerMovement = GetComponent<PlayerMovement>();
            playerAttack = GetComponent<PlayerAttack>();
            playerDetector = GetComponent<PlayerDetector>();
            
            StateMachine.Initialize();
        }
        
        private void Update()
        {
            StateMachine.Update();
        }

        private void FixedUpdate()
        {
            StateMachine.FixedUpdate();
        }
    }
}

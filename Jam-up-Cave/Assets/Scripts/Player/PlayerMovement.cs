using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private CharacterController _characterController;
        private Transform _movementDirection;
        private Vector3 _lastFixedPosition;
        private Vector3 _nextFixedPosition;
        private Vector3 _velocity;

        private const float Speed = 5.0f;
        
        private void Awake()
        {
            _movementDirection = transform;
        }

        private void Start()
        {
            _characterController = GetComponent<CharacterController>();
        }
        
        public void MoveCharacter()
        {
            var interpolationAlpha = (Time.time - Time.fixedTime) / Time.fixedDeltaTime;
            _characterController.Move(Vector3.Lerp(_lastFixedPosition, _nextFixedPosition, interpolationAlpha) - transform.position);
        }
        
        public void CalculateNextFixedPosition(Vector2 moveInput)
        {
            _lastFixedPosition = _nextFixedPosition;

            var planeVelocity = GetXZVelocity(moveInput.x, moveInput.y);
            _velocity = new Vector3(planeVelocity.x, 0, planeVelocity.z);

            _nextFixedPosition += _velocity * Time.fixedDeltaTime;
        }
        
        /// <summary>
        /// 대각선 이동에서도 일정한 속도로 이동하기 위해 x, z축의 속도를 계산합니다.
        /// </summary>
        /// <param name="horizontalInput"></param>
        /// <param name="verticalInput"></param>
        /// <returns></returns>
        private Vector3 GetXZVelocity(float horizontalInput, float verticalInput)
        {
            var moveVelocity = _movementDirection.forward * verticalInput + _movementDirection.right * horizontalInput;
            var moveDirection = moveVelocity.normalized;
            var moveSpeed = Mathf.Min(moveVelocity.magnitude, 1.0f) * Speed;

            return moveDirection * moveSpeed;
        }
    }
}

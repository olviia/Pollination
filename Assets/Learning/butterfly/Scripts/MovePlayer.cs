using UnityEngine;
using UnityEngine.InputSystem;

namespace Platformer
{
    public class MovePlayer : MonoBehaviour
    {
        [SerializeField] private InputActionReference leftMoveAction;
        [SerializeField] private InputActionReference rightMoveAction;

        public float speed = 5f;
    
        void OnEnable()
        {
            leftMoveAction.action.Enable();
            rightMoveAction.action.Enable();
        }
    
        void OnDisable()
        {
            leftMoveAction.action.Disable();
            rightMoveAction.action.Disable();
        }
    
        void Update()
        {
            Vector2 leftStick = leftMoveAction.action.ReadValue<Vector2>();
            Vector2 rightStick = rightMoveAction.action.ReadValue<Vector2>();
        
            // Move butterfly based on input
            Vector3 movement = new Vector3(leftStick.x, rightStick.y, leftStick.y) * speed * Time.deltaTime;
            transform.Translate(movement);
        }
    }
}

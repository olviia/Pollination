using UnityEngine;

namespace fpv
{
    public class KeyboardInputSource : IInputSource
    
    {
        public event System.Action<IInputSource> OnBecameActive;

        public FlightInput GetInput()
        {
            float throttleDirection = 0f;
            if (Input.GetKey(KeyCode.W)) throttleDirection = 1f;
            if (Input.GetKey(KeyCode.S)) throttleDirection = -1f;
    
            float yaw = 0f;
            if (Input.GetKey(KeyCode.A)) yaw = -1f;
            if (Input.GetKey(KeyCode.D)) yaw = 1f;
            
            float pitch = 0f;
            if (Input.GetKey(KeyCode.UpArrow)) pitch = 1f;
            if (Input.GetKey(KeyCode.DownArrow)) pitch = -1f;
    
            float roll = 0f;
            if (Input.GetKey(KeyCode.LeftArrow)) roll = -1f;
            if (Input.GetKey(KeyCode.RightArrow)) roll = 1f;
            
            // Fire event if any input detected
            if (throttleDirection != 0 || yaw != 0 || pitch != 0 || roll != 0)
            {
                OnBecameActive?.Invoke(this);
            }
    
            return new FlightInput(throttleDirection, yaw, pitch, roll);
        }

        void Update()
        {

        }

    }
}

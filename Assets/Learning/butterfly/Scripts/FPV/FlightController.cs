using Platformer;
using Unity.Android.Gradle.Manifest;
using UnityEngine;

namespace fpv
{
    public class FlightController : MonoBehaviour
    {
        [SerializeField] private InputManager inputManager;
        [SerializeField] private Rigidbody playerRigidbody;

        private float currentThrottlePercent = 50f; // Start at hover
        private float maxThrust; // We'll calculate this
        public float throttleSpeed = 2f; // 0 to 100% in 2 seconds
  
        void Start()
        {
            // Calculate what 100% throttle force should be
            maxThrust = playerRigidbody.mass * 9.81f * 2f; // 2:1 ratio
        }
        void FixedUpdate()
        {
            FlightInput input = inputManager.GetFlightInput();


            // Determine target throttle based on input
             
            
             float   targetThrottle = 50f + (input.throttle * 50f); // 50% to 0%
    
            // Move current throttle toward target at 50% per second
            currentThrottlePercent = Mathf.MoveTowards(currentThrottlePercent, targetThrottle,  0.5f * Time.fixedDeltaTime);

            // Clamp between 0 and 100
            currentThrottlePercent = Mathf.Clamp(currentThrottlePercent, 0f, 100f);
            Debug.Log($"throttle: {currentThrottlePercent}");

            Vector3 thrustForce = transform.up * (currentThrottlePercent / 100f) * maxThrust;
            
            Debug.Log($"gravity force: {playerRigidbody.mass * Physics.gravity}");
            Debug.Log($"force: {playerRigidbody.velocity}");

            playerRigidbody.AddForce(thrustForce);

            if (currentThrottlePercent == 50)
            {
                //playerRigidbody.velocity = (playerRigidbody.velocity.x, 0f, playerRigidbody.velocity.z);
            }
            

        }
    }
}

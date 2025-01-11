using UnityEngine;

namespace DefaultNamespace
{
    public class Ball : MonoBehaviour
    {
        // Control variable
        public bool direction = true;
        public float flightTime = 1.5f;
        public float distance = 10f;
        public float speed = 10f;
        public float gravityScale = 1f;
    
        // Ball object
        private Rigidbody rb;

        public void Start()
        {
            rb = GetComponent<Rigidbody>();
        }
        public void Update()
        {
            Movement();
        }

        private void OnCollisionEnter(Collision collision)
        {
                Debug.Log("Collision");
                HitBall();
        }

        public void HitBall()
        {
            // Revert the forward direction
            direction = !direction;

            // Extract the velocity in the forward direction
            float forwardVelocity = (direction ? 1 : -1) * distance / flightTime;

            // Extract the velocity in the right direction
            float rightVelocity = 0f;

            // Extract the velocity in the up direction
            float upVelocity = (9.81f * flightTime) / 2.0f;

            // Output the velocities for debugging
            Debug.Log("Forward Velocity: " + forwardVelocity);
            Debug.Log("Right Velocity: " + rightVelocity);
            Debug.Log("Up Velocity: " + upVelocity);
            
            // Update ball velocity
            rb.linearVelocity = transform.forward * forwardVelocity + transform.right * rightVelocity + transform.up * upVelocity;
        }
        
        private void Movement()
        {
            rb.position = rb.position + speed * Time.deltaTime * rb.linearVelocity;
        }
        
        public void ApplyForce(Vector3 force)
        {
            rb.AddForce(force);
        }
    }
}

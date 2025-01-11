using System;
using UnityEngine;

namespace DefaultNamespace {
    public class Player : MonoBehaviour {
        public Transform Transform;
        public BoxCollider Collider;
        public Ball Ball;
        
        protected bool BallWithinBounds = false;
        
        protected void Awake() {
            Transform = GetComponent<Transform>();
            Collider = GetComponent<BoxCollider>();
            Collider.isTrigger = false;
        }

        public void Swing() {
            if (BallWithinBounds) {
                Ball.HitBall();
            }
        }

        private void OnCollisionEnter(Collision other) {
            BallWithinBounds = true;
        }

        private void OnCollisionStay(Collision other) {
            BallWithinBounds = true;
        }

        private void OnCollisionExit(Collision other) {
            BallWithinBounds = false;
        }

        protected void Update() {
            /* Check if the ball is  */
        }
    }
}
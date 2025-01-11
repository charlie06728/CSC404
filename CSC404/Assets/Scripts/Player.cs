using System;
using UnityEngine;

namespace DefaultNamespace {
    public class Player : MonoBehaviour {
        public Transform Transform;
        
        protected void Awake() {
            Transform = GetComponent<Transform>();
        }
    }
}
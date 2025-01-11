using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DefaultNamespace {
    public class InputControlSystem : MonoBehaviour {
        public InputActionMap InputActionMap;
        public Player Player1;
        public Player Player2;

        public float PlayermoveSpeed = 1.0f;

        protected bool AMovingLeft = false;
        protected bool AMovingRight = false;
        protected bool BMovingLeft = false;
        protected bool BMovingRight = false;

        protected void Awake() {
            InputActionMap["AToLeft"].performed += ctx => { AMovingLeft = true; };
            InputActionMap["AToLeft"].canceled += ctx => { AMovingLeft = false; };
            InputActionMap["AToRight"].performed += ctx => { AMovingRight = true; };
            InputActionMap["AToRight"].canceled += ctx => { AMovingRight = false; };
            InputActionMap["ASwing"].performed += ctx => { Player1.Swing(); };
            
            InputActionMap["BToLeft"].performed += ctx => { BMovingLeft = true; };
            InputActionMap["BToLeft"].canceled += ctx => { BMovingLeft = false; };
            InputActionMap["BToRight"].performed += ctx => { BMovingRight = true; };
            InputActionMap["BToRight"].canceled += ctx => { BMovingRight = false; };
            InputActionMap["BSwing"].performed += ctx => { Player2.Swing(); };
            
            InputActionMap.Enable();
        }

        protected void Update() {
            float timeDelta = Time.deltaTime;
            if (AMovingLeft) { MovePlayerLeft(1, timeDelta); }
            if (AMovingRight) {MovePlayerRight(1, timeDelta);}
            if (BMovingLeft) { MovePlayerLeft(2, timeDelta); }
            if (BMovingRight) {MovePlayerRight(2, timeDelta);}
        }

        public void MovePlayerLeft(int player, float time) {
            Player targetPlayer = player == 1 ? Player1 : Player2;
            Vector3 p = targetPlayer.Transform.position;
            targetPlayer.Transform.position = new Vector3(p.x, p.y, p.z - time * PlayermoveSpeed);
        }
        
        public void MovePlayerRight(int player, float time) {
            Player targetPlayer = player == 1 ? Player1 : Player2;
            Vector3 p = targetPlayer.Transform.position;
            targetPlayer.Transform.position = new Vector3(p.x, p.y, p.z + time * PlayermoveSpeed);
        }
    }
}
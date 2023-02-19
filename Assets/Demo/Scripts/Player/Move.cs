using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
namespace Survival.Demo
{
    public class Move : MonoBehaviour
    {
        public Player player;
        public StayInRadiusBehavior_3D radius;

        public float turnSpeed = 5.0f;
        public float currentSpeed = 0.0f;
        public float maxMoveSpeed = 5.0f;
        public float acceleration = 1.0f;
        public bool isPressed = false;
        Action<Vector3> center;
        private void Start()
        {
            player = Player.Instance;
            if (player.joystick != null)
            {
                player.joystick.pointerDown += pressedStatus;
            }
            center += radius.setCenter;
        }
        public void pressedStatus(bool status)
        {
            isPressed = status;
            if (!isPressed)
            {
                currentSpeed = 0f;
            }
        }
        public void TurnTowards(Vector2 direction)
        {
            if (direction != Vector2.zero)
            {

                // Calculate the target rotation based on the input direction
                Quaternion targetRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.y), Vector3.up);

                // Smoothly rotate towards the target rotation
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
            }
        }
        public void MoveInDirection(Vector2 direction)
        {
            currentSpeed = Mathf.Lerp(currentSpeed, maxMoveSpeed * direction.magnitude, acceleration * Time.deltaTime);

            Vector3 movement = new Vector3(direction.x, 0, direction.y) * currentSpeed * Time.deltaTime;

            // Move the object along the calculated movement vector
            transform.position += movement;

        }

        void Update()
        {
            if (isPressed)
            {
                Vector3 dir = player.joystick.Direction;
                HandleKeyboardInput(dir);
                center.Invoke(transform.position);
            }

#if UNITY_EDITOR
            if (Input.GetKey(KeyCode.W))
            {
                HandleKeyboardInput(Vector2.up);
            }
            if (Input.GetKey(KeyCode.S))
            {
                HandleKeyboardInput(Vector2.down);
            }
            if (Input.GetKey(KeyCode.A))
            {
                HandleKeyboardInput(Vector2.left);
            }
            if (Input.GetKey(KeyCode.D))
            {
                HandleKeyboardInput(Vector2.right);

            }
#endif
        }
        public void HandleKeyboardInput(Vector2 dir)
        {
            MoveInDirection(dir);
            TurnTowards(dir);
            player.anim.getMagnitude(dir);
        }

    }
}
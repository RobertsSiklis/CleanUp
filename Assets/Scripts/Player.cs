using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Player : MonoBehaviour
{
    private float movementSpeed = 20f;
    [SerializeField] private float rotationSpeed = 20f;
    private Vector2 inputVector;
    private Vector3 movementDirection;
    private void Update() {
        SetInputVector();
        SetMovementDirection();
        MovePlayer();
        RotatePlayer();
    }

    private void SetInputVector() {
        inputVector = GameInput.Instance.GetMovementVectorNormalized();
    }

    private void SetMovementDirection() {
        movementDirection = new Vector3(inputVector.x, inputVector.y, 0f);
    }

    private void MovePlayer() {
        transform.position += movementDirection * (movementSpeed * Time.deltaTime);
    }

    private void RotatePlayer() {
        
    }
}

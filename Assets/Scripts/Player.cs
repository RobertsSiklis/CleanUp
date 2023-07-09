using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Player : MonoBehaviour
{
    public event EventHandler OnGunAttack;

    public static Player Instance { get; private set; }

    private float movementSpeed = 20f;
    private Vector2 inputVector;
    private Vector3 movementDirection;
    private Vector3 lookDirection;

    private void Awake() {
        InstantiateInstance();
    }

    private void InstantiateInstance() {
        Instance = this;
    }

    private void Update() {
        SetInputVector();
        SetMovementDirection();
        MovePlayer();
        RotatePlayerToMousePosition();
        
        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("Player Has Shot");
            OnGunAttack?.Invoke(this, EventArgs.Empty);
        }
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

    private void DirectionFromMousePositionToPlayerPosition() {
        lookDirection = GameInput.Instance.GetMousePosition() - (Vector2)transform.position;
    }

    private void NormalizeLookDirection() {
        lookDirection.Normalize();
    }

    private void RotatePlayerToMousePosition() {
        DirectionFromMousePositionToPlayerPosition();
        NormalizeLookDirection();
        transform.rotation = Quaternion.LookRotation(Vector3.forward, lookDirection);
    }

    public Vector3 GetPlayerLocation() {
        return transform.position;
    }
}

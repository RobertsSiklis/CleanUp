using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }
    private PlayerInputActions playerInputActions;

    private void Awake() {
        InstantiateInstance();
        InstantiatePlayerInputActions();
        EnablePlayerActionMap();
    }
    private void InstantiateInstance() {
        Instance = this;
    }

    private void InstantiatePlayerInputActions() {
        playerInputActions = new PlayerInputActions();
    }

    private void EnablePlayerActionMap() {
        playerInputActions.Player.Enable();
    }
    public Vector2 GetMousePosition() {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public Vector2 GetMovementVectorNormalized() {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
        return NormalizeMovementVector(inputVector);
    }

    private Vector2 NormalizeMovementVector(Vector2 inputVector) {
        return inputVector.normalized;
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector2 targetDir;
    private float bulletSpeed = 30;

    private void Start() {
        targetDir = GameInput.Instance.GetMousePosition().normalized;
    }
    private void Update() {
        transform.position += (Vector3)targetDir * bulletSpeed * Time.deltaTime;
    }

}

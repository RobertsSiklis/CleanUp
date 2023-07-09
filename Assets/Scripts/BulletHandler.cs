using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHandler : MonoBehaviour
{
    [SerializeField] private Transform bullet;

    private void Start() {
        Player.Instance.OnGunAttack += Instance_OnGunAttack;
    }

    private void Instance_OnGunAttack(object sender, EventArgs e) {
        Instantiate(bullet, Player.Instance.GetPlayerLocation(), new Quaternion());
    }
}

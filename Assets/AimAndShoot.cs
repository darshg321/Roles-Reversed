using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AimAndShoot : MonoBehaviour
{
    [SerializeField] private GameObject gun;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletSpawnPoint;

    private GameObject bulletInstance;

    private Vector2 direction;
    private Vector2 worldPosition;
    private float angle;
    private float defaultYScale;

    private void Start()
    {
        defaultYScale = gun.transform.localScale.y;
    }
    void Update()
    {
        GunRotation();
        GunShooting();
    }
    private void GunRotation()
    {
        worldPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        direction = (worldPosition - (Vector2)gun.transform.position).normalized;

        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (gameObject.transform.localScale.x < 0)
        {
            gun.transform.right = -direction;
        }
        else
        {
            gun.transform.right = direction;
        }


        //Vector3 localScale = new Vector3(gun.transform.localScale.x, gun.transform.localScale.y, gun.transform.localScale.z);

        //if (angle > 90 || angle < -90)
        //{
        //    localScale.y = -defaultYScale;
        //}
        //else
        //{
        //    localScale.y = defaultYScale;
        //}
        //gun.transform.localScale = localScale;
    }

    private void GunShooting()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            bulletInstance = Instantiate(bullet, bulletSpawnPoint.position, gun.transform.rotation);
        }
    }
}

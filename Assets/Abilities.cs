using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour
{
    [SerializeField] private KeyCode spiralKey = KeyCode.E;
    [SerializeField] private GameObject gunPrefab;
    [SerializeField] private int gunAmount = 9;
    void Update()
    {
        if (Input.GetKeyDown(spiralKey))
        {
            SpiralAttack();
        }
    }

    private void SpiralAttack()
    {
        //for (int rotation = 0; rotation < (gunAmount * 15) / 360; rotation += 15)
        //{
        //    Vector3 pos = rotation / 15;
        //    Instantiate(gunPrefab, pos, rotation);
        //}
        
    }
}

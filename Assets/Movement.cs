using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] private Vector2 speed = new Vector2(50, 50);

    private float defaultXScale;
    private Vector3 worldPosition;

    private void Start()
    {
        defaultXScale = gameObject.transform.localScale.x;
    }
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(speed.x * inputX, speed.y * inputY, 0) * Time.deltaTime;
        transform.Translate(movement);

        worldPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        if (transform.position.x > worldPosition.x)
        {
            transform.localScale = new Vector3(-defaultXScale, transform.localScale.y, transform.localScale.z);
        }
        else if (transform.position.x < worldPosition.x)
        {
            transform.localScale = new Vector3(defaultXScale, transform.localScale.y, transform.localScale.z);
        }
    }
}

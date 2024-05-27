using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialMoves : MonoBehaviour
{
    private float jumpStart = 0f;
    private float jumpTime = 0f;
    public float jumpTimeLimit = 0.5f;
    public float jumpMultiplier = 15;
    private bool isJumping = false;

    public float dashMultiplier = 100f;
    private KeyCode lastKeyPressed;
    private float lastKeyPressTime;
    private float doublePressTimeThreshold = 0.3f;

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            jumpStart = Time.time;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            jumpTime = Time.time - jumpStart;

            if (jumpTime > jumpTimeLimit) { jumpTime = jumpTimeLimit; }
            jumpStart = 0f;

            float inputY = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(jumpTime * inputX * jumpMultiplier, jumpTime * inputY * jumpMultiplier, 0);

            transform.Translate(movement);
            isJumping = false;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (lastKeyPressed == KeyCode.A && Time.time - lastKeyPressTime <= doublePressTimeThreshold)
            {
                // Double press detected for 'A', move left
                Vector3 movement = new Vector3(inputX * dashMultiplier, 0, 0);
                transform.Translate(movement);
            }
            else
            {
                // Single press for 'A', update the last key pressed and time
                lastKeyPressed = KeyCode.A;
                lastKeyPressTime = Time.time;
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (lastKeyPressed == KeyCode.D && Time.time - lastKeyPressTime <= doublePressTimeThreshold)
            {
                // Double press detected for 'D', move right
                Vector3 movement = new Vector3(inputX * dashMultiplier, 0, 0);
                transform.Translate(movement);
            }
            else
            {
                // Single press for 'D', update the last key pressed and time
                lastKeyPressed = KeyCode.D;
                lastKeyPressTime = Time.time;
            }
        }
    }

}

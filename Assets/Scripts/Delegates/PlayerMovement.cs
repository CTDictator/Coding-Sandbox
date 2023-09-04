using System;
using UnityEngine;

// class that switches between running and walking whenever the player holds shift.
public class PlayerMovement : MonoBehaviour
{
    private Action moveAction;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;

    private void Start()
    {
        moveAction = Walk;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveAction = Run;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveAction = Walk;
        }
        moveAction();
    }

    private Vector2 GetDirection()
    {
        Vector2 direction = new(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        direction.Normalize();
        return direction;
    }

    private void Walk()
    {
        Vector2 direction = GetDirection();
        direction *= walkSpeed * Time.deltaTime;
        transform.Translate(direction.x, 0.0f, direction.y);
    }

    private void Run()
    {
        Vector2 direction = GetDirection();
        direction *= runSpeed * Time.deltaTime;
        transform.Translate(direction.x, 0.0f, direction.y);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    
    Vector2 axisValue;

    private void FixedUpdate() {
        Move();
        
    }

    void Move()
    {
        if (axisValue.sqrMagnitude < 0.01) { return; }

        var scaledSpeed = speed * Time.deltaTime; 

        var newPosition = new Vector3(axisValue.x * scaledSpeed, axisValue.y * scaledSpeed, 0f);

        transform.position += newPosition;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        axisValue = context.ReadValue<Vector2>();
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        print("collidi com " + other.gameObject);
        Destroy(other.gameObject);
    }

}

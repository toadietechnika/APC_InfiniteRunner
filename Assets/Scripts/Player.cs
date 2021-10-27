using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb2D;
    public float jumpForce;
    bool canJump;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Detection if it's on the ground
        canJump = Physics2D.Linecast(transform.position, (Vector2)transform.position + (Vector2.down * 0.55f), 1 << LayerMask.NameToLayer("Ground")) && rb2D.velocity.y <= 0;

        //Jump Function
        if (Input.GetMouseButtonDown(0) && canJump)
        {
            canJump = true;
            rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void OnTriggerEnter2D(Collider2D _c)
    {
        if (_c.GetComponent<Spikes>() != null)
            Destroy(gameObject);
    }

    void OnDrawGizmos()
    {
        if (!canJump)
            Gizmos.color = Color.red;
        else
            Gizmos.color = Color.green;

        Gizmos.DrawLine(transform.position, (Vector2)transform.position + (Vector2.down * 0.55f));
    }
}

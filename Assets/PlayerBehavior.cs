using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerBehavior : MonoBehaviour
{

    private Rigidbody2D rb;

    [SerializeField]
    private float speed;

    private bool isTouchingClock = false;
    private bool isTouchingShop = false;
    private int money = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, Input.GetAxisRaw("Vertical") * speed);

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isTouchingClock)
            {

                // if you have the correct item, you fix the clock
            }
            if (isTouchingShop)
            {
                // Starts the shop in canvas
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Collectible")
        {
            Destroy(collision.gameObject);
            money++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Clock")
        {
            isTouchingClock = true;
        }
        if (collision.gameObject.tag == "Shop")
        {
            isTouchingShop = true;
        }
    }
}

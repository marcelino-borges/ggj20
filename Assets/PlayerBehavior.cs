using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerBehavior : MonoBehaviour
{

    private Rigidbody2D rb;

    public Text moneyText;
    public Text itemText;

    private GameObject touchingNeffesh;

    private float speed;

    private bool isTouchingClock = false;
    private bool isTouchingShop = false;

    [HideInInspector]
    public static int money = 0;

    [HideInInspector]
    public static int item = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 5f;
    }

    void Update()
    {
        moneyText.text = "Money: " + money.ToString();
        itemText.text = "Cogs: " + item.ToString();

        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, Input.GetAxisRaw("Vertical") * speed);

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isTouchingClock)
            {
                if (item >= 1)
                {
                    item--;
                    touchingNeffesh.GetComponent<ClockBehavior>().DeactivateClock();
                }
                // if you have the correct item, you fix the clock
            }
            if (isTouchingShop)
            {
                touchingNeffesh.GetComponent<ShopBehavior>().ActivateShop();
                // Starts the shop in canvas
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Collectible")
        {
            collision.gameObject.transform.parent.GetComponent<Spawner>().hasSpawnedItem = false;
            Destroy(collision.gameObject);
            money++;
        }
        if (collision.gameObject.tag == "Boss")
        {
            Application.Quit();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Clock")
        {
            touchingNeffesh = collision.gameObject;
            isTouchingClock = true;
        }
        if (collision.gameObject.tag == "Shop")
        {
            touchingNeffesh = collision.gameObject;
            isTouchingShop = true;
        }
    }
}

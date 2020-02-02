using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopBehavior : MonoBehaviour
{

    public GameObject canvas;

    private void Awake()
    {
        canvas = GameObject.Find("ShopCanvas");
        canvas.SetActive(false);
    }

    public void BuyItem()
    {
        if (PlayerBehavior.money >= 5)
        {
            PlayerBehavior.money -= 5;
            PlayerBehavior.item++;
        }
        else
        {
            //add a textbox that says YOU POOR, YOU LEAVE, NO STAY
        }
    }

    public void ActivateShop()
    {
        canvas.SetActive(true);
    }

    public void DeactivateShop()
    {
        canvas.SetActive(false);
    }
}

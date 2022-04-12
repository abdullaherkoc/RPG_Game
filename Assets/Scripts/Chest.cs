using System.Collections;
using System.Collections.Generic;
using System.IO;
using TreeEditor;
using UnityEditor;
using UnityEngine;

public class Chest : Collectable
{
    public Sprite emptyChest;
    public int coinAmount = 5;


     [Range(0, 100)]
    public int fontsize;
     [Range(0, 100)]
    public int speed;
     [Range(0, 100)]
    public float time;

    protected override void OnCollect()
    {
        if (!collected)
        {
            collected = true;
            GetComponent<SpriteRenderer>().sprite=emptyChest;
            GameManager.instance.coins += coinAmount;
            GameManager.instance.ShowText(" + " + coinAmount + " Coin! ",fontsize,Color.yellow,transform.position,Vector3.up*speed,time);
            Debug.Log("sandık aldın ");
        }
    }

}

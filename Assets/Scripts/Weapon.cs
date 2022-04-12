using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Purchasing;
using UnityEngine;

public class Weapon : Collidable
{
    public int[] damagePoint = { 1, 2, 3, 4, 5, 6, 7 };
    public float[] force = { 2.0f, 2.2f, 2.5f, 3f, 3.2f, 3.6f, 4f };

    public int weaponLevel = 0;
    public SpriteRenderer spriteRenderer;


    private Animator anim;
    private float coolDown = 0.5f;
    private float lastSwing;



    protected override void Start()
    {
        base.Start();
        
        anim = GetComponent<Animator>();
    }
    protected override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time - lastSwing > coolDown)
            {
                lastSwing = Time.time;
                Swing();
            }
        }

    }

    protected override void OnCollide(Collider2D coll)
    {

        if (coll.tag == "Fighter")
        {

            if (coll.name == "Player")
                return;


            Damage dmg = new Damage
            {
                damageAmount = damagePoint[weaponLevel],
                origin = transform.position,
                pushForce = force[weaponLevel]
            };

            coll.SendMessage("ReceiveDamage", dmg);


            Debug.Log(coll.name);




        }

    }
    private void Swing()
    {
        anim.SetTrigger("Swing");



    }
    internal void UpgradeWeapon()
    {
        weaponLevel++;
        spriteRenderer.sprite = GameManager.instance.weaponSprites[weaponLevel];
    }

    public void SetWeaponLevel(int level)
    {
        weaponLevel = level;
        spriteRenderer.sprite = GameManager.instance.weaponSprites[weaponLevel];
    }

}

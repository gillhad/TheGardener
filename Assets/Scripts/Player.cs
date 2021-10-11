using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 2.0f;
    public bool clickOk = true, clickW = false,clickA = false,clickS = false,clickD = false;
    float delay = 0;
    public static int coins;
    public static int speedUpgrade = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*float h = Input.GetAxisRaw("Horizontal");
            GetComponent<Rigidbody2D>().velocity = Vector2.right *h * speed;
        float v = Input.GetAxisRaw("Vertical");
        GetComponent<Rigidbody2D>().velocity = Vector2.up * v * speed;*/
        


        if (this !=null)
        {
            if (Input.GetKey(KeyCode.W) && !clickA && !clickS && !clickD)
            {
                GetComponent<Rigidbody2D>().velocity = UnityEngine.Vector2.up * speed* speedUpgrade;
                clickW = true;
            }
            else
            if (Input.GetKey(KeyCode.A) && !clickW && !clickS && !clickD)
            {
                GetComponent<Rigidbody2D>().velocity = UnityEngine.Vector2.left * speed * speedUpgrade;
                clickA= true;
            }
            else
            if (Input.GetKey(KeyCode.S) && !clickA && !clickW && !clickD)
            {
                GetComponent<Rigidbody2D>().velocity = UnityEngine.Vector2.down * speed * speedUpgrade;
                clickS = true;
            }
            else
            if (Input.GetKey(KeyCode.D) && !clickA && !clickS && !clickW)
            {
                GetComponent<Rigidbody2D>().velocity = UnityEngine.Vector2.right * speed * speedUpgrade;
                clickD = true;
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = UnityEngine.Vector2.zero;
                RoundPosition();
                DelayClick();
                
            }   

        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = UnityEngine.Vector2.zero;
            DelayClick();
        }
        

    }

    public void RoundPosition() {
        float posx = (int)Math.Round(GetComponent<Rigidbody2D>().position.x*2f)*0.5f;
        float posy = (float)Math.Round(GetComponent<Rigidbody2D>().position.y*2f)*0.5f;
        GetComponent<Rigidbody2D>().position = new UnityEngine.Vector2(posx, posy);

    }

    public void DelayClick() {
        
        delay += Time.deltaTime;
        if (delay >= 0.5f) {
            clickW = false;
            clickA = false;
            clickS = false;
            clickD = false;

        }

    }

    

}

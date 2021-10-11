using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;
using System;
using System.Runtime.CompilerServices;
using UnityEditor;
using System.Numerics;
using UnityEngine.SceneManagement;

public class Grass : MonoBehaviour
{
    public GameObject[] grass;
    public Sprite[] grassSprite;
    public Array[] grassNumber = new Array[4];
    int grassLevel;
    float growthTime;
    public int grassh = 5, grassw = 10;
    public LayerMask treeLayer;
    UnityEngine.Vector3 rayCast = new UnityEngine.Vector3(0,0,20);
    public bool isTouchingtree = false;
    bool treeCheck = false;
    


    private void Start()
    {
        
    }
        private void FixedUpdate()
    {
        //Debug.DrawRay(this.transform.position, UnityEngine.Vector3.back * 20, Color.green);
        while (!treeCheck)
        {
            HasATree();
            treeCheck = true;
        }
        growthTime += Time.deltaTime;
        if (growthTime >= 5.0f)
        {
            GrowGrass2();
            growthTime = 0;
        }

        
    }

    IEnumerator GrowhtFactor() {
        while (true)
        {
            yield return new WaitForSeconds(5.0f);
            GrowGrass2();
        }
    }


    public void GrowGrass() {
        int growth = System.Array.IndexOf(grassSprite, this.grassSprite);
        if (this.grassSprite.Equals(0))
        {
            GetComponent<SpriteRenderer>().sprite = grassSprite[1];
            Debug.Log(grassSprite[1]);
        }
        else if (this.grassSprite.Equals(1)) {
            GetComponent<SpriteRenderer>().sprite = grassSprite[2];
        }
        else if (this.grassSprite.Equals(2))
        {
            GetComponent<SpriteRenderer>().sprite = grassSprite[3];
        }
    }

    public void GrowGrass2() {
        
        if (this.grassLevel == 3 )
        {
            Debug.Log("has perdido");
            SceneManager.LoadScene("MenuScene");
            return;
            
        }
        else
        {
            //Debug.Log(grassLevel);
            grassLevel++;
            GetComponent<SpriteRenderer>().sprite = grassSprite[grassLevel];
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag =="Player") {
            GetComponent<SpriteRenderer>().sprite = grassSprite[0];
            grassLevel = 0;
            Player.coins++;
        }
        
    }

   
    public void HasATree() {
                
        if (Physics2D.Raycast(this.transform.position, UnityEngine.Vector2.down, 0.1f, treeLayer)) { 
            //Debug.Log("toca un arbol");
            this.enabled = false;
        }

    }

    
}

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditorInternal;
using UnityEngine;

public class GreenGem : MonoBehaviour
{
    static GreenGem gem;
    public LayerMask treeLayer;    
    public static float spawnTime;
    public static bool spawnGemTime = true;
    public static bool spawnedInTree = false;
    public static bool gemIsPicked;
    public static LayerMask treeStaticLayer;
    public static bool gemHasBeenCheck = false;
    

    private void Awake()
    {
        gem = this;
        treeStaticLayer = treeLayer;

    }
    private void FixedUpdate()
    {
        if (this !=null && !gemHasBeenCheck)
        {
            placedOnTree();
            gemHasBeenCheck = true;
        }      
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {        
    
        if (this!=null && collision.tag == "Player") {            
            Debug.Log("gem picked");
            Player.coins += 5;
            GameManager.gemIsPicked = true;
            GameManager.gemSpawnTime = 5f;
            Destroy(this.gameObject);

        }
    }
   
    
    public static void placedOnTree() {
        if (Physics2D.Raycast(gem.transform.position, UnityEngine.Vector2.down, 0.1f, treeStaticLayer))
        {
            
            Debug.Log("toca un arbol");
            GameManager.gemIsPicked = true;
            Debug.Log("se debe poner como picked");
            GameManager.gemSpawnTime = 0f;
            if (GameManager.gemIsPicked) {
                Destroy(gem.gameObject);
            }
        }
        else {
            
            Debug.Log("todo correcto con las gemas");
        }
    }
    
       

}

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Text coinsScore;
    Player playerManager;
    public GameObject tree;
    public GameObject greenGem;    
    public static GameManager sharedInstance = null;

    //gem
    public static float gemSpawnTime = 5f;
    public static bool gemIsPicked = true;
    public bool gemIsPickedWatcher;

    //Tree
    int minXTree = 1;
    int maxXTree = 3;

    // Start is called before the first frame update

    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
        InvokeTree();
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        coinsScore.text = "" + Player.coins + " $";
        if (gemIsPicked) {
            gemSpawnTime -= Time.deltaTime;
            }
        if (gemSpawnTime <= 0 && gemIsPicked) {
            InvokeGem();
        }

        gemIsPickedWatcher = gemIsPicked;
        
    }

    public void InvokeTree() {
        int randomTreeNumber = Random.Range(1,3);
        for (int x = 0; x <= randomTreeNumber; x++)
        {
            
            int randomPositionX = Random.Range(minXTree, maxXTree);
            int randomPositionY = Random.Range(1, 4);
            Vector3 treePosition = new Vector3(randomPositionX + 0.2f, randomPositionY -0.2f, 0);
            Instantiate(tree, treePosition, Quaternion.identity);
            minXTree = minXTree + 2;
            maxXTree = maxXTree + 2;
        }

    
    }

    IEnumerator InvokeGemCall() {
        yield return new WaitForSeconds(2f);
    }
    public void InvokeGem()
    {
        int randomPositionX = Random.Range(1, 8);
        int randomPositionY = Random.Range(1, 3);
        Vector2 gemPosition = new Vector2(randomPositionX, randomPositionY);
        Instantiate(greenGem, gemPosition, Quaternion.identity);
        gemIsPicked = false;
        GreenGem.placedOnTree();

    }

        
}

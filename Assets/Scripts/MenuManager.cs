using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadGame()
    {
        SceneManager.LoadScene("GameScene");

    }

    public void Display() {

        Debug.Log("display this");
    }

    public void LoadUpgrade() {
        SceneManager.LoadScene("UpgradeScene");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{

    private Button thisButton;
    public void MushUpgrade() {
        if (Player.coins >= 10)
        {
            Player.coins -= 200;
            Player.speedUpgrade = 2;
            thisButton.interactable = false;
        }
        else {
            Debug.Log("not enough coins");
        }

    }

    public void LoadMenu() {

        SceneManager.LoadScene("MenuScene");
    }

}


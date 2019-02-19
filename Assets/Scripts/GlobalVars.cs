using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
public class GlobalVars : MonoBehaviour {
    void Start () {
        
    }
	void Update () {
        if(GameObject.FindWithTag("PlayerCastle").GetComponent<PlayerCastleMain>().playerCastleHealth <= 0 
           || GameObject.FindWithTag("ComputerCastle").GetComponent<ComputerCastleMain>().computerCastleHealth <= 0){
            Time.timeScale = 0;
            SceneManager.LoadScene("GameOverScene");
        }
	}
}

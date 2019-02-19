using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCastleMain : MonoBehaviour {
    public float playerCastleHealth = 1000.0f;
    public int playerCastleEnergy = 100;
    public Slider energySlider;
    public Slider playerHealthSlider;
	// Use this for initialization
	void Start () {
        StartCoroutine(IncreaseEnergy());
	}
	
	// Update is called once per frame
	void Update () {
        playerHealthSlider.value = playerCastleHealth;
        energySlider.value = playerCastleEnergy;
	}
    IEnumerator IncreaseEnergy()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (playerCastleEnergy < 100)
            {
                playerCastleEnergy += 1;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ComputerCastleMain : MonoBehaviour {
    public GameObject goblinPrefab;
    public GameObject skeletonPrefab;
    public GameObject prettyWarriorPrefab;
    public GameObject scarySkeletonPrefab;
    public float computerCastleHealth = 1000.0f;
    public float computerCastleEnergy = 100;
    public int enemyTotalAttackPower;
    public int enemyTotalHealth;
    public Slider computerHealthSlider;
	// Use this for initialization
	void Start () {
        StartCoroutine(IncreaseEnergy());

	}
	
	// Update is called once per frame
	void Update () {
        computerHealthSlider.value = computerCastleHealth;
        if(computerCastleEnergy >= 25){
            int tempRnd = (int) Random.Range(1.0f,100.0f);
            if(tempRnd > 0 && tempRnd < 20){
                SpawnGoblin();
            }
            if (tempRnd > 20 && tempRnd < 50)
            {
                SpawnSkeleton();
            }
            if (tempRnd > 50 && tempRnd < 80)
            {
                SpawnPrettyWarrior();
            }
            if (tempRnd > 80 && tempRnd < 100)
            {
                SpawnScarySkeleton();
            }
        }
	}
    public void SpawnGoblin()
    {
        if (GameObject.FindWithTag("PlayerCastle").GetComponent<PlayerCastleMain>().playerCastleEnergy >= 10)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(4f, 0f), 0f,4.8f);
            //Vector3 spawnPosition = new Vector3(2f, 0f, 4.8f);
            Instantiate(goblinPrefab, spawnPosition, Quaternion.identity);
            DecreaseComputerEnergy(10);

        }
        return;
    }
    public void SpawnSkeleton()
    {
        if (GameObject.FindWithTag("PlayerCastle").GetComponent<PlayerCastleMain>().playerCastleEnergy >= 15)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(4f, 0f), 0f,4.8f);
            //Vector3 spawnPosition = new Vector3(2f, 0f, 4.8f);
            Instantiate(skeletonPrefab, spawnPosition, Quaternion.identity);
            DecreaseComputerEnergy(15);
        }
        return;
    }
    public void SpawnPrettyWarrior()
    {
        if (GameObject.FindWithTag("PlayerCastle").GetComponent<PlayerCastleMain>().playerCastleEnergy >= 20)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(4f, 0f), 0f,4.8f);
            //Vector3 spawnPosition = new Vector3(2f, 0f, 4.8f);
            Instantiate(prettyWarriorPrefab, spawnPosition, Quaternion.identity);
            DecreaseComputerEnergy(20);
        }
        return;
    }
    public void SpawnScarySkeleton()
    {
        if (GameObject.FindWithTag("PlayerCastle").GetComponent<PlayerCastleMain>().playerCastleEnergy >= 25)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(4f, 0f), 0f,4.8f);
            //Vector3 spawnPosition = new Vector3(2f, 0f, 4.8f);
            Instantiate(scarySkeletonPrefab, spawnPosition, Quaternion.identity);
            DecreaseComputerEnergy(25);
        }
        return;
    }
    public void DecreaseComputerEnergy(int energyCost)
    {
        computerCastleEnergy -= energyCost;
    }
    IEnumerator IncreaseEnergy()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (computerCastleEnergy < 100)
            {
                computerCastleEnergy += 1.3f;
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Buttons : MonoBehaviour {
    public GameObject goblinPrefab;
    public GameObject skeletonPrefab;
    public GameObject prettyWarriorPrefab;
    public GameObject scarySkeletonPrefab;
    public GameObject globalVariables;
    public int totalHeatlh;
    public int totalAttack;
    // Use this for initialization
    void Start () {

	}
    void Update(){
    }
	// Update is called once per frame
    public void GoblinButtonOnClick()
    {
        if(GameObject.FindWithTag("PlayerCastle").GetComponent<PlayerCastleMain>().playerCastleEnergy >= 10){
            totalAttack += 10;
            Vector3 spawnPosition = new Vector3(Random.Range(4f, 0f), 0f, -3.49f);
            //Vector3 spawnPosition = new Vector3(2f, 0f, -3.49f);
            Instantiate(goblinPrefab, spawnPosition, Quaternion.identity);
            DecreasePlayerEnergy(10);

        }
        return;
    }
    public void SkeletonButtonOnClick()
    {
        if (GameObject.FindWithTag("PlayerCastle").GetComponent<PlayerCastleMain>().playerCastleEnergy >= 15)
        {
            totalAttack += 16;
            Vector3 spawnPosition = new Vector3(Random.Range(4f, 0f), 0f, -3.49f);
            //Vector3 spawnPosition = new Vector3(2f, 0f, -3.49f);
            Instantiate(skeletonPrefab, spawnPosition, Quaternion.identity);
            DecreasePlayerEnergy(15);
        }
        return;
    }
    public void PrettyWarriorButtonOnClick()
    {
        if (GameObject.FindWithTag("PlayerCastle").GetComponent<PlayerCastleMain>().playerCastleEnergy >= 20)
        {
            totalAttack += 25;
            Vector3 spawnPosition = new Vector3(Random.Range(4f, 0f), 0f, -3.49f);
            //Vector3 spawnPosition = new Vector3(2f, 0f, -3.49f);
            Instantiate(prettyWarriorPrefab, spawnPosition, Quaternion.identity);
            DecreasePlayerEnergy(20);
        }
        return;
    }
    public void ScarySkeletonButtonOnClick()
    {
        if (GameObject.FindWithTag("PlayerCastle").GetComponent<PlayerCastleMain>().playerCastleEnergy >= 25)
        {
            totalAttack += 30;
            Vector3 spawnPosition = new Vector3(Random.Range(4f, 0f), 0f, -3.49f);
            //Vector3 spawnPosition = new Vector3(2f, 0f, -3.49f);
            Instantiate(scarySkeletonPrefab, spawnPosition, Quaternion.identity);
            DecreasePlayerEnergy(25);
        }
        return;
    }
    public void DecreasePlayerEnergy(int energyCost){
        GameObject.FindWithTag("PlayerCastle").GetComponent<PlayerCastleMain>().playerCastleEnergy -= energyCost;
    }
}

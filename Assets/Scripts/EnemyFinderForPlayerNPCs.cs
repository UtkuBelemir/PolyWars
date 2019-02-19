using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFinderForPlayerNPCs : MonoBehaviour {
    public GameObject parentObject;
    public int targetId;
    public GameObject enemyObject;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    private void OnTriggerEnter(Collider other)
    {
        if (targetId == 0 && other.gameObject.tag == "ComputerCastle")
        {
            targetId = 10;
        }
        else if( targetId == 0 && other.gameObject.tag == "ComputerNPC")
        {
            targetId = other.GetInstanceID();
            enemyObject = other.gameObject;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other){
            if (targetId == 0 && other.gameObject.tag == "ComputerCastle")
            {
                targetId = 10;
            }
            else if (targetId == 0 && other.gameObject.tag == "ComputerNPC")
            {
                targetId = other.GetInstanceID();
                enemyObject = other.gameObject;
            }
            if (enemyObject != null && enemyObject.GetComponent<MoveComputerNPCs>().health <= 0)
            {
                
                Destroy(enemyObject);
                enemyObject = null;
                targetId = 0;
                return;
            }   
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other && other.GetInstanceID() == targetId)
        {
            targetId = 0;
        }
        
    }
}

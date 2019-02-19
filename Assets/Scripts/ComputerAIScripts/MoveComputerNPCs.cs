using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveComputerNPCs : MonoBehaviour {
    public float speed = 1.0f;
    public float health = 100.0f;
    private Vector3 playerCastlePosition;
    private Animator animCtrl;
    private bool canMove = true;
    public EnemyFinderForComputerNPCs enemyFinder;
    public float distanceFromEnemy = 0.18f;
    public float minPower;
    public float maxPower;
    public bool isDead = false;
    // Use this for initialization
    void Start () {
        playerCastlePosition = new Vector3(Random.Range(1.105f, 3.066f), transform.position.y, -3.754f);
        animCtrl = transform.gameObject.GetComponent<Animator>();
        enemyFinder = transform.Find("EnemyFinder").GetComponent<EnemyFinderForComputerNPCs>();
    }  
	
	// Update is called once per frame
	void Update () {
        if (health <= 0)
        {
            animCtrl.SetFloat("Die", 1.0f);
            isDead = true;
        }
        if (canMove)
        {
            if (enemyFinder.targetId != 0 && enemyFinder.targetId != 11)
            {
                Vector3 tempEnemyPos = enemyFinder.enemyObject.transform.position;
                if(Vector3.Distance(transform.position,tempEnemyPos) >= distanceFromEnemy)
                {
                    animCtrl.SetFloat("Attack", 0f);
                    animCtrl.SetFloat("Walk", 1f);
                    transform.position = Vector3.MoveTowards(transform.position, enemyFinder.enemyObject.transform.position, speed * Time.deltaTime);
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation((tempEnemyPos - transform.position).normalized), Time.deltaTime*2);
                }
                else
                {
                    animCtrl.SetFloat("Walk", 0f);
                    animCtrl.SetFloat("Attack", 1f);
                }
                
            }
            else if(enemyFinder.targetId == 0 || enemyFinder.targetId == 11)
            {
                if(Vector3.Distance(transform.position,playerCastlePosition) >= distanceFromEnemy)
                {
                    animCtrl.SetFloat("Attack", 0f);
                    animCtrl.SetFloat("Walk", 1f);
                    transform.position = Vector3.MoveTowards(transform.position, playerCastlePosition, speed * Time.deltaTime);
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation((playerCastlePosition - transform.position).normalized), Time.deltaTime*2);
                }
                else
                {
                    animCtrl.SetFloat("Walk", 0f);
                    animCtrl.SetFloat("Attack", 1f);
                }
               
            }
           

        }
        
    }
    public void AttackTarget(){
        int tempAtkPower = (int)Random.Range(minPower, maxPower);
        if(enemyFinder.targetId == 11){
            GameObject.FindWithTag("PlayerCastle").GetComponent<PlayerCastleMain>().playerCastleHealth -= tempAtkPower;    
        }
        else if(enemyFinder.targetId != 0 && enemyFinder.targetId != 11){
            enemyFinder.enemyObject.GetComponent<MovePlayerNPCs>().health -= tempAtkPower;
        }
    }
    public void DeathAndDestroy()
    {
        Destroy(transform);
    }
}
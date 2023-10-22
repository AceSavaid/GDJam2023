using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class GameProcess : MonoBehaviour
{
    [Header("Spawn Points")]
    [SerializeField] GameObject pSpawn;
    private List<Transform> PlayerSpawnPoints = new List<Transform>();
    [SerializeField] GameObject eSpawn;
    List<Transform> EnemySpawnPoints = new List<Transform>();

    [Header("Turn Handling")]
    bool newTurn = false;
    float timeBetweenTurns = 2.0f;

    //Party information for both sides
    [SerializeField] List<EntityBase> activePlayerParty = new List<EntityBase>();
    [SerializeField] List<EntityBase> activeEnemyParty = new List<EntityBase>();

    [Header("Cards")]
    [SerializeField] List<CardSO> cards = new List<CardSO>();
    [SerializeField] List<CardSO> enemyCards = new List<CardSO>();




    // Start is called before the first frame update
    void Start()
    {
        Attack();
    }

    // Update is called once per frame
    void Update()
    {
        if (newTurn)
        {
            Attack();
        }
    }

    void Attack()
    {
        activePlayerParty[0].Hurt(activeEnemyParty[0].damage);
        activeEnemyParty[0].Hurt(activePlayerParty[0].damage);
        Debug.Log(activePlayerParty[0].name + "did " + activePlayerParty[0].damage);
        Debug.Log(activeEnemyParty[0].name + "did" + activeEnemyParty[0].damage);

        newTurn = false;
        StartCoroutine(TurnTimer());
    }

    public void CheckGameEnd() //Checks to see if any of the condition 
    {
        
        if ((activePlayerParty.Count <= 0) && (activeEnemyParty.Count <= 0)) //draw
        {
            newTurn = false;
            Debug.Log("Draw");
        }
        else if (activePlayerParty.Count <= 0) // enemy wins
        {
            newTurn = false;
            Debug.Log("Enemy Wins");
        }
        else if (activeEnemyParty.Count <= 0) // player wins 
        {
            newTurn = false;
            Debug.Log("Player Wins");
        }

        //if none of these conditions 
    }

    public void playerPawnDied()
    {
        activePlayerParty.RemoveAt(1);
        Debug.Log("Player Died.");
        CheckGameEnd();
    }

    public void enemyPawnDied()
    {
        activeEnemyParty.RemoveAt(1);
        Debug.Log("Enemy Died.");
        CheckGameEnd();
    }

    IEnumerator TurnTimer()
    {
        yield return new WaitForSeconds(timeBetweenTurns);
        newTurn = true;
        Debug.Log("New Turn");
    }
}

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


    bool newTurn = false;
    int playerPawnCount;
    int enemyPawnCount;
    [SerializeField] List<EntityBase> activePlayerParty = new List<EntityBase>();
    [SerializeField] List<EntityBase> activeEnemyParty = new List<EntityBase>();

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
        
    }

    void Attack()
    {
        activePlayerParty[0].Hurt(activeEnemyParty[0].damage);
        activeEnemyParty[0].Hurt(activePlayerParty[0].damage);
        Debug.Log(activePlayerParty[0].name + "did " + activePlayerParty[0].damage);
    }

    public void CheckWin()
    {
        if ((playerPawnCount <= 0) && (enemyPawnCount <= 0)) 
        {

        }
        else if (PlayerSpawnPoints.Count <= 0)
        {

        }
        else
        {

        }
    }
}

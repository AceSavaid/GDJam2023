using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject pSpawn;
    List<Transform> PlayerSpawnPoints = new List<Transform>();
    GameObject eSpawn;
    List<Transform> EnemySpawnPoints = new List<Transform>();

    bool newTurn = false;
    int playerPawnCount;
    int enemyPawnCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

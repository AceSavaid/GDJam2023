using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    public bool sacrificeMode = false;

    //Party information for both sides
    [SerializeField] List<GameObject> activePlayerParty = new List<GameObject>();
    [SerializeField] List<GameObject> activeEnemyParty = new List<GameObject>();

    [Header("Cards")]
    [SerializeField] List<GameObject> cards = new List<GameObject>();
    [SerializeField] List<GameObject> enemyCards = new List<GameObject>();

    [Header("Buttons and UI")]
    [SerializeField] Button startTurnButton;
    [SerializeField] Button sacrificeButton;
    [SerializeField] TMP_Text messageText;

    [Header("Colour Effects")]
    [SerializeField] Color hitColour;
    [SerializeField] Color deathColour;

    [Header("Sound Effects")]
    [SerializeField] AudioClip nextTurnSound;
    [SerializeField] AudioClip attackSound;
    [SerializeField] AudioClip playerDeathSound;
    [SerializeField] AudioClip enemyDeathSound;
    [SerializeField] AudioClip sacrificeOnSound;
    [SerializeField] AudioClip sacrificeOffSound;


    // Start is called before the first frame update
    void Start()
    {
        //enables the start button which is used to progress the actions
        startTurnButton.enabled = true;
        startTurnButton.onClick.AddListener(NextTurn);
        sacrificeButton.enabled = true;
        sacrificeButton.onClick.AddListener(ToggleSacrificeMode);

        //creates the list of spawn points
        foreach (Transform child in pSpawn.transform)
        {
            PlayerSpawnPoints.Add(child);
        }
        foreach (Transform child in eSpawn.transform)
        {
            EnemySpawnPoints.Add(child);
        }

        //spawns both the player and enemy sides of the board (should remove the player's one for the custom later)
        /*
        foreach (Transform t in PlayerSpawnPoints)
        {
            GameObject g = Instantiate(cards[Random.Range(0, cards.Count)], t);
            activePlayerParty.Add(g);
            Debug.Log("Spawning Player Card" + g);

        }*/

        foreach (Transform t in EnemySpawnPoints)
        {
            GameObject g = Instantiate(enemyCards[Random.Range(0, enemyCards.Count)], t);
            activeEnemyParty.Add(g);
            Debug.Log("Spawning Enemy Card" + g);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (newTurn)
        {
            Attack();
        }
    }

    public bool IsPartyFull()
    {
        if(activeEnemyParty.Count >= 4) { 
            return true;
        }
        else
        {
            return false;
        }
        
    }

    public void AddToParty(GameObject card)
    {
        GameObject g = Instantiate(card, PlayerSpawnPoints[activePlayerParty.Count-1]);
        activePlayerParty.Add(g);
    }

    void Attack()
    {
        //safety check 
        if (activePlayerParty.Count > 0 && activePlayerParty.Count > 0)
        {
            activePlayerParty[0].GetComponent<EntityBase>().Hurt(activeEnemyParty[0].GetComponent<EntityBase>().damage);
            Debug.Log(activeEnemyParty[0].name + "did" + activeEnemyParty[0].GetComponent<EntityBase>().damage);

            activeEnemyParty[0].GetComponent<EntityBase>().Hurt(activePlayerParty[0].GetComponent<EntityBase>().damage);
            Debug.Log(activePlayerParty[0].name + "did " + activePlayerParty[0].GetComponent<EntityBase>().damage);
            
        }
        else { 
            Debug.LogWarning("Attacking without pawns");
        }

        newTurn = false;
        //StartCoroutine(TurnTimer());
    }

    public void CheckGameEnd() //Checks to see if any of the condition 
    {
        
        if ((activePlayerParty.Count <= 0) && (activeEnemyParty.Count <= 0)) //draw
        {
            newTurn = false;
            startTurnButton.enabled= false;
            Debug.Log("Draw");
        }
        else if (activePlayerParty.Count <= 0) // enemy wins
        {
            newTurn = false;
            startTurnButton.enabled = false;
            Debug.Log("Enemy Wins");
        }
        else if (activeEnemyParty.Count <= 0) // player wins 
        {
            newTurn = false;
            startTurnButton.enabled = false;
            Debug.Log("Player Wins");
        }

        //if none of these conditions it just continues 
    }

    public void playerPawnDied() //if a player pawn dies, remove it from the list
    {
        activePlayerParty.RemoveAt(0);
        Debug.Log("Player Pawn Died.");
        PlaySoundEffect(playerDeathSound);


    }

    public void enemyPawnDied() //if an enemy pawn dies
    {
        activeEnemyParty.RemoveAt(0);
        Debug.Log("Enemy Pawn Died.");
        PlaySoundEffect(enemyDeathSound);
    }
    
    void NextTurn() //for button call
    {
        newTurn = true;
        Debug.Log("New Turn");
        PlaySoundEffect(nextTurnSound);
    }

    void ToggleSacrificeMode()
    {
        sacrificeMode = !sacrificeMode;
        Debug.Log("Sacrifice Mode is " +  sacrificeMode);
        if (sacrificeMode)
        {
            PlaySoundEffect(sacrificeOnSound);
        }
        else
        {
            PlaySoundEffect(sacrificeOffSound);
        }
    }
    
    void Sacrifice()
    {
        activeEnemyParty[0].GetComponent<EntityBase>().Hurt(Random.Range(1,15));

    }

    void PlaySoundEffect(AudioClip sound)
    {
        if (sound)
        {
            AudioSource.PlayClipAtPoint(sound, this.transform.position);
        }
        
    }

    IEnumerator TurnTimer()// this was when the turn would trigger every 2 seconds for testing
    {
        CheckGameEnd();
        yield return new WaitForSeconds(timeBetweenTurns);
        newTurn = true;
        Debug.Log("New Turn");
    }
}

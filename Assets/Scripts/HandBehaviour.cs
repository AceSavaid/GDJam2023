using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandBehaviour : MonoBehaviour
{
    [SerializeField] private List<GameObject> Cards = new List<GameObject>();
    /*
        0 = Death
        1 = Justice
        2 = Strength
        3 = Temperance
        4 = The Devil
        5 = The Fool
        6 = The Hanged Man
        7 = The Hermit
    */

    private List<GameObject> Deck = new List<GameObject>();

    [SerializeField] private GameObject playerHand;

    int horiShift = 2;
    float roShift = -2;
    float vertShift = 1;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 1; i <= 8; i++)
        {
            int cardChance = Random.Range(1, 101);

            switch(cardChance)
            {
                case <= 25: // 1
                    Deck.Add(Cards[0]);
                    Debug.Log("Death");
                    Deck[Deck.Count-1].GetComponent<CardBehaviour>().inDeck = true;
                    break;
                case > 25 and <= 35: // 2
                    Deck.Add(Cards[1]);
                    Debug.Log("Justice");
                    Deck[Deck.Count-1].GetComponent<CardBehaviour>().inDeck = true;
                    break;
                case > 35 and <= 40: // 3
                    Deck.Add(Cards[2]);
                    Debug.Log("Strength");
                    Deck[Deck.Count-1].GetComponent<CardBehaviour>().inDeck = true;
                    break;
                case > 40 and <= 60: // 4
                    Deck.Add(Cards[3]);
                    Debug.Log("Temperance");
                    Deck[Deck.Count-1].GetComponent<CardBehaviour>().inDeck = true;
                    break;
                case > 60 and <= 70: // 5
                    Deck.Add(Cards[4]);
                    Debug.Log("The Devil");
                    Deck[Deck.Count-1].GetComponent<CardBehaviour>().inDeck = true;
                    break;
                case > 70 and <= 90: // 6
                    Deck.Add(Cards[5]);
                    Debug.Log("The Fool");
                    Deck[Deck.Count-1].GetComponent<CardBehaviour>().inDeck = true;
                    break;
                case > 90 and <= 99: // 7
                    Deck.Add(Cards[6]);
                    Debug.Log("The Hanged Man");
                    Deck[Deck.Count-1].GetComponent<CardBehaviour>().inDeck = true;
                    break;
                case 100: // 8
                    Deck.Add(Cards[7]);
                    Debug.Log("The Hermit");
                    Deck[Deck.Count-1].GetComponent<CardBehaviour>().inDeck = true;
                    break;
            }
        }

        for(int i = 0; i <= 7; i++)
        {
            Instantiate(Deck[i], new Vector3(-5.3f + horiShift, -5 + vertShift, 0), Quaternion.Euler(new Vector3(0, 0, 22 + roShift)));
            horiShift += 1;
            roShift -= 5.5f;

            switch(i)
            {
                case < 2:
                    vertShift += 0.25f;
                    break;
                case 2:
                    vertShift = 1.60f;
                    break;
                case 3:
                    roShift = -25.5f;
                    break;
                case 4:
                    vertShift = 1.5f;
                    break;
                case > 4:
                    vertShift -= 0.25f;
                    break;
            }
        }

        foreach( var x in Deck) {
            Debug.Log( x.ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

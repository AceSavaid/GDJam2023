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

    int shift = -20;

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
                    break;
                case > 25 and <= 35: // 2
                    Deck.Add(Cards[1]);
                    Debug.Log("Justice");
                    break;
                case > 35 and <= 40: // 3
                    Deck.Add(Cards[2]);
                    Debug.Log("Strength");
                    break;
                case > 40 and <= 60: // 4
                    Deck.Add(Cards[3]);
                    Debug.Log("Temperance");
                    break;
                case > 60 and <= 70: // 5
                    Deck.Add(Cards[4]);
                    Debug.Log("The Devil");
                    break;
                case > 70 and <= 90: // 6
                    Deck.Add(Cards[5]);
                    Debug.Log("The Fool");
                    break;
                case > 90 and <= 99: // 7
                    Deck.Add(Cards[6]);
                    Debug.Log("The Hanged Man");
                    break;
                case 100: // 8
                    Deck.Add(Cards[7]);
                    Debug.Log("The Hermit");
                    break;
            }
        }

        for(int i = 0; i <= 7; i++)
        {
            Instantiate(Deck[i], playerHand.transform);
            shift += 5;
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

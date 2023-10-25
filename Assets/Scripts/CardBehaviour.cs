using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CardBehaviour : MonoBehaviour
{
    [SerializeField] EntityBase cardData;
    [SerializeField] Image image;
    [SerializeField] TMP_Text text;

    [SerializeField] GameObject gameMananger;

    [SerializeField] Vector3 ogPos;

    Vector3 mousePos = new Vector3();

    bool isColliding = false;
    public bool inDeck = false;

    private void Awake()
    {
        gameMananger = FindObjectOfType<GameProcess>().gameObject;
        cardData = GetComponent<EntityBase>();
        text.text = "Name: \n" + cardData.name + "\nHealth: " + cardData.health + "\n Damage:" +cardData.damage;
    }

    void Start()
    {
        ogPos = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        mousePos.z = -Camera.main.transform.position.z;

        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

    }

    void OnMouseDrag()
    {
        if(gameMananger.GetComponent<GameProcess>().CanSacrifice() == true)
        {
            gameMananger.GetComponent<GameProcess>().Sacrifice();
            Destroy(this.gameObject);
        }

        if(inDeck == true)
        {
            transform.position = new Vector3(mousePos.x, mousePos.y, 0);
        }
    }

    void OnMouseUp()
    {
        if(isColliding == false)
        {
            transform.position = ogPos;
        } else
        {
            Debug.Log("__ Mouse Up");
            if (gameMananger.GetComponent<GameProcess>().IsPartyFull() == false)
            {
                inDeck = false;
                Debug.Log("Party not full");
                gameMananger.GetComponent<GameProcess>().AddToParty(this.gameObject);
                Destroy(gameObject);
            }
        }
    }   
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isColliding = true;

        Debug.Log("test");
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Mouse Up");
            if (gameMananger.GetComponent<GameProcess>().IsPartyFull() == false)
            {
                Debug.Log("Party not full");
                gameMananger.GetComponent<GameProcess>().AddToParty(this.gameObject);
                Destroy(gameObject);
            }
            else
            {
                transform.position = ogPos;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (Input.GetMouseButtonUp(0))
        {
            transform.position = ogPos;
        }
    }
}

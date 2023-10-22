using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.Build.Content;

public class CardBehaviour : MonoBehaviour
{
    [SerializeField] EntityBase cardData;
    [SerializeField] Image image;
    [SerializeField] TMP_Text text;

    [SerializeField] GameObject gameMananger;

    [SerializeField] Vector3 ogPos;

    Vector3 mousePos = new Vector3();

    bool isColliding = false;


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
        transform.position = new Vector3(mousePos.x, mousePos.y, 0);
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

    
}

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

    private void Awake()
    {
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
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        isColliding = true;

        Debug.Log("test");

        if(Input.GetMouseButtonUp(0))
        {
            if(gameMananger.GetComponent<GameProcess>().IsPartyFull() == false)
            {
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

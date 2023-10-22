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

    Vector3 ogPos = new Vector3();
    Vector3 mousePos = new Vector3();

    private void Awake()
    {
        cardData = GetComponent<EntityBase>();
        text.text = "Name: \n" + cardData.name + "\nHealth: " + cardData.health + "\n Damage:" +cardData.damage;
        ogPos = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        mousePos.z = -Camera.main.transform.position.z;

        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Debug.Log(mousePos);
    }

    void OnMouseDrag()
    {
        transform.position = new Vector3(mousePos.x, mousePos.y, 0);
    }

    void OnMouseUp()
    {
        transform.position = ogPos;
    }
}

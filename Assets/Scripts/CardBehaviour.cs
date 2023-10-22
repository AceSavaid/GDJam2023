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


    private void Awake()
    {
        cardData = GetComponent<EntityBase>();
        text.text = "Name: \n" + cardData.name + "\nHealth: " + cardData.health + "\n Damage:" +cardData.damage;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

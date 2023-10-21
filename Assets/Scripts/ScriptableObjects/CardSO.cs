using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Card", menuName = "ScriptableObjects/Card", order = 1)]
public class CardSO : ScriptableObject
{
    [SerializeField] public GameObject pawns;
    [SerializeField] public int health = 5;
    [SerializeField] public int damage = 5;
    [SerializeField] public Image image = null;
    [SerializeField][TextArea(3, 10)] public string description = "Description";


}

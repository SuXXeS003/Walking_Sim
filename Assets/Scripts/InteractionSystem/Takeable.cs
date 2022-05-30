using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Takeable : MonoBehaviour, IInteractionItem
{
    [SerializeField] private string Name;
    [SerializeField] private int Id;
    [SerializeField] private string InfoText;

    public void Interact()
    {
        Debug.Log("Take item with name " + Name);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Readable : MonoBehaviour, IInteractionItem
{
    [SerializeField] private string Name;
    [SerializeField] private int Id;
    [SerializeField] private string InfoText;

    public void Interact()
    {
        Debug.Log("Read " + Name);
    }
}
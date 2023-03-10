using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InteractType
{
    Health,
    Refill
}

public class Interactable : MonoBehaviour
{
    public InteractType itemType;   // Type of the interactable

    public string collectableID = "";   // ID of the collectable

    public InteractType GetInteractType() { return itemType; }  // Return type of interactable

    public string GetCollectableID() { return collectableID; } // Return collectable ID
}

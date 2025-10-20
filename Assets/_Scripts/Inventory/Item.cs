using UnityEngine;

[CreateAssetMenu(fileName = "Items", menuName = "Scriptable Objects/Items")]
public class Item : ScriptableObject
{
    public Sprite fishImg;
    public string description;
    public bool canStack;
}

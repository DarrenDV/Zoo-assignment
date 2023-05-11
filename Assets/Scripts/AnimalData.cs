using UnityEngine;

[CreateAssetMenu(fileName = "New Animal", menuName = "ScriptableObjects/Animal", order = 1)]
public class AnimalData : ScriptableObject
{
    public string name;
    public CreatureType creatureType;
    public Sprite image;
    public bool canDoTrick;
    public string helloText;
    public string eatingText;
}

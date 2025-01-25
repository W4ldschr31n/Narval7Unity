using UnityEngine;

[CreateAssetMenu(fileName = "NewDialogue", menuName = "Data/Dialogue", order = 1)]
public class Dialogue : ScriptableObject
{
    public string npcName;
    [TextArea(3,5)]
    public string[] quotes;
}
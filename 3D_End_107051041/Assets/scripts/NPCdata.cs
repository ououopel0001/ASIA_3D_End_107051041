using UnityEngine;

[CreateAssetMenu(fileName = "NPC資料", menuName = "OUBAO/NPC資料")]
public class NPCdata : ScriptableObject
{
    [Header("第一段對話"), TextArea(1,5)]
    public string dialougA;
    [Header("第二段對話"), TextArea(1, 5)]
    public string dialougB;
    [Header("第三段對話"), TextArea(1, 5)]
    public string dialougC;
    [Header("未完成任務數量")]
    public int count;
    [Header("以完成任務數量")]
    public int counted;
}

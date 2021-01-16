using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NPC : MonoBehaviour
{
    [Header("NPC資料")]
    public NPCdata data;
    [Header("對話框")]
    public GameObject dialog;
    [Header("對話內容")]
    public Text textContent;
    [Header("對話間隔")]
    public float interval = 0.2f;
    [Header("對話者名稱")]
    public Text textName;


    //判斷玩家是否進入感應區
    public bool playerInArea;

    public enum NPCstate
    {
        First,Second,final
    }
    public NPCstate state = NPCstate.First;


    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "黑人(玩家)")
        {
            playerInArea = true;
            StartCoroutine(Dialog());
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if(other.name == "黑人(玩家)")
        {
            playerInArea = false;
            StopDialog();
        }
    }

    private void StopDialog()
    {
        dialog.SetActive(false);  //關閉對話框
        StopAllCoroutines();  //停止協程
    }

    private IEnumerator Dialog()
    {
        dialog.SetActive(true); //顯示對話框
        textContent.text = ""; //清空文字

        textName.text = name;

        //要說的對話
        string dialogString = data.dialougA;

        switch (state)
        {
            case NPCstate.First:
                dialogString = data.dialougA;
                break;
            case NPCstate.Second:
                dialogString = data.dialougB;
                break;
            case NPCstate.final:
                dialogString = data.dialougC;
                break;
        }

        for (int i = 0; i< dialogString.Length; i++)
        {
            textContent.text += dialogString[i] + "";
            yield return new WaitForSeconds(interval);
        }
    }
}

using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class QuestDialog : MonoBehaviour
{
    public Queue<string> dialogQueue = new Queue<string>();
    public GameObject dialogPanel; // UI Panel
    public TextMeshProUGUI questText; // UI Text (TextMeshPro)
    private bool isDialogActive = false;

    void Start()
    {
        dialogQueue.Enqueue("1. 뭐야 당신");
        dialogQueue.Enqueue("2. 악");
        dialogQueue.Enqueue("3. 건들지마");
        dialogQueue.Enqueue("4. 살려줘");
        dialogQueue.Enqueue("5. 내가 뭘 잘못했지?");
        dialogQueue.Enqueue("6. 기둥살려!");
        dialogQueue.Enqueue("7. 기둥살려요!!");
        dialogQueue.Enqueue("8. ....");
        dialogQueue.Enqueue("9. ........");
        dialogQueue.Enqueue("10. .............");

        dialogPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !dialogPanel.active)
        {
            dialogPanel.SetActive(true);
            DisplayNextDialog();
            isDialogActive = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //if (other.CompareTag("Player"))
        //{
        //    dialogPanel.SetActive(false);
        //    isDialogActive = false;
        //}
    }

    void Update()
    {
        if (isDialogActive && Input.GetKeyDown(KeyCode.Space))
        {
            DisplayNextDialog();
        }
    }

    void DisplayNextDialog()
    {
        if (dialogQueue.Count > 0)
        {
            questText.text = dialogQueue.Dequeue();
        }
        else
        {
            dialogPanel.SetActive(false);
            isDialogActive = false;
        }
    }
}

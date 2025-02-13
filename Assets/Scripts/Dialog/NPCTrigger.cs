using UnityEngine;

public class NPCTrigger : MonoBehaviour
{
    public GameObject dialoguePanel; // UI Panel (텍스트 창)

    void Start()
    {
        dialoguePanel.SetActive(false); // 게임 시작 시 텍스트 창 숨김
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // 플레이어가 닿았을 때
        {
            dialoguePanel.SetActive(true); // 텍스트 창 표시
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // 플레이어가 벗어났을 때
        {
            dialoguePanel.SetActive(false); // 텍스트 창 숨김
        }
    }
}

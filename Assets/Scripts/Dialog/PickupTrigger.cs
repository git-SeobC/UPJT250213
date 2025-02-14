using UnityEngine;

public class PickupTrigger : MonoBehaviour
{
    [SerializeField] private Quest currentQuest; // 현재 퀘스트 SO
    private bool hasTriggered = false; // 콜라이더 감지가 2번씩 되는 문제 방지용

    void Start()
    {
        currentQuest = Resources.Load<Quest>("Quest");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (hasTriggered) return;
        if (collision.gameObject.CompareTag("Player")) // 플레이어가 닿았을 때
        {
            hasTriggered = true;
            currentQuest.itemCount += 1;
            Debug.Log($"itemCount : {currentQuest.itemCount}");
            SuccessEvent.Instance.PanelUpdate();
            if (currentQuest.itemCount >= currentQuest.itemGoal)
            {
                Debug.Log("퀘스트 완료!");
                SuccessEvent.Instance.TriggerSuccess();
            }

            Destroy(gameObject);
        }
    }
}

using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SuccessEvent
{
    public event EventHandler SuccessCheck;

    public void QuestCompleted(GameObject panel)
    {
        TextMeshProUGUI text = panel.GetComponent<TextMeshProUGUI>();
        panel.SetActive(true);
        text.text = "퀘스트를 완료했습니다";
    }
}

public class QuestCountUp : MonoBehaviour
{
    [SerializeField] private GameObject textPanel;
    [SerializeField] private GameObject questPanel;
    [SerializeField] private Quest currentQuest;
    SuccessEvent successEvent = new SuccessEvent();

    void Start()
    {
        currentQuest = Resources.Load<Quest>("Quest");
        questPanel = GameObject.Find("Canvas/QuestPanel");
        textPanel = GameObject.Find("Canvas/TextPanel");
        textPanel.SetActive(false);

        successEvent.SuccessCheck += new EventHandler(MonsterKill);

        if (currentQuest == null)
        {
            Debug.LogError("Quest Scriptable Object를 찾을 수 없습니다");
            return;
        }

        if (questPanel == null)
        {
            Debug.LogError("TextPanel 찾을 수 없습니다");
            return;
        }

        if (questPanel != null && currentQuest != null)
        {
            InitializeQuestPanel();
        }
    }
    void InitializeQuestPanel()
    {
        TextMeshProUGUI titleText = questPanel.transform.Find("TitleText")?.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI descriptionText = questPanel.transform.Find("DescriptionText")?.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI goalText = questPanel.transform.Find("GoalText")?.GetComponent<TextMeshProUGUI>();


        if (titleText != null) titleText.text = currentQuest.title;
        if (descriptionText != null) descriptionText.text = currentQuest.description;
        if (goalText != null) goalText.text = currentQuest.goal + " (" + currentQuest.monsterNow + "/" + currentQuest.monsterGoal + ")";
    }

    public void UpdateQuestPanel()
    {
        TextMeshProUGUI goalText = questPanel.transform.Find("GoalText")?.GetComponent<TextMeshProUGUI>();
        if (goalText != null)
        {
            goalText.text = currentQuest.monsterGoal + " (" + currentQuest.monsterNow + "/" + currentQuest.monsterGoal + ")";
        }
        if (currentQuest.success)
        {

        }
    }

    private void MonsterKill(object sender, EventArgs e)
    {
        Debug.Log("포탈이 열렸습니다.");
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U) && currentQuest != null)
        {
            currentQuest.monsterNow += 1;

            UpdateQuestPanel();

            if (currentQuest.monsterNow >= currentQuest.monsterGoal)
            {
                currentQuest.success = true;
                Debug.Log("퀘스트 완료!");

                //SuccessCheck.Invoke(currentQuest);
            }
        }
    }
}

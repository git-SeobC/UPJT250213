using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SuccessEvent // 싱글톤 디자인 패턴으로 이벤트 작성
{
    private static SuccessEvent instance;
    public static SuccessEvent Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new SuccessEvent();
            }
            return instance;
        }
    }
    public event EventHandler SuccessCheck;
    public event EventHandler UpdatePanel;
    public void TriggerSuccess() // 성공 업데이트
    {
        Debug.Log("TriggerSuccess Event");
        SuccessCheck.Invoke(this, EventArgs.Empty);
    }
    public void PanelUpdate() // UI 업데이트
    {
        Debug.Log("PanelUpdate Event");
        UpdatePanel.Invoke(this, EventArgs.Empty);
    }
}

public class QuestCountUp : MonoBehaviour
{
    [SerializeField] private GameObject textPanel;
    [SerializeField] private GameObject questPanel;
    [SerializeField] private Quest currentQuest;
    [SerializeField] private Toggle progressCheckToggle;
    [SerializeField] private Toggle successCheckToggle;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private TextMeshProUGUI goalText;
    [SerializeField] private TextMeshProUGUI CompleteText;

    void Start()
    {
        #region 기본 Initialize
        currentQuest = Resources.Load<Quest>("Quest");
        questPanel = GameObject.Find("Canvas/QuestPanel");
        textPanel = GameObject.Find("Canvas/TextPanel");
        progressCheckToggle = GameObject.Find("Canvas/QuestPanel/ProgressCheck").GetComponent<Toggle>();
        successCheckToggle = GameObject.Find("Canvas/QuestPanel/SuccessCheck").GetComponent<Toggle>();
        titleText = questPanel.transform.Find("TitleText")?.GetComponent<TextMeshProUGUI>();
        descriptionText = questPanel.transform.Find("DescriptionText")?.GetComponent<TextMeshProUGUI>();
        goalText = questPanel.transform.Find("GoalText")?.GetComponent<TextMeshProUGUI>();
        CompleteText = textPanel.transform.Find("QuestText")?.GetComponent<TextMeshProUGUI>();
        SuccessEvent.Instance.SuccessCheck += new EventHandler(QuestCompleted);
        SuccessEvent.Instance.UpdatePanel += new EventHandler(UpdateQuestPanel);
        textPanel.SetActive(false);
        #endregion

        if (currentQuest == null)
        {
            Debug.LogError("Quest Scriptable Object를 찾을 수 없습니다");
            return;
        }
        currentQuest.itemCount = 0;
        currentQuest.success = false;
        currentQuest.progress = true;
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

    /// <summary>
    /// 퀘스트 UI 패널 초기화
    /// </summary>
    void InitializeQuestPanel()
    {
        if (titleText != null) titleText.text = currentQuest.title;
        if (descriptionText != null) descriptionText.text = currentQuest.description;
        if (goalText != null) goalText.text = currentQuest.goal + " (" + currentQuest.itemCount + "/" + currentQuest.itemGoal + ")";
        progressCheckToggle.isOn = currentQuest.progress;
        successCheckToggle.isOn = currentQuest.success;
    }

    /// <summary>
    /// 퀘스트 UI 패널 업데이트 이벤트
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void UpdateQuestPanel(object sender, EventArgs e)
    {
        Debug.Log("UpdateQuestPanel");
        if (goalText != null)
        {
            goalText.text = currentQuest.goal + " (" + currentQuest.itemCount + "/" + currentQuest.itemGoal + ")";
        }
    }

    /// <summary>
    /// 퀘스트 완료 업데이트 이벤트
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void QuestCompleted(object sender, EventArgs e)
    {
        Debug.Log("QuestCompleted");
        textPanel.SetActive(true);
        CompleteText.text = "퀘스트를 완료했습니다.";
        progressCheckToggle.isOn = currentQuest.progress = false;
        successCheckToggle.isOn = currentQuest.success = true;
    }
}

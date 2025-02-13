using System;
using UnityEngine;

// 퀘스트 유형
public enum QuestType
{
    normal, daily, weekly
}
// 일반 퀘스트 : 클리어하면 더이상 깰 수 없음
// 데일리 퀘스트 : 매일을 기준으로 퀘스트 갱신
// 위클리 퀘스트 : 주를 기준으로 퀘스트 갱신

[CreateAssetMenu(fileName = "Quest", menuName = "Quest/Quest")]
public class Quest : ScriptableObject
{
    public QuestType questType;
    //public Reward reward;
    //public Requirement requirement;

    public int money;
    public float exp;

    public int itemGoal;
    public int itemCount;

    [Header("퀘스트 정보")]
    public string title;
    public string goal;
    [TextArea] public string description;

    public bool success;
    public bool progress;
}

//[Serializable]
//[CreateAssetMenu(fileName = "Requirement", menuName = "Quest/Requirement")]
//public class Requirement : ScriptableObject
//{
//    public int itemGoal;
//    public int itemCount;
//}


//[Serializable]
//[CreateAssetMenu(fileName = "Reward", menuName = "Quest/Reward")]
//public class Reward : ScriptableObject
//{
//    public int money;
//    public float exp;
//}

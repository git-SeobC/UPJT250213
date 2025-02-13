using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

// 유니티에서 특정 데이터 또는 기능을 구현하기 위해 적합한 자료형을 고르는 건 필수
// 기본 자료형 이외에 특정 기능, 작업을 진행할 수 있는 데이터 집합체를 자료구조 (데이터 값의 모임)

// 자주 활용되는 자료구조
// 1. 리스트(List) : 순서대로 저장할 수 있고, 저장 데이터를 추가, 삭제, 검색할 수 있는 변경이 가능한 배열
// 2. 딕셔너리(dictionary) : 키 - 값으로 묶어서 저장할 수 있는 형태(json의 기본구조)
// 3. 순서대로 저장할 수 있고, 저장 데이터를 추가, 삭제, 검색할 수 있는 변경이 가능한 배열
// 4. 스택(Stack) : 자료를 후입선출(LIFO)로 관리할 때 사용하는 자료구조
// 5. 해시셋(HashSet) : 데이터의 중복을 전혀 허락하지 않는 경우, 정렬 순서가 필요 없는 경우

public class DataStructureSample : MonoBehaviour
{
    // 큐(Queue)
    // 제공해주는 기능 : 삽입, 삭제, 첫번째 값 조회 기능
    // 단점 : 중간에 있는 데이터를 접근하는 부분에서 매우 비효율적

    // string 형태의 값만 저장할 수 있는 Queue ==
    public Queue<string> stringQueue = new Queue<string>();

    private void Start()
    {
        // 1) 큐에 데이터 추가
        stringQueue.Enqueue("좀나 와도주세요.");
        stringQueue.Enqueue("문스 이일죠?.");
        stringQueue.Enqueue("나나바 껍질 20개가 해요필요.");
        stringQueue.Enqueue("와도리드겠습다니.");
        stringQueue.Enqueue("합사감니다.");

        // 2) 첫 번째 데이터 조회
        foreach (string dialog in stringQueue)
        {
            Debug.Log(stringQueue.Peek()); // 큐에 저장된 가장 맨 앞의 값을 return
        }

        // 3) 큐에 데이터 삭제
        Debug.Log(stringQueue.Dequeue()); // 큐에 저장된 맨 앞의 값을 return
        Debug.Log(stringQueue.Dequeue()); // + 맨 앞의 값을 제거
        Debug.Log(stringQueue.Dequeue());
        Debug.Log(stringQueue.Dequeue());
        Debug.Log(stringQueue.Dequeue());
    }
}

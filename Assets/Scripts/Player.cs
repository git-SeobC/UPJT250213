using System;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public AudioEvent audioEvent;
    public Item item;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioEvent.OnPlay += PlaySound;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            audioEvent.Play("등장 배경음");
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            DropItem();
        }
    }

    private void PlaySound(string soundName)
    {
        Debug.Log(soundName + "플레이 중입니다.");
    }

    private void DropItem()
    {
        var itemObject = item.gameObject;
        Instantiate(itemObject, transform.position, Quaternion.identity);
    }
}

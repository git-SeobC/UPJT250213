using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public float speed = 5f; // 이동 속도
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // A, D 또는 좌우 화살표 입력
        float moveVertical = Input.GetAxis("Vertical"); // W, S 또는 상하 화살표 입력

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical) * speed;
        rb.linearVelocity = new Vector3(movement.x, rb.linearVelocity.y, movement.z);
    }
}

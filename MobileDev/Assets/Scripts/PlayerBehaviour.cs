using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private Rigidbody rb;

    [Tooltip("Как быстро мяч движется влево/вправо")]
    public float dodgeSpeed = 5f;
    [Tooltip("Как быстро мяч движется вперед автоматически")]
    public float rollSpeed = 5f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        var horizontalSpeed = Input.GetAxis("Horizontal") * dodgeSpeed;

        rb.AddForce(horizontalSpeed, 0, rollSpeed);
    }
}

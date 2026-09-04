using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerBehaviour : MonoBehaviour
{
    /// <summary>
    /// Ссылка на компонент Rigidbody
    /// </summary>
    private Rigidbody rb;

    [Tooltip("Как быстро мяч движется влево/вправо")]
    [Range(0, 10)]
    public float dodgeSpeed = 5f;
    [Tooltip("Как быстро мяч движется вперед автоматически")]
    [Range(0, 10)]
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

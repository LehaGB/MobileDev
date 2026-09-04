using UnityEngine;

/// <summary>
/// Настроить камеру, чтобы следовать за целью и смотреть на нее. 
/// </summary>
public class CameraBehaviour : MonoBehaviour
{
    [Tooltip("На какой объект должна смотреть камера")]
    public Transform target;

    [Tooltip("Какое смещение будет у камеры относительно цели")]
    public Vector3 offset = new Vector3(0, 3, -6);

    private void Update()
    {
        transform.position = target.position + offset;
        transform.LookAt(target);
    }
}

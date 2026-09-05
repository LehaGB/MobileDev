using UnityEngine;


/// <summary>
/// Обрабатывает создание новой плитки и уничтожение этой
/// при достижении игроком конца
/// </summary>
public class TheEndBehaviour : MonoBehaviour
{
    [Tooltip("Сколько времени ждать перед уничтожением плитки после достижение конца")]
    public float destroyTime = 1.5f;

    //  Сначала проверяем, столкнулись ли мы с игроком.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerBehaviour>())
        {
            //  Если да, создаем новую плитку.
            var gm = GameObject.FindObjectOfType<GameManager>();
            gm.SpawnNextTile();

            //  И уничтожте эту плитку чере короткую задержку.
            Destroy(transform.parent.gameObject, destroyTime);
        }
    }
}

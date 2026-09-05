using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleBehaviour : MonoBehaviour
{
    [Tooltip("Как долго ждать перед запуском игры")]
    public float waitTime = 2.0f;

    private void OnCollisionEnter(Collision collision)
    {
        //  Сначала проверяем, столкнулись ли с игроком.
        if (collision.gameObject.GetComponent<PlayerBehaviour>())
        {
            //  Уничтожаем ирока.
            Destroy(collision.gameObject);

            //  Вызывам функцию ResetGame после истечения времени(waitTime).
            Invoke("ResetGame", waitTime);
        }
    }


    /// <summary>
    /// Перезапустит текущий загруженный уровень
    /// </summary>
    private void ResetGame()
    {
        //  Получаем имя текущего уровня.
        string sceneName = SceneManager.GetActiveScene().name;

        //  Перезапускает текущий уровень.
        SceneManager.LoadScene(sceneName);
    }
}

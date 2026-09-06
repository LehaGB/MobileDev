using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


/// <summary>
/// Управляет основным процессом игры.
/// </summary>
public class GameManager : MonoBehaviour
{
    [Tooltip("Ссылка на плитку, которую мы хотим создать")]
    public Transform tile;

    [Tooltip("Ссылка на препятствие, которую мы хотим создать")]
    public Transform obstacle;

    [Tooltip("Где должна быть размещена первая плитка")]
    public Vector3 startPoint = new Vector3(0, 0, -5);

    [Tooltip("Сколько плиток мы должны создать в advance")]
    [Range(1, 15)]
    public int initSpawnNum = 10;

    [Tooltip("Сколько тайлоа создать без препятствий")]
    public int initNoObstacle = 4;

    /// <summary>
    /// Где должен быть создан следующий тайл.
    /// </summary>
    private Vector3 nextTileLocation;


    /// <summary>
    /// Как должет быть повернут следующий тайл ?
    /// </summary>
    private Quaternion nextTileRotation;

    private void Start()
    {
        //  Установим нашу начальную точку
        nextTileLocation = startPoint;
        nextTileRotation = Quaternion.identity;

        for (int i = 0; i < initSpawnNum; ++i)
        {
            SpawnNextTile(i >= initNoObstacle);
        }
    }


    /// <summary>
    /// Создаст тайл в определенном место и
    /// настроит следующую позицию
    ///  <param name="spawnObstacles">Если мы должны создать
    ///  препятствие</param>
    /// </summary>
    public void SpawnNextTile(bool spawnObstacle = true)
    {
        var newTile = Instantiate(tile, nextTileLocation, nextTileRotation);

        //  Определите, где и под каким углом мы
        //  должны создать следующий элемент
        var nextTile = newTile.Find("NextSpawnPoint");
        nextTileLocation = nextTile.position;
        nextTileRotation = nextTile.rotation;

        if (spawnObstacle)
        {
            SpawnObstacle(newTile);
        }
    }


    private void SpawnObstacle(Transform newTile)
    {
        //  Теперь нам нужно получить все возможные места для появления припятстаия.
        var obstacleSpawnPoints = new List<GameObject>();

        //  Проходим через каждый из дочерних игровых объектов в нашем тайле.
        foreach (Transform child in newTile)
        {
            //  Если у него есть тег ObstacleSpawn.
            if (child.CompareTag("ObstacleSpawn"))
            {
                //  Мы добовляем его как возможность.
                obstacleSpawnPoints.Add(child.gameObject);
            }
            //  Убедись, что есть хотя бы одна.
            if(obstacleSpawnPoints.Count > 0)
            {
                //  Получите случайную точку спауна из тех, что есть.
                int index = Random.Range(0, obstacleSpawnPoints.Count);
                var spawnPoint = obstacleSpawnPoints[index];

                //  Сохраните ее позицию для использования.
                var spawnPos = spawnPoint.transform.position;

                //  Создайте наше припятствие.
                var newObstacle = Instantiate(obstacle, spawnPos, Quaternion.identity);

                //  Привяжите его к плитке.
                newObstacle.SetParent(spawnPoint.transform);
            }
        }
    }
}

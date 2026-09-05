using System;
using UnityEngine;


/// <summary>
/// Управляет основным процессом игры.
/// </summary>
public class GameManager : MonoBehaviour
{
    [Tooltip("Ссылка на плитку, которую мы хотим создать")]
    public Transform tile;

    [Tooltip("Где должна быть размещена первая плитка")]
    public Vector3 startPoint = new Vector3(0, 0, -5);

    [Tooltip("Сколько плиток мы должны создать в advance")]
    [Range(1, 15)]
    public int initSpawnNum = 10;

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
            SpawnNextTile();
        }
    }


    /// <summary>
    /// Создаст тайл в определенном место и
    /// настроит следующую позицию
    /// </summary>
    private void SpawnNextTile()
    {
        var newTile = Instantiate(tile, nextTileLocation, nextTileRotation);

        //  Определите, где и под каким углом мы
        //  должны создать следующий элемент
        var nextTile = newTile.Find("NextSpawnPoint");
        nextTileLocation = nextTile.position;
        nextTileRotation = nextTile.rotation;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SquareSpawner : MonoBehaviour
{
    [SerializeField] private SquareController[] _squarePrefabs;
    [SerializeField] private float _minSpawnTime;
    [SerializeField] private float _maxSpawnTime;
    
    [SerializeField] private Transform _leftSpawnBorder;
    [SerializeField] private Transform _rightSpawnBorder;
    
    [SerializeField] private Transform _leftTargetBorder;
    [SerializeField] private Transform _rightTargetBorder;
    
    private float _delayBeforeNextSpawn;

    private void Update()
    {
        if (_delayBeforeNextSpawn > 0)
        {
            _delayBeforeNextSpawn -= Time.deltaTime;
            return;
        }
        var square = SpawnRandomSquare();
        var targetDirection = GetTargetDirection(square);
        square.SetDirection(targetDirection);
        
        _delayBeforeNextSpawn = Random.Range(_minSpawnTime, _maxSpawnTime);
    }
    private Vector3 GetTargetDirection(SquareController square)
    {
        var targetPosition = GenerateRandomPointOnLine(_leftTargetBorder, _rightTargetBorder);
        var direction = targetPosition - square.transform.position;
        return direction;
    }

    private SquareController SpawnRandomSquare()
    {
        var randomPrefabIndex = Random.Range(0, _squarePrefabs.Length);

        var square = Instantiate(_squarePrefabs[randomPrefabIndex], transform);
        square.transform.position = GenerateRandomPointOnLine(_leftSpawnBorder, _rightSpawnBorder);
        return square;
    }
    private Vector3 GenerateRandomPointOnLine(Transform left, Transform right)
    {
        var randomProgress = Random.Range(0f, 1f);
        return Vector3.Lerp(left.position, right.position, randomProgress);
    }
}

using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform _spawnPoint;

    [SerializeField]
    private Item _itemPrefab;

    private Item _itemInstance;

    private void Start()
    {
        _itemInstance = Instantiate(_itemPrefab, _spawnPoint.position, Quaternion.identity);
    }

    private void Update()
    {
        if (_itemInstance == null)
        {
            _itemInstance = Instantiate(_itemPrefab, _spawnPoint.position, Quaternion.identity);
        }
    }
}

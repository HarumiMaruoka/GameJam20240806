using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform[] _spawnPoints;

    [SerializeField]
    private Item[] _itemPrefabs;

    private Stack<Item> _itemTable = new Stack<Item>();

    public HashSet<Item> _items = new HashSet<Item>();

    private void Start()
    {
        ShuffleAndStoreItems();
    }

    public void RemoveItem(Item item)
    {
        _items.Remove(item);
        item.gameObject.SetActive(false);
        _itemTable.Push(item);
    }

    private void SpawnItems(int count = 1)
    {
        for (int i = 0; i < count; i++)
        {
            var point = _spawnPoints[UnityEngine.Random.Range(0, _spawnPoints.Length)];
            if (_itemTable.Count == 0)
            {
                ShuffleAndStoreItems();
            }

            var item = _itemTable.Pop();
            item.gameObject.SetActive(true);
            item.transform.position = point.position;
            _items.Add(item);
        }
    }

    private void ShuffleAndStoreItems()
    {
        // _itemPrefabs‚ðƒVƒƒƒbƒtƒ‹‚·‚é
        for (int i = 0; i < _itemPrefabs.Length; i++)
        {
            int j = UnityEngine.Random.Range(0, _itemPrefabs.Length);
            var temp = _itemPrefabs[i];
            _itemPrefabs[i] = _itemPrefabs[j];
            _itemPrefabs[j] = temp;
        }

        // _itemTable‚É_itemPrefabs‚ð’Ç‰Á‚·‚é
        foreach (var itemPrefab in _itemPrefabs)
        {
            var item = Instantiate(itemPrefab);
            item.gameObject.SetActive(false);
            _itemTable.Push(item);
        }
    }
}

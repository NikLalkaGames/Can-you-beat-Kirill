using System;
using Common.Containers;
using Items.Interaction.Base;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Items.Generation
{
    public class ItemGeneratorWorld : ItemGenerator
    {
        [SerializeField] private Vector2 locationRectSize;
        
        [SerializeField] private int numberOfItems;

        private Collider[] _collisions;

        protected override void Awake()
        {
            base.Awake();
            _collisions = new Collider[10];
        }
        
        private void Start()
        {
            GenerateRandomItems();
        }
        
        private void GenerateRandomItems()
        {
            for (int i = 0; i < numberOfItems; i++)
            {
                GenerateRandomItem();
            }
        }
        
        public void GenerateRandomItem()
        {
            PoolManager.SpawnObject(
                GetRandomItem(),
                GetFreeSpawnPosition(),
                Quaternion.identity);
        }
        
        private GameObject GetRandomItem()
        {
            return ItemPrefabs[Random.Range(0, ItemPrefabs.Length)].gameObject;
        }
        
        private Vector2 GetFreeSpawnPosition()
        {
            Vector2 spawnPosition;
            do
            {
                spawnPosition = GetRandomPoint(locationRectSize);
            }
            while(Physics.OverlapSphereNonAlloc(spawnPosition, 1f, _collisions) > 0);

            return spawnPosition;
        }

        private Vector2 GetRandomPoint(Vector2 rectSize)
        {
            return new Vector2(Random.Range(-rectSize.x, rectSize.x), Random.Range(-rectSize.y, rectSize.y));
        }
        

        
    }
}
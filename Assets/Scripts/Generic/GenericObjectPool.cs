using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class GenericObjectPool<T> where T : Component
    {
        private Stack<T> itemPool;
        protected int initialPoolSize;
        protected T itemPrefab;
        
        public GenericObjectPool(T prefab, int size) {
            itemPrefab = prefab;
            initialPoolSize = size;
            itemPool = new Stack<T>();
            InitializePool();
        }

        private void InitializePool(){
            for(int i=0; i<initialPoolSize; i++){
                ReturnItem(CreateNewItem());
            }
        }

        public T GetItem(){
            if(itemPool.Count == 0){
                return CreateNewItem();
            }
            return itemPool.Pop();
        }

        private T CreateNewItem(){
            T item = GameObject.Instantiate<T>(itemPrefab);
            item.gameObject.SetActive(false);
            return item;
        }

        public void ReturnItem(T item){
            item.gameObject.SetActive(false);
            itemPool.Push(item);
        }

        public void SetPrefab(T prefab){
            itemPrefab = prefab;
        }

        public void SetInitialPoolSize(int size){
            initialPoolSize = size;
        }
    }
}

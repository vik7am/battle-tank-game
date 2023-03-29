using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public abstract class GenericObjectPool<T> : GenericMonoSingleton<GenericObjectPool<T>>
    where T : Component
    {
        private Stack<T> itemPool;
        protected int initialPoolSize;
        protected T itemPrefab;
        
        private void Start() {
            itemPool = new Stack<T>();
            SetPrefab();
            SetInitialPoolSize();
            InitializePool();
        }

        private void InitializePool(){
            for(int i=0; i<initialPoolSize; i++){
                ReturnItem(CreateNewItem());
            }
        }

        public T GetItem(){
            if(itemPool.Count == 0)
                return CreateNewItem();
            return itemPool.Pop();
        }

        private T CreateNewItem(){
            T item = Instantiate<T>(itemPrefab);
            item.gameObject.SetActive(false);
            return item;
        }

        public void ReturnItem(T item){
            item.gameObject.SetActive(false);
            itemPool.Push(item);
        }

        protected abstract void SetPrefab();
        protected abstract void SetInitialPoolSize();
    }
}

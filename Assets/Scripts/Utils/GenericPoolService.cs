using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public abstract class GenericObjectPool<T> : GenericMonoSingleton<GenericObjectPool<T>>
    where T : MonoBehaviour
    {
        private Queue<T> itemPool;
        protected T itemPrefab;
        private void Start() {
            itemPool = new Queue<T>();
            SetPrefab();
        }

        public T GetItem(){
            if(itemPool.Count == 0)
                return CreateNewItem();
            return itemPool.Dequeue();
        }

        private T CreateNewItem(){
            T item = Instantiate<T>(itemPrefab);
            item.gameObject.SetActive(false);
            return item;
        }

        public void ReturnItem(T item){
            itemPool.Enqueue(item);
        }

        protected abstract void SetPrefab();
    }
}

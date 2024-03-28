using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Card
{
    public class CardFactory
    {
        private readonly ObjectPool pool;

        public CardFactory(ObjectPool pool)
        {
            this.pool = pool;
            pool.Initialize(30);
        }

        public CardView CreateCard()
        {
            return pool.GetObject();
        }
    }
    
    public class ObjectPool
    {
        private readonly IObjectResolver container;
        private readonly Game.GameMachine gameMachine;
        
        private Stack<CardView> objects = new Stack<CardView>();
        private List<CardView> activeObjects = new List<CardView>();
        private CardView prefab;
        private GameObject poolParrent;

        public ObjectPool(CardView prefab, IObjectResolver container, Game.GameMachine gameMachine)
        {
            this.prefab = prefab;
            this.container = container;
            this.gameMachine = gameMachine;
        }
        
        public void Initialize(int count)
        {
            poolParrent = new GameObject("CardPool");
            for (int i = 0; i < count; i++)
            {
                CardView obj = container.Instantiate(prefab, poolParrent.transform);
                obj.gameObject.SetActive(false);
                objects.Push(obj);
                
                gameMachine.AddListener(obj);
            }
        }

        public CardView GetObject()
        {
            if (objects.Count == 0)
            {
                CardView obj = container.Instantiate(prefab, poolParrent.transform);
                obj.gameObject.SetActive(false);
                objects.Push(obj);
                
                gameMachine.AddListener(obj);
            }

            CardView pooledObject = objects.Pop();
            activeObjects.Add(pooledObject);
            pooledObject.gameObject.SetActive(true);
            return pooledObject;
        }
        
        public void ReturnObject(CardView obj)
        {
            obj.gameObject.SetActive(false);
            objects.Push(obj);
        }
        
        public void ReturnAllObjects()
        {
            foreach (var obj in activeObjects)
            {
                objects.Push(obj);
                obj.gameObject.SetActive(false);
            }
            activeObjects.Clear(); 
        }
    }
}

    
    
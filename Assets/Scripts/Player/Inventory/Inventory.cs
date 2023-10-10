using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    public class Inventory : MonoBehaviour {

        #region Singleton
        public static Inventory instance;
        void Awake() {
            if (instance != null) {
                Debug.Log("More than one instance of inventory Out");
                return;
            }
            instance = this;
        }
        #endregion

        [Header("Inventory space")]
        [SerializeField]
        public int space = 20; //How many slots inventory contain
        
        public List<Item> items = new List<Item>();

        public bool Add(Item item) {
            if (!item.isDefaultItem) {
                if (items.Count >= space) {
                    Debug.Log("Not enough room");
                    return false;
                }
                items.Add(item);
            }

            return true;
        }

        public void Remove(Item item) {

            items.Remove(item);
        }

    }

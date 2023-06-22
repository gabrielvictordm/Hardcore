using System.Collections.Generic;
using UnityEngine;
using Inventory.Model;
using System;

namespace DefaultNamespace
{
    public class SaveExample : MonoBehaviour
    {
        [Header("CACHE")]
        public SaveSystem.SaveData data;
        
        [Header("REFERENCES")]
        public InventorySO inventory;

        public Transform player;
        
        public ItemSO[] items;
        public ItemParameterSO[] itemsParametersSO;
         
        void OnGUI()
        {
            if (GUI.Button(new Rect(10, 10, 200, 25), "Save"))
            {
                #region Aplicar valores
                List<SaveSystem.ItemStack> stacks = new();
                
                foreach (var item in inventory.inventoryItems)
                {
                    List<SaveSystem.ItemStackParameter> lista = new List<SaveSystem.ItemStackParameter>();
                    foreach (var parameter in item.itemState)
                    {
                        lista.Add(new SaveSystem.ItemStackParameter()
                        {
                             id = Array.IndexOf(this.itemsParametersSO, parameter.itemParameter),
                            value = parameter.value
                        });
                    }

                    stacks.Add(new SaveSystem.ItemStack()
                    {
                        id = Array.IndexOf(this.items, item.item),
                        amount = item.quantity,
                        parameters = lista.ToArray()
                    });
                }
                
                data.playerPos = player.position;
                data.playerRot = player.eulerAngles;

                data.itemStacks = stacks.ToArray();
                #endregion
                
                //Save em si
                SaveSystem.Save(data, 0);
            }
            
            if (GUI.Button(new Rect(10, 40, 200, 25), "Load"))
            {
                //Load em si
                data = SaveSystem.Load(0);
                Debug.Log(data.itemStacks.Length);
            
                #region Ler valores
                player.position = data.playerPos;
                player.eulerAngles = data.playerRot;
                
                inventory.inventoryItems.Clear();
                
                foreach (var item in data.itemStacks)
                {
                    InventoryItem i = new InventoryItem();
                    i.quantity = item.amount;
                    i.itemState = new List<ItemParameter>();
                    if(item.id>=0) i.item = this.items[item.id];
                    inventory.inventoryItems.Add(i);
                    foreach (var VAr in item.parameters)
                    {
                        i.itemState.Add(new ItemParameter()
                        {
                            itemParameter = itemsParametersSO[VAr.id],
                            value = VAr.value
                        });
                    }
                }
                
                //Carregado
                #endregion
            }
        }
    }
}
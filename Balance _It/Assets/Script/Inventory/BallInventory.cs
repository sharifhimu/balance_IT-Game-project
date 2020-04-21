//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class BallInventory : MonoBehaviour {

//    public InventoryButton[] ballButton;
//    public InventoryItems inventoryItem;
//    private void OnEnable()
//    {
//        InitButtons();
//    }

//    public void InitButtons()
//    {
//        for(int i=0; i<ballButton.Length; i++)
//        {
//            if(Scores.Instance)
//            {
//                if(Scores.Instance.settings.ballUnlocked[i])
//                {  
//                    ballButton[i].GotoUnlocked(inventoryItem.items[i].id, inventoryItem.items[i].sprite);
//                    if (Scores.Instance.settings.ballIndx == i)
//                        ballButton[i].GotoUsed(inventoryItem.items[i].id, inventoryItem.items[i].sprite);
//                }
//                else
//                {
                    
//                    ballButton[i].GotoLocked(inventoryItem.items[i].id, inventoryItem.items[i].coinsNeededToUnlock, inventoryItem.items[i].sprite);
//                }
                
//            }
//        }
//    }
//}

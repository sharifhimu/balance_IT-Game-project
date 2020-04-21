//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;


//public class InventoryButton : MonoBehaviour {

//    public int id;

//    [Header("Objects")]
//    public GameObject Downbar;
//    public GameObject coinImage;
//    public GameObject tick;

//    [Header("Text")]
//    public Text CoinNeededText;

//    [Header("Ball Image")]
//    public Image ballImage;

//    public void GotoUnlocked(int id, Sprite img)
//    {
//        this.id = id;
//        ballImage.sprite = img;
//        Downbar.SetActive(false);

//    }

//    public void GotoLocked(int id, int score, Sprite img)
//    {
//        this.id = id;
//        ballImage.sprite = img;
//        Downbar.SetActive(true);
//        tick.SetActive(false);
//        CoinNeededText.gameObject.SetActive(true);
//        coinImage.SetActive(true);
//        CoinNeededText.text = score.ToString();
//    }

//    public void GotoUsed(int id, Sprite img)
//    {
//        this.id = id;
//        ballImage.sprite = img;
//        Downbar.SetActive(true);
//        tick.SetActive(true);
//        coinImage.SetActive(false);
//        CoinNeededText.gameObject.SetActive(false);
//    }

//    public void ButtonPressed()
//    {
//        if(Scores.Instance)
//        {
//            BallInventory inventory = GetComponentInParent<BallInventory>();
//            if(Scores.Instance.settings.ballUnlocked[id])
//            {
//                Scores.Instance.settings.ballIndx = id;
//                inventory.InitButtons();
//            }
//            else
//            {
//                if(Scores.Instance.records.coin >= inventory.inventoryItem.items[id].coinsNeededToUnlock)
//                {
//                    Scores.Instance.settings.ballUnlocked[id] = true;
//                    Social.ReportProgress(inventory.inventoryItem.items[id].GPGID, 100.0f, (bool success) =>
//                     {  
//                         //If want to check
//                     });
//                    Scores.Instance.records.coin -= inventory.inventoryItem.items[id].coinsNeededToUnlock;
//                    inventory.InitButtons();
//                    MainMenuScript.instance.UpdateInventoryCoinText();
//                    Scores.Instance.SaveRecordBinaryData();
//                    Scores.Instance.SaveSettingsBinaryData();


//                }
//                else
//                {
//                    SSTools.ShowMessage("Not enough coin", SSTools.Position.bottom, SSTools.Time.oneSecond);
//                }
//            }
//        }
//        else
//        {
//            Debug.Log("Inventory Button not working cos scores object not found");
//        }
//    }
//}

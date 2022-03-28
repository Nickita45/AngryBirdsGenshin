using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SquadController : MonoBehaviour
{
    public GameObject[] slots;
    GenerateCollectionItems collection;
    bool isChange = false;
    int idButton = -1;
    void Start()
    {
        collection = this.GetComponent<GenerateCollectionItems>();
        generateSlotsItem();
        setBackgroundSlotsWhite();
    }
    public void generateSlotsItem()
    {
        
        for(int i=0; i < slots.Length;i++)
        {
            
            Image[] imgs = slots[i].GetComponentsInChildren<Image>(true);
            ItemCollectionClass item = getItem(DataHandler.Instance.userdata.squad[i]);
            imgs[2].sprite = item.spriteCharacter;
            imgs[3].sprite = ElementsSingleton.Instance.searchSpriteByElement(item.elementCharacter.ToString());
            
            imgs[4].gameObject.SetActive(false);
            imgs[6].gameObject.SetActive(false);
    
            slots[i].GetComponentsInChildren<TextMeshProUGUI>()[0].text = item.nameCharacter;
            slots[i].GetComponentInChildren<Button>(true).enabled = false;
        }
    }
    public ItemCollectionClass getItem(string nameCharacter)
    {
        ItemCollectionClass item = collection.characterItem[0];
        foreach(ItemCollectionClass itemcollect in collection.characterItem)
        {
            if(itemcollect.nameCharacter == nameCharacter)
                return itemcollect;
        }
        return item;
    }
    public void setBackgroundSlotsWhite()
    {
        for(int i=0; i < slots.Length;i++)
        {
            slots[i].transform.parent.GetComponent<Image>().color = Color.white;;
        }
    }
    public void clickToChange(Button btn)
    {
        setBackgroundSlotsWhite();
        int id = int.Parse(btn.gameObject.name.Replace("ImageSlot","")) - 1;
        Color clr = btn.GetComponent<Image>().color;
        if(!isChange || id != idButton)
        {    
            
            clr = Color.yellow;
            isChange = true;
            idButton = id;
        }
        else
        {   
            
            clr = Color.white;
            isChange = false;
            idButton = -1;
        }
        btn.GetComponent<Image>().color = clr;
    }
    public void clickToChooseBird(ItemCollectionClass item)
    {
        
        Dictionary<string,int> customCollection = this.GetComponent<SquadController>().removeCountBirds(DataHandler.Instance.userdata.collection);
       

        print(item.nameCharacter+"-"+customCollection[item.nameCharacter]);
        if(customCollection[item.nameCharacter] > 0 && idButton != -1)
        {
            DataHandler.Instance.userdata.squad[idButton] = item.nameCharacter;
            DataHandler.Instance.SaveData();
           
            idButton = -1;
            isChange = false;
            generateSlotsItem();
            collection.GenerateCollection();
            setBackgroundSlotsWhite();
        }
    }
    public Dictionary<string,int> removeCountBirds(Dictionary<string,int> dict)
    {
        
        Dictionary<string,int> customCollection = new Dictionary<string, int>(dict);
        /*foreach(KeyValuePair<string,int> kvp in customCollection)
        {
            print(kvp.Key+":"+kvp.Value);
        }*/
        for(int i=0;i < DataHandler.Instance.userdata.squad.Length;i++)
        {
            customCollection[DataHandler.Instance.userdata.squad[i]]=customCollection[DataHandler.Instance.userdata.squad[i]]-1;
        }
        return customCollection; 
    }
}

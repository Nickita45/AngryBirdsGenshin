using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
public class GenerateCollectionItems : MonoBehaviour
{
    [SerializeField]
    public GameObject prefabItem;
    [SerializeField]
    public ItemCollectionClass[] characterItem;
    public UnityEvent onClickItems;
    public bool isShowCountText = false;
    List<ItemCollectionClass> collectionSort = new List<ItemCollectionClass>();

    // Start is called before the first frame update
    void Start()
    {
        setMyCollection();    
    }
    public void setMyCollection()
    {
        generateListWithPlayerCollection();
        GenerateCollection();  
    }
    public void setAllCollection()
    {
        collectionSort.Clear();
        collectionSort.AddRange(characterItem);
        GenerateCollection();
        
    }
    public void generateListWithPlayerCollection()
    {
        collectionSort.Clear();
        foreach(ItemCollectionClass item in characterItem)
        {
            if(DataHandler.Instance.userdata.collection.ContainsKey(item.nameCharacter))
            {
                collectionSort.Add(item);
            }
        }

    }
    public void GenerateCollection()
    {
        deleteComponents(this.gameObject);
        GameObject childObj;
        
        var originalCollection = DataHandler.Instance.userdata.collection;
        Dictionary<string,int> collectionCUSTOM = new Dictionary<string, int>(originalCollection);
        if(isShowCountText)
        {
            //collectionCUSTOM.Clear();
            collectionCUSTOM = this.GetComponent<SquadController>().removeCountBirds(DataHandler.Instance.userdata.collection);
        }
        foreach(ItemCollectionClass item in collectionSort)
        {
            childObj = Instantiate(prefabItem,transform);
            Image[] imgs = childObj.GetComponentsInChildren<Image>();
            
            imgs[2].sprite = item.spriteCharacter;
            imgs[3].sprite = ElementsSingleton.Instance.searchSpriteByElement(item.elementCharacter.ToString());
            if(collectionCUSTOM.ContainsKey(item.nameCharacter) == true)
            {
                imgs[4].gameObject.SetActive(false);
                imgs[6].gameObject.SetActive(false);

                if(isShowCountText)
                    childObj.GetComponentsInChildren<TextMeshProUGUI>()[1].text = collectionCUSTOM[item.nameCharacter].ToString();
                
            }
            
            childObj.GetComponentsInChildren<TextMeshProUGUI>()[0].text = item.nameCharacter;
            if(isShowCountText)
            childObj.GetComponentInChildren<Button>().onClick.AddListener(() => this.GetComponent<SquadController>().clickToChooseBird(item));
        }
    }
    public void deleteComponents(GameObject gmj)
    {
        
        for(int i=gmj.transform.childCount-1;i>=0;i--)
        {
            Destroy(gmj.transform.GetChild(i).gameObject);
        }
    }
}

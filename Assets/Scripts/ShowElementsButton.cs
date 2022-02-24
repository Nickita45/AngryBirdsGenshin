using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowElementsButton : MonoBehaviour
{
    public bool isActivated = false;
    public GameObject PrefabElement;
    Dictionary<string,Color> colors = new Dictionary<string,Color>(){{"Cryo",Color.cyan},
                                                                {"Hydro",Color.blue},
                                                                {"Anemo",Color.green}};
    public List<GameObject> elements = new List<GameObject>();
    public static ShowElementsButton Instance
    {
         get
         {
             if (instance == null)
                 instance = FindObjectOfType(typeof(ShowElementsButton)) as ShowElementsButton;
 
             return instance;
         }
         set
         {
             instance = value;
         }
    }
    private static ShowElementsButton instance;
    public void changeActive(bool isChange)
    {
        if(isChange)
        {
            if(isActivated == true)
                isActivated = false;
            else
                isActivated = true;
        }

        if(isActivated == true)
        {
            isShowElementary();
            Color c = this.GetComponent<Image>().color;
            c.a = 0.4f;
            this.GetComponent<Image>().color = c;
        }
        else
        {
            clearAllElements();
            Color c = this.GetComponent<Image>().color;
            c.a = 1f;
            this.GetComponent<Image>().color = c;
        }
    }
    public void clearAllElements()
    {
        //MoveWithObjects[] elements = FindObjectsOfType<MoveWithObjects>();
        for(int i=elements.Count-1;i>-1;i--)
        {
            Destroy(elements[i].gameObject);
        }
    }
    public void isShowElementary()
    {
        clearAllElements();
        elements.Clear();
        BallShoot[] birds = FindObjectsOfType<BallShoot>();
        EntityClass[] entities = FindObjectsOfType<EntityClass>();
        List<EntityClass> entitesWithElementary = new List<EntityClass>();
        //entitesWithElementary.Remove(r => r.gameObject.CompareTag("Untagged") == true)
        for(int i=0;i<entities.Length;i++)
        {
            if(!entities[i].gameObject.CompareTag("Untagged"))
                entitesWithElementary.Add(entities[i]);
        }
        print(entitesWithElementary.Count);
        print(birds.Length);

        for(int i=0;i<birds.Length;i++)
        {
            if(!birds[i].GetComponent<BallShoot>().enabled)
                continue;
            GameObject gmj;
            Vector2 vector2 = new Vector2(birds[i].transform.position.x,birds[i].transform.position.y+1f);
            gmj = Instantiate(PrefabElement,vector2,PrefabElement.transform.rotation);
            gmj.GetComponent<MoveWithObjects>().setFollowObject(birds[i].transform);
            gmj.GetComponent<SpriteRenderer>().color = colors[birds[i].tag.ToString()];
            elements.Add(gmj);
        }
        foreach(EntityClass entity in entitesWithElementary)
        {
            GameObject gmj;
            Vector2 vector2 = new Vector2(entity.transform.position.x,entity.transform.position.y+1f);
            gmj = Instantiate(PrefabElement,vector2,PrefabElement.transform.rotation);
            gmj.GetComponent<MoveWithObjects>().setFollowObject(entity.transform);
            gmj.GetComponent<SpriteRenderer>().color = colors[entity.tag.ToString()];
            elements.Add(gmj);
        }
    }
    
}

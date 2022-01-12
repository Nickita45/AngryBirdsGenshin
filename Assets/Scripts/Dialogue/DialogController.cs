using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class DialogController : MonoBehaviour
{
    public DialogClass[] dialogs;
    private DialogClass currentDialog;
    private int currentPage = 0;
    public GameObject prefab;
    private GameObject currentSpawnObj;
    public void setCurrentDialog(int i)
    {
        currentDialog =  dialogs[i];
        currentPage = 0;
        GameObject gmjCanvas = FindObjectOfType<Canvas>().gameObject;
        currentSpawnObj = Instantiate(prefab,gmjCanvas.transform);
        currentSpawnObj.GetComponentInChildren<TextMeshProUGUI>().text = currentDialog.dilogue[0];
        currentSpawnObj.GetComponent<Button>().onClick.AddListener(() => updatePageByClick());
    }
    public void updatePageByClick()
    {
        currentPage++;
        if(currentPage >= currentDialog.dilogue.Count)
        {
            Destroy(currentSpawnObj);
        }
        else
        {
            currentSpawnObj.GetComponentInChildren<TextMeshProUGUI>().text = currentDialog.dilogue[currentPage];
        }

    }
    
    public static DialogController Instance
    {
         get
         {
             if (instance == null)
                 instance = FindObjectOfType(typeof(DialogController)) as DialogController;
 
             return instance;
         }
         set
         {
             instance = value;
         }
    }
    private static DialogController instance;
}

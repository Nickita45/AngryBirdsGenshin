using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static LevelManager Instance
    {
         get
         {
             if (instance == null)
                 instance = FindObjectOfType(typeof(LevelManager)) as LevelManager;
 
             return instance;
         }
         set
         {
             instance = value;
         }
    }
    private static LevelManager instance;
    [SerializeField] private int maxFor3Stars = 5000;
    [SerializeField] private int maxFor2Stars = 4000;
    public GameObject EnemiesObject,PanelWin,BallsObject;
    private int currentRating = 0; 
    private int currentEnemyCount = 1;
    bool isEndLevel = false;
    [SerializeField] private TextMeshProUGUI textCount;
    public GameObject prefabDisplayText;
    public Sprite starActive;
    void Start()
    {
        currentEnemyCount = EnemiesObject.transform.childCount;
        textCount.text = currentRating+"";
    }
    public void increaseRating(int count, bool isEnity)
    {

        currentRating+=count;
        if(isEnity)
        {
            currentEnemyCount--;
            if(currentEnemyCount <= 0 && !isEndLevel)
            {    
                isEndLevel = true;
                StartCoroutine(winLevel());
            }
        }
        textCount.text = currentRating+"";
    }
    IEnumerator winLevel()
    {
        yield return new WaitForSeconds(1f);
        
        BallShoot[] balls = BallsObject.GetComponentsInChildren<BallShoot>();
        int countSurviveBird = 0;
        for(int i=0;i<balls.Length;i++)
        {
            if(balls[i].enabled)
            {
                GameObject gmj;
                gmj = Instantiate(prefabDisplayText,balls[i].transform.position,Quaternion.identity);
                gmj.SetActive(true);
                gmj.GetComponent<TextMeshPro>().text = "1000";
                //gmj.GetComponent<TextMeshPro>().fontSize = gmj.GetComponent<TextMeshPro>().fontSize * sizeText;
                //if(!isEnity)
                gmj.GetComponent<TextMeshPro>().color = Color.red;
                print(gmj.GetComponent<Animation>().clip);
                gmj.GetComponent<Animation>()["Test_Display"].speed = 0.5f;
                gmj.GetComponent<Animation>().Play();

                countSurviveBird++;
            }
        }
        yield return new WaitForSeconds(0.5f);
        PanelWin.SetActive(true);
        TextMeshProUGUI[] texts = PanelWin.GetComponentsInChildren<TextMeshProUGUI>();
        Image[] images = PanelWin.GetComponentsInChildren<Image>();
        
        
        //print(countSurviveBird);
        currentRating+=countSurviveBird*1000;
        texts[3].text = currentRating.ToString();
        //7,8,9
        
        images[7].sprite = starActive;
        if(currentRating >= maxFor2Stars)
            images[8].sprite = starActive;
        if(currentRating >= maxFor3Stars)
            images[9].sprite = starActive;
    }
    public IEnumerator lostLevel()
    {
        
        yield return new WaitForSeconds(1.0f);
        if(isEndLevel == false)
        {
            isEndLevel = true;
            PanelWin.SetActive(true);
            TextMeshProUGUI[] texts = PanelWin.GetComponentsInChildren<TextMeshProUGUI>();
            Image[] images = PanelWin.GetComponentsInChildren<Image>();
            texts[0].text = "Уровень не пройден!";
            //int countSurviveBird = BallsObject.GetComponentsInChildren<BallShoot>().Length;
            //currentRating+=countSurviveBird*1000;
            texts[3].text = currentRating.ToString();
            images[5].gameObject.SetActive(false);
        }
    }
    public void restartLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}

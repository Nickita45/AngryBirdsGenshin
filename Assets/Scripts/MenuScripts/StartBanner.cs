using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class StartBanner : MonoBehaviour
{
    public GameObject animButton;
    public GameObject BannerPanel;
    public int currentPage = 0;
    public List<BannerClass> banners;
    public Sprite classicBannerWeapon;//УБРАТЬ!
    public AudioSource audioSource;
    public AudioClip[] audioClipsForBanner;
    public LevelController startAction;
    public void startBannerButton()
    {
        if(DataHandler.Instance.userdata.levels.Count > 1)
        {
            animButton.SetActive(true);
            animButton.GetComponent<Animation>().Play();
            audioSource.PlayOneShot(audioClipsForBanner[0]);
            StartCoroutine(startBannersAfterAnim());
        }
    }
    IEnumerator startBannersAfterAnim()
    {   
        while(animButton.GetComponent<Animation>().isPlaying)
        {
            yield return new WaitForSeconds(0.1f);
        }
        animButton.SetActive(false);
        BannerPanel.SetActive(true);
        
        generateItems();
    }
    public void generateItems()
    {
        if(!BannerPanel.GetComponent<Animation>().isPlaying)
        {
            BannerPanel.GetComponent<Animation>().Play();
            currentPage++;
            
            if(currentPage > banners.Count)
            {
                //END
                if(DataHandler.Instance.userdata.dialogs[3] == false)
                {
                    DialogController.Instance.setCurrentDialog(3);
                    DataHandler.Instance.userdata.dialogs[3] = true;
                    
                }
                DataHandler.Instance.userdata.isXiao = true;
                DataHandler.Instance.SaveData();
                BannerPanel.SetActive(false);
                startAction.Start();
                UIController.Instance.SetBannerButton();
            }
            else
            {
                if(banners[currentPage-1].countStars == 3)
                    audioSource.PlayOneShot(audioClipsForBanner[1]);
                else
                    audioSource.PlayOneShot(audioClipsForBanner[2]);
                Image[] imgs = BannerPanel.GetComponentsInChildren<Image>(true);
                    
                imgs[1].sprite = banners[currentPage-1].mainPicture;    
                if(banners[currentPage-1].isWeapon)
                {
                    imgs[2].gameObject.SetActive(true);
                    imgs[1].sprite = classicBannerWeapon;
                    imgs[2].sprite = banners[currentPage-1].mainPicture;
                }        
                else
                    imgs[2].gameObject.SetActive(false);
    
            
                BannerPanel.GetComponentInChildren<TextMeshProUGUI>().text = banners[currentPage-1].name;
                for(int i=0;i<5;i++)
                {
                    imgs[3+i].gameObject.SetActive(true);
                }
                for(int i=5;i>banners[currentPage-1].countStars;i--)
                {
                    imgs[7-(5-i)].gameObject.SetActive(false);
                }
            }
        }
    }
    

}

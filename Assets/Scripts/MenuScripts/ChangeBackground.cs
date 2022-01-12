using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeBackground : MonoBehaviour
{
    [SerializeField] private RawImage _img;
    [SerializeField] private Texture[] backgrounds;
    [SerializeField] private float _x,_y; 
    void Start()
    {
        _img = GetComponent<RawImage>();
        StartCoroutine(changeBackground());
    }
    void Update()
    {
        _img.uvRect = new Rect(_img.uvRect.position + new Vector2(_x,_y) * Time.deltaTime,_img.uvRect.size);

    }
    IEnumerator changeBackground()
    {
        yield return new WaitForSeconds(20.0f);
        _x= _x*-1;
        //_img.uvRect = new Rect(new Vector2(0,0),_img.uvRect.size);
        //_img.texture = backgrounds[Random.Range(0,backgrounds.Length)];
        StartCoroutine(changeBackground());
    }
    public void setToStart()
    {
        _img.uvRect = new Rect(new Vector2(0,0),_img.uvRect.size);
        _x = 0.01f;
        StartCoroutine(changeBackground());
    }
}

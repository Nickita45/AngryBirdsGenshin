using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectEffetct : MonoBehaviour
{
    private SpriteRenderer spriteRender;
    private Vector2 vectorMove;
    private int speedDiseble;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        spriteRender = GetComponent<SpriteRenderer>();
        float rnd = Random.Range(0.2f, 0.5f);
        gameObject.transform.localScale = new Vector2(rnd, rnd);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.transform.position += (Vector3)vectorMove * Mathf.Abs(Time.deltaTime);
        spriteRender.color -= new Color32 (0, 0, 0, (byte)(speedDiseble * Time.deltaTime));
        

       
        if (spriteRender.color.a <= 0)
        {
            Destroy(gameObject);
        }


    }

    

    public void setStats(Sprite sprite, int speedDiseble, Vector2 vectorMove)
    {
        Start();
        spriteRender.sprite = sprite;
        this.speedDiseble = speedDiseble;
        this.vectorMove = vectorMove;
    }
}

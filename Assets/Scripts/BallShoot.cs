using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShoot : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody2DBullet;
    [SerializeField] public Rigidbody2D rigidbody2DShoot;
    [SerializeField] public GameObject ShootPrefab;
    [SerializeField] public Transform BallSpawnerPos;

    [SerializeField] private float maxDistance = 2f;
    [SerializeField] private bool isPressed = false;
    [SerializeField] private bool isFirst = false;
    private MusicBalls soundBall;
    private float randomTimeSound = 2;
    private void Start()
    {
        rigidbody2DBullet = GetComponent<Rigidbody2D>();
        soundBall = GetComponent<MusicBalls>();
    }
    private void Update()
    {
        if(isPressed)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(Vector2.Distance(mousePos, rigidbody2DShoot.position) > maxDistance)
            {
                rigidbody2DBullet.position = rigidbody2DShoot.position + (mousePos - rigidbody2DShoot.position).normalized * maxDistance;
            }
            else
            {
                rigidbody2DBullet.position = mousePos;
            }
        }

        if (randomTimeSound < 0f)
        {
                soundBall.playStaySound();
                randomTimeSound = Random.Range(1f, 7f);
        }
        else
        {
                randomTimeSound -= Time.deltaTime;
        }

    }
    public void OnMouseDown(){
        if(isFirst)
        {
            isPressed = true;
            rigidbody2DBullet.isKinematic = true;
        }
    }
    public void OnMouseUp(){
        if(isFirst)
        {
            isPressed = false;
            rigidbody2DBullet.isKinematic = false;
            StartCoroutine(LetGo());
        }
    }
    IEnumerator LetGo()
    {
        yield return new WaitForSeconds(0.1f);
        soundBall.playflySound();
        gameObject.GetComponent<SpringJoint2D>().enabled = false;
        this.enabled = false;

        yield return new WaitForSeconds(2f);
        if(ShootPrefab != null)
        {
            ShootPrefab.transform.position = BallSpawnerPos.position;
            ShootPrefab.GetComponent<BallShoot>().isFirst = true;
        }
        else
        {
            StartCoroutine(LevelManager.Instance.lostLevel());
        }
    }
    
}

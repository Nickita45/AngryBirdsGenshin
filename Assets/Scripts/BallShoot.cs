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
    private Animation animation;
    private float randomTimeSound = 2;

    private const float SPEEDJUMP = 3, TIMERBEETWEENSTEPS = 0.01f; 

    private void Start()
    {
        animation = GetComponent<Animation>();
        rigidbody2DBullet = GetComponent<Rigidbody2D>();
        soundBall = GetComponent<MusicBalls>();
        StartCoroutine(Jump());
    }
    private void Update()
    {
        if(isPressed)
        {
            animation = null;
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

        if(isFirst && animation != null)
        {
            StopAllCoroutines();
            animation = null;
        }

    }
    public void OnMouseDown(){
        if(isFirst)
        {
            isPressed = true;
            Camera.main.GetComponent<CameraMovement>().isPressedOnBall = true;
            rigidbody2DBullet.isKinematic = true;
        }
    }
    public void OnMouseUp(){
        if(isFirst)
        {
            isPressed = false;
            Camera.main.GetComponent<CameraMovement>().isPressedOnBall = false;
            rigidbody2DBullet.isKinematic = false;
            StartCoroutine(LetGo());
        }
    }
    IEnumerator LetGo()
    {
        Vector3 oldPos = gameObject.transform.position;
        yield return new WaitForSeconds(0.1f);
        animation = null;
        
        soundBall.playflySound();
        gameObject.GetComponent<SpringJoint2D>().enabled = false;
        this.enabled = false;
        Camera.main.GetComponent<CameraMovement>().isFollowObj = true;
        //Camera.main.GetComponent<CameraMovement>().objOldPos = oldPos;
        Camera.main.GetComponent<CameraMovement>().objFollow = this.gameObject;
        StartCoroutine(Camera.main.GetComponent<CameraMovement>().FollowObjectCamera());

        yield return new WaitForSeconds(2f);
        nextBirdOrFinish();
    }
    public void nextBirdOrFinish()
    {
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
    IEnumerator Jump()
    {
        Vector2 startposition = this.transform.position;


        yield return new WaitForSeconds(Random.Range(2, 5));
        while (animation != null)
        {
            animation.Play();
            Vector2 targetposion = startposition + new Vector2(0, 1.2f);
            rigidbody2DBullet.gravityScale = 0;
            while (Vector2.Distance(transform.position, targetposion) > 0.1f)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetposion, SPEEDJUMP * Time.deltaTime);
                yield return new WaitForSeconds(TIMERBEETWEENSTEPS);
            }
            yield return new WaitForSeconds(0.1f);
            while (Vector2.Distance(transform.position, startposition) > 0.1f)
            {
                transform.position = Vector2.MoveTowards(transform.position, startposition, SPEEDJUMP * Time.deltaTime);
                yield return new WaitForSeconds(TIMERBEETWEENSTEPS);
            }

            rigidbody2DBullet.gravityScale = 1;
            yield return new WaitForSeconds(Random.Range(2, 5));

        }

    }
}

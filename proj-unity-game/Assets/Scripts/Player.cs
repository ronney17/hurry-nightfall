using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;

    public float speed;

    public float jumpSpeed;

    bool isOnGround;

    Animator anim;

    int posPlayer = 0;

    LevelManager myLevel;

    float moveQt;

    public GameObject startPosition;
    public AudioSource audioMorte;
    public AudioSource audioAterrissagem;
    public AudioSource audioPulo;
    public gameController restart;
    public float speedMultiplier;
    public float speedIncreaseMilestone;
    private float speedIncreaseMilestoneCount;
    public float fallMultiplier = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        myLevel = FindObjectOfType<LevelManager>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        isOnGround = true;
        positionAdjust();
        speedIncreaseMilestoneCount = speedIncreaseMilestone;
    }

    // Update is called once per frame
    private void Update()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }

        if (transform.position.z > speedIncreaseMilestoneCount)
        {
            speedIncreaseMilestoneCount += speedIncreaseMilestone;
            speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
            speed = speed * speedMultiplier;
        }

        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speed);

        if ((Input.GetButtonDown("Jump") || (Input.GetKeyDown(KeyCode.UpArrow)) && isOnGround))
        {
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            isOnGround = false;
            anim.SetBool("jump", !isOnGround);
            //audioPulo.Play();
        }

        if ((Input.GetKeyDown(KeyCode.A) || (Input.GetKeyDown(KeyCode.LeftArrow)) && posPlayer == 0 && isOnGround == true))
        {
            transform.position = new Vector3(transform.position.x - moveQt, transform.position.y, transform.position.z);
            posPlayer = 1;
        }
        else if ((Input.GetKeyDown(KeyCode.D) || (Input.GetKeyDown(KeyCode.RightArrow)) && posPlayer == 0 && isOnGround == true))
        {
            transform.position = new Vector3(transform.position.x + moveQt, transform.position.y, transform.position.z);
            posPlayer = 2;
        }
        else if ((Input.GetKeyDown(KeyCode.D) || (Input.GetKeyDown(KeyCode.RightArrow)) && posPlayer == 1 && isOnGround == true))
        {
            transform.position = new Vector3(transform.position.x + moveQt, transform.position.y, transform.position.z);
            posPlayer = 0;
        }
        else if ((Input.GetKeyDown(KeyCode.A) || (Input.GetKeyDown(KeyCode.LeftArrow)) && posPlayer == 2 && isOnGround == true))
        {
            transform.position = new Vector3(transform.position.x - moveQt, transform.position.y, transform.position.z);
            posPlayer = 0;
        }
    }
    void FixedUpdate()
    {
        if ((Input.GetKey(KeyCode.Space) || (Input.GetKeyDown(KeyCode.UpArrow)) && isOnGround))
        {
            isOnGround = false;
        }
        else if (!isOnGround)
        {
            audioAterrissagem.Play();
        }
    }

    private void OnCollisionStay(Collision other)
    {
        isOnGround = true;
        anim.SetBool("jump", !isOnGround);
        if (other.gameObject.tag == "hit")
        {
            transform.position = startPosition.transform.position;
            posPlayer = 0;
            audioMorte.Play();
            pausa();
            restart.GameOver();
        }
    }

    void positionAdjust()
    {
        moveQt = myLevel.firstGround.GetComponent<BoxCollider>().bounds.extents.x;
        moveQt = (moveQt / 2) + (moveQt / 3);
    }
    public void pausa()
    {
        speed = 0;
    }
}
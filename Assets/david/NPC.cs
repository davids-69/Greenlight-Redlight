using System.Collections;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] private float speed = 1.5f;
    public GameObject player;
    private bool HasLineOfSight = false;
   // public float degreesPerSec;
    public bool startRotate = false;
    private bool isInDeathZone;
    public bool goalzone;



    public Rigidbody2D rb;
   // public Vector2 movement;
    public float PlayerVelocity = 0;
    public bool ismoving;

    Color head_Color;
    public SpriteRenderer sr;
    SpriteRenderer head;
    public int unitchangecolor;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = player.GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        StartCoroutine(RotationHandler());
    }


    // Update is called once per frame
    void Update()
    {
        if (isInDeathZone == true && GameObject.FindGameObjectWithTag("Goal").GetComponent<goal>().Goalzone == false)
        {
            PlayerVelocity = rb.linearVelocity.magnitude;
            if (PlayerVelocity > 0.01f)
            {
                ismoving = true;
                Destroy(player);


            }
        }
        else
        {
            ismoving = false;
            
        }
            

        

        /*movement = new Vector2(Input.)
        if (Input.GetKey(KeyCode.D))
        { 
            rb.linearVelocity = new Vector2(0, speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.linearVelocity = new Vector2(0, -speed);
        }
        if (PlayerVelocity > 0)
        { 
            ismoving = true;
        }
        else
        {
            ismoving = false;
        }*/


        /*if (HasLineOfSight)
        {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
                transform.localRotation = Quaternion.Euler(new Vector3(0, 0, transform.localRotation.eulerAngles.z + degreesPerSec * Time.deltaTime));
                transform.localScale = new Vector3(1, -1, -1);   
        }*/


        if (startRotate == true)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
            //Ändra färg till rött
            //Kommunicera med ett objekts spriterenderer
            sr.color = Color.green; // go 
        }
        else 
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            //Ändra färg till grönt 
            //Kommunicera med ett objekts spriterenderer
             sr.color = Color.red; // stop
            
        }

    }
    // -178.699

    private void FixedUpdate()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, player.transform.position - transform.position);
        if (ray.collider != null)
        {
            HasLineOfSight = ray.collider.CompareTag("Player");
            if (HasLineOfSight == true)
            {
                Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.green);
            }
            else
            {
                Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.red);
            }
        }
    }
    IEnumerator RotationHandler()
    {
        while (true)
        {
            float randomtimer = Random.Range(1, 7);
            yield return new WaitForSeconds(randomtimer);
            startRotate = !startRotate;
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (player == other.gameObject)
        {
            isInDeathZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (player == other.gameObject)
        { 
            isInDeathZone = false; 
        }
    } 
}

using System.Collections;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] private float speed = 1.5f;
    private GameObject player;

    private bool HasLineOfSight = false;
    public float degreesPerSec;
    public bool startRotate = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(RotationHandler());
       
    }


    // Update is called once per frame
    void Update()
    {
        if (HasLineOfSight)
        {
            //transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            // transform.localRotation = Quaternion.Euler(new Vector3(0, 0, transform.localRotation.eulerAngles.z + degreesPerSec * Time.deltaTime));

           // transform.localScale = new Vector3(1, -1, -1);

        }
        if (startRotate == true)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
        }
        else 
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        
        }
    // -178.699

    private void FixedUpdate()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, player.transform.position - transform.position);
        if (ray.collider != null)
        {
            Debug.Log("test");
            HasLineOfSight = ray.collider.CompareTag("Player");
            if (HasLineOfSight)
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
}

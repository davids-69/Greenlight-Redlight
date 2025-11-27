using UnityEngine;

public class goal : MonoBehaviour
{
    public SpriteRenderer sr;
    SpriteRenderer Goal;
    public BoxCollider2D rb;
    public GameObject player;

    public bool Goalzone = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = player.GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (player == collision.gameObject)
        {
            Goalzone = true;


        }
    }

    
}

using System.Collections;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class timer : MonoBehaviour
{
    public GameObject gameoverwin;

    public int countdown = 60;
    public TMP_Text stats;
    public float Timer = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        StartCoroutine(ttimer());
    }

    // Update is called once per frame
    void Update()
    {
        stats = stats.GetComponent<TMP_Text>();
        stats.text = "Timer: " + countdown;

        if(countdown == 0)
        {
            StopAllCoroutines();
            gameoverwin.GetComponent<changescene>().ChangeScene("gameover");
        }
    } 
            

    IEnumerator ttimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            countdown -= 1;


        }

    }
}
    





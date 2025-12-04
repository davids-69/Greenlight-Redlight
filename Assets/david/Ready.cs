using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Ready : MonoBehaviour
{
    // public GameObject gameoverwin;

    public int countdown;
    public TMP_Text stats;
    public float Timer = 1;

    public GameObject NPC;

    public float RotateTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        NPC = GameObject.FindGameObjectWithTag("NPC");
        stats = stats.GetComponent<TMP_Text>();
        stats.text = "Ready: " + countdown;

        DontDestroyOnLoad(gameObject);
       // StartCoroutine(ttimer());
    }

    // Update is called once per frame
    void Update()
    {
        RotateTime = NPC.GetComponent<NPC>().TimeToRotate;
        if (RotateTime > 3)
        {
            stats.text = "Ready?" ;
        }
        else if (RotateTime > 2)
        {
            stats.text = "3 " ;
        }
        else if (RotateTime > 1)
        {
            stats.text = "2 " ;
        }
        else if (RotateTime > 0.5)
        {
            stats.text = "1 " ;
        }
        else 
        {
            stats.text = "STOP " ;
        }
    }

        // StopAllCoroutines();
        // gameoverwin.GetComponent<changescene>().ChangeScene("gameover");


      /* private IEnumerator ttimer()
        {
            while (true)
            {
                yield return new WaitForSeconds(1);
                countdown -= 1;
           }

        }*/
    }

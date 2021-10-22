using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerKontrol : MonoBehaviourPunCallbacks
{
    private Rigidbody2D fizik;
    public GameObject[] obje;
    public GameObject player;
    public int hareketsayac;
    private float screenwidth;
    PhotonView pw;
    string[] playerColor = { "Red", "Blue", "Yellow" };
    
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            if (gameObject.name== "Player"+playerColor[i]+"(Clone)")
            {
                hareketsayac = i + 1;
            }
        }
        pw = gameObject.GetComponent<PhotonView>();
        fizik = GetComponent<Rigidbody2D>();
        screenwidth = Screen.width;
        //for (int i = 0; i < obje.Length; i++)
        //{
        //    obje[i] = GetComponent<GameObject>();
        //}
      
        
    }
    void Update()
    {
        if (pw.IsMine)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                if (Input.GetTouch(i).phase == TouchPhase.Began) Hareket();
            }
            //Hareket();
        }
        

    }

    void Hareket()
    {
        int i = 0;
        while (i < Input.touchCount)
        {
            //if (Input.touchCount == 3)
            
                if (Input.GetTouch(0).position.x < screenwidth / 2)
                {
                    if (hareketsayac != 0)
                    {
                        hareketsayac--;
                    }
                }
                if (Input.GetTouch(0).position.x > screenwidth / 2)
                {
                    if (hareketsayac != 4)
                    {
                        hareketsayac++;
                    }
                }
            
            i++;
        }
        
        gameObject.transform.position = obje[hareketsayac].transform.position;
        //    if (Input.GetKeyDown(KeyCode.A))
        //{
        //    Debug.Log("a ya bas");
        //    if (hareketsayac != 0)
        //    {
        //        hareketsayac--;
        //    }
        //}
        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    Debug.Log("d ya bas");
        //    if (hareketsayac != 4)
        //    {
        //        hareketsayac++;
        //    }
        //}

        //Debug.Log("hareket");

    }


    public void solhareket()
    {

        if (hareketsayac != 0)
        {
            hareketsayac--;
        }
        Debug.Log("Solharekt");

        player.transform.position = obje[hareketsayac].transform.position;
    }
    public void saghareket()
    {
        if (hareketsayac != 4)
        {
            hareketsayac++;
        }
        Debug.Log("Sagharekt");
        player.transform.position = obje[hareketsayac].transform.position;
    }
}

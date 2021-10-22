using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;


public class playerBluefail : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    public GameObject oyunkontrol;
    public GameObject butonlar;
    [PunRPC]
    public void yokol()
    {
        PhotonNetwork.Destroy(gameObject);
    }


    public Text scoredegisken;
   
    int count;
    void Start()
    {
        Debug.Log("deydimiyor");
        truesound.GetComponent<AudioSource>();
        falsesound.GetComponent<AudioSource>();
        //playerredcollider.GetComponent<Collider2D>();

        count = 0;

    }
    
    // Update is called once per frame

    public AudioSource truesound;
    public AudioSource falsesound;

   

    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("deldi geçti");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PhotonView pw = gameObject.GetComponent<PhotonView>();
        Debug.Log("triger");
        var direk = collision.GetComponent<DirekKontrol>();
        SpriteRenderer sprite = collision.GetComponent<SpriteRenderer>();
        //SpriteRenderer player = gameObject.GetComponent<SpriteRenderer>();
        //if (direk.color.ToString() == "RGBA(1,000, 0,106, 0,000, 1,000)")

        Debug.Log(sprite.material.name.ToString());
        if (sprite.material.name.ToString() == "Blue (Instance)")
        {
            
            count++;

            //Destroy(collision.gameObject);
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            truesound.Play();

            scoredegisken.GetComponent<Text>().text = count.ToString();
        }
        if (sprite.material.name.ToString() == "Yellow (Instance)")
        {
      
            falsesound.Play();
            //butonlar.transform.gameObject.SetActive(true);
            //oyunkontrol.transform.gameObject.SetActive(false);
            //GameObject.FindWithTag("direkler").SetActive(false);

            
            //gameObject.GetComponent<CircleCollider2D>().enabled = false;
            //this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            PhotonNetwork.Destroy(this.gameObject);
            
        }
        if (sprite.material.name.ToString() == "Red (Instance)")
        {
           
            falsesound.Play();
            //butonlar.transform.gameObject.SetActive(true);
            //oyunkontrol.transform.gameObject.SetActive(false);
            //GameObject.FindWithTag("direkler").SetActive(false);

            
            
            //gameObject.GetComponent<CircleCollider2D>().enabled = false;
            //gameObject.GetComponent<SpriteRenderer>().enabled = false;
            PhotonNetwork.Destroy(this.gameObject);
        }
        //if (direk.Color == ColorEnum.Red)
        //{

            
        //}
        //else if (direk.Color == ColorEnum.Blue || direk.Color == ColorEnum.Purple)
        //{
            
        //}

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;


public class playerfail : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    public GameObject oyunkontrol;
    GameObject butonlar;
    public ColorEnum color;
    public GameObject scoredegisken;
    PhotonView pw;
    int count;
    void Start()
    {
        butonlar = GameObject.FindGameObjectWithTag("Restart");
        
        pw = gameObject.GetComponent<PhotonView>();
        truesound.GetComponent<AudioSource>();
        falsesound = GameObject.FindGameObjectWithTag("Carpti").GetComponent<AudioSource>();
        
        count = 0;
    }
    public AudioSource truesound;
    AudioSource falsesound;

    string[] RedColorString = { "Red (Instance)", "Yellow (Instance)", "Blue (Instance)" };
    string[] BlueColorString = { "Blue (Instance)", "Yellow (Instance)", "Red (Instance)" };
    string[] YellowColorString = {  "Yellow (Instance)", "Blue (Instance)","Red (Instance)" };


    private void OnTriggerEnter2D(Collider2D collision)
    {
        SpriteRenderer sprite = collision.GetComponent<SpriteRenderer>();
        if (gameObject.name == "PlayerRed(Clone)")
        {
            Colored(collision, RedColorString);
            //pw.RPC("Colored", RpcTarget.All, collision, RedColorString);
        }
        if (gameObject.name == "PlayerBlue(Clone)")
        {
            Colored(collision, BlueColorString);
            //pw.RPC("Colored", RpcTarget.All, collision, BlueColorString);
        }
        if (gameObject.name == "PlayerYellow(Clone)")
        {
            Colored(collision, YellowColorString);
            //pw.RPC("Colored", RpcTarget.All, collision, YellowColorString);
        }

        //if (pw.IsMine)
        //{
        //    if (collision.gameObject.GetComponent<DirekKontrol>().Color == gameObject.GetComponent<playerfail>().color)
        //    {
        //        truesound.Play();

        //        PhotonNetwork.Destroy(collision.GetComponent<GameObject>().gameObject);
        //        count++;
        //        GameObject scorecu = GameObject.FindGameObjectWithTag("Score");
        //        scorecu.GetComponent<Text>().text = count.ToString();

        //    }
        //    else
        //    {
        //        falsesound.Play();


        //        butonlar.gameObject.GetComponent<Canvas>().enabled = true;

        //        PhotonNetwork.Destroy(gameObject);

        //    }
        //}




    }
    public void direkSpriteFalse(Collision2D collision)
    {
        collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
    void Colored(Collider2D collision, string[] Renkler)
    {

        SpriteRenderer sprite = collision.GetComponent<SpriteRenderer>();
        if (sprite.material.name.ToString() == Renkler[0])
        {
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            truesound.Play();
            if (pw.IsMine)
            {
               
                collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                count++;
                GameObject scorecu = GameObject.FindGameObjectWithTag("Score");
                scorecu.GetComponent<Text>().text = count.ToString();
            }

        }

        if (sprite.material.name.ToString() == Renkler[1] || sprite.material.name.ToString() == Renkler[2])
        {

            falsesound.Play();
            //butonlar.transform.gameObject.SetActive(true);
            //oyunkontrol.transform.gameObject.SetActive(false);
            //gameObject.GetComponent<CircleCollider2D>().enabled = false;
            //gameObject.GetComponent<SpriteRenderer>().enabled = false;
            //PhotonNetwork.Destroy(this.gameObject);
            if (pw.IsMine)
            {
                butonlar.gameObject.GetComponent<Canvas>().enabled = true;
                PhotonNetwork.Destroy(gameObject);
            }
          
            
            
            
            //Regen();
        }
    }
    void Regen()
    {
        GameObject LifePlayer = GameObject.FindGameObjectWithTag("Oyuncu");
        if (LifePlayer == null)
        {
            GameObject Network = GameObject.FindGameObjectWithTag("Network");
            GameObject[] Direkler = GameObject.FindGameObjectsWithTag("direkler");


            //StopCoroutine(Network.gameObject.GetComponent<Network>().GameStart());
            butonlar.gameObject.GetComponent<Canvas>().enabled = true;
            for (int i = 0; i < Direkler.Length; i++)
            {
                Destroy(Direkler[i]);
            }
            //Network.gameObject.GetComponent<Network>().OnLeftRoom();
            //Network.gameObject.GetComponent<Network>().OnLeftLobby();

        }
    }
    
       
         
        

  
}
    
  
        
        
        
        
    


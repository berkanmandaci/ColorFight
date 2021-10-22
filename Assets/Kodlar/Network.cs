using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Network : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    public Transform spawndirekler;
    public GameObject karakter,hareketliDirekParent,hareketliDirekKonum;
    public Transform[] spawn;
    public GameObject[] direkler;
    GameObject oyunbaslaButton;
    public int[] direklerchildIndex = { 0, 1, 2, 3, 4, 5 };
    public float Timer = 0;
    int click = 0;
    int[] esitle;


    public int PlayerNumber;
    string[] Colors = {"Red","Blue","Yellow"};
    Color[] ColorsDeger = {Color.red,Color.blue,Color.yellow};

    GameObject[] LifePlayer;
    PhotonView pw;
    GameObject butonlar;
    void Start()
    {

        oyunbaslaButton = GameObject.FindGameObjectWithTag("Text");
        PhotonNetwork.ConnectUsingSettings();
        
        pw = gameObject.GetComponent<PhotonView>();
       
      
    }
   public void yenidenoynacanvas()
    {
        butonlar = GameObject.FindGameObjectWithTag("Restart");
        butonlar.gameObject.GetComponent<Canvas>().enabled = true;
    }
    public override void OnJoinedRoom()//odaya katılındı karakterler oluştururuldu.
    {

        Debug.Log("Odaya Giriş Yapıldı.");
        PlayerNumber = PhotonNetwork.PlayerList.Length;
        //PhotonNetwork.Instantiate("PlayerRed", spawn[0].position, spawn[0].rotation, 0, null);
        //LifePlayer = GameObject.FindGameObjectsWithTag("Oyuncu");
        /////Deneme1
        //for (int i = 0; i < PlayerNumber - 1; i++)
        //{
        //    if (LifePlayer[i].GetComponent<playerfail>().color != ColorEnum.Red) PhotonNetwork.Instantiate("PlayerRed", spawn[0].position, spawn[0].rotation, 0, null);
        //    else if (LifePlayer[i].GetComponent<playerfail>().color != ColorEnum.Blue) PhotonNetwork.Instantiate("PlayerBlue", spawn[1].position, spawn[1].rotation, 0, null);
        //    else if ((LifePlayer[i].GetComponent<playerfail>().color != ColorEnum.Yellow)) PhotonNetwork.Instantiate("PlayerYellow", spawn[2].position, spawn[2].rotation, 0, null);
        //}

        /////Deneme2
        //Oyuncu yoksa kırmızı oyuncu oyuna giricek

        //if(LifePlayer==null) PhotonNetwork.Instantiate("PlayerRed", spawn[0].position, spawn[0].rotation, 0, null);
        // else
        // {
        //     //Yaşayan oyuncular döndürülücek. Olmayan Color enum oyuna dahil olucak.
        //     for (int i = 0; i < LifePlayer.Length; i++)
        //     {

        //         switch (LifePlayer[i].GetComponent<playerfail>().color)
        //         {
        //             case ColorEnum.Red:


        //                 break;
        //             case ColorEnum.Blue:

        //                 break;
        //             case ColorEnum.Yellow:

        //                 break;
        //         }
        //     }


        // }


        //Kusurlu Çalışıyor
        switch (PlayerNumber)
        {
            case 1:
                Debug.Log("Player" + Colors[PlayerNumber - 1]);
                karakter = PhotonNetwork.Instantiate("Player" + Colors[PlayerNumber - 1], spawn[PlayerNumber - 1].position, spawn[PlayerNumber - 1].rotation, 0, null);
                break;
            case 2:

                karakter = PhotonNetwork.Instantiate("Player" + Colors[PlayerNumber - 1], spawn[PlayerNumber - 1].position, spawn[PlayerNumber - 1].rotation, 0, null);
                break;
            case 3:
                karakter = PhotonNetwork.Instantiate("Player" + Colors[PlayerNumber - 1], spawn[PlayerNumber - 1].position, spawn[PlayerNumber - 1].rotation, 0, null);
                break;

            default:
                break;
        }
        GameObject scorecu = GameObject.FindGameObjectWithTag("Score");

    }
    public void buttonbaslagit()//Zorla basla butonuna basıldı.
    {
        if (PhotonNetwork.IsMasterClient)
        {
            Debug.Log("1-MasterClientten Butona basıldı.");
            GetComponent<PhotonView>().RPC("buttonbas", RpcTarget.All, null);
        }
        else
        {
            GameObject.Find("InfoText").GetComponent<Text>().text = "Yanlızca oda kurucusu oyunu başlatabilir!";

        }
    }
    [PunRPC]
    public void Randomize(int[] items)//Dizi'yi karıştır
    {
        System.Random rand = new System.Random();

        for (int i = 0; i < items.Length - 1; i++)
        {
            int j = rand.Next(i, items.Length);
            int temp = items[i];
            items[i] = items[j];
            items[j] = temp;
        }
    }
    public void renklendir()//Direklerin sırasını karıştırarak spawnla
    {
        Timer -= Time.deltaTime;
       

        if (Timer <= 0f)
        {
       
            Randomize(direklerchildIndex);

            for (int i = 0; i < 6; i++)
            {

                PhotonNetwork.Instantiate("hareketlidirek" + direklerchildIndex[i].ToString(), spawndirekler.transform.GetChild(i).position, Quaternion.identity);
            }
           
            Timer = 0.7f;
        }
    }
    private void FixedUpdate()

    {
        if (click == 1&&PhotonNetwork.IsMasterClient)//master client butona bastıysa
        {
            renklendir();
            
        }
        if (click==1)
        {
            GetComponent<PhotonView>().RPC("playerfailed", RpcTarget.All, null);
        }

    }

    public void yenidenoynagit()
    {
        
        photonView.RPC("yenidenoyna", RpcTarget.All, null);

    }

    [PunRPC]
    public void yenidenoyna()
    {
        if (LifePlayer.Length == 0)
        {
            //GameObject.Find("yenidenoynaCanvas").transform.gameObject.SetActive(false);
            //GameObject Network = GameObject.FindGameObjectWithTag("Network");
            //Network.gameObject.GetComponent<Network>().OnLeftRoom();
            //Network.gameObject.GetComponent<Network>().OnLeftLobby();
            PhotonNetwork.LeaveRoom();
            PhotonNetwork.LeaveLobby();


            PhotonNetwork.LoadLevel("oyun");
        }
    }
    [PunRPC]
    public void playerfailed()
    {
        
        LifePlayer = GameObject.FindGameObjectsWithTag("Oyuncu");
        Debug.Log(LifePlayer.Length.ToString());
        if (LifePlayer.Length == 0)
        {
            GameObject[] Direkler = GameObject.FindGameObjectsWithTag("direkler");

            for (int i = 0; i < Direkler.Length; i++)
            {
                Destroy(Direkler[i]);
            }
            click = 2;
            //Network.gameObject.GetComponent<Network>().OnLeftRoom();
            //Network.gameObject.GetComponent<Network>().OnLeftLobby();-
        }
    }
 
    [PunRPC]
    void buttonbas()
    {
        Debug.Log("2-Butona basıldı. Bilgisi oyuncuya yollandı.");
        click = 1;
        oyunbaslaButton.GetComponent<Canvas>().enabled = false;
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("servere girildi");
        PhotonNetwork.JoinLobby();
    }
    public override void OnJoinedLobby()
    {
        Debug.Log("Lobiye giriş yapıldı");

        PhotonNetwork.JoinOrCreateRoom("Room1", new RoomOptions { MaxPlayers = 3, IsOpen = true, IsVisible = true }, TypedLobby.Default);

    }

    //public override void OnLeftLobby()
    //{
    //    Debug.Log("lobiden cıkıldı");
    //    PhotonNetwork.LeaveLobby();
    //}
    //public override void OnLeftRoom()
    //{
    //    Debug.Log("odadan cıkıldı");
    //    PhotonNetwork.LeaveRoom();

    //}

    public void anamanugit()
    {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.LeaveLobby();
        PhotonNetwork.Disconnect();
        ///*Application.Quit()*/;
        PhotonNetwork.LoadLevel("anamenu");
        //SceneManager.LoadScene("anamenu");
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("Oda bulunamadı.");
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Herhangi bir odaya girilemedi.");
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Oda kurulamadı.");
    }


}

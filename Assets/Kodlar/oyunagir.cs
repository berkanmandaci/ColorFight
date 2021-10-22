using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class oyunagir : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
 public void oyunagit()
    {
        PhotonNetwork.LoadLevel("oyun");
        //SceneManager.LoadScene("Oyun");
    }
    public void oyundancik()
    {
        Application.Quit();
    }
}

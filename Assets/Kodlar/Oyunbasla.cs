using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Oyunbasla : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    public void oyunaGit()
    {
        SceneManager.LoadScene("oyun");
    }
    public void oyundanCik()
    {
        Application.Quit();
    }

}

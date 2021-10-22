using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class direktazele : MonoBehaviour
{
   public GameObject direkkonum;
    private void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
        Debug.Log("degdi");
        other.transform.position = direkkonum.transform.position;
        
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public enum ColorEnum
{
    Blue,
    Red,
    Yellow,
}
public class DirekKontrol : MonoBehaviour

{
    // Start is called before the first frame update

    public ColorEnum Color;
    public GameObject _canvas, oyunkontrol, hareketliDirekParent;
    GameObject hareketliDirekKonum;
  

    public float Speed = 1;

    //void Start()
    //{
    //    //fizik = GetComponent<Rigidbody2D>();
    Rigidbody2D rb;

    //    //fizik.velocity = new Vector2(0, -hiz);
    Vector3 velocity = Vector3.zero;
    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        hareketliDirekKonum = GameObject.FindGameObjectWithTag("hareketliDirekKonum");
        
    }

    //}
    void Update()
    {
        //if (gameObject.GetComponent<SpriteRenderer>().enabled == false)
        //{
        //    this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        //}

        //transform.position += Vector3.down * Speed * Time.deltaTime;
        //if (gameObject.GetComponent<SpriteRenderer>().enabled == false)
        //{
        //    this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        //}

        //float step = Speed * Time.deltaTime; // calculate distance to move
        //transform.position = Vector3.SmoothDamp(transform.position, transform.position + Vector3.down,ref velocity, .3f);
       
       
    }
    private void FixedUpdate()
    {
        //Instantiate(hareketliDirekParent, hareketliDirekKonum.position, Quaternion.identity);
        if (gameObject.transform.position.y <= -10 )
        {
            Destroy(gameObject);
            //    gameObject.transform.parent.position = new Vector3(-3, 9);

        }
        transform.position += Vector3.down * Speed * Time.deltaTime;
        //rb.MovePosition(rb.position+(Vector2.down/2)*20*Time.fixedDeltaTime);
    }
}




    

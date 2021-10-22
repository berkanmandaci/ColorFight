using System.Collections;
using UnityEngine;



    public class OyunKontrol : MonoBehaviour
    {
        //public GameObject playerred;
        // Start is called before the first frame update
       
        public GameObject direkler, _canvas;
        public GameObject[] hareketlidirekler;
        //Spawnlanıcak direk objesi
        public GameObject Startposition;
        //Başlıyacağı konum
        SpriteRenderer[] spriteRendere;
        int[] direklerchildIndex = { 0, 1, 2, 3, 4, 5 };
        //Renkleri değiştirmek için direklerin child larını dizi eklemek
        //Random rnd = new Random();
        Color[] altColor = new Color[3];
        //Renk kodlarını tutmak için Color dizi si
        int renkdgr;
        //randomdan gelen değeri tutmak için 
        public float Speed = 1;
        Transform gametest;

       
        void Renkler()
        {
            //mavi
            ColorUtility.TryParseHtmlString("#004EE7", out altColor[0]);
            //kırmızı
            ColorUtility.TryParseHtmlString("#FF1B00", out altColor[1]);
            //mor
            ColorUtility.TryParseHtmlString("#F500FF", out altColor[2]);
        }


        void Start()
        {
            
            StartCoroutine(GameStart());
            //Renkler();

            //spriteRendere = direkler.GetComponentsInChildren<SpriteRenderer>();
            ////Renklendir();
            //StartCoroutine(olustur());
            
        }

        IEnumerator GameStart()
        {
            //this.transform.parent = yourParentObject;
            //direkler.transform.parent = gametest;
            gametest = transform.GetComponentInParent<Transform>();
            //gametest = direkler.transform.GetChild(0);
            Randomize<int>(direklerchildIndex);
            for (int i = 0; i < 6; i++)
            {
                GameObject direks = Instantiate(direkler.transform.GetChild(direklerchildIndex[i]).gameObject, Startposition.transform.GetChild(i).transform.position, Startposition.transform.GetChild(i).transform.rotation);
                //direks.transform.localPosition = Vector3.zero;
                //direks.transform.position = Startposition.transform.GetChild(i).transform.position;
            
           
            }
            yield return new WaitForSeconds((float)0.70);
            StartCoroutine(GameStart());
        }
        public static void Randomize<T>(T[] items)
        {
            System.Random rand = new System.Random();

            // For each spot in the array, pick
            // a random item to swap into that spot.
            for (int i = 0; i < items.Length - 1; i++)
            {
                int j = rand.Next(i, items.Length);
                T temp = items[i];
                items[i] = items[j];
                items[j] = temp;
            }
        }

        IEnumerator olustur()
        {
            Renklendir();

            yield return new WaitForSeconds((float) 0.55);
            var born = Instantiate(direkler, Startposition.transform);
            born.transform.localPosition = Vector3.zero;

            StartCoroutine(olustur());
        }

        void Renklendir()
        {
            for (int h = 0; h < hareketlidirekler.Length; h++)
            {
                int a = 0, b = 0, c = 0;
                //spriteRendere = hareketlidirekler[h].GetComponentsInChildren<SpriteRenderer>();
                for (int i = 0; i < spriteRendere.Length; i++)
                {
                    renkdgr = Random.Range(0, 3);
                    if (a < 2 && renkdgr == 0 || b < 2 && renkdgr == 1 || c < 2 && renkdgr == 2)
                    {
                        switch (renkdgr)
                        {
                            case 0:
                                a++;
                                break;
                            case 1:
                                b++;
                                break;
                            case 2:
                                c++;
                                break;
                        }

                        spriteRendere[i].color = altColor[renkdgr];
                        spriteRendere[i].transform.GetComponent<DirekKontrol>().Color = (ColorEnum) renkdgr;
                    }
                    else
                    {
                        i--;
                    }
                }
            }
        }
    }

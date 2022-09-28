using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playercontroller : MonoBehaviour
{
    
    public Text score;
    public GameObject duck;
    float ranY;
    float ranX;
    Vector3 whereToSpawn;
    public float spawnRate = 1f;
    public float nextSpawn = 1f;
    public float para = 0;
    public Text money;
    public GameObject win;
    public GameObject fail;
    bool see = false;
    public Material invmaterial;
    public Material seeingmaterial;
    public bool touch = false;
    private Rigidbody rb;
    private float speed = 8;

    public bool mousehold;
    //public float movementspeed;
    //public float poweruptimer;
    //public bool powerup;
    // Start is called before the first frame update
    void Start()
    {
        //movementspeed = 5;
        //poweruptimer = 0;
        //powerup = false;
        
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousehold = true;
        }
        if (mousehold)
        {
            this.transform.Translate(new Vector3(0, 0, Time.deltaTime * speed));
            //transform.position += transform.forward * Time.deltaTime * movementspeed;
        }
        money.text = para.ToString();

        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            ranY = Random.Range(-4, 4);
            ranX = Random.Range(-4, 4);
            whereToSpawn = new Vector3(ranY, 1f, ranX);

            Instantiate(duck, whereToSpawn, Quaternion.identity);
        }


        //if (powerup)
        //{
        //    poweruptimer += Time.deltaTime;
        //    if (poweruptimer >= 3)
        //    {
        //        movementspeed = 5;
        //        poweruptimer = 0;
        //        powerup = false;
        //    }



        //}


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "win")
        {
            win.SetActive(true);
            
            touch = false;
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z);

        }
        //if (other.gameObject.tag == "testere" && see == false)
        //{
        //    Time.timeScale = 0;
        //    fail.SetActive(true);
        //}
        if (other.gameObject.tag == "coin")
        {
            para += 1;
            score.text = "Score: " + para.ToString();
            Destroy(other.gameObject);
            
        }
        if (other.gameObject.tag == "speedpower")
        {
            Invoke("speedup", 2.5f);
            speed = speed + 10;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "invpower")
        {
            this.gameObject.GetComponent<MeshRenderer>().material = invmaterial;
            see = true;
            Destroy(other.gameObject);
            Invoke("seeing", 2.5f);
        }
    }
    public void speedup()
    {
        speed = 16;
    }
    public void seeing()
    {
        this.gameObject.GetComponent<MeshRenderer>().material = seeingmaterial;
        see = false;

    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "speedpower")
    //    {
    //        powerup = true;
    //        movementspeed = 10;
    //        Destroy(other.gameObject);
    //    }
    //}
}

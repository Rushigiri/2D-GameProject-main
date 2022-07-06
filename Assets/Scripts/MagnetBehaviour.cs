using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MagnetBehaviour : MonoBehaviour
{
    public GameObject player;
    public GameObject magnet;
    public Canvas CarryText;
    float distance;
    bool playerPickMagnet;
    public GameObject magnetPosition;
    public Rigidbody2D rb;
    public bool isDrag;

    public static MagnetBehaviour instance;

    public bool magnetChildOfPlayer;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        magnetChildOfPlayer = false;

      
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(player.transform.position, magnet.transform.position);

        if((distance < 2f)&& !playerPickMagnet)
        {
            CarryText.gameObject.SetActive(true);
        }
        else
        {
            CarryText.gameObject.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            
            rb.isKinematic = true;
           rb.simulated = false;
            CarryMagnet();
           

        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            rb.isKinematic = false;
            rb.simulated = true;
            DropMagnet();
           
        }
        if (isDrag)
        {

           //rb.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
          //rb.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,0,0));

        }


    }

    public void CarryMagnet()
    {
        magnetChildOfPlayer = true;
        CarryText.gameObject.SetActive(false);
        transform.SetParent(magnetPosition.transform);
        transform.position = magnetPosition.transform.position;
        playerPickMagnet = true;
        
        //GetComponent<SpringJoint2D>().enabled = true;
    }

    public void DropMagnet()
    {
        magnetChildOfPlayer = false;
        CarryText.gameObject.SetActive(true);
        transform.parent = null;
        playerPickMagnet = false;

        //rb.velocity = transform.right * DiractionManage.rushi.force;
        rb.velocity = DiractionManage.rushi.shotPoint.transform.right * DiractionManage.rushi.force;
    }

    //private void OnMouseDown()
    //{
        

    //}
    //private void OnMouseDrag()
    //{
    //    Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    transform.position = new Vector3(newPosition.x, newPosition.y);
    //}
    //private void OnMouseUp()
    //{
        
    //}

    //private void OnMouseUp()
    //{
    //    isDrag = false;
    //   GetComponent<SpringJoint2D>().enabled = false;
    //    //GetComponent<BoxCollider2D>().enabled = false;
    //}

    //IEnumerator UnHook()
    //{
    //    yield return new WaitForSeconds(unHookTime);
    //    //GetComponent<SpringJoint2D>().enabled = false;
    //    //this.enabled = false;

    //}



}

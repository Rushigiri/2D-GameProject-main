using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiractionManage : MonoBehaviour
{
    public GameObject magnet;
    public Transform shotPoint;
    public float force;
    Vector2 direction;
    public GameObject newMagnet;
    public GameObject point;
    GameObject[] points;
    public int numberOfPoints;
    public float spaceBetweenPoints;

    public static DiractionManage rushi;


    private void Awake()
    {
        rushi = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        points = new GameObject[numberOfPoints];
        for (int i = 0; i < numberOfPoints; i++)
        {
            points[i] = Instantiate(point, shotPoint.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 magnetPosition = transform.position;
        direction = mousePosition - magnetPosition;
        transform.right = direction;

        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        if(Input.GetKey(KeyCode.E))
        {
            if(MagnetBehaviour.instance.magnetChildOfPlayer)
            {
                for (int i = 0; i < numberOfPoints; i++)
                {
                    points[i].transform.position = PointPosition(i * spaceBetweenPoints);
                    points[i].SetActive(true);
                }
            }
            
        }
        else
        {
            foreach (GameObject point in points)
            {
                point.SetActive(false);
            }
        }

    }

    void Shoot()
    {
        //GameObject newMagnet = Instantiate(magnet, shotPoint.position, shotPoint.rotation);
        //newMagnet.GetComponent<Rigidbody2D>().velocity = transform.right * force;
    }

    Vector2 PointPosition(float t)
    {
        Vector2 position = (Vector2)shotPoint.position + (direction.normalized * force * t) + 0.5f * Physics2D.gravity * (t * t);
        return position;
    }
}

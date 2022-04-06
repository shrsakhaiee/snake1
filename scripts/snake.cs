using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class snake : MonoBehaviour
{
    public GameObject Body;
    public GameObject Food ;

    public GameObject WallRight ;
    public GameObject WallTop ;
    public GameObject WallBottom ;
    public GameObject WallLeft ;

    public Vector2 direction = new Vector2(0,0);
    public float speed = 2 ;

    List<GameObject> tail = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        NewSib();
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0 ; i<tail.Count ; i++)
        {
            tail[i].transform.position = ;
        }
        if(Input.GetKey(KeyCode.UpArrow))
        {
            direction = Vector2.up;
            transform.rotation = Quaternion.Euler(0 , 0 , 180);
        }
        else if(Input.GetKey(KeyCode.DownArrow))
        {
            direction = - Vector2.up;
            transform.rotation = Quaternion.Euler(0 , 0 , 0);
        }
        
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            direction = Vector2.right;
            transform.rotation = Quaternion.Euler(0 , 0 , 90);
        }
        
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            direction = - Vector2.right;
            transform.rotation = Quaternion.Euler(0 , 0 , -90);
        }
        
        GetComponent<Rigidbody2D>().velocity = direction * speed ;
           
    }

    void NewSib()
    {
        int x = (int)Random.Range(WallLeft.transform.position.x + 2 , WallRight.transform.position.x - 2);
        int y = (int)Random.Range(WallBottom.transform.position.y + 2 , WallTop.transform.position.y - 2);

        Instantiate(Food,
                    new Vector2(x,y),
                    Quaternion.Euler(0 , 0 , 0)
                    );
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.name.StartsWith("apple"))
        {
            Destroy(target.gameObject);
            NewSib();
            Debug.Log("Ommmmm! bah bah che khoshmaze!");

            GameObject new_body = Instantiate(Body,
                                              transform.position,
                                              transform.rotation);
            tail.Insert(0, new_body);                                  
        }
        else
        {
            Debug.Log("Game Over");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

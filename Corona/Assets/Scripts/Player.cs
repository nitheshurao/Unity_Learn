using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Transform ball;

    public Transform dng;
    public Transform Health;
    public Rigidbody2D _Player;
    public float Jumpforce = 0.3f;
    private bool toMoveRight = false;

    public Button Right;
    public Button Left;

    public Color red;
    public Color green;
    public Renderer _PlrColor;


    public float health = 0f;

    // Start is called before the first frame update
    void Start()

    {

       _Player= GetComponent<Rigidbody2D>();
        _PlrColor = _Player.GetComponent<Renderer>();
        Button Right = GetComponent<Button>();
        Right.onClick.AddListener(MovementRight);

        Button Left = GetComponent<Button>();
        Left.onClick.AddListener(MovementLeft);



    }

    // Update is called once per frame
    void Update()
    {
        if (toMoveRight)
        {
            toMoveRight = false;
        }
    }

   public void MovementRight()
    {
        //Debug.Log("Player Moved Right");

        _Player.velocity = Vector2.zero;
        _Player.AddForce(new Vector2(-200f, 0));
    }

   public void MovementLeft()
    {
        //Debug.Log("Player Moved Left");

        _Player.velocity = Vector2.zero;
        _Player.AddForce(new Vector2(200f, 0));
    }
    public void Movementup()
    {
        //Debug.Log("Player Moved up");

        _Player.velocity = Vector2.zero;
        _Player.AddForce(new Vector2(0, 200f));
    }

    public void Movementdown()
    {
        //Debug.Log("Player Moved down");

        _Player.velocity = Vector2.zero;
        _Player.AddForce(new Vector2(  0, -200f));
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "man")
        {


            //Destroy(collision.gameObject);
            collision. gameObject.SetActive(false);




            float spawnY = Random.Range
                    ((new Vector2(0, 0)).y, (new Vector2(4, _Player.position.y + 9f)).y);
            float spawnX = Random.Range
                 ((new Vector2(0, 0)).x, (new Vector2(_Player.position.x + 9f, 1)).x);

            Vector2 spawnPosition = new Vector2(spawnX, spawnY);
            FreFabs.Instance.spawnFromPool("man", spawnPosition, Quaternion.identity);

            collision.gameObject.GetComponent<Renderer>().material.color = _PlrColor.material.color;

            if (health == 1)
            {
                _PlrColor.material.color = collision.gameObject.GetComponent<Renderer>().material.color;
            }
        }
        if(_PlrColor.material.color == red)
        {
            for (int i = 0; i < 3; i++)
            {
                float spawnY = Random.Range
                    ((new Vector2(0, 0)).y, (new Vector2(4, _Player.position.y + 9f)).y);
                float spawnX = Random.Range
                     ((new Vector2(0, 0)).x, (new Vector2(_Player.position.x + 9f, 1)).x);

                Vector2 spawnPosition = new Vector2(spawnX, spawnY);
                //Instantiate(dng, spawnPosition, transform.rotation);

                FreFabs.Instance.spawnFromPool("covd", spawnPosition, Quaternion.identity);
            }
        }


// chnage near object color to red, and if player faild to tuch yellow object with in time game Over

        if (collision.tag == "covd")
        {

            health--;
         
            Destroy(collision.gameObject);

           
            if (health <= 5)
            {
                _PlrColor.material.color = Color.yellow;

            }
            if (health <= 2)
            {
                _PlrColor.material.color = Color.red;

            }
            if (health <= 2)
            {
                _PlrColor.material.color = Color.red;
                Debug.Log("Game Over");

            }

            for (int i = 0; i < 3; i++)
            {
                float spawnY = Random.Range
                    ((new Vector2(0, 0)).y, (new Vector2(4, _Player.position.y + 9f)).y);
                float spawnX = Random.Range
                     ((new Vector2(0, 0)).x, (new Vector2(_Player.position.x + 9f, 1)).x);

                Vector2 spawnPosition = new Vector2(spawnX, spawnY);
                Instantiate(dng, spawnPosition, transform.rotation);
            }
            for (int i = 0; i < 3; i++)
            {
                float spawnY = Random.Range
                    ((new Vector2(0, 0)).y, (new Vector2(4, _Player.position.y + 9f)).y);
                float spawnX = Random.Range
                     ((new Vector2(0, 0)).x, (new Vector2(_Player.position.x + 9f, 1)).x);

                Vector2 spawnPosition = new Vector2(spawnX, spawnY);
                Instantiate(Health, spawnPosition, transform.rotation);
            }

            //RandomColor();

        }



        if (collision.tag == "health")
        {

            GameObject.FindWithTag("ball").GetComponent<Renderer>().material.color = Color.white;
            Destroy(GameObject.FindWithTag("dng"));

            health++;
            if(health == 5)
            {
                Destroy(GameObject.FindWithTag("health"));
            }

        }




        //void RandomColor()
        //{


        //    _PlrColor.material.color = Color.red;



        //}
    }

}

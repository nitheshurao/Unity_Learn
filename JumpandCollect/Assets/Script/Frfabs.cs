using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frfabs : MonoBehaviour
{
    public Transform ball;

    public Transform dng;
    // Start is called before the first frame update
    void Start()
    {



        for (int i = 0; i < 4; i++)
        {

            float spawnY = Random.Range
                ((new Vector2(0, 0)).y, (new Vector2(0, ball.position.y + 8)).y);
            float spawnX = Random.Range
                 ((new Vector2(0, 0)).x, (new Vector2(ball.position.x + 2, 0)).x);

            Vector2 spawnPosition = new Vector2(spawnX, spawnY);
            Instantiate(ball, spawnPosition, Quaternion.identity);
         
        }
        for (int i = 0; i < 2; i++)
        {
            float spawnY = Random.Range
                ((new Vector2(0, 0)).y, (new Vector2(0, ball.position.y + 8)).y);
            float spawnX = Random.Range
                 ((new Vector2(0, 0)).x, (new Vector2(ball.position.x + 2, 0)).x);

            Vector2 spawnPosition = new Vector2(spawnX, spawnY);

            Instantiate(dng, spawnPosition, Quaternion.identity);
        }


      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

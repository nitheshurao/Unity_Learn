using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;




public class Player1 : MonoBehaviour
{
    public Rigidbody2D _Player;
    public void Start()
    {
         //FreFabss = FreFabs.Instance;
    }


    private void FixedUpdate()
    {


        float spawnY = Random.Range
                    ((new Vector2(0, 0)).y, (new Vector2(4, _Player.position.y+9f)).y);
                float spawnX = Random.Range
                     ((new Vector2(0, 0)).x, (new Vector2(_Player.position.x+9f,1)).x);

                Vector2 spawnPosition = new Vector2(spawnX, spawnY);
        FreFabs.Instance.spawnFromPool("hmn", spawnPosition ,Quaternion.identity);
    }
}

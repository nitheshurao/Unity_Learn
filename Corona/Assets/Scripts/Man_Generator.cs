using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Man_Generator : MonoBehaviour
{
    // Start is called before the first frame update

    public static Man_Generator SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;
    public Rigidbody2D _player;
    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        pooledObjects = new List<GameObject>();
        float spawnY = Random.Range
                   ((new Vector2(0, 0)).y, (new Vector2(4, _player.position.y + 9f)).y);
        float spawnX = Random.Range
             ((new Vector2(0, 0)).x, (new Vector2(_player.position.x + 9f, 1)).x);

        Vector2 spawnPosition = new Vector2(spawnX, spawnY);
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(objectToPool, spawnPosition, _player.transform.rotation);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }


    }
    public GameObject GetPooledObject()
    {
        //1
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            //2
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        //3   
        return null;
    }

    // Update is called once per frame
 

}

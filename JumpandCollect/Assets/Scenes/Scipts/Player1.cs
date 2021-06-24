using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;




public class Player1 : MonoBehaviour
{

    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;
    // Start is called before the first frame update
    //public static ObjectPooler SharedInstance;

    void Awake()
    {
        //SharedInstance = this;
    }

    void Start()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(objectToPool);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }


    }

    // Update is called once per frame
    void Update()
    {
        //obj.SetActive(true);

    }
}

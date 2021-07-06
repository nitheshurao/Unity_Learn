using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreFabs : MonoBehaviour
{
    // Start is called before the first frame update
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefabs;
        public int size;
    }
    public List<Pool> pools;

    public static FreFabs Instance;
    private void Awake()
    {
        Instance = this;
    }

    public Dictionary<string, Queue<GameObject>> poolDictionary;
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefabs);
                obj.SetActive(true);

                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(pool.tag, objectPool);

        }
    }

   
    public GameObject spawnFromPool(string tag, Vector3 postion, Quaternion roation)
    {

        GameObject objectSpawn = poolDictionary[tag].Dequeue();

        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.Log("Pool " + tag + " not exit");
            return null;
        }
        //active(true, objectSpawn);
       
            objectSpawn.SetActive(true);
            objectSpawn.transform.position = postion;
            objectSpawn.transform.rotation = roation;

        //poolDictionary[tag].Enqueue(objectSpawn);
        return objectSpawn;
    }

   

        

    //public void active(bool yes, GameObject objectSpawn)
        //{

        //    if( yes == false)
        //    {
        //        objectSpawn.SetActive(false);
        //        poolDictionary[tag].Enqueue(objectSpawn);

        //    }
        //    if( yes == true)
        //    {
        //        objectSpawn.SetActive(tru);
        //    }



        //}



    }


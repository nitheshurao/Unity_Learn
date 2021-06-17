using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameObjectExt
{
    // private static List<GameObject> storage;
    public static T CreateAndGet<T>(this GameObject prefab, Transform parent, bool enableVisibility = true) where T : MonoBehaviour
    {
        GameObject qObj =  MonoBehaviour.Instantiate(prefab, parent, false);
        qObj.SetActive(enableVisibility);
        qObj.transform.SetParent(parent);
        qObj.transform.localPosition = prefab.transform.localPosition;
        qObj.transform.localScale = prefab.transform.localScale;
        return qObj.GetComponent<T>();
    }
    
    // public static void ReturnAllToPool()
    // {
    //     if (storage != null)
    //     {
    //         foreach (var item in storage)
    //         {
    //             item.SetActive(false);
    //             item.transform.SetParent(parent, false);
    //         }   
    //     }
    // }
}

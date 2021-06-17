using UnityEngine;
using System.Collections;

public class CustomBehaviour : MonoBehaviour
{

    GameObject mGo;

    public GameObject cachedGameObject
    {
        get
        {
            if (mGo == null)
            {
                mGo = gameObject;
            }
            return mGo;
        }
    }

    Transform mTrans;

    public Transform cachedTransform
    {
        get
        {
            if (mTrans == null)
            {
                mTrans = GetComponent<Transform>();
            }
            return mTrans;
        }
    }

}

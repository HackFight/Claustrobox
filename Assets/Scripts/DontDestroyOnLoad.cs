using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this);

        GameObject[] GameObjectsWithSameTag = GameObject.FindGameObjectsWithTag(this.gameObject.tag);

        foreach (var item in GameObjectsWithSameTag)
        {
            if (item != this)
            {
                Destroy(gameObject);
            }
        }
    }
}

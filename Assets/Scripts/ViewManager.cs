using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewManager : MonoBehaviour
{
    private Transform parent;

    int m_IndexNumber;

    // Start is called before the first frame update
    void Awake()
    {
        parent = GameObject.FindWithTag("Viewport").transform;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.SetParent(parent);
            transform.SetSiblingIndex(1);
        }
    }
}

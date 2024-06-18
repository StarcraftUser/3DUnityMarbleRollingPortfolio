using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemsCan : MonoBehaviour
{
    public static int ItemNumber = 0;
    protected float ratateSpeed;
    //protected Vector3 ItemsRotation;
    void Awake()
    {
        ItemNumber++;
        ratateSpeed = 100f;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * ratateSpeed, Space.World);
    }


}

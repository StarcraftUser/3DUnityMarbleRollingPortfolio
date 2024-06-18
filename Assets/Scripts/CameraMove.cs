using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    Transform playerTransfrom;
    Vector3 Offset;
    // Start is called before the first frame update
    void Awake()
    {
        playerTransfrom = GameObject.FindGameObjectWithTag("Player").transform;
        Offset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LateUpdate()
    {
        transform.position = playerTransfrom.position + Offset;
    }
}

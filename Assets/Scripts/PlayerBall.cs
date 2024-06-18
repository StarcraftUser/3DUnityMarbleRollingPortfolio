using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class PlayerBall : MonoBehaviour
{
    protected Rigidbody rigid;
    protected Vector3 temp;// = new Vector3();
    public float JumpPower;// = 50;
    public float MovePower;// = 50;
    public int ItemCount;
    public GameManagerLogic Manager;
    protected AudioSource audio;
    protected bool isJump;

    // Start is called before the first frame update
    void Awake()
    {
        audio = GetComponent<AudioSource>();
        isJump = false;
        temp = new Vector3();
        //JumpPower = 50;
        rigid = GetComponent<Rigidbody>();

    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && !isJump)
        {
            isJump = true;
            rigid.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        temp.x = h;
        temp.y = 0;
        temp.z = v;

        temp *= Time.deltaTime * MovePower;

        rigid.AddForce(temp, ForceMode.Impulse);
    }

    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
            isJump = false;
        if (collision.gameObject.tag == "EndFloor")
        {
            ItemsCan.ItemNumber = 0;
            SceneManager.LoadScene("SampleScene" + GameManagerLogic.stage.ToString());
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Items")
        {
            //PlayerBall player = other.GetComponent<PlayerBall>();
            ItemCount++;
            audio.Play();
            Destroy(other.gameObject);
            Manager.GetItem(ItemCount);
        }
        else if (other.gameObject.tag == "Finish")
        {
            if (ItemCount == Manager.totalItemCount)
            {
                if (SceneManager.GetActiveScene().name == "SampleScene2")
                {
                    GameManagerLogic.stage = 0;
                    SceneManager.LoadScene("VictoryScene");
                    return;
                }
                SceneManager.LoadScene("SampleScene"+ (++GameManagerLogic.stage).ToString());
            }
            else
            {
                SceneManager.LoadScene("SampleScene"+ GameManagerLogic.stage.ToString());
            }
        }
    }
}

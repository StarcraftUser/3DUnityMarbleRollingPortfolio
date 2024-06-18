using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerLogic : MonoBehaviour
{
    public int totalItemCount;
    public static int stage;
    public TextMeshProUGUI stageCountText;
    public TextMeshProUGUI playerCountText;

    void Awake()
    {
    }

    void Start()
    {
        totalItemCount = ItemsCan.ItemNumber;
        ItemsCan.ItemNumber = 0;
        stageCountText.text = "  / " + totalItemCount.ToString();
    }

    // Update is called once per frame
    public void GetItem(int count)
    {
        playerCountText.text = count.ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ItemsCan.ItemNumber = 0;
            SceneManager.LoadScene("SampleScene" + GameManagerLogic.stage.ToString());
        }
    }
}

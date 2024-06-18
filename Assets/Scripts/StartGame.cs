using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        GameManagerLogic.stage = 0;
    }

    void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            SceneManager.LoadScene("SampleScene" + GameManagerLogic.stage.ToString());
        }
    }
}

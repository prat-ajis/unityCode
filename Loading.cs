using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Loading : MonoBehaviour
{
    float time,second;
    public Image fillImage;

    // Start is called before the first frame update
    void Start()
    {
        second = 3;
        Invoke("LoadGame",3);
    }

    // Update is called once per frame
    void Update()
    {
        if(time < 3)
        {
            time += Time.deltaTime;
            fillImage.fillAmount = time / second;

        }
    }
    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
}

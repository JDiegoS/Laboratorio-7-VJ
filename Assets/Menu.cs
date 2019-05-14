using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("knuckles") == null)
        {
            Defeat();
        }
        if (GameObject.Find("eggman") == null)
        {
            Victory();
        }

    }
    public void Restart()
    {

        SceneManager.LoadScene("Game");
    }
    public void Victory()
    {
        Time.timeScale = 0.0f;
        transform.Find("Victory").gameObject.SetActive(true);

    }
    public void Defeat()
    {

        Time.timeScale = 0.0f;
        transform.Find("Defeat").gameObject.SetActive(true);


    }
}

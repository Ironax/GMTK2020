using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Play : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(PlayHome);
    }



    // Update is called once per frame
    void Update()
    {
       
    }

    public void PlayHome()
    {
       
        if (PlayerPrefs.GetInt("Progression") == 0)
        {
            SceneManager.LoadScene("Tuto");
        }
        else
        {
            Debug.Log("Lvl " + PlayerPrefs.GetInt("Progression"));
            SceneManager.LoadScene("Lvl " + PlayerPrefs.GetInt("Progression"));
        }

    }
}

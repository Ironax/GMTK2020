using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public GameObject GrimFace;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Subject>())
        {
            GrimFace.SetActive(true);
            gameObject.GetComponent<DialogTrigger>().TriggerDialog();
          //  SceneManager.LoadScene("Main Menu");
        }
           
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoToOptions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(LoadOptions);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadOptions()
    {

        SceneManager.LoadScene("Options");

    }
}

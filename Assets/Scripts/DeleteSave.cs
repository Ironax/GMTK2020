using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteSave : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(DeletePlayerPrefs);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeletePlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }

}

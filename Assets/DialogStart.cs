using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogStart : DialogTrigger
{
    // Start is called before the first frame update
    void Start()
    {
        dialogBox.StartDialog(dialog);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

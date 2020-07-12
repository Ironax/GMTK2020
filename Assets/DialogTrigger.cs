using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DialogTrigger : MonoBehaviour
{
	[SerializeField] protected Dialog dialog;
	[SerializeField] public DialogBox dialogBox = null;

    // Start is called before the first frame update
    void Awake()
	{
		if(dialogBox == null)
			dialogBox = FindObjectOfType<DialogBox>();
	}

	public void TriggerDialog()
	{
		dialogBox.StartDialog(dialog);
	}
}

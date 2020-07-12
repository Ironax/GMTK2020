using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DialogTrigger : MonoBehaviour
{
	[SerializeField] protected Dialog dialog;

	protected DialogBox dialogBox;
    // Start is called before the first frame update
    void Awake()
	{
		dialogBox = FindObjectOfType<DialogBox>();
	}

	protected void TriggerDialog()
	{
		dialogBox.StartDialog(dialog);
	}
}

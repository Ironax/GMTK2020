using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public struct Dialog
{
	[TextArea(1,3)]
	public List<string> Sentences;
}

public class DialogBox : MonoBehaviour
{
	[SerializeField] private Text body;
	private Queue<string> sentencesQueue = new Queue<string>();
 
	public void StartDialog(Dialog dialog)
	{
		Time.timeScale = 0;
		sentencesQueue.Clear();
		foreach (string sentence in dialog.Sentences)
		{
			sentencesQueue.Enqueue(sentence);
		}
		NextSentence();
	}

	public void NextSentence()
	{
		if (sentencesQueue.Count == 0)
		{
			CloseDialog();
			return;
		}
		else
		{
			gameObject.SetActive(true);
		}

		body.text = sentencesQueue.Dequeue();
	}

	public void CloseDialog()
	{
		Time.timeScale = 1;

		sentencesQueue.Clear();

		gameObject.SetActive(false);
	}

	// Start is called before the first frame update
	void Start()
	{
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}

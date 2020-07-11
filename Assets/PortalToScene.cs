using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalToScene : MonoBehaviour
{
	[SerializeField] private string toScene;

	private void OnTriggerEnter2D(Collider2D other)
	{
		SceneManager.LoadScene(toScene);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalToScene : MonoBehaviour
{
	[SerializeField] private string toScene;
	[SerializeField] private GameObject canvas = null;
	[SerializeField] private AudioSource audio = null;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Subject"))
		{
			audio.Play();
			canvas.gameObject.SetActive(true);
			Time.timeScale = 0f;
		}
	}

	public void OpenScene()
	{
		SceneManager.LoadScene(toScene);
	}
}

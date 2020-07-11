using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Killzone : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D other)
	{ 
		if(other.gameObject.GetComponent<Subject>())
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}

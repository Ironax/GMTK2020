using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhobiaTrigger : MonoBehaviour
{
	[SerializeField]
	private Phobia phobia = default;
	private bool hasTriggered = false;

	private void OnTriggerStay2D(Collider2D other)
	{
		if(hasTriggered)
			return;

		Subject s = other.GetComponent<Subject>();
		if (s)
			hasTriggered = s.TriggerPhobia(phobia);
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		hasTriggered = false;
	}
}

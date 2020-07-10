using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhobiaTrigger : MonoBehaviour
{
	[SerializeField]
	private Phobia phobia = default;

	private void OnTriggerEnter2D(Collider2D other)
	{
		other.GetComponent<Subject>()?.TriggerPhobia(phobia);
	}
}

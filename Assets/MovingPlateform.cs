using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovingPlateform : MonoBehaviour
{
	[SerializeField] private Vector3 startPos = default;
	[SerializeField] private Vector3 endPos = default;
	[SerializeField] private float speed = 1;
	[SerializeField] private int direction = 1;
	[SerializeField] private float delayOnEdges = 0;

	private Rigidbody2D rb = null;

	private float timerEdge = 0f;
    // Start is called before the first frame update
    void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		rb.isKinematic = true;
	}

    // Update is called once per frame
    void FixedUpdate()
	{
		timerEdge += Time.deltaTime;
		if (timerEdge >= delayOnEdges)
		{
			if (direction == 1)
			{
				Vector2 diff     = endPos - transform.position ;
				float   distance = diff.magnitude;
				if (distance <= Time.deltaTime * speed)
				{
					direction   = -direction;
					rb.position = endPos;
					timerEdge   = 0f;
					return;
				}

				diff        /= distance;
				rb.position += speed * Time.deltaTime * diff;
			}
			else if (direction == -1)
			{
				Vector2 diff     = startPos - transform.position;
				float   distance = diff.magnitude;
				if (distance <= Time.deltaTime * speed)
				{
					direction   = -direction;
					rb.position = startPos;
					timerEdge   = 0f;
					return;
				}
				diff        /= distance;
				rb.position += speed * Time.deltaTime * diff;
			}
		}
	}
}

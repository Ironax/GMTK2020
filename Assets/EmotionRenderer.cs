using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EmotionRenderer : MonoBehaviour
{
	[Serializable]
	struct EmotionSprite
	{
		public Reaction Reaction;
		public Sprite Sprite;
	}
	[SerializeField] private List<EmotionSprite> emotionSprites;

	private SpriteRenderer m_spriteRenderer = null;

	private float timer = 0f;
	[SerializeField] private float timeRendered;
	[SerializeField] private float maxHeight;
	[SerializeField] private AnimationCurve animationCurve;
	private float startHeigth;

	private void Awake()
	{
		m_spriteRenderer = GetComponent<SpriteRenderer>();
		gameObject.SetActive(false);
		startHeigth = transform.localPosition.y;
	}

	private void Update()
	{
		timer += Time.deltaTime;
		if (timer >= timeRendered)
		{
			m_spriteRenderer.gameObject.SetActive(false);
			transform.localPosition = Vector3.up * startHeigth;
		}
		else
		{
			float ratio = timer / timeRendered;
				transform.localPosition = (animationCurve.Evaluate(timer/timeRendered) * (maxHeight - startHeigth) + startHeigth) * Vector3.up;
		}
	}

	public void DrawEmotion(Reaction reaction)
	{
		foreach (var emotion in emotionSprites)
		{
			if (emotion.Reaction == reaction)
			{
				m_spriteRenderer.sprite = emotion.Sprite;
				gameObject.SetActive(true);
				timer = 0;
				return;
			}
		}
	}
}

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class PhobiaDrag : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
	[SerializeField] private GameObject phobiaPrefab = null;
	private Canvas canvas = default;
	private RectTransform rectTransform = default;
	private Vector2 startPos = default;

    void Start()
	{
		canvas = GetComponentInParent<Canvas>();
		rectTransform = GetComponent<RectTransform>();
	}

    void Update()
    {
        
    }

	public void InstaciateObject()
	{
		Vector3 mousePosWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePosWorld.z = 0;
		Instantiate(phobiaPrefab, mousePosWorld, Quaternion.identity);
	}

	public void OnPointerDown(PointerEventData eventData)
	{ }

	public void OnBeginDrag(PointerEventData eventData)
	{
		startPos = rectTransform.anchoredPosition;
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		rectTransform.anchoredPosition = startPos;
	}

	public void OnDrag(PointerEventData eventData)
	{
		rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
	}
}

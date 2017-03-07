using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DraggableUI : MonoBehaviour, IDragHandler, IPointerEnterHandler, IPointerDownHandler {

	public RectTransform mainPanel;

	public RectTransform targetRect;

	public Vector2 edgeBuffer;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	public void OnPointerEnter(PointerEventData eventData){
		Debug.Log("up " + this.name);
	}

	public void OnPointerDown(PointerEventData eventData){
		Debug.Log("down " + this.name);
	}

	public void OnDrag(PointerEventData eventData){
		if (eventData == null) { return; }
		Vector3 currentPosition = targetRect.position;
		currentPosition.x += eventData.delta.x;
		currentPosition.y += eventData.delta.y;
		targetRect.position = currentPosition;

		targetRect.anchoredPosition = new Vector2(
			Mathf.Clamp(targetRect.anchoredPosition.x, edgeBuffer.x, mainPanel.sizeDelta.x - edgeBuffer.x - targetRect.sizeDelta.x),
			Mathf.Clamp(targetRect.anchoredPosition.y, edgeBuffer.y, mainPanel.sizeDelta.y - edgeBuffer.y - targetRect.sizeDelta.y)
		);
	}

}

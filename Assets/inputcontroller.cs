using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class inputcontroller : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField] private float leftMovementLimit = -4;

    [SerializeField] private float righMovementLimit = 4;

    [SerializeField] private float movementSensivity = 100f;

    [SerializeField] private Transform playerTransform;

   
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        Vector3 tempPosition = playerTransform.position;
        tempPosition.x = Mathf.Clamp(tempPosition.x + (eventData.delta.x / movementSensivity), leftMovementLimit, righMovementLimit);
        playerTransform.position = tempPosition;

    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("IpointerDown");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("IpointerUp");
    }

}

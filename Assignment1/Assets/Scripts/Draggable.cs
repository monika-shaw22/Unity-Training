using UnityEngine;
public class Draggable : MonoBehaviour
{
   private Vector3 offset;
   private Camera cam;
   void Start()
   {
       cam = Camera.main;
   }
   void OnMouseDown()
   {
       Vector3 mousePos = Input.mousePosition;
       mousePos.z = cam.WorldToScreenPoint(transform.position).z;
       offset = transform.position - cam.ScreenToWorldPoint(mousePos);
   }
   void OnMouseDrag()
   {
       Vector3 mousePos = Input.mousePosition;
       mousePos.z = cam.WorldToScreenPoint(transform.position).z;
       transform.position = cam.ScreenToWorldPoint(mousePos) + offset;
   }
}
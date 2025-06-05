using UnityEngine;
using System.Collections;
 
public class TelesopicView : MonoBehaviour {
 
 public float zoomLevel = 2.0f;
 public float zoomInSpeed = 100.0f;
 public float zoomOutSpeed = 100.0f;
 
 private float initFOV;
 
 void Start()
 {
 //��ȡ��ǰ���������Ұ��Χ
 initFOV = GetComponent<Camera>().fieldOfView;
 }
 
 void Update()
 {
 if(Input.GetMouseButton(0))
 {
 ZoomInView();
 }
 else
 {
 ZoomOutView();
 }
 }
 
 //�Ŵ����������Ұ����
 void ZoomInView()
 {
 if (Mathf.Abs(Camera.main.fieldOfView - (initFOV / zoomLevel)) < 3.0f)
 {
 Camera.main.fieldOfView = initFOV / zoomLevel;
 }
 else if (Camera.main.fieldOfView - (Time.deltaTime * zoomInSpeed) >= (initFOV / zoomLevel))
 {
 Camera.main.fieldOfView -= (Time.deltaTime * zoomInSpeed);
 }
 }
 
 //��С���������Ұ����
 void ZoomOutView()
 {
 if (Mathf.Abs(Camera.main.fieldOfView - initFOV) < 3.0f)
 {
 Camera.main.fieldOfView = initFOV;
 }
 else if (Camera.main.fieldOfView + (Time.deltaTime * zoomOutSpeed) <= initFOV)
 {
 Camera.main.fieldOfView += (Time.deltaTime * zoomOutSpeed);
 }
 }
}
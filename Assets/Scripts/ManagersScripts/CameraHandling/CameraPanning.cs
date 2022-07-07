using System;
using Cinemachine;
using UnityEngine;
using UnityEngine.UIElements;

namespace ManagersScripts.CameraHandling
{
    public class CameraPanning : MonoBehaviour
    {
        [SerializeField] private Camera cam;
        [SerializeField] private CinemachineVirtualCamera cmVCam;
        [SerializeField] private SpriteRenderer DragConfiner;
        private float mapMinX, mapMaxX, mapMinY, mapMaxY;
        private Vector3 dragOrigin;

        private void Awake()
        {
            var position = DragConfiner.transform.position;
            var bounds = DragConfiner.bounds;
            mapMinX = position.x - bounds.size.x / 2f;
            mapMaxX = position.x + bounds.size.x / 2f;
            mapMinY = position.y - bounds.size.x / 2f;
            mapMaxY = position.y + bounds.size.x / 2f;
        }

        private void Update()
        {
            PanCamera();
        }

        private void PanCamera()
        {
            if (Input.GetMouseButtonDown(0))
            {
                dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);
            }

            if (Input.GetMouseButton(0))
            {
                Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);
                cmVCam.transform.position = new Vector3(ClampCamera(cmVCam.transform.position + difference).x,
                    ClampCamera(cmVCam.transform.position + difference).y,
                    ClampCamera(cmVCam.transform.position + difference).z);
                    
            }
        }

        private Vector3 ClampCamera(Vector3 targetPosition)
        {
            float camHeight = cam.orthographicSize;
            float camWidth = cam.orthographicSize * cam.aspect;

            float minX = mapMinX + camWidth;
            float maxX = mapMaxX - camWidth;
            float minY = mapMinY + camHeight;
            float maxY = mapMaxY - camHeight;

            float newX = Mathf.Clamp(targetPosition.x, minX, maxX);
            float newY = Mathf.Clamp(targetPosition.y, minY, maxY);

            return new Vector3(newX, newY, cmVCam.transform.position.z);
        }
    }
}
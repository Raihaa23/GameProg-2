using Cinemachine;
using Events;
using UnityEngine;

namespace ManagersScripts.CameraHandling
{
    public class CameraPanningMovement : MonoBehaviour
    {
        [Header("Component References")]
        [SerializeField] private Camera cam;
        [SerializeField] private CinemachineVirtualCamera cmVCam;
        [SerializeField] private SpriteRenderer dragConfiner;
        private Vector3 _dragOrigin;
        [Header("Stats")]
        private float _mapMinX, _mapMaxX, _mapMinY, _mapMaxY;
        
        private bool _onDrag = false;
        

        private void Awake()
        {
            var position = dragConfiner.transform.position;
            var bounds = dragConfiner.bounds;
            _mapMinX = position.x - bounds.size.x / 2f;
            _mapMaxX = position.x + bounds.size.x / 2f;
            _mapMinY = position.y - bounds.size.x / 2f;
            _mapMaxY = position.y + bounds.size.x / 2f;
        }
        
        public void CheckForConfiner(bool canDrag)
        {
            if (!canDrag) return;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            var hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
            if (!hit.collider.CompareTag("DragConfiner")) return;
            // UIEvents.OnToggleAmmoTextMethod();
            // UIEvents.OnToggleAmmoButtonMethod();
            _dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);
            _onDrag = true;
        }

        public void CheckForConfinerDrag()
        {
            if (!_onDrag) return;
            var difference = _dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);
            var position = cmVCam.transform.position;
            position = new Vector3(ClampCamera(position + difference).x,
                ClampCamera(position + difference).y,
                ClampCamera(position + difference).z);
            cmVCam.transform.position = position;
        }

        public void CheckForConfinerRelease()
        {
            if (!_onDrag) return;
            // UIEvents.OnToggleAmmoTextMethod();
            // UIEvents.OnToggleAmmoButtonMethod();
            _onDrag = false;
        }
        
        private Vector3 ClampCamera(Vector3 targetPosition)
        {
            var camHeight = cam.orthographicSize;
            var camWidth = cam.orthographicSize * cam.aspect;

            var minX = _mapMinX + camWidth;
            var maxX = _mapMaxX - camWidth;
            var minY = _mapMinY + camHeight;
            var maxY = _mapMaxY - camHeight;

            var newX = Mathf.Clamp(targetPosition.x, minX, maxX);
            var newY = Mathf.Clamp(targetPosition.y, minY, maxY);

            return new Vector3(newX, newY, cmVCam.transform.position.z);
        }
    }
}
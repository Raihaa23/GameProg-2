using System;
using System.Collections;
using System.Collections.Generic;
using Data.Player;
using Events;
using LineRendererScripts;
using ManagersScripts;
using UnityEngine;

namespace SlingshotScripts
{
   public class SlingshotMovement : MonoBehaviour
   {
      [SerializeField] private PlayerData playerData;

      [SerializeField] private List<RubberRender> slingRubber = new List<RubberRender>();
      // private LineRenderer _line;
      private Vector2 _worldPosition;
      private string _temporaryTag;
      private Rigidbody2D _rigidB, _slingRb;
      private SpringJoint2D _springJ;
      private float  _mouseToSlingDistance;
      private float _releaseDelay;
      public float maxDragDistance;
   
      private bool _isDraggable;
   
      private void Start()
      {
         // _line = gameObject.AddComponent<LineRenderer>();
         // _line.SetWidth(0.05F, 0.05F);
         // _line.SetVertexCount(2);
         // _line.enabled = false;
         foreach (var rubber in slingRubber)
         {
            rubber.ChangeSlingRubberProjectile(gameObject.transform);
            rubber.EnableSlingRubber();
         }
         
         _rigidB = GetComponent<Rigidbody2D>();
         _springJ = GetComponent<SpringJoint2D>();
         _slingRb = _springJ.connectedBody;
         _releaseDelay = 1 / (_springJ.frequency * 4);
      
         _isDraggable = true;
      }

      private void Update()
      {
         HandleRaycast();
         // LineRender();
      }

      public void CheckForBall() //returns the tag of the projectile
      {
         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         // Casts the ray and get the first game object hit
         var hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
         Debug.Log(hit.collider.tag);
         if (!hit.collider.CompareTag(playerData.equippedAmmo) || !_isDraggable) return;
         _temporaryTag = "BallTag";
         _rigidB.isKinematic = true;
         CameraEvents.OnSwitchCameraPriorityMethod(1,0);
         CameraEvents.OnToggleDraggableCameraMethod(false);
         CameraEvents.OnForceReleaseMethod();
         UIEvents.OnToggleAmmoTextMethod();
         UIEvents.OnToggleAmmoButtonMethod();
         TimerEvents.OnPauseTurnTimerMethod();
      }

      public void CheckForBallDrag() //drags the projectile while in the slingshot
      {
         if (_temporaryTag != "BallTag") return;
         // _line.enabled = true;
         if (_mouseToSlingDistance > maxDragDistance)
         {
            var position = _slingRb.position;
            Vector2 direction = (_worldPosition - position).normalized;
            _rigidB.position = position + direction * maxDragDistance;
         }
         else
         {
            _rigidB.position = _worldPosition;
         }
      }

      public void CheckForBallRelease() //releases the projectile
      {
         if (_temporaryTag != "BallTag") return;
         // _line.enabled = false;
         _temporaryTag = null;
         _rigidB.isKinematic = false;
         StartCoroutine(Release());
         _isDraggable = false;
         PlayerTurnManager.Instance.isProjectileReleased = true;
         AmmoEvents.OnReduceAmmoMethod();
      }

   
   
      private IEnumerator Release() //delay for projectile release
      {
         yield return new WaitForSeconds(_releaseDelay);
         foreach (var rubber in slingRubber)
         {
            rubber.DisableSlingRubber();
         }
         _springJ.enabled = false;
         CameraEvents.OnSetCameraMethod(gameObject);
      }

      private void HandleRaycast() // handles the raycast and converts the mouse position
      {
         Vector2 mousePos = Input.mousePosition;
         if (Camera.main == null) return;
         _worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
         _mouseToSlingDistance = Vector2.Distance(_worldPosition, _slingRb.position);
      }
   
      // private void LineRender() //renders the slingshot line
      // {
      //    _line.SetPosition(0, _rigidB.position);
      //    _line.SetPosition(1, _slingRb.position);
      // }

      private void OnEnable()
      {
         if (_springJ == null) return;
         _springJ.enabled = true;
         _isDraggable = true;
         foreach (var rubber in slingRubber)
         {
            rubber.ChangeSlingRubberProjectile(gameObject.transform);
            rubber.EnableSlingRubber();
         }
      }

      private void OnDisable()
      {
         foreach (var rubber in slingRubber)
         {
            rubber.DisableSlingRubber();
         }
      }
   }
}

using System;
using Data.Player;
using Unity.VisualScripting;
using UnityEngine;

namespace LineRendererScripts
{
    public class RubberRender : MonoBehaviour
    {
        private LineRenderer _line;
        private Transform _projectile;
        [SerializeField] private Material colorMaterial;
        private void Start()
        {
            _line = gameObject.GetComponent<LineRenderer>();
            _line.startWidth =  0.25f;
            _line.endWidth = 0.25f;
            _line.positionCount = 2;
            // _line.material = colorMaterial;
            _line.enabled = false;
        }

        private void Update()
        {
            UpdateSlingRubberPos();
            
        }

        public void ChangeSlingRubberProjectile(Transform newProjectile)
        {
            _projectile = newProjectile;
        }

        public void EnableSlingRubber()
        {
            _line.enabled = true;
        }

        public void DisableSlingRubber()
        {
            _line.enabled = false;
        }
        
        private void UpdateSlingRubberPos() //renders the slingshot line
        {
            
            if (_projectile == null) return;
            _line.SetPosition(0, gameObject.transform.position);
            _line.SetPosition(1, _projectile.position);
        }
    }
}
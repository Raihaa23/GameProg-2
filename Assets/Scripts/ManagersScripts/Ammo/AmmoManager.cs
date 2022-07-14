using System;
using System.Collections.Generic;
using Data.Player;
using Events;
using SlingshotScripts;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace ManagersScripts.Ammo
{
    public class AmmoManager : MonoBehaviour
    {
        [Header("Component References")]
        [SerializeField] private AmmoUIManager ammoUI;
        [SerializeField] private PlayerData playerData;
        [Header("Slingshot References")]
        [SerializeField] private Transform origin;
        [SerializeField] private Rigidbody2D originRigidBody2D;
        [Header("Ammo References")]
        [SerializeField] private GameObject currentAmmo;
        [SerializeField] private int ammoLeft = 0;
        [SerializeField] private int ammoIndex;
        [SerializeField] private List<GameObject> ammoList = new List<GameObject>();

        private void Start()
        {
            LoadAmmo();
        }
        
        private void LoadAmmo() //instantiates a ball and sets its origin
        {
            if (playerData.playerName != PlayerTurnManager.Instance.playerInTurnName) return;
            currentAmmo = ammoList[ammoIndex];
            var projectile = currentAmmo.GetComponent<Projectile>();
            ammoLeft = projectile.totalAmmo;
            var ammoName = currentAmmo.GetComponent<Projectile>().ammoName;
            ammoUI.UpdateAmmoText(ammoLeft, ammoName);
            currentAmmo.transform.position = origin.position;
            currentAmmo.GetComponent<SpringJoint2D>().connectedBody = originRigidBody2D;
            playerData.equippedAmmo = currentAmmo.tag;
            currentAmmo.transform.eulerAngles = new Vector3(0,0,0);
            currentAmmo.SetActive(true);
            PlayerTurnManager.Instance.isProjectileReleased = false;
        }

        
        public void LoadNextAmmo() // Loads the next ammo in the ammoList
        {
            AmmoEvents.OnDestroyAmmoMethod();
            if (ammoIndex >= ammoList.Count - 1)
            {
                ammoIndex = 0;
            }
            else
            {
                ammoIndex += 1;
            }
            LoadAmmo();
        }

        public void LoadPreviousAmmo() // Loads the previous ammo in the list
        {
            AmmoEvents.OnDestroyAmmoMethod();
            if (ammoIndex <= 0)
            {
                ammoIndex = ammoList.Count - 1;
                
            }
            else
            {
                ammoIndex -= 1;
                
            }
            LoadAmmo();
        }
        
        private void ReduceAmmo() // reduces ammo count
        {
            if (playerData.playerName != PlayerTurnManager.Instance.playerInTurnName) return;
            if (ammoLeft == -1) return;
            ammoLeft--;
            if (ammoLeft == 0)
            {
                ammoList.Remove(currentAmmo);
            }
            ammoIndex = 0;
        }

        private void OnEnable()
        {
            AmmoEvents.OnLoadAmmo += LoadAmmo;
            AmmoEvents.OnReduceAmmo += ReduceAmmo;
        }

        private void OnDisable()
        {
            AmmoEvents.OnLoadAmmo -= LoadAmmo;
            AmmoEvents.OnReduceAmmo -= ReduceAmmo;
        }
    }
}

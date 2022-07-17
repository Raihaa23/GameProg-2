using UnityEngine;

namespace Events
{
    public class AmmoEvents : MonoBehaviour
    { // EVENTS FOR AMMUNITION ACTIONS
        public delegate void LoadAmmo();
        public static event LoadAmmo OnLoadAmmo;
        public static void OnLoadAmmoMethod()
        {
            if (OnLoadAmmo != null)
            {
                OnLoadAmmo();
            }
        }
        
        public delegate void DestroyAmmo();
        public static event DestroyAmmo OnDestroyAmmo;
        public static void OnDestroyAmmoMethod()
        {
            if (OnDestroyAmmo != null)
            {
                OnDestroyAmmo();
            }
        }
        
        public delegate void ReduceAmmo();
        public static event ReduceAmmo OnReduceAmmo;
        public static void OnReduceAmmoMethod()
        {
            if (OnReduceAmmo != null)
            {
                OnReduceAmmo();
            }
        }
        
        public delegate void UnfreezeConstraints();
        public static event UnfreezeConstraints OnUnfreezeConstraints;
        public static void OnUnfreezeConstraintsMethod()
        {
            if (OnUnfreezeConstraints != null)
            {
                OnUnfreezeConstraints();
            }
        }
    }
}
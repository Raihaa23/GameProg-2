using Unity.VisualScripting;
using UnityEngine;

namespace DestructibleScripts
{
    public class NonPlayableCharacters : Destructible
    {
        protected override void ChangeSprite()
        {
            GetComponent<Animator>().SetBool("LowHealth", true);
            base.ChangeSprite();
        }
    }
}
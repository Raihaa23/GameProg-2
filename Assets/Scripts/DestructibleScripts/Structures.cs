using UnityEngine;

namespace DestructibleScripts
{
    public class Structures : Destructible
    {
        [SerializeField] private Sprite lowHealthSprite;
        protected override void ChangeSprite()
        {
            GetComponent<SpriteRenderer>().sprite = lowHealthSprite;
            base.ChangeSprite();
        }
    }
}
using UnityEngine;
using UnityEngine.EventSystems;

namespace Script.Item
{
    public class HeroCardItem : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
    {
        public int heroModelId;
        public void OnPointerDown(PointerEventData eventData)
        {
            Game.instance.Move(true,heroModelId);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Game.instance.Move(false,heroModelId);
        }
    }
}

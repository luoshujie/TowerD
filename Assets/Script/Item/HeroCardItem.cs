using UnityEngine;
using UnityEngine.EventSystems;

namespace Script.Item
{
    public class HeroCardItem : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
    {
        public int heroModelId;
        public void OnPointerDown(PointerEventData eventData)
        {
            PlaceContent.MoveEvent.Invoke(true,heroModelId);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            PlaceContent.MoveEvent.Invoke(false,heroModelId);
        }
    }
}

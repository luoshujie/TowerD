using UnityEngine;
using UnityEngine.EventSystems;

namespace Script.Item
{
    public class HeroCardItem : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
    {
        public int heroModelId;
        public void OnPointerDown(PointerEventData eventData)
        {
            FightUiMgr.instance.Move(true,heroModelId);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            FightUiMgr.instance.Move(false,heroModelId);
        }
    }
}

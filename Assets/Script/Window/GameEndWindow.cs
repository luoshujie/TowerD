using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Script.Window
{
    public class GameEndWindow : MonoBehaviour,IPointerClickHandler
    {
        public Image img;
        public Sprite winSprite;
        public Sprite loseSprite;

        public void Init(bool state)
        {
            Time.timeScale = 0;
            img.sprite = state ? winSprite : loseSprite;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Home");
            Destroy(gameObject);
        }
    }
}

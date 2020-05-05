using Script.Manager;
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
        public AudioClip loseClip;
        public AudioSource audioSource;

        public void Init(bool state)
        {
            MainMgr.instance.audioSource.Stop();
            if (state)
            {
                audioSource.Play();
            }
            else
            {
                audioSource.clip = loseClip;
                audioSource.Play();
            }
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

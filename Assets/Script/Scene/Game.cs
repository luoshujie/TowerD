using System;
using System.Collections.Generic;
using DG.Tweening;
using Script.Manager;
using Script.Role.Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Script
{
    public class Game : MonoBehaviour
    {
        public static Game instance;
        private GameObject _dragObj;

        public Text numText;
        public Text crystalCntText;
        public Text coinText;
        public Button pauseBtn;
        public Button addSpeedBtn;
        public Button startFightBtn;
        public Button retreatBtn;
        
        private void Awake()
        {
//            if (MainMgr.instance==null)
//            {
//                SceneManager.LoadScene("Init");
//                return;
//            }
//            WindowMgr.instance.UpdateCamera();
            instance = this;
        }

        private void FixedUpdate()
        {
            if (_dragObj != null)
            {
                Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                pos.z = 10;
                _dragObj.transform.position =pos;
                if (!_dragObj.activeSelf)
                {
                    _dragObj.SetActive(true);
                }
                
            }
        }
        

        public void Move(bool state, int heroId)
        {
            if (state)
            {
                _dragObj = FightMgr.instance.GetHeroModel(heroId);
                
                FightMgr.instance.ShowHighlight(StanceEnum.Highland);
            }
            else
            {
                FightMgr.instance.CloseHighlight(heroId,StanceEnum.Highland);
                _dragObj.SetActive(false);
                _dragObj = null;
                
            }
        }
        
        private bool GetPlaceState(StanceEnum stance)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit))
            {
                if (hit.collider.CompareTag($"PlacePlatform"))
                {
                    if (hit.collider.GetComponent<PlatformItem>().stance == stance)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
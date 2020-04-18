﻿using System;
using System.Collections.Generic;
using DG.Tweening;
using Script.Manager;
using Script.Role.Data;
using UnityEngine;

namespace Script
{
    public class FightUiMgr : MonoBehaviour
    {
        public static FightUiMgr instance;
        private GameObject _dragObj;
        public Transform content;

        private void Awake()
        {
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

        private Tweener _moveTween;

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

            int dir = state ? -1 : 1;
            _moveTween?.Kill(true);
            _moveTween = content.DOBlendableMoveBy(dir * 5 * content.up, 0.5f);
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
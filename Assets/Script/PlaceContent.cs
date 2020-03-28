using System;
using System.Collections.Generic;
using DG.Tweening;
using Script.Role.Data;
using UnityEngine;

namespace Script
{
    public class PlaceContent : MonoBehaviour
    {
        public static Action<bool, int> MoveEvent;
        public List<GameObject> heroModelList;
        private GameObject _dragObj;

        private void Awake()
        {
            MoveEvent += Move;
        }

        private void OnDestroy()
        {
            MoveEvent -= Move;
        }

        private void FixedUpdate()
        {
            if (_dragObj != null)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out var hit, Mathf.Infinity))
                {
                    _dragObj.transform.position = hit.point;
                }
                else
                {
                    Vector3 pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
                    pos = Camera.main.ScreenToWorldPoint(pos);
                    _dragObj.transform.position = pos;
                }
            }
        }

        private Tweener _moveTween;

        private void Move(bool state, int heroId)
        {
            if (state)
            {
                _dragObj = GetHeroModel(heroId);
                _dragObj.SetActive(true);
            }
            else
            {
                _dragObj.SetActive(false);
                _dragObj = null;

                // todo 检测是否可以放置
            }

            int dir = state ? -1 : 1;
            _moveTween?.Kill(true);
            _moveTween = transform.DOBlendableMoveBy(dir * 50 * transform.up, 0.5f);
        }

        private GameObject GetHeroModel(int id)
        {
            if (heroModelList.Count > id)
            {
                return heroModelList[id];
            }

            return null;
        }

        private bool GetPlaceState(StanceEnum stance)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit))
            {
                if (hit.collider.CompareTag($"PlacePlatform"))
                {
                    if (hit.collider.GetComponent<PlacePlatform>().stance == stance)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
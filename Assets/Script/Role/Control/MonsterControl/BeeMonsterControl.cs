using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Script.Role.Control.MonsterControl
{
    public class BeeMonsterControl : MonoBehaviour
    {
        private List<Transform> pathList;
        private int movePathIndex;
        private float speed = 1;
        private float times;
        private float distance;

        public void Init(List<Transform> path)
        {
            pathList = path;
            movePathIndex = 0;
            transform.position = pathList[movePathIndex].position;
            movePathIndex++;
            MoveForTarget();
        }

        private Tweener moveTween;

        private void MoveForTarget()
        {
            if (movePathIndex >= pathList.Count)
            {
                //到达目标地点
                ForTarget();
                moveTween.Kill(true);
                return;
            }

            distance = Vector3.Distance(transform.position, pathList[movePathIndex].position);
            times = distance / speed;
            moveTween = transform.DOMove(pathList[movePathIndex].position, times).SetEase(Ease.Linear).OnComplete(() =>
            {
                movePathIndex++;
                MoveForTarget();
            });
        }

        private void ForTarget()
        {
            Debug.LogWarning("到达目标地点");
            gameObject.SetActive(false);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!CompareTag("Monster"))
            {
                Debug.LogWarning(other.name);
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MIS
{
    public class TouchScreen : InputDevice<TouchScreen>
    {
        Vector3 downPos;    // 터치 시작위치
        Vector3 upPos;      // 터치 종료위치

        Vector3 dragPrevPos;    // 터치 드래그 이전위치
        Vector3 dragLastPos;    // 터치 드래그 이후위치

        float minDistance;  // 최소 드래그 이동거리 10f로 설정
        float minimumMovedDistance; // 드래그 이동거리 갱신에 필요한 최소 이동거리 제한값
        float movedDistance;

        private void Awake()
        {
            Reset_ClickValues();
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.touchCount > 0)
            {
                if(Input.touchCount == 1)
                {
                    Touch_Single(Input.GetTouch(0));
                }
                else
                {
                    Touch_Multiple(Input.touches);
                }
            }
        }

        /// <summary>
        /// 한 손가락 터치
        /// 클릭, 드래그 처리
        /// </summary>
        /// <param name="touch"></param>
        private void Touch_Single(Touch touch)
        {
            if(touch.phase == TouchPhase.Began)
            {
                downPos = touch.position;   // 터치 시작위치 할당
            }
            else if(touch.phase == TouchPhase.Moved)
            {
                // 현재 터치 포인트 할당
                dragLastPos = touch.position;
                // 이전 터치 포인트를 터치 위치 - 이동위치 역산으로 계산
                dragPrevPos = touch.position - touch.deltaPosition;

                float dragDist = Vector3.Distance(dragPrevPos, dragLastPos);
                //Debug.Log($"drag distance : {dragDist}");
                if(dragDist > minimumMovedDistance) // 드래그 최소이동거리 제한
                {
                    // 터치 중 포인트 이동거리 합산
                    movedDistance += dragDist;

                    // 드래그 이동벡터 할당
                    Vector3 deltaVector = touch.deltaPosition;

                    //-----------------------------------
                    // [드래그 이벤트 발생] vec3 드래그값 전달
                    if(movedDistance > minDistance)
                    {
                        // deltaVector
                        Debug.Log($"On Drag vector : {deltaVector}");
                    }
                }
            }
            else if(touch.phase == TouchPhase.Stationary)
            {
                // 대 기
            }
            else if(touch.phase == TouchPhase.Ended)
            {
                // 터치 끝
                upPos = touch.position;

                // 식1 : (터치 최소이동거리 > 드래그 이동거리) ?
                // 식2 : (터치 최소이동거리 > 터치 시작위치, 터치 종료위치간 거리) ?
                bool expr1 = minDistance > movedDistance;
                bool expr2 = minDistance > Vector3.Distance(downPos, upPos);

                if(expr1 && expr2)
                {
                    //-----------------------------------
                    // [클릭 이벤트 발생] Vec3 클릭 종료위치 전달
                    Debug.Log($"On Touch position : {upPos}");

                }

                Reset_ClickValues();
            }
            else if(touch.phase == TouchPhase.Canceled)
            {
                Reset_ClickValues();
            }
        }

        /// <summary>
        /// 두 손가락 터치
        /// 줌 인, 아웃 처리
        /// </summary>
        /// <param name="touches"></param>
        private void Touch_Multiple(Touch[] touches)
        {

        }

        /// <summary>
        /// 변수 초기화
        /// </summary>
        private void Reset_ClickValues()
        {
            downPos = default(Vector3);
            upPos = default(Vector3);

            dragPrevPos = default(Vector3);
            dragLastPos = default(Vector3);

            movedDistance = default(float);

            minDistance = 20f;
            minimumMovedDistance = 5f;
        }
    }
}

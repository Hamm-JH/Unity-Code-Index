using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MIS
{
    public class Mouse : InputDevice<Mouse>
    {
        Vector3 downPos;    // 마우스 클릭 시작위치
        Vector3 upPos;      // 마우스 클릭 종료위치

        Vector3 dragPrevPos;    // 마우스 드래그 이전위치
        Vector3 dragLastPos;    // 마우스 드래그 이후위치

        float minDistance;      // 최소 드래그 이동거리 10f로 설정
        float minimumMovedDistance; // 드래그 이동거리 갱신에 필요한 최소 이동거리 제한값
        float movedDistance;

        //#region Module
        //private static Mouse module;

        //public static Mouse Module
        //{
        //    get
        //    {
        //        if(module == null)
        //        {
        //            module = FindObjectOfType<Mouse>() as Mouse;
        //            if(module == null)
        //            {
        //                GameObject obj = new GameObject("Mouse");
        //                Mouse mouse = obj.AddComponent<Mouse>();
        //                module = mouse;
        //                obj.transform.SetParent(InputManager.Instance.transform);
        //            }
        //        }
        //        return module;
        //    }
        //}

        //public void Init()
        //{

        //}
        //#endregion

        private void Awake()
        {
            Reset_ClickValues();
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetAxis("Mouse ScrollWheel") != 0)
            {
                //-----------------------------------
                // [스크롤 이벤트 발생] float 스크롤 값 전달 
                //Debug.Log(Input.GetAxis("Mouse ScrollWheel"));
                //Debug.Log("On Scroll");
                //Debug.Log($"On Scroll vector : {Input.GetAxis("Mouse ScrollWheel")}");
                Debug.Log($"On Scroll vector : {Input.mouseScrollDelta.y}");
            }

            if(Input.GetMouseButtonDown(0))
            {
                downPos = Input.mousePosition;  // 클릭 시작위치 할당

                dragPrevPos = downPos;          // 마우스 드래그 이전위치 할당
            }
            else if(Input.GetMouseButton(0))
            {
                // 현재 드래그 위치 할당
                dragLastPos = Input.mousePosition;

                // 드래그 이전위치 - 드래그 이후위치간 거리계산
                float dragDist = Vector3.Distance(dragPrevPos, dragLastPos);
                if(dragDist > minimumMovedDistance) // 드래그 최소이동거리 제한
                {
                    // 클릭중 이동거리 계산
                    movedDistance += dragDist;
                
                    // 드래그 이동벡터 계산
                    Vector3 deltaVector = dragLastPos - dragPrevPos;

                    //-----------------------------------
                    // [드래그 이벤트 발생] Vec3 드래그값 전달
                    // ! : 최소 이동거리 이상 드래그했을 경우 값 전달 고려
                    if (movedDistance > minDistance)
                    {
                        //deltaVector
                        //Debug.Log("On Drag");
                        Debug.Log($"On Drag vector : {deltaVector}");
                    }
                }

                // 드래그 판단값 갱신
                dragPrevPos = dragLastPos;
            }
            else if(Input.GetMouseButtonUp(0))
            {
                upPos = Input.mousePosition;

                // 식1 : (클릭 최소이동거리 > 드래그 이동거리) 인가?
                // 식2 : (클릭 최소이동거리 > 클릭시작위치, 클릭종료위치간 거리) 인가?
                bool expr1 = minDistance > movedDistance;
                bool expr2 = minDistance > Vector3.Distance(downPos, upPos);

                if(expr1 && expr2)
                {
                    //-----------------------------------
                    // [클릭 이벤트 발생] Vec3 클릭 종료위치 전달
                    //Debug.Log("On Click");
                    Debug.Log($"On Click position : {upPos}");
                }

                // 클릭변수 초기화
                Reset_ClickValues();
            }
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

            minDistance = 10f;
            minimumMovedDistance = 0.5f;
        }
    }
}

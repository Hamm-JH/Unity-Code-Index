using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MIS
{
    public class Mouse : InputDevice<Mouse>
    {
        Vector3 downPos;    // ���콺 Ŭ�� ������ġ
        Vector3 upPos;      // ���콺 Ŭ�� ������ġ

        Vector3 dragPrevPos;    // ���콺 �巡�� ������ġ
        Vector3 dragLastPos;    // ���콺 �巡�� ������ġ

        float minDistance;      // �ּ� �巡�� �̵��Ÿ� 10f�� ����
        float minimumMovedDistance; // �巡�� �̵��Ÿ� ���ſ� �ʿ��� �ּ� �̵��Ÿ� ���Ѱ�
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
                // [��ũ�� �̺�Ʈ �߻�] float ��ũ�� �� ���� 
                //Debug.Log(Input.GetAxis("Mouse ScrollWheel"));
                //Debug.Log("On Scroll");
                //Debug.Log($"On Scroll vector : {Input.GetAxis("Mouse ScrollWheel")}");
                Debug.Log($"On Scroll vector : {Input.mouseScrollDelta.y}");
            }

            if(Input.GetMouseButtonDown(0))
            {
                downPos = Input.mousePosition;  // Ŭ�� ������ġ �Ҵ�

                dragPrevPos = downPos;          // ���콺 �巡�� ������ġ �Ҵ�
            }
            else if(Input.GetMouseButton(0))
            {
                // ���� �巡�� ��ġ �Ҵ�
                dragLastPos = Input.mousePosition;

                // �巡�� ������ġ - �巡�� ������ġ�� �Ÿ����
                float dragDist = Vector3.Distance(dragPrevPos, dragLastPos);
                if(dragDist > minimumMovedDistance) // �巡�� �ּ��̵��Ÿ� ����
                {
                    // Ŭ���� �̵��Ÿ� ���
                    movedDistance += dragDist;
                
                    // �巡�� �̵����� ���
                    Vector3 deltaVector = dragLastPos - dragPrevPos;

                    //-----------------------------------
                    // [�巡�� �̺�Ʈ �߻�] Vec3 �巡�װ� ����
                    // ! : �ּ� �̵��Ÿ� �̻� �巡������ ��� �� ���� ���
                    if (movedDistance > minDistance)
                    {
                        //deltaVector
                        //Debug.Log("On Drag");
                        Debug.Log($"On Drag vector : {deltaVector}");
                    }
                }

                // �巡�� �Ǵܰ� ����
                dragPrevPos = dragLastPos;
            }
            else if(Input.GetMouseButtonUp(0))
            {
                upPos = Input.mousePosition;

                // ��1 : (Ŭ�� �ּ��̵��Ÿ� > �巡�� �̵��Ÿ�) �ΰ�?
                // ��2 : (Ŭ�� �ּ��̵��Ÿ� > Ŭ��������ġ, Ŭ��������ġ�� �Ÿ�) �ΰ�?
                bool expr1 = minDistance > movedDistance;
                bool expr2 = minDistance > Vector3.Distance(downPos, upPos);

                if(expr1 && expr2)
                {
                    //-----------------------------------
                    // [Ŭ�� �̺�Ʈ �߻�] Vec3 Ŭ�� ������ġ ����
                    //Debug.Log("On Click");
                    Debug.Log($"On Click position : {upPos}");
                }

                // Ŭ������ �ʱ�ȭ
                Reset_ClickValues();
            }
        }

        /// <summary>
        /// ���� �ʱ�ȭ
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

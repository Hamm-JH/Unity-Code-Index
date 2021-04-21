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

        public override void Init(Def.DeviceParams param)
        {
            Reset_ClickValues(param);
        }

        private void Awake()
        {
            Reset_ClickValues();
        }

        // Update is called once per frame
        void Update()
        {
            //Debug.Log(Input.GetAxis("Mouse ScrollWheel"));
            //Debug.Log(Input.mouseScrollDelta.y);
            if(Input.GetAxis("Mouse ScrollWheel") != 0)
            {
                //-----------------------------------
                // [��ũ�� �̺�Ʈ �߻�] float ��ũ�� �� ���� 
                //Debug.Log(Input.GetAxis("Mouse ScrollWheel"));
                //Debug.Log("On Scroll");
                //Debug.Log($"On Scroll vector : {Input.GetAxis("Mouse ScrollWheel")}");

                //Debug.Log($"On Scroll vector : {Input.mouseScrollDelta.y}");
                InputManager.Instance.OnZoom.Invoke(Input.mouseScrollDelta.y);
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
                        //Debug.Log($"On Drag vector : {deltaVector}");
                        InputManager.Instance.OnDrag.Invoke(deltaVector);
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
                    //Debug.Log($"On Click position : {upPos}");
                    InputManager.Instance.OnClick.Invoke(upPos);
                }

                // Ŭ������ �ʱ�ȭ
                Reset_ClickValues();
            }
        }

        #region Reset values
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
        }

        private void Reset_ClickValues(Def.DeviceParams param)
        {
            Reset_ClickValues();

            minDistance = param.dragBoundary;
            minimumMovedDistance = param.minimumDragBoundary;
        }
        #endregion

        public void Inputs()
        {
            
            if(Input.GetMouseButtonDown(0)) { }

            Touch touch = Input.GetTouch(0);
        }
    }
}

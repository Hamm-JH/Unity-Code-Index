using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MIS
{
    public class TouchScreen : InputDevice<TouchScreen>
    {
        Vector3 downPos;    // ��ġ ������ġ
        Vector3 upPos;      // ��ġ ������ġ

        Vector3 dragPrevPos;    // ��ġ �巡�� ������ġ
        Vector3 dragLastPos;    // ��ġ �巡�� ������ġ

        float minDistance;  // �ּ� �巡�� �̵��Ÿ� 10f�� ����
        float minimumMovedDistance; // �巡�� �̵��Ÿ� ���ſ� �ʿ��� �ּ� �̵��Ÿ� ���Ѱ�
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
        /// �� �հ��� ��ġ
        /// Ŭ��, �巡�� ó��
        /// </summary>
        /// <param name="touch"></param>
        private void Touch_Single(Touch touch)
        {
            if(touch.phase == TouchPhase.Began)
            {
                downPos = touch.position;   // ��ġ ������ġ �Ҵ�
            }
            else if(touch.phase == TouchPhase.Moved)
            {
                // ���� ��ġ ����Ʈ �Ҵ�
                dragLastPos = touch.position;
                // ���� ��ġ ����Ʈ�� ��ġ ��ġ - �̵���ġ �������� ���
                dragPrevPos = touch.position - touch.deltaPosition;

                float dragDist = Vector3.Distance(dragPrevPos, dragLastPos);
                //Debug.Log($"drag distance : {dragDist}");
                if(dragDist > minimumMovedDistance) // �巡�� �ּ��̵��Ÿ� ����
                {
                    // ��ġ �� ����Ʈ �̵��Ÿ� �ջ�
                    movedDistance += dragDist;

                    // �巡�� �̵����� �Ҵ�
                    Vector3 deltaVector = touch.deltaPosition;

                    //-----------------------------------
                    // [�巡�� �̺�Ʈ �߻�] vec3 �巡�װ� ����
                    if(movedDistance > minDistance)
                    {
                        // deltaVector
                        Debug.Log($"On Drag vector : {deltaVector}");
                    }
                }
            }
            else if(touch.phase == TouchPhase.Stationary)
            {
                // �� ��
            }
            else if(touch.phase == TouchPhase.Ended)
            {
                // ��ġ ��
                upPos = touch.position;

                // ��1 : (��ġ �ּ��̵��Ÿ� > �巡�� �̵��Ÿ�) ?
                // ��2 : (��ġ �ּ��̵��Ÿ� > ��ġ ������ġ, ��ġ ������ġ�� �Ÿ�) ?
                bool expr1 = minDistance > movedDistance;
                bool expr2 = minDistance > Vector3.Distance(downPos, upPos);

                if(expr1 && expr2)
                {
                    //-----------------------------------
                    // [Ŭ�� �̺�Ʈ �߻�] Vec3 Ŭ�� ������ġ ����
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
        /// �� �հ��� ��ġ
        /// �� ��, �ƿ� ó��
        /// </summary>
        /// <param name="touches"></param>
        private void Touch_Multiple(Touch[] touches)
        {

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

            minDistance = 20f;
            minimumMovedDistance = 5f;
        }
    }
}

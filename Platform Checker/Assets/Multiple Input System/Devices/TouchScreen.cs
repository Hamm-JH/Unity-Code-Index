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

        public override void Init(Def.DeviceParams param)
        {
            
        }

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
            int index = touches.Length;
            if(index >= 2)
            {
                Vector2[] touchPrevPoses = new Vector2[2] { default(Vector2), default(Vector2) };
                float[] touchMagnitudes = new float[2] { default(float), default(float) };

                // �� ��ġ ��ġ�� ���� �������� ��ġ�� ����
                for (int i = 0; i < 2; i++)
                {
                    touchPrevPoses[i] = touches[i].position - touches[i].deltaPosition;
                }

                // ���� �����Ӱ� ���� ������ ������ ��ġ������ ����
                // 0 : ���� �������� ��ġ����
                touchMagnitudes[0] = (touchPrevPoses[0] - touchPrevPoses[1]).magnitude;
                // 1 : ���� �������� ��ġ����
                touchMagnitudes[1] = (touches[0].position - touches[1].position).magnitude;

                // �� ������ ��ġ���ݰ� �� ����
                float deltaMagnitudeDiff = touchMagnitudes[0] - touchMagnitudes[1];

                string result =
                    $"currPos 0 : {touches[0].position}\n" +
                    $"currPos 1 : {touches[1].position}\n" +
                    $"prevPos 0 : {touchPrevPoses[0]}\n" +
                    $"prevPos 1 : {touchPrevPoses[1]}\n" +
                    $"prevMag 0 : {touchMagnitudes[0]}\n" +
                    $"currMag 1 : {touchMagnitudes[1]}\n" +
                    $"deltaMagnitude : {deltaMagnitudeDiff}";

                Debug.Log(result);

                // [�� ��, �ƿ� �̺�Ʈ �߻�] float delta�� ����
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
    }
}

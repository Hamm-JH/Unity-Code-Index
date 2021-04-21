using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MIS.Def
{
    public struct DeviceParams
    {
        /// <summary>
        /// [Target]
        /// ----------------------
        /// DEVICE 12 : Mouse
        /// DEVICE 21 : TouchScreen
        /// ----------------------
        /// �ּ� �巡�� ���
        /// Ŭ���� �巡�� ���� ���Ѱ��
        /// </summary>
        public float dragBoundary;

        /// <summary>
        /// [Target]
        /// ----------------------
        /// DEVICE 12 : Mouse
        /// DEVICE 21 : TouchScreen
        /// ----------------------
        /// �ּ� �巡�� ���Ѱ��
        /// ���� ��ġ���� �巡�׸� �����ϴ� �ּҰ��
        /// </summary>
        public float minimumDragBoundary;

        /// <summary>
        /// ��� ������ �⺻�� �Ҵ��Ѵ�.
        /// ���� �÷������� �Ϻ� ������� �ʴ� ������ ������ �� �־� ��ü ���� �ʱ�ȭ�� �����Ѵ�.
        /// </summary>
        public void Init()
        {
            dragBoundary = default(float);
            minimumDragBoundary = default(float);
        }

        public void Init(Platform platform, Device device)
        {
            Init();

            if(platform == Platform.PC && device == Device.MOUSE)
            {
                dragBoundary = 10;
                minimumDragBoundary = 1;
            }
            else if(platform == Platform.MOBILE && device == Device.TOUCHSCREEN)
            {
                dragBoundary = 50;
                minimumDragBoundary = 20;
            }
        }
    } 
}

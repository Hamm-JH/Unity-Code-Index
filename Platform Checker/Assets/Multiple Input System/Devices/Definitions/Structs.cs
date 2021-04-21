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
        /// 최소 드래그 경계
        /// 클릭과 드래그 간의 제한경계
        /// </summary>
        public float dragBoundary;

        /// <summary>
        /// [Target]
        /// ----------------------
        /// DEVICE 12 : Mouse
        /// DEVICE 21 : TouchScreen
        /// ----------------------
        /// 최소 드래그 제한경계
        /// 고정 위치에서 드래그를 시작하는 최소경계
        /// </summary>
        public float minimumDragBoundary;

        /// <summary>
        /// 모든 변수를 기본값 할당한다.
        /// 여러 플랫폼에서 일부 사용하지 않는 변수를 포함할 수 있어 전체 변수 초기화를 실행한다.
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
 
namespace Test
{
    public class ChangeCursorTest : MonoBehaviour//, ISelectHandler, IDeselectHandler
    {
        private EventSystem system;                                 //事件系统
        private bool isSelect = false;                              //光标是否在当前输入框标志
        public Direction direction = Direction.vertical;            //垂直切换输入框的光标
 
		public InputField inputF;
 
        //枚举光标切换的方向
        public enum Direction
        {
            //垂直切换
            vertical = 0,
            //水平切换
            horizontal = 1
        }
        void Start()
        {
            system = EventSystem.current;
        }
 
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Z) )
            {
				if(!inputF.isFocused) {
					inputF.ActivateInputField();
				}
                Debug.Log(inputF.isFocused);
            }
        }
 
       /* private static Selectable GetNextSelectable(Selectable current, Vector3 dir)
        {
            Selectable next = current.FindSelectable(dir);
            if (next == null)
                next = current.FindLoopSelectable(-dir);
            return next;
        }
 
        IEnumerator Wait(Selectable next)
        {
            yield return new WaitForEndOfFrame();
            system.SetSelectedGameObject(next.gameObject, new BaseEventData(system));
        }
 
        public void OnSelect(BaseEventData eventData)
        {
            isSelect = true;
        }
 
        public void OnDeselect(BaseEventData eventData)
        {
            isSelect = false;
        }
    }//class_end
    public static class Develop
    {
        public static Selectable FindLoopSelectable(this Selectable current, Vector3 dir)
        {
            Selectable first = current.FindSelectable(dir);
            if (first != null)
            {
                current = first.FindLoopSelectable(dir);
            }
            return current;
        }*/
    }
 
 
}

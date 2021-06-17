using UnityEngine;
using System.Collections;

namespace UIFramework
{

    public abstract class PopupBase : PanelBase
    {
        public override bool IsActive
        {
            get
            {
                return cachedGameObject.activeSelf;
            }
        }

        public override void Activate()
        {
            base.Activate();
            cachedGameObject.SetActive(true);
        }

        public override void Deactivate()
        {
            base.Deactivate();
        }

        public override void OnBackKeyPressed()
        {
            base.OnBackKeyPressed();
            Deactivate();
        }
    }
}
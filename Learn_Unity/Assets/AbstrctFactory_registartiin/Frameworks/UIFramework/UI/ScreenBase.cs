using UnityEngine;
using System.Collections;

namespace UIFramework
{

	public abstract class ScreenBase : PanelBase
	{

		public override void Activate ()
		{
			base.Activate ();
			cachedGameObject.SetActive (true);
		}

		public override void Deactivate ()
		{
			base.Deactivate ();
			cachedGameObject.SetActive (false);
		}

		public override void OnBackKeyPressed ()
		{
			base.OnBackKeyPressed ();
			Deactivate ();
		}
	}

}
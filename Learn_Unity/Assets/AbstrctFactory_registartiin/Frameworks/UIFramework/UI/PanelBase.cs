using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UIFramework;

namespace UIFramework
{
	/// <summary>
	/// Base class for all panels
	/// </summary>
	public abstract class PanelBase : UIBehaviour, IPanel
	{
		public virtual bool IsActive { get; private set; }

		/// <summary>
		/// Initialize the Panel
		/// </summary>
		public virtual void Init ()
		{
		}

		/// <summary>
		/// Activate the Panel
		/// </summary>
		public virtual void Activate ()
		{
//			Debug.Log ("Activate - " + GetType ().Name);
			IsActive = true;
		}

		/// <summary>
		/// Deactivate the Panel
		/// </summary>
		public virtual void Deactivate ()
		{
			//Debug.Log ("Deactivate - " + GetType ().Name);
			IsActive = false;
		}

		/// <summary>
		/// Called after panel is activated
		/// </summary>
		public virtual void OnShow ()
		{
		}

		/// <summary>
		/// Called before panel is deactivated
		/// </summary>
		public virtual void OnHide ()
		{
		}

		/// <summary>
		/// Called on every button click inside this panel
		/// </summary>
		public void OnButtonEventReceived ()
		{
			OnButtonClick (EventSystem.current.currentSelectedGameObject);
		}

		/// <summary>
		/// Called on every button click with button reference
		/// </summary>
		/// <param name="button">Button Reference.</param>
		public virtual void OnButtonClick (GameObject button)
		{
		}
		///
		///
		//public virtual void OnButtonClick1(GameObject button)
		//{
		//}
		///


		/// <summary>
		/// Called on back or escape key pressed
		/// </summary>
		public virtual void OnBackKeyPressed ()
		{
			Debug.Log ("On Back Key - " + GetType ().Name);
		}
	}
}
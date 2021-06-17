using UnityEngine;
using System.Collections;

namespace UIFramework
{
	public abstract class UIAbstractFactory<U> : UIBehaviour where U : PanelBase
	{
		/// <summary>
		/// All panels.
		/// </summary>
		[SerializeField] protected U[] allPanels;

		/// <summary>
		/// Awake this instance.
		/// </summary>
		private void Awake ()
		{
			for (int i = 0; i < allPanels.Length; i++)
			{
				allPanels [i].Init ();
			}
			Init ();
		}

		protected virtual void Init ()
		{
		}

		public IEnumerator CallBackRoutine (System.Action callback)
		{
			yield return new WaitForEndOfFrame ();
			callback.Invoke ();
		}

		/// <summary>
		/// Gets the panel object given the type of panel
		/// </summary>
		/// <returns>The panel.</returns>
		/// <typeparam name="T">Panel Type.</typeparam>
		public T GetPanel<T> () where T : PanelBase
		{
			return System.Array.Find (allPanels, t => t.GetType ().Name == typeof(T).Name) as T;
		}
   
	}
}
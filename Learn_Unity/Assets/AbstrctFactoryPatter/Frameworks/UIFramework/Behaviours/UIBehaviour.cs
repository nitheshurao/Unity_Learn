using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace UIFramework
{
	public class UIBehaviour : CustomBehaviour
	{
		RectTransform mRectTrans;

		public RectTransform cachedRectTransform {
			get {
				if (mRectTrans == null) {
					mRectTrans = GetComponent<RectTransform> ();
				}
				return mRectTrans;
			}
		}

		Image mImage;

		public Image cachedImage {
			get {
				if (mImage == null) {
					mImage = GetComponent<Image> ();
				}
				return mImage;
			}
		}

		Text mText;

		public virtual Text cachedText {
			get {
				if (mText == null) {
					mText = GetComponent<Text> ();
				}
				return mText;
			}
		}

	}
}
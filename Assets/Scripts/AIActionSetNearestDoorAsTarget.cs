using MoreMountains.Tools;
using Unity.VisualScripting;
using UnityEngine;

namespace MoreMountains.CorgiEngine
{
	/// <summary>
	/// An AIAction used to set a specified Transform as the target
	/// </summary>
	[AddComponentMenu("Corgi Engine/Character/AI/Actions/AIActionSetNearestDoorAsTarget")]
	public class AIActionSetNearestDoorAsTarget : AIAction
	{
		public Transform TargetTransform;
		public bool OnlyRunOnce = true;

		protected bool _alreadyRan = false;

		/// <summary>
		/// On init we initialize our action
		/// </summary>
		public override void Initialization()
		{
			base.Initialization();
			_alreadyRan = false;
		}

		/// <summary>
		/// Sets a new target
		/// </summary>
		public override void PerformAction()
		{
			if (OnlyRunOnce && _alreadyRan)
			{
				return;
			}
			//search for nearest door.
			DoorColor[] doorcolors = FindObjectsOfType<DoorColor>();
			float minDistance = float.MaxValue;
			foreach (DoorColor doorColor in doorcolors)
			{
				//find the same color door
				if (doorColor.color.Equals(GetComponent<GenieColor>().color))
				{
					float currentDist = Vector3.Distance(gameObject.transform.position, doorColor.gameObject.transform.position);
					if (currentDist < minDistance)
					{
						minDistance = currentDist;
						TargetTransform = doorColor.gameObject.transform;
					}
				}
			}
			_brain.Target = TargetTransform;
		}

		/// <summary>
		/// On enter state we reset our flag
		/// </summary>
		public override void OnEnterState()
		{
			base.OnEnterState();
			_alreadyRan = false;
		}
	}
}
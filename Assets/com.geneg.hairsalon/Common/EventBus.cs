using System;
using System.Collections.Generic;

namespace com.geneg.hairsalon.Common
{
	
	public class EventBus
	{
		private Dictionary<Type, List<Action<object>>> eventHandlers = new Dictionary<Type, List<Action<object>>>();

		public void Subscribe<T>(Action<T> handler)
		{
			Type eventType = typeof(T);
			if (!eventHandlers.ContainsKey(eventType))
			{
				eventHandlers[eventType] = new List<Action<object>>();
			}
			eventHandlers[eventType].Add(obj => handler((T)obj));
		}

		public void Unsubscribe<T>(Action<T> handler)
		{
			Type eventType = typeof(T);
			if (eventHandlers.ContainsKey(eventType))
			{
				eventHandlers[eventType].Remove(obj => handler((T)obj));
			}
		}
		
		public void Publish<T>(T eventData)
		{
			Type eventType = typeof(T);
			if (eventHandlers.ContainsKey(eventType))
			{
				foreach (var handler in eventHandlers[eventType])
				{
					handler.Invoke(eventData);
				}
			}
		}
	}

}

using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Hacklab2015.ConfigurationModels
{
	public class HackLabConfigurationElementCollection<TKey, TElement> : ConfigurationElementCollection, IEnumerable<TElement> where TElement : HackLabConfigurationElement<TKey>, new()
	{
		protected override ConfigurationElement CreateNewElement()
		{
			return new TElement();
		}

		protected override object GetElementKey(ConfigurationElement element)
		{
			return ((TElement) element).GetKey();
		}

		public TElement this[TKey key]
		{
			get { return (TElement) BaseGet(key); }

			set
			{
				if (BaseGet(key) != null)
				{
					BaseRemove(key);
				}

				BaseAdd(value);
			}
		}

		public TElement this[int index]
		{
			get
			{
				return (TElement)BaseGet(index);
			}
			set
			{
				if (BaseGet(index) != null)
				{
					BaseRemoveAt(index);
				}
				BaseAdd(index, value);
			}
		}

		public bool ContainsKey(TKey key)
		{
			return BaseGet(key) != null;
		}

		public new IEnumerator<TElement> GetEnumerator()
		{
			// If the source collection implements IEnumerable<T> (like this class does), Cast<T> returns the underlying collection
			// which is bad in this case as we're trying to avoid writing an implementation of GetEnumerator. Wrapping "this" into an ArrayList
			// helps us avoid that.
			return new ArrayList(this).Cast<TElement>().GetEnumerator();
		}
	}
}
using System.Collections;
using System.Collections.Generic;

namespace Freshdesk
{
    /// <summary>
    /// Represents a collection of string keys and object values. Null objects are ignored and are not added to the collection.
    /// This is an abstract base-class wrapping a <see cref="T:System.Collections.Generic.Dictionary`2"/> with virtual methods.
    /// Adapted from the VirtualDictionary written by <see href="https://stackoverflow.com/questions/6250706/override-dictionary-add"/>Allon Guralnek</see>.
    /// </summary>
    public class CustomFields : IDictionary<string, object>
    {
        protected IDictionary<string, object> wrappedDictionary;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomFields{string,object}"/> class that is empty, has the default initial capacity, and uses the default equality comparer for the key type.
        /// </summary>
        public CustomFields()
        {
            wrappedDictionary = new Dictionary<string, object>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomFields{string,object}"/> class that is empty, has the specified initial capacity, and uses the default equality comparer for the key type.
        /// </summary>
        /// <param name="capacity">The initial number of elements that the <see cref="T:System.Collections.Generic.CustomFields`2"/> can contain.</param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="capacity"/> is less than 0.</exception>
        public CustomFields(int capacity)
        {
            wrappedDictionary = new Dictionary<string, object>(capacity);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomFields{string,object}"/> class that is empty, has the default initial capacity, and uses the specified <see cref="T:System.Collections.Generic.IEqualityComparer`1"/>.
        /// </summary>
        /// <param name="comparer">The <see cref="T:System.Collections.Generic.IEqualityComparer`1"/> implementation to use when comparing keys, or null to use the default <see cref="T:System.Collections.Generic.EqualityComparer`1"/> for the type of the key.</param>
        public CustomFields(IEqualityComparer<string> comparer)
        {
            wrappedDictionary = new Dictionary<string, object>(comparer);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomFields{string,object}"/> class that is empty, has the specified initial capacity, and uses the specified <see cref="T:System.Collections.Generic.IEqualityComparer`1"/>.
        /// </summary>
        /// <param name="capacity">The initial number of elements that the <see cref="CustomFields{string,object}"/> can contain.</param><param name="comparer">The <see cref="T:System.Collections.Generic.IEqualityComparer`1"/> implementation to use when comparing keys, or null to use the default <see cref="T:System.Collections.Generic.EqualityComparer`1"/> for the type of the key.</param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="capacity"/> is less than 0.</exception>
        public CustomFields(int capacity, IEqualityComparer<string> comparer)
        {
            wrappedDictionary = new Dictionary<string, object>(capacity, comparer);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomFields{string,object}"/> class that contains elements copied from the specified <see cref="T:System.Collections.Generic.IDictionary`2"/> and uses the default equality comparer for the key type.
        /// </summary>
        /// <param name="dictionary">The <see cref="T:System.Collections.Generic.IDictionary`2"/> whose elements are copied to the new <see cref="CustomFields{string,object}"/>.</param><exception cref="T:System.ArgumentNullException"><paramref name="dictionary"/> is null.</exception><exception cref="T:System.ArgumentException"><paramref name="dictionary"/> contains one or more duplicate keys.</exception>
        public CustomFields(IDictionary<string, object> dictionary)
        {
            wrappedDictionary = new Dictionary<string, object>(dictionary);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomFields{string,object}"/> class that contains elements copied from the specified <see cref="T:System.Collections.Generic.IDictionary`2"/> and uses the specified <see cref="T:System.Collections.Generic.IEqualityComparer`1"/>.
        /// </summary>
        /// <param name="dictionary">The <see cref="T:System.Collections.Generic.IDictionary`2"/> whose elements are copied to the new <see cref="CustomFields{string,object}"/>.</param><param name="comparer">The <see cref="T:System.Collections.Generic.IEqualityComparer`1"/> implementation to use when comparing keys, or null to use the default <see cref="T:System.Collections.Generic.EqualityComparer`1"/> for the type of the key.</param><exception cref="T:System.ArgumentNullException"><paramref name="dictionary"/> is null.</exception><exception cref="T:System.ArgumentException"><paramref name="dictionary"/> contains one or more duplicate keys.</exception>
        public CustomFields(IDictionary<string, object> dictionary, IEqualityComparer<string> comparer)
        {
            wrappedDictionary = new Dictionary<string, object>(dictionary, comparer);
        }

        /// <summary>
        /// Adds an element with the provided key and value to the <see cref="T:System.Collections.Generic.IDictionary`2"/>.
        /// </summary>
        /// <param name="key">The object to use as the key of the element to add.</param><param name="value">The object to use as the value of the element to add.</param><exception cref="T:System.ArgumentNullException"><paramref name="key"/> is null.</exception><exception cref="T:System.ArgumentException">An element with the same key already exists in the <see cref="T:System.Collections.Generic.IDictionary`2"/>.</exception><exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.IDictionary`2"/> is read-only.</exception>
        public virtual void Add(string key, object value)
        {
            if (value != null)
                wrappedDictionary.Add(key, value);
        }

        /// <summary>
        /// Determines whether the <see cref="T:System.Collections.Generic.IDictionary`2"/> contains an element with the specified key.
        /// </summary>
        /// <returns>
        /// true if the <see cref="T:System.Collections.Generic.IDictionary`2"/> contains an element with the key; otherwise, false.
        /// </returns>
        /// <param name="key">The key to locate in the <see cref="T:System.Collections.Generic.IDictionary`2"/>.</param><exception cref="T:System.ArgumentNullException"><paramref name="key"/> is null.</exception>
        public virtual bool ContainsKey(string key)
        {
            return wrappedDictionary.ContainsKey(key);
        }

        /// <summary>
        /// Gets an <see cref="T:System.Collections.Generic.ICollection`1"/> containing the keys of the <see cref="T:System.Collections.Generic.IDictionary`2"/>.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.Generic.ICollection`1"/> containing the keys of the object that implements <see cref="T:System.Collections.Generic.IDictionary`2"/>.
        /// </returns>
        public virtual ICollection<string> Keys
        {
            get
            {
                return wrappedDictionary.Keys;
            }
        }

        /// <summary>
        /// Removes the element with the specified key from the <see cref="T:System.Collections.Generic.IDictionary`2"/>.
        /// </summary>
        /// <returns>
        /// true if the element is successfully removed; otherwise, false.  This method also returns false if <paramref name="key"/> was not found in the original <see cref="T:System.Collections.Generic.IDictionary`2"/>.
        /// </returns>
        /// <param name="key">The key of the element to remove.</param><exception cref="T:System.ArgumentNullException"><paramref name="key"/> is null.</exception><exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.IDictionary`2"/> is read-only.</exception>
        public virtual bool Remove(string key)
        {
            return wrappedDictionary.Remove(key);
        }

        /// <summary>
        /// Gets the value associated with the specified key.
        /// </summary>
        /// <returns>
        /// true if the object that implements <see cref="T:System.Collections.Generic.IDictionary`2"/> contains an element with the specified key; otherwise, false.
        /// </returns>
        /// <param name="key">The key whose value to get.</param><param name="value">When this method returns, the value associated with the specified key, if the key is found; otherwise, the default value for the type of the <paramref name="value"/> parameter. This parameter is passed uninitialized.</param><exception cref="T:System.ArgumentNullException"><paramref name="key"/> is null.</exception>
        public virtual bool TryGetValue(string key, out object value)
        {
            return wrappedDictionary.TryGetValue(key, out value);
        }

        /// <summary>
        /// Gets an <see cref="T:System.Collections.Generic.ICollection`1"/> containing the values in the <see cref="T:System.Collections.Generic.IDictionary`2"/>.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.Generic.ICollection`1"/> containing the values in the object that implements <see cref="T:System.Collections.Generic.IDictionary`2"/>.
        /// </returns>
        public virtual ICollection<object> Values
        {
            get
            {
                return wrappedDictionary.Values;
            }
        }

        /// <summary>
        /// Gets or sets the element with the specified key.
        /// </summary>
        /// <returns>
        /// The element with the specified key.
        /// </returns>
        /// <param name="key">The key of the element to get or set.</param><exception cref="T:System.ArgumentNullException"><paramref name="key"/> is null.</exception><exception cref="T:System.Collections.Generic.KeyNotFoundException">The property is retrieved and <paramref name="key"/> is not found.</exception><exception cref="T:System.NotSupportedException">The property is set and the <see cref="T:System.Collections.Generic.IDictionary`2"/> is read-only.</exception>
        public virtual object this[string key]
        {
            get
            {
                return wrappedDictionary[key];
            }
            set
            {
                if (value != null)
                    wrappedDictionary[key] = value;
            }
        }

        /// <summary>
        /// Adds an item to the <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <param name="item">The object to add to the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param><exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only.</exception>
        public virtual void Add(KeyValuePair<string, object> item)
        {
            if (item.Value != null)
                wrappedDictionary.Add(item);
        }

        /// <summary>
        /// Removes all items from the <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only. </exception>
        public virtual void Clear()
        {
            wrappedDictionary.Clear();
        }

        /// <summary>
        /// Determines whether the <see cref="T:System.Collections.Generic.ICollection`1"/> contains a specific value.
        /// </summary>
        /// <returns>
        /// true if <paramref name="item"/> is found in the <see cref="T:System.Collections.Generic.ICollection`1"/>; otherwise, false.
        /// </returns>
        /// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param>
        public virtual bool Contains(KeyValuePair<string, object> item)
        {
            return wrappedDictionary.Contains(item);
        }

        /// <summary>
        /// Copies the elements of the <see cref="T:System.Collections.Generic.ICollection`1"/> to an <see cref="T:System.Array"/>, starting at a particular <see cref="T:System.Array"/> index.
        /// </summary>
        /// <param name="array">The one-dimensional <see cref="T:System.Array"/> that is the destination of the elements copied from <see cref="T:System.Collections.Generic.ICollection`1"/>. The <see cref="T:System.Array"/> must have zero-based indexing.</param><param name="arrayIndex">The zero-based index in <paramref name="array"/> at which copying begins.</param><exception cref="T:System.ArgumentNullException"><paramref name="array"/> is null.</exception><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="arrayIndex"/> is less than 0.</exception><exception cref="T:System.ArgumentException">The number of elements in the source <see cref="T:System.Collections.Generic.ICollection`1"/> is greater than the available space from <paramref name="arrayIndex"/> to the end of the destination <paramref name="array"/>.</exception>
        public virtual void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
        {
            wrappedDictionary.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Gets the number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <returns>
        /// The number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </returns>
        public virtual int Count
        {
            get
            {
                return wrappedDictionary.Count;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only.
        /// </summary>
        /// <returns>
        /// true if the <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only; otherwise, false.
        /// </returns>
        public virtual bool IsReadOnly
        {
            get { return wrappedDictionary.IsReadOnly; }
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <returns>
        /// true if <paramref name="item"/> was successfully removed from the <see cref="T:System.Collections.Generic.ICollection`1"/>; otherwise, false. This method also returns false if <paramref name="item"/> is not found in the original <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </returns>
        /// <param name="item">The object to remove from the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param><exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only.</exception>
        public virtual bool Remove(KeyValuePair<string, object> item)
        {
            return wrappedDictionary.Remove(item);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public virtual IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            return wrappedDictionary.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;

namespace SixtenLabs.Spawn
{
	/// <summary>
	/// This will serialize objects and dynamic objects into 
	/// xml with a specific pattern for use with Spawn XSLT templates.
	/// </summary>
	public class SpawnXmlSerializer : IXmlSerializer
	{
		private const string DefaultElementName = "object";

		/// <summary>
		/// Gets the array element.
		/// </summary>
		/// <param name="input">The input object.</param>
		/// <param name="element">The element name.</param>
		/// <returns>Returns an XElement with the array collection as child elements.</returns>
		private XElement SerializeEnumerable(IEnumerable input, string element)
		{
			var rootElement = new XElement(element);
			var enumerator = input.GetEnumerator();

			while (enumerator.MoveNext())
			{
				var value = enumerator.Current;
				XElement childElement = null;

				if (value.GetType().IsSimpleOrNullableType())
				{
					childElement = new XElement(element + "Item", value);
				}
				else
				{
					if (value is KeyValuePair<string, object>)
					{
						var kvp = (KeyValuePair<string, object>)value;
						childElement = !string.IsNullOrEmpty(kvp.Key) ? new XElement(kvp.Key, kvp.Value) : null;
					}
					else
					{
						childElement = ToXElementInternal(value, element + "Item");
					}
				}

				rootElement.Add(childElement);
			}

			return rootElement;
		}

		private XElement ToXElementInternal(object input, string element)
		{
			if (input == null)
			{
				return null;
			}

			if (string.IsNullOrWhiteSpace(element))
			{
				element = DefaultElementName;
			}

			element = XmlConvert.EncodeName(element);

			var enumerable = input as IEnumerable;

			if (enumerable != null)
			{
				return SerializeEnumerable(enumerable, element);
			}

			var xElement = new XElement(element);

			var props = GetProperties(input);
			var elements = props
				.Where(x => x.Value != null)
				.Select(x => x.Value.GetType().IsSimpleOrNullableType()
								? new XElement(x.Key, x.GetType() == typeof(DateTime) ? ((DateTime)x.Value).ToString("yyyy-MM-dd HH:mm:ss.ffff") : x.Value)
								: ToXElementInternal(x.Value, x.Key));

			xElement.Add(elements);

			return xElement;
		}

		private static IEnumerable<KeyValuePair<string, object>> GetProperties(object input)
		{
			var type = input.GetType();

			if (input is KeyValuePair<string, object>)
			{
				var dict = new Dictionary<string, object>();
				var kvp = (KeyValuePair<string, object>)input;
				dict.Add(kvp.Key, kvp.Value);

				return dict;
			}
			else
			{
				var bindingFlags = BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.Public;

				return type.GetProperties(bindingFlags).ToDictionary(x => x.Name, x => x.GetValue(input, null));
			}
		}

		/// <summary>
		/// Converts an object of type <typeparam name="T" /> to an XElement.
		/// </summary>
		/// <param name="input">The input.</param>
		/// <param name="element">The element name.</param>
		/// <returns>Returns the object as it's XML representation in an XElement.</returns>
		public XElement ToXElement<T>(T input, string element)
			where T : class
		{
			return ToXElementInternal(input, element);
		}

		/// <summary>
		/// Generates an XML representation of an object of type <typeparam name="T" /> and returns a <see cref="Stream"/> containing the result.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="input">The input.</param>
		/// <param name="stream">The <see cref="Stream"/> used to write the XML document.</param>
		/// <param name="element">The root element name.</param>
		/// <returns>A <see cref="Stream"/> with the resulting XML.</returns>
		public void ToXml<T>(T input, Stream stream, string element)
			where T : class
		{
			if (input == null)
			{
				throw new ArgumentNullException("input");
			}

			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}

			var xmlElement = ToXElement(input, element);

			if (xmlElement != null)
			{
				xmlElement.Save(stream);
			}
		}
	}
}

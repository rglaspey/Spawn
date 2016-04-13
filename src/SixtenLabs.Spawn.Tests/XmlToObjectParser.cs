using SixtenLabs.Spawn.Utility;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace SixtenLabs.Spawn.Tests
{
	public class XmlToObjectParser
	{
		public static dynamic ParseFromXml(XElement rootXml)
		{
			var root = CreateElement(rootXml);

			return root;
		}

		private static dynamic CreateElement(XElement xmlNode)
		{
			if (xmlNode.Attributes().Count() == 0 && xmlNode.Elements().Count() == 0)
			{
				return null;
			}

			IDictionary<string, object> node = new FastExpando();

			GetAttributes(xmlNode, node);
			GetChildren(xmlNode, node);
						
			return node;
		}

		private static void GetAttributes(XElement xmlNode, IDictionary<string, object> node)
		{
			var attributes = xmlNode.Attributes().ToList();

			foreach (var attribute in xmlNode.Attributes())
			{
				node.Add(attribute.Name.LocalName, attribute.Value);

				if (!node.ContainsKey("NodeName"))
				{
					node.Add("NodeName", attribute.Parent.Name.LocalName);
				}
			}
		}
		
		private static void GetChildren(XElement xmlNode, IDictionary<string, object> node)
		{
			var childElements = xmlNode.Elements().ToList();

			foreach (var childElement in childElements)
			{
				var childNode = CreateElement(childElement);

				if (childNode != null)
				{
					string nodeName = childNode.NodeName;

					if (node.ContainsKey(nodeName) && node[nodeName].GetType() != typeof(List<dynamic>))
					{
						var firstValue = node[nodeName];
						node[nodeName] = new List<dynamic>();
						((dynamic)node[nodeName]).Add(firstValue);
						((dynamic)node[nodeName]).Add(childNode);
					}
					else if (node.ContainsKey(nodeName) && node[nodeName].GetType() == typeof(List<dynamic>))
					{
						((dynamic)node[nodeName]).Add(childNode);
					}
					else
					{
						node.Add(childElement.Name.LocalName, CreateElement(childElement));

						if (!node.ContainsKey("NodeName"))
						{
							node.Add("NodeName", xmlNode.Name.LocalName);
						}
					}
				}
				else
				{
					if (node.ContainsKey(childElement.Name.LocalName))
					{
						var firstValue = node[childElement.Name.LocalName];
						node[childElement.Name.LocalName] = new List<dynamic>();
						((List<dynamic>)node[childElement.Name.LocalName]).Add(firstValue);
						((List<dynamic>)node[childElement.Name.LocalName]).Add(childElement.Value);
					}
					else
					{
						node.Add(childElement.Name.LocalName, childElement.Value);
					}

					if (!node.ContainsKey("NodeName"))
					{
						node.Add("NodeName", xmlNode.Name.LocalName);
					}
				}
			}
		}
	}
}

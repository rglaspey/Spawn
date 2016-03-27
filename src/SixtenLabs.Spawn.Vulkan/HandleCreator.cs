using SixtenLabs.Spawn.Utility;
using SixtenLabs.Spawn.Vulkan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SixtenLabs.Spawn.Vulkan
{
	public class HandleCreator : BaseCreator
	{
		public HandleCreator(ICodeGenerator generator, IVulkanSpec vulkanSpec)
			: base(generator, vulkanSpec, 30, "Type", "Type")
		{
		}

		static bool TypeHandleFilter(XElement xtype)
		{
			var xcat = xtype.Attribute("category");

			return xcat != null && xcat.Value == "handle";
		}

		private VulkanHandle ReadHandle(XElement xtype)
		{
			if (xtype.Name != "type")
				throw new ArgumentException("Not a type element", nameof(xtype));

			var xcategory = xtype.Attribute("category");
			if (xcategory == null || xcategory.Value != "handle")
				throw new ArgumentException("Invalid category", nameof(xtype));

			var xelements = xtype.Elements();
			if (xelements.Count() == 0)
				throw new ArgumentException("Contains no elements", nameof(xtype));

			var vkHandle = new VulkanHandle();

			foreach (var xelm in xelements)
			{
				switch (xelm.Name.ToString())
				{
					case "type":
						vkHandle.HandleType = xelm.Value;
						break;
					case "name":
						vkHandle.Name = xelm.Value;
						break;
					default: throw new NotImplementedException(xelm.Name.ToString());
				}
			}

			var xattributes = xtype.Attributes();
			if (xattributes.Count() != 0)
			{
				foreach (var xattrib in xattributes)
				{
					switch (xattrib.Name.ToString())
					{
						case "parent":
							vkHandle.Parent = xattrib.Value;
							break;
						case "category": break;
						default: throw new NotImplementedException(xattrib.Name.ToString());
					}
				}
			}

			return vkHandle;
		}

		public override void MapTypes()
		{
			var xTypes = VulkanSpec.SpecTree.Element("types").Elements("type");

			var handles = xTypes
									 .Where(TypeHandleFilter)
									 .Select(ReadHandle);

			foreach (var handle in handles)
			{
				VulkanSpec.AllTypes.Add(handle.Name, handle);
			}
		}

		public override void Rewrite()
		{
			foreach (var vkHandle in VulkanSpec.Handles)
			{
				if (vkHandle.Name.StartsWith("Vk"))
				{
					vkHandle.Name = vkHandle.Name.Remove(0, 2); // trim `Vk`
				}
			}
		}

		public override void Build()
		{
		}

		public override void Create()
		{
		}
	}
}

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
	public class TypeCreator : BaseCreator
	{
		public TypeCreator(ICodeGenerator generator, IVulkanSpec rules)
			: base(generator, rules, 10, "Type", "Type")
		{
		}

		private bool TypePlatformFilter(XElement xtype)
		{
			var xreq = xtype.Attribute("requires");

			return xreq != null && xreq.Value == "vk_platform";
		}

		private VulkanStruct CreatePlatformStruct(string name)
		{
			var vkStruct = new VulkanStruct();

			vkStruct.Name = vkStruct.SpecName = name;

			return vkStruct;
		}

		/// <summary>
		/// These are mainly primitives like void, uint32_t, size_t, etc. 
		/// They are treated specially by the pipeline.
		/// </summary>
		public override void MapTypes()
		{
			var xTypes = VulkanSpec.SpecTree.Element("types").Elements("type");

			var plaformTypes = xTypes
										.Where(TypePlatformFilter)
										.Select(x => x.Attribute("name").Value)
										.ToList();

			var platformStructs = plaformTypes.Select(CreatePlatformStruct).ToList();

			foreach (var vkStruct in platformStructs)
			{
				VulkanSpec.AllTypes.Add(vkStruct.Name, vkStruct);
			}
		}

		public override void Rewrite()
		{
		}

		public override void Build()
		{
		}

		public override void Create()
		{
		}
	}
}

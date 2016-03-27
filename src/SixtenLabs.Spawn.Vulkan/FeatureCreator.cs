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
	//public class FeatureCreator : BaseCreator
	//{
	//	public FeatureCreator(ICodeGenerator generator, IVulkanSpec vulkanSpec)
	//		: base(generator, vulkanSpec, 60, "Feature", "Feature")
	//	{
	//	}

	//	private VulkanFeatureRequirement ReadRequirement(XElement xrequire)
	//	{
	//		if (xrequire.Name != "require")
	//			throw new ArgumentException("Not a requirement", nameof(xrequire));

	//		var xelements = xrequire.Elements();
	//		if (xelements.Count() == 0)
	//			throw new ArgumentException("Contains no elements", nameof(xrequire));

	//		var vkRequire = new VulkanFeatureRequirement();

	//		var xcomment = xrequire.Attribute("comment");
	//		if (xcomment != null)
	//			vkRequire.Comment = xcomment.Value;

	//		var types = new List<string>();
	//		var enums = new List<string>();
	//		var commands = new List<string>();
	//		foreach (var elm in xelements)
	//		{
	//			switch (elm.Name.ToString())
	//			{
	//				case "type":
	//					types.Add(elm.Attribute("name").Value);
	//					break;
	//				case "enum":
	//					enums.Add(elm.Attribute("name").Value);
	//					break;
	//				case "command":
	//					commands.Add(elm.Attribute("name").Value);
	//					break;
	//				default: throw new NotImplementedException(elm.Name.ToString());
	//			}
	//		}

	//		vkRequire.Types = types.ToArray();
	//		vkRequire.Enums = enums.ToArray();
	//		vkRequire.Commands = commands.ToArray();

	//		return vkRequire;
	//	}

	//	private VulkanFeature ReadFeature(XElement xfeature)
	//	{
	//		if (xfeature.Name != "feature")
	//			throw new ArgumentException("Not a feature", nameof(xfeature));

	//		var vkFeature = new VulkanFeature();

	//		var xattributes = xfeature.Attributes();
	//		if (xattributes.Count() != 0)
	//		{
	//			foreach (var xattrib in xattributes)
	//			{
	//				switch (xattrib.Name.ToString())
	//				{
	//					case "api":
	//						vkFeature.Api = xattrib.Value;
	//						break;
	//					case "name":
	//						vkFeature.Name = xattrib.Value;
	//						break;
	//					case "number":
	//						vkFeature.Number = xattrib.Value;
	//						break;
	//					default: throw new NotImplementedException(xattrib.Name.ToString());
	//				}
	//			}
	//		}

	//		vkFeature.Requirements = xfeature.Elements().Select(ReadRequirement).ToArray();

	//		return vkFeature;
	//	}

	//	public override void MapTypes()
	//	{
	//		var features = VulkanSpec.SpecTree.Elements("feature");
	//		VulkanSpec.Features = features.Select(ReadFeature).ToArray();
	//	}

	//	public override void Rewrite()
	//	{
			
	//	}

	//	public override void Build()
	//	{

	//	}

	//	public override void Create()
	//	{
	//	}
	//}
}

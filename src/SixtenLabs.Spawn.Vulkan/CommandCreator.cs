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
	public class CommandCreator : BaseCreator
	{
		public CommandCreator(ICodeGenerator generator, IVulkanSpec vulkanSpec)
			: base(generator, vulkanSpec, 50, "Command", "Command")
		{
		}

		private VulkanParam ReadParam(XElement xparam)
		{
			if (xparam.Name != "param")
				throw new ArgumentException("Not a parameter", nameof(xparam));

			var xelements = xparam.Elements();
			if (xelements.Count() == 0)
				throw new ArgumentException("Contains no elements", nameof(xparam));

			var vkParam = new VulkanParam();

			foreach (var xelm in xelements)
			{
				switch (xelm.Name.ToString())
				{
					case "type":
						vkParam.Type = VulkanSpec.GetOrAddType(xelm.Value);
						break;
					case "name":
						vkParam.Name = xelm.Value;
						break;
					default: throw new NotImplementedException(xelm.Name.ToString());
				}
			}

			if (string.IsNullOrEmpty(vkParam.Name) || vkParam.Type == null)
				throw new InvalidOperationException("Param does not have proper `<name>` or `<type>` element");

			// Gah! Why are these not encoded properly!
			var paramStr = xparam.Value;
			vkParam.PointerRank = paramStr.Count(x => x == '*');
			vkParam.IsConst = paramStr.Contains("const");

			// read parameter attributes
			var xattributes = xparam.Attributes();
			if (xattributes.Count() != 0)
			{
				foreach (var xattrib in xattributes)
				{
					switch (xattrib.Name.ToString())
					{
						case "optional":
							vkParam.Optional = xattrib.Value.Split(',');
							break;
						case "len":
							vkParam.Len = xattrib.Value;
							break;
						case "externsync":
							vkParam.ExternSync = xattrib.Value == "true";
							break;
						case "noautovalidity":
							vkParam.NoAutoValidity = xattrib.Value == "true";
							break;
						default: throw new NotImplementedException(xattrib.Name.ToString());
					}
				}
			}

			return vkParam;
		}

		private VulkanCommand ReadCommand(XElement xcommand)
		{
			if (xcommand.Name != "command")
				throw new ArgumentException("Not a command", nameof(xcommand));

			var xproto = xcommand.Element("proto");
			if (xproto == null)
				throw new ArgumentException("No prototype", nameof(xcommand));

			var vkCommand = new VulkanCommand();
			vkCommand.Name = vkCommand.SpecName = xproto.Element("name").Value;
			vkCommand.ReturnType = VulkanSpec.GetOrAddType(xproto.Element("type").Value);
			vkCommand.ErrorCodes = new string[0];
			vkCommand.SuccessCodes = new string[0];
			vkCommand.Queues = new string[0];

			// todo: return is const
			// todo: return is pointer
			var xprotoStr = xproto.Value;
			if (xprotoStr.Contains("*") || xprotoStr.Contains("const"))
				throw new NotImplementedException();

			var xparams = xcommand.Elements("param");
			vkCommand.Parameters = xparams.Select(ReadParam).ToArray();

			var elements = xcommand.Elements();
			if (elements.Count() == 0)
				throw new ArgumentException("Contains no elements", nameof(xcommand));

			foreach (var xelm in elements)
			{
				switch (xelm.Name.ToString())
				{
					case "proto":
					case "param":
						break;
					case "validity":
						vkCommand.Validity = xelm.Elements().Select(x => x.Value).ToArray();
						break;
					case "implicitexternsyncparams":
						vkCommand.ImplicitExternSyncParams = xelm.Elements().Select(x => x.Value).ToArray();
						break;
					default: throw new NotImplementedException(xelm.Name.ToString());
				}
			}

			// note: queues / renderpass / cmdbufferlevel - If one is present all three must be

			// read command attributes
			var xattributes = xcommand.Attributes();
			if (xattributes.Count() != 0)
			{
				foreach (var xattrib in xattributes)
				{
					switch (xattrib.Name.ToString())
					{
						case "successcodes":
							vkCommand.SuccessCodes = xattrib.Value.Split(',');
							break;
						case "errorcodes":
							vkCommand.ErrorCodes = xattrib.Value.Split(',');
							break;
						case "queues":
							vkCommand.Queues = xattrib.Value.Split(',');
							break;
						case "renderpass":
							vkCommand.RenderPass = xattrib.Value;
							break;
						case "cmdbufferlevel":
							vkCommand.CmdBufferLevel = xattrib.Value.Split(',');
							break;
						default: throw new NotImplementedException(xattrib.Name.ToString());
					}
				}
			}

			return vkCommand;
		}

		public override void MapTypes()
		{
			var commandsRoot = VulkanSpec.SpecTree.Element("commands");
			var commands = commandsRoot.Elements("command");
			VulkanSpec.Commands = commands.Select(ReadCommand).ToArray();
		}

		public override void Rewrite()
		{
			foreach(var vkCommand in VulkanSpec.Commands)
			{
				if (vkCommand.Name.StartsWith("vk"))
					vkCommand.Name = vkCommand.Name.Remove(0, 2); // trim `Vk`

				for (var x = 0; x < vkCommand.Parameters.Length; x++)
				{
					var param = vkCommand.Parameters[x];
					var paramName = param.Name;

					if (paramName == "event" || paramName == "object")
						paramName = '@' + paramName; // alias names

					if (param.PointerRank != 0)
						paramName = paramName.TrimStart(new[] { 'p' });

					param.Name = paramName;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixtenLabs.Spawn.Vulkan.Model
{
	//public class VulkanCommand
	//{
	//	public string Name;

	//	public VulkanType ReturnType;

	//	public int ReturnPointerRank;

	//	public VulkanParam[] Parameters;

	//	public string[] SuccessCodes;

	//	public string[] ErrorCodes;

	//	public string RenderPass;       // possibly only for queue functions?

	//	public string[] Queues;         //

	//	public string[] CmdBufferLevel; //

	//	public string[] Validity;

	//	public string[] ImplicitExternSyncParams;

	//	public string SpecName { get; set; }

	//	public string ToDeclaration()
	//	{
	//		StringBuilder sb = new StringBuilder();
	//		sb.Append(ReturnType);
	//		sb.Append(new string('*', ReturnPointerRank));
	//		sb.Append(" ");
	//		sb.Append(SpecName);
	//		sb.Append("(");

	//		for (int x = 0; x < Parameters.Length; x++)
	//		{
	//			sb.Append(Parameters[x]);
	//			if (x + 1 < Parameters.Length)
	//				sb.Append(", ");
	//		}

	//		sb.Append(")");

	//		return sb.ToString();
	//	}

	//	public override string ToString() => $"{ReturnType} {Name}(...)";
	//}
}

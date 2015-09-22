using System;
using System.Collections.Generic;

namespace wMetroGIS.wCurve
{
	public class CurveRelation
	{
		public TreeNodeCurve m_RootNode = new TreeNodeCurve();

		public bool CreateRelationship(System.Collections.Generic.List<Curve> curveList)
		{
			this.m_RootNode = new TreeNodeCurve();
			bool result;
			if (curveList == null || curveList.Count == 0)
			{
				result = false;
			}
			else
			{
				int id = 1;
				foreach (Curve newCurve in curveList)
				{
					if (!newCurve.IsClosed)
					{
						newCurve.CurveRelationTreeNode = null;
					}
					else
					{
						TreeNodeCurve newNode = new TreeNodeCurve();
						newNode.MyNodeID = id++;
						newNode.MyCurve = newCurve;
						newNode.Text = string.Format("ID={0:000}  Value={1:0.0}", newNode.MyNodeID, newNode.MyCurve.CurveValue);
						newCurve.CurveRelationTreeNode = newNode;
						if (newNode.MyNodeID == 42)
						{
						}
						this.AddNodeToTree(this.m_RootNode, newNode);
					}
				}
				result = true;
			}
			return result;
		}

		private void AddNodeToTree(TreeNodeCurve thisNode, TreeNodeCurve newNode)
		{
			if (thisNode.MyCurve != null && newNode.MyCurve.CurveInMe(thisNode.MyCurve))
			{
				TreeNodeCurve parentNode = (TreeNodeCurve)thisNode.Parent;
				if (parentNode != null)
				{
					parentNode.Nodes.Remove(thisNode);
					parentNode.Nodes.Add(newNode);
				}
				newNode.Nodes.Add(thisNode);
			}
			else
			{
				for (int i = 0; i < thisNode.Nodes.Count; i++)
				{
					TreeNodeCurve childNode = (TreeNodeCurve)thisNode.Nodes[i];
					if (newNode.MyCurve.CurveInMe(childNode.MyCurve))
					{
						thisNode.Nodes.Remove(childNode);
						this.AddNodeToTree(newNode, childNode);
						i--;
					}
				}
				for (int i = 0; i < thisNode.Nodes.Count; i++)
				{
					TreeNodeCurve childNode = (TreeNodeCurve)thisNode.Nodes[i];
					if (childNode.MyCurve.CurveInMe(newNode.MyCurve))
					{
						this.AddNodeToTree(childNode, newNode);
						return;
					}
				}
				thisNode.Nodes.Add(newNode);
			}
		}
	}
}

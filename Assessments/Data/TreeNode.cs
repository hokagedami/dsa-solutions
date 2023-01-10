using System.Collections;

namespace Assessments.Data;

public class TreeNode
{
    public int Val;
    public TreeNode Left;
    public TreeNode Right;
    public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
    this.Val = val;
    this.Left = left;
    this.Right = right;
    }
}

public static class LevelOrder{
    public static List<IList<int>> Solution(TreeNode root)
    {
        var result = new List<IList<int>>();
        RecursiveSolution(root, result, 0);
        return result;

        void RecursiveSolution(TreeNode currentRoot, IList<IList<int>> currentResult, int depth)
        {
            while (true)
            {
                if (currentRoot == null) return;
                if (currentResult.Count < depth + 1) currentResult.Add(new List<int>());
                currentResult[depth].Add(currentRoot.Val);

                RecursiveSolution(currentRoot.Left, currentResult, depth + 1);
                currentRoot = currentRoot.Right;
                depth += 1;
            }
        }
    }
}
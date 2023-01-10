namespace Assessments.Data;

public class Node
{
    public int Val;
    public IList<Node> Children;

    public Node() {}

    public Node(int val) {
        Val = val;
    }

    public Node(int val,IList<Node> children) {
        Val = val;
        Children = children;
    }
}

public static class Preorder{
    public static IList<int> SolutionOne(Node root)
    {
        
        var result = new List<int>();
        if (root == null) return result;
        result.Add(root.Val);
        if (root.Children == null) return result;
        foreach (var child in root.Children)
        {
            result.AddRange(SolutionOne(child));
        }
        return result;
    }
    
    public static IList<int> SolutionTwo(Node root)
    {
        var result = new List<int>();
        if (root == null) return result;
        var stack = new Stack<Node>();
        stack.Push(root);
        while (stack.Any())
        {
            var current = stack.Pop();
            result.Add(current.Val);
            for (var i = current.Children.Count - 1; i >= 0; i--)
            {
                stack.Push(current.Children[i]);
            }
            
        }
        return result;
    }

    public static IList<int> SolutionThree(Node root)
    {
        var result = new List<int>();
        Preorder(root);
        return result;
        void Preorder(Node node)
        {
            if(root == null) return;
            result.Add(node.Val);
            foreach (var child in node.Children)
            {
                Preorder(child);
            }
        }
    }
}
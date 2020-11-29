import java.util.ArrayList;
public class SalesPath {
    static class Node{
        int cost;
        Node[] children;
        Node parent;

        Node(int cost){
            this.cost = cost;
            children = null;
            parent = null;
        }
    }

    static class Sales{
        boolean isLeaf(Node node){
            return node.children == null;
        }
        
        ArrayList<Integer> costs = new ArrayList<Integer>();

        int pathCost(Node node, int currentCost){
            if(isLeaf(node))
                costs.add(currentCost);
            else{
                for (Node child : node.children) {
                    pathCost(child, currentCost + child.cost);
                }
            }
            return currentCost;
        }

        int getCheapestCost(Node rootNode){
            int cost = 0;
            pathCost(rootNode, cost);
            int minCost = Integer.MAX_VALUE;
            for (int element : costs) {
                if(element<minCost){
                    minCost = element;
                }
            }
            return minCost;
        } 
    }

    public static void main(String[] args){
        Node rootNode = new Node(0);
        Node nodeA = new Node(5);
        nodeA.parent=rootNode;
        Node nodeB = new Node(3);
        nodeB.parent = rootNode;
        Node nodeC = new Node(6);
        nodeC.parent = rootNode;
        rootNode.children = new Node[] {nodeA, nodeB, nodeC};
        Node nodeD = new Node(4);
        nodeD.parent = nodeA;
        nodeA.children = new Node[] {nodeD};
        Node nodeE = new Node(2);
        nodeE.parent = nodeB;
        Node nodeF = new Node(0);
        nodeF.parent = nodeB;
        nodeB.children = new Node[] {nodeE, nodeF};
        Node nodeG = new Node(1);
        nodeG.parent = nodeC;
        Node nodeH = new Node(5);
        nodeH.parent = nodeC;
        nodeC.children = new Node[]{nodeG, nodeH};
        Node nodeI = new Node(1);
        nodeI.parent = nodeE;
        nodeE.children = new Node[]{nodeI};
        Node nodeJ = new Node(10);
        nodeJ.parent = nodeF;
        nodeF.children = new Node[]{nodeJ};
        Node nodeK = new Node(1);
        nodeK.parent = nodeI;
        nodeI.children = new Node[]{nodeK};

        Sales sales = new Sales();
        System.out.println("cost: " + sales.getCheapestCost(rootNode));

    }
}

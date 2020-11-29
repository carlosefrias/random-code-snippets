public class BtsSuccessorSearch {
/*
    In a Binary Search Tree (BST), an Inorder Successor of a node
    is defined as the node with the smallest key greater than the key
    of the input node (see examples below). Given a node 
    inputNode in a BST, you're asked to write a function
    findInOrderSuccessor that returns the Inorder Successor of 
    InputNode. If inputNode has no Successor, return null.

    Explain your solution and analyse its time space complexities.

                                20
                            /       \
                            9        25
                        /       \
                        5       12
                            /       \
                            11      14
            In this diagram, the inorder successor of 9 is 11 and
            the inorder successor of 14 is 20
    Example:
    In the diagram above, for inputNode whose key = 11
    Your function would return:
    The Inorder Successor node whose key = 12
*/

    static class Node{
        int key;
        Node left;
        Node right;
        Node parent;

        Node(int key){
            this.key = key;
            left = null;
            right = null;
            parent = null;
        }
    }

    static class BinarySearchTree{
        Node root;
  
        /* Given a non-empty binary search  
        tree, return the minimum data   
        value found in that tree. Note that  
        the entire tree does not need 
        to be searched. */
        Node minValue(Node node) 
        { 
            Node current = node; 
    
            /* loop down to find the leftmost leaf */
            while (current.left != null) { 
                current = current.left; 
            } 
            return current; 
        } 
        
        Node findInOrderSuccessor(Node inputNode){
            // step 1 of the above algorithm 
            if (inputNode.right != null) { 
                return minValue(inputNode.right); 
            } 
    
            // step 2 of the above algorithm 
            Node currentNode = inputNode.parent; 
            while (currentNode != null && inputNode == currentNode.right) { 
                inputNode = currentNode; 
                currentNode = currentNode.parent; 
            } 
            return currentNode; 
        }

        void insert(int key){
            //1. if the tree is empty, create the root
            if(this.root == null){
                this.root = new Node(key);
                return;
            }
            //2. Otherwise, create a node with the key 
            //and traverse down the tree to find where to 
            //insert the new node
            Node currentNode = this.root;
            Node newNode = new Node(key);
            while(currentNode != null){
                if(key < currentNode.key){
                    if(currentNode.left == null){
                        currentNode.left = newNode;
                        newNode.parent = currentNode;
                        break;
                    }else{
                        currentNode = currentNode.left;
                    }
                }else{
                    if(currentNode.right == null){
                        currentNode.right = newNode;
                        newNode.parent = currentNode;
                        break;
                    }else{
                        currentNode = currentNode.right;
                    }
                }
            }
        }
        Node getNodeByKey(int key){
            Node currentNode = this.root;
            while(currentNode != null){
                if(key == currentNode.key){
                    return currentNode;
                }
                if(key < currentNode.key){
                    currentNode = currentNode.left;
                }else{
                    currentNode = currentNode.right;
                }
            }
            return null;
        }
        public static void main(String[] args){
            Node test = null, succ = null;
            BinarySearchTree tree = new BinarySearchTree();
            tree.insert(20);
            tree.insert(9);
            tree.insert(25);
            tree.insert(5);
            tree.insert(12);
            tree.insert(11);
            tree.insert(14);

            test = tree.getNodeByKey(14);
            succ = tree.findInOrderSuccessor(test);
            if(succ != null){
                System.out.println("InOrder successor is: " + succ.key);
            }else{
                System.out.println("There is no InOrder successor");
            }
        }
    }
    


}

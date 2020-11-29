import java.util.Arrays;

public class KMessedArraySort {

/*
Given an array of integers arr where each element is at most k
places away from its sorted position, code an efficient function
sortKMessedArray thar sorts arr. For instance, for an input
array of size 10 and k=2, an element belonging to index 6
in the sorted array will be located at either index 4, 5, 6, 7
or 8 in the input array.

Analyse the time and space complexities of your solution.
 */

    static int[] sortKMessedArray(int[] arr, int k){
        for(int start = 0; start < arr.length; start++){
            int min = arr[start];
            for(int i = start + 1; i < Math.min(arr.length, start + 2 * k); i++){
                if(arr[i] < min){
                    int temp = arr[i];
                    arr[i] = min;
                    arr[start] = temp;
                    min = temp;
                }
            }
        }
        return arr;
    }
    public static void main(String[] args){
        int[] arr = new int[]{1,4,5,2,3,7,8,6,10,9};
        int k=2;
        sortKMessedArray(arr, k);
        System.out.println(Arrays.toString(arr));
    }
}

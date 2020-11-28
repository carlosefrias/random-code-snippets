import java.util.Arrays;

public class Pancake {
    /*
    1)
        write a function flip(arr, k) that reverses the order of the first k elements in the array arr
    */
    
    public static void flip(int[] arr, int k){
        if(k >= 0 && k <= arr.length){
            for(int i=0; i<k; i++){
                int temp = arr[i];
                arr[i] = arr[k-1];
                arr[k-1] = temp;
                k--;
            }
        }
    }

    /*
    2)
    Write a function pancakeSort(arr) that sorts and returns the sorted array.
    You are allowed to use only the previous flip function
    */
    public static int[] pancakeSort(int[] arr){
        if(arr!= null && arr.length>=2){
            for(int j=0; j<arr.length; j++){
                int max = arr[0];
                int max_idx = 0;
                for(int i=1; i<arr.length-j; i++){
                    if(arr[i]>max){
                        max =arr[i];
                        max_idx = i;
                    }
                }
                flip(arr, max_idx+1);
                flip(arr, arr.length-j);
            }
        }
        return arr;
    }
    public static void main(String[] args){
        int[] arr = new int[]{6,7,3,9,11,2,5,8};
        flip(arr, 6);
        int[] sorted = pancakeSort(arr);
        System.out.println(Arrays.toString(sorted));
    }
}

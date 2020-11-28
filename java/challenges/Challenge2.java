import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;

public class Challenge2 {
    public static void main(String[] args){
        int[] arr = new int[] {5,6,3,1,9,10,0};
        int n = nthSmallest(arr, 5);
        System.out.println(n);
    }


    public static int nthSmallest(int[] arr, int n){
        int val=arr[0];
        ArrayList<Integer> smaller = new ArrayList<Integer>();
        ArrayList<Integer> bigger = new ArrayList<Integer>();

        for(int i=1; i<arr.length; i++){
            int element=arr[i];
            if(element > val){
                bigger.add(element);
            }
            else {
                smaller.add(element);
            }
        }
        smaller.add(val);
        smaller.addAll(bigger);
        int[] newArray = new int[arr.length];
        for(int i=0; i<arr.length;++i){
            newArray[i]=smaller.get(i);
        }
        System.out.println(Arrays.toString(newArray));
        Collections.sort(smaller);
        System.out.println(smaller);
        return 0;
    }
}

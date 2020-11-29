import java.util.Arrays;

public class QuatroSum {
    
    static int[] quatriSum(int[] arr, int val){
        if(arr == null || arr.length < 4) 
            return new int[]{};
        
            Arrays.sort(arr);
        
        for(int i=0; i<arr.length; i++){
            for(int j = i+1; j < arr.length; j++){
                int k = 0;
                int l = arr.length-1;
                int partialSum = arr[i]+arr[j];
                while(k < l){
                    int sum = partialSum + arr[k] + arr[l];
                    if(sum == val){
                        return new int[]{arr[i],arr[j],arr[k],arr[l]};
                    }
                    else if(sum > val){
                        l--;
                    }
                    else{
                        k++;
                    }
                }
            }
        }
        return new int[]{};
    }
    
    
    public static void main(String[] args){
        int[] arr = new int[]{5,7,8,6,1,2,3,4};
        System.out.println(Arrays.toString(quatriSum(arr, 15)));
    }
}

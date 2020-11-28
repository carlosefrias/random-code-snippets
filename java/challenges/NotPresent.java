public class NotPresent {
    
    private static boolean contains(int[] arr, int val){
        for (int element : arr) {
            if(element == val) return true;
        }
        return false;
    }
    
    private static int getMinNonPresent(int[] arr){
        for(int i=0; i < Integer.MAX_VALUE; i++){
            if(!contains(arr, i))
                return i;
        }
        return Integer.MAX_VALUE;
    }

    public static void main(String[] args){
        System.out.println(getMinNonPresent(new int[]{3,5,6,1,2,4,0}));
    }   
}

/*
Write a function that takes two strings as arguments, s and p and returns a boolean
denoting whether s matches p

p is a sequence of any number of the following:
    1. a-z - which stands for itself
    2. . - which matches any character
    3. * - which matches 0 or more occurrences of the previous single character

    s = "aba", p = "ab" => false
    s = "aa", p = "a*" => true
    s = "ab", p = ".*" => true
    s = "ab", p = "." => false
    s = "aab", p = "c*a*b" => true
    s = "aaa", p = "a*" => true
*/

function is_a_match(s, p){
    let idxP = 0
    for(i = 0; i < s.length; i++){
        if(p[idxP] === '.'){
            continue;
        }
        if(s[i] != p[idxP]){
            return false
        }
        idxP++
    }
    return true
}

console.log(is_a_match("aba", "ab"))
console.log(is_a_match("aa", "a*"))
console.log(is_a_match("ab", ".*"))
console.log(is_a_match("ab", "."))
console.log(is_a_match("aaa", "c*a*b"))
console.log(is_a_match("aaa", "a*"))
#include <iostream>

std::string revert(std::string word){
    std::string result = "";
    for(unsigned int i = 0; i < word.size(); i++){
        char c = word[word.size() - i - 1];
        result += c;
    }
    return result;
}

int main (){
    std::cout << revert("hello world!") << std::endl;
    return 0;
}
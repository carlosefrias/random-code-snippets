#include<iostream>
#include<vector>
#include<algorithm>

using namespace std;


int main() {
    vector<int> v{10,3,5,2,5,6,7};

    sort(begin(v), end(v));
    cout << v[0] << endl;
    if (__cplusplus == 201703L) std::cout << "C++17\n";
    else if (__cplusplus == 201402L) std::cout << "C++14\n";
    else if (__cplusplus == 201103L) std::cout << "C++11\n";
    else if (__cplusplus == 199711L) std::cout << "C++98\n";
    else std::cout << "pre-standard C++\n";

    return 0;
}
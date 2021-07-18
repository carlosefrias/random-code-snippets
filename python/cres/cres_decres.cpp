#include<iostream>
#include<algorithm>
#include<vector>

vector<int> combinations(int n, int p)
{
	std::vector<bool> v(10);
	std::fill(v.begin(), v.begin() + 6, true);
	vector<int> lista;
	do {
		for (int i = 0; i < 10; ++i) {
		   if (v[i]) {
			   std::cout << i << " ";
		   }
		}
	std::cout << "\n";
	} while (std::prev_permutation(v.begin(), v.end()));
}

int main()
{
	auto numbers = {0,1,2,3,4,5,6,7,8,9};
	return 0;
}

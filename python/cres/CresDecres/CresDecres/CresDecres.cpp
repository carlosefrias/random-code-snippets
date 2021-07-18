#include<iostream>
#include<algorithm>
#include<vector>

std::vector<std::vector<int>> combinations(int n, int p)
{
	std::vector<bool> v(n);
	std::fill(v.begin(), v.begin() + p, true);
	std::vector<std::vector<int>> lista;
	do 
	{
		std::vector<int> val;
		for (auto i = 0; i < n; ++i) 
		{
			if (v[i]) 
			{
				val.push_back(i);
			}
		}
		lista.push_back(val);
	} while (std::prev_permutation(v.begin(), v.end()));
	return lista;
}

int calc_number_cres(std::vector<int> vect)
{
	auto val = 0;
	for (auto i = vect.begin(); i != vect.end(); ++i)
	{
		if (i > vect.begin()) 
		{
			val *= 10;
			val += *i;
		}
		else
		{
			val += *i;
		}
	}
	return val;
}

int calc_number_decres(std::vector<int> vect)
{
	auto first = true;
	auto val = 0;
	for (auto i = vect.rbegin(); i != vect.rend(); ++i)
	{
		if (!first)
		{
			val *= 10;
			val += *i;
		}
		else
		{
			val += *i;
			first = false;
		}
	}
	return val;
}

int main()
{
	std::vector<int> listaC, listaD;
	std::vector<std::vector<int>> combin = combinations(10, 6);
	for (std::vector<int> elemn : combin)
	{
		if(elemn.front() > 0)
		{
			listaC.push_back(calc_number_cres(elemn));
		}
		listaD.push_back(calc_number_decres(elemn));
	}

	std::cout << "ordem crescente: " << listaC.size() << std::endl;
	std::cout << "ordem decrescente: " << listaD.size() << std::endl;
	std::cout << "total: " << listaC.size() + listaD.size() << std::endl;
	return 0;
}

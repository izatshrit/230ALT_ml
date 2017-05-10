#include "Header.h"
#include <string>
#include <fstream>
#include <iostream>

using namespace std;

//DO NOT CHANGE ANY SPACES IN THE TEXT, THEY ARE FIXED!!!.

string A[12];

void SplitOnSpace(const char* ptr)
{
	int i = 0;
	A[0] = A[1] = A[2] = A[3] = A[4] = A[5] = A[6] = A[7] = A[8] = A[9] = A[10] = A[11] = "";
	while (*ptr)
	{
		if (*ptr == ' ') i++;
		else A[i] += *ptr;
	//	cout << *ptr;
		ptr++;
	}
}

myGen void generator() {
	string str[256];
	ifstream inf;
	ofstream outf;
	inf.open("finalSorted.txt");
	outf.open("code.txt");

	int numberOfLines = 0;
	char ch;

	while (inf) {
		inf >> noskipws >> ch;
		if (ch == '\n')
			numberOfLines++;
		else
			str[numberOfLines] += ch;
	}
	inf.close();
	
	string prevIdentifer = "-1";
	string prevPermission = "C";
	for (int i = 0; i <= numberOfLines-3; i++) {
		
		SplitOnSpace(&str[i][0]);
		if (prevIdentifer != A[0]) {
			prevPermission = "C";
			if (prevIdentifer != "-1") {
				outf << "};\n";
			}
			outf << "class " << A[1] <<" \n{\n";
		}
		if (prevPermission != A[2]) {
			string s;
			if (A[2] == "#")s = "protected: \n";
			else if (A[2] == "+")s = "public: \n";
			else s = "private: \n";
			outf << s;
		}
		outf << "    ";
		if (A[8] == "True") outf << "static ";
		if (A[7] == "True") outf << "const ";	
		
		if (A[3][1] == 'f') {
			if (A[10] == "True") outf << "virtual ";
			string st = ""; 
			for (int k = 0; k < 4; k++) st += A[11][k]; 
			if (st == "True") outf << "friend "; 
			
			string s = "";
			for (int k = 0; k < A[5].length(); k++) { // change ; to WS 
				if (A[5][k] == ';') s += ' ';
				else s += A[5][k];
			}
			if (A[6] != "constructor")
				outf << A[6] << " ";
			outf << s << ";\n";
			
		}
		else { // attribute
			if (A[6] == "char") {
				if (A[9] == "")

					outf << A[6] << " " << A[5] << ";\n";
				else
					outf << A[6] << " " << A[5] << " = '" << A[9] << "';\n"; // set ''

			}
			else if (A[6] == "string") {
				if (A[9] == "")
					outf << A[6] << " " << A[5] << ";\n";
				else
					outf << A[6] << " " << A[5] << " = \"" << A[9] << "\";\n"; // set ""
			}
			else
			{
				if (A[9] != "constructor")
					outf << A[6] << " ";
				if (A[9] == "")
					outf << A[5] << ";\n";
				else
					outf << A[5] << " = " << A[9] << ";\n";
			}
		}
		prevPermission = A[2];
		prevIdentifer = A[0];
	}
	outf << "};";
	outf.close();
}

int main() {
	generator();
	int i;
	cin >> i;
	return 0;
}
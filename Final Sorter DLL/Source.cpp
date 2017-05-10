#include "Header.h"
#include <string>
#include <fstream>
#include <iostream>

using namespace std;



myIndexer void filter(const char * ptr)
{
	
	string str[256];
	ifstream inf;
	ofstream outf;
	inf.open("textSorted.txt");
	outf.open("finalSorted.txt", ofstream::out);

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

	string prev = "";
	string prevLine = "";
	//go 4 white spaces then take the 0a

	for (int i = 0; i < numberOfLines - 2; i++) // get the final edit which has the higher edit number
	{
		string st = str[i];
		int NoWS = 0;
		int k = 0;
		while (NoWS != 3) {
			if (st[k] == 32) NoWS++;
			k++; // is on 0a		
		}

		string IFname = "";
		IFname += st[0];
		IFname += st[k];
		IFname += st[k + 1];

		//check
		if (prev == "") { // first line case - works only once			
			prev = IFname;
			prevLine = str[i];
		}
		else {
			if (prev != IFname) {
				//write prevline to text
				outf << prevLine << '\n';
			}
		}
		prev = IFname;
		prevLine = str[i];
	}
	outf << str[numberOfLines - 3] << "\n";
	outf.close();

	////////////////////////
	inf.open("finalSorted.txt"); // sort again depending on the permission
	numberOfLines = 0;
	string str2[256]; // lines goes here
	while (inf) { // read from text and assign them to the string array- line assigned
		inf >> noskipws >> ch;
		if (ch == '\n') {
			cout << str2[numberOfLines] << endl;
			numberOfLines++;
		}
		else {
			str2[numberOfLines] += ch;
		}
	}

	for (int i = 0; i < numberOfLines - 1 - 1; i++) { //sort depending on the calss identifier + permission type
		for (int k = 0; k < numberOfLines - i - 1 - 1; k++) {

			string st = str2[k];
			int NoWS = 0;
			int l = 0;
			string toCompare = ""; // first permission

			toCompare += st[0]; // add class identifier
			while (NoWS != 2) { // find permission
				if (st[l] == 32) NoWS++;
				l++;
			}
			toCompare += st[l]; // add permission

			string st2 = str2[k + 1]; // same thing for the next line
			NoWS = 0;
			l = 0;
			string nextCompare = "";

			nextCompare += st2[0];
			while (NoWS != 2) {
				if (st2[l] == 32) NoWS++;
				l++;
			}
			nextCompare += st2[l];

			if (strcmp(&toCompare[0], &nextCompare[0]) > 0) { // compare Idetifier+permission each line with the next one
				string swap = str2[k]; // swap...
				str2[k] = str2[k + 1];
				str2[k + 1] = swap;
				cout << str2[k] << endl; // debug
				cout << str[k + 1] << endl; // debug

			}
		}
	} 
	outf.open("finalSorted.txt");  // write result into the same text
	for (int i = 0; i < numberOfLines; i++) {
		
		int NoWS = 0, l = 0; // check if defualt value = Alt230ML to delete
		char *st = &str2[i][0];
		while (NoWS != 9) { // find permission
			if (st[l] == 32) NoWS++;
			l++;
		}
		string s = "";
		for (int n = l; n < l + 8; n++) s += st[n]; // get Alt230ML
		cout << s << endl;
		if(s!="Alt230ML") // if delete detected dont write the line
			outf << str2[i] << endl;
	}	
	outf.close();
}

int main() {
	filter();
	int i;
	cin >> i;
	return 0;
}
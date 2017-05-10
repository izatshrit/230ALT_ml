
#pragma once

using namespace std;
#define myIndexer __declspec(dllexport)

extern "C" {
	myIndexer void filter(const char* ptr);
}

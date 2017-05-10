#pragma once

using namespace std;
#define myGen __declspec(dllexport)

extern "C" {
	myGen void generator();
}
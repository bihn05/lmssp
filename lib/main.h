#pragma once

__declspec(dllexport) void ProcessGlyphSort();
__declspec(dllexport) void resetHead();
__declspec(dllexport) void readHead();
__declspec(dllexport) void resetGlyphTable();
__declspec(dllexport) void readGlyphTable();
__declspec(dllexport) void resetData();
__declspec(dllexport) void readData();
__declspec(dllexport) void readFile(const char* filename);
__declspec(dllexport) void saveFile();
__declspec(dllexport) void closeFile();
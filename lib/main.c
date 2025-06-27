#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <malloc.h>
#include "dtbs.h"
#include "main.h"

Glyph glyphBuffer;
FileHeadChunk fileHeadChunk;
GlyphTableChunk glyphTableChunk;
DataChunk dataChunk;
FILE* fp;
Gte* gteBuffer;
Gte tableEntry;
PT* ptBuffer;
PT ptEntry;
int filesize = 0;
#define mstrHead 0x00444846
#define mstrGlyphTable 0x00425447
#define mstrData 0x00544144
int CompareByIndex(const void* a, const void* b)
{
	const Gte* gteA = (const Gte*)a;
	const Gte* gteB = (const Gte*)b;
	return (gteA->Index - gteB->Index);
}
__declspec(dllexport) void ProcessGlyphSort() {
	qsort(gteBuffer, glyphTableChunk.Length / 16, 16, CompareByIndex);
}
__declspec(dllexport) void resetHead()
{
	memset((char*)&fileHeadChunk, 0, sizeof(fileHeadChunk));
	fileHeadChunk.ChunkID = mstrHead;
	fileHeadChunk.Version = 1;
	fileHeadChunk.Length = 56;
	strcpy(fileHeadChunk.FontName, "Untitled");
}
__declspec(dllexport) void readHead()
{
	memset((char*)&fileHeadChunk, 0, sizeof(fileHeadChunk));
	fileHeadChunk.ChunkID = mstrHead;
	fread((char*)&fileHeadChunk + 4, 4, 1, fp);
	fread((char*)&fileHeadChunk + 8, fileHeadChunk.Length, 1, fp);
}
__declspec(dllexport) void resetGlyphTable()
{
	memset((char*)&glyphTableChunk, 0, 8);
	glyphTableChunk.ChunkID = mstrGlyphTable;
	glyphTableChunk.Length = 0;
	free(gteBuffer);
}
__declspec(dllexport) void readGlyphTable()
{
	memset((char*)&glyphTableChunk, 0, 8);
	fileHeadChunk.ChunkID = mstrGlyphTable;
	fread((char*)&glyphTableChunk + 4, 4, 1, fp);
	fread((char*)&gteBuffer, glyphTableChunk.Length, 1, fp);
}
__declspec(dllexport) void resetData()
{
	memset((char*)&dataChunk, 0, 8);
	dataChunk.ChunkID = mstrData;
	dataChunk.Length = 0;
	free(ptBuffer);
}
__declspec(dllexport) void readData()
{
	memset((char*)&dataChunk, 0, 8);
	dataChunk.ChunkID = mstrData;
	fread((char*)&dataChunk + 4, 4, 1, fp);
	fread((char*)&ptBuffer, dataChunk.Length, 1, fp);
}
__declspec(dllexport) void readFile(const char* filename)
{
	unsigned int tmp;
	fp = fopen(filename, "rb+");
	if (fp == NULL)
	{
		return;
	}
	fseek(fp, 0, SEEK_END);
	filesize = ftell(fp);
	printf("File size = %d\n", filesize);
	fseek(fp, 0, SEEK_SET);
	while (ftell(fp) < filesize)
	{
		printf("\n%d", ftell(fp));
		fread((char*)&tmp, 4, 1, fp);
		printf("\t0x%08x\n", tmp);
		switch (tmp)
		{
		case mstrHead: { readHead(); break; }
		case mstrGlyphTable: { readGlyphTable(); break; }
		case mstrData: { readData(); break; }
		}
	}
}
__declspec(dllexport) void saveFile()
{
	fseek(fp, 0, 0);
	fwrite((char*)&fileHeadChunk, fileHeadChunk.Length + 8, 1, fp);
	fwrite((char*)&glyphTableChunk, 8, 1, fp);
	fwrite((char*)gteBuffer, glyphTableChunk.Length, 1, fp);
}
__declspec(dllexport) void closeFile()
{
	fclose(fp);
}
__declspec(dllexport) int searchGlyph(int index, Gte* gteptr)
{
	if (glyphTableChunk.ChunkID == mstrGlyphTable)
	{
		for (int i = 0; i < glyphTableChunk.Length / 16; i++)
		{
			if (gteBuffer[i].Index == index)
			{
				*gteptr = gteBuffer[i];
				return 0;
			}
		}
		return -1;
	}
	return -2;
}
__declspec(dllexport) int addGlyphEntry(Gte* gteptr) {
	if (glyphTableChunk.ChunkID == mstrGlyphTable)
	{
		for (int i = 0; i < glyphTableChunk.Length / 16; i++)
		{
			if (gteBuffer[i].Index == gteptr->Index)
			{
				return -1;
			}
		}
		gteBuffer = (Gte*)realloc(gteBuffer, glyphTableChunk.Length + 16);
		glyphTableChunk.Length += 16;
		gteBuffer[glyphTableChunk.Length / 16 - 1] = *gteptr;
		return 0;
	}
	return -2;
}

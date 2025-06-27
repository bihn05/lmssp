#pragma once
#pragma pack(4)
//点
typedef struct {
	float X;
	float Y;
} PT;

//字型
//实际上这个不能被存到文件里面，是程序运行的时候会为了方便处理的缓冲区东西
typedef struct {
	int Index;
	char Name[16];
//	PT Route[]; //路径点
} Glyph;

//字形表项目
typedef struct {
	int Index; //xx字
	int IdxId; //xx区
	int Share; //本字
	int Offset; //偏移值
} Gte;

//文件头块
typedef struct {
	unsigned int ChunkID;
	int Length;
	int Version;
	char FontName[20];
	char FontDisp[32];
} FileHeadChunk;

//字形表块
typedef struct {
	unsigned int ChunkID;
	int Length;
//	Gte Entries[];
} GlyphTableChunk;

//数据块
typedef struct {
	unsigned int ChunkID;
	int Length;
//	PT Pts[];
} DataChunk;
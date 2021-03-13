#ifndef TSPACECRAFT_H
#define TSPACECRAFT_H
#include "TDynamicModel.h"
#include <math.h>
using namespace std;

class TSpaceCraft:public TDynamicModel
{
private:
	double FindRadius();
public:
	TSpaceCraft();
	~TSpaceCraft();

	TVector RightParts() override;
};

TSpaceCraft::TSpaceCraft()
{}

TSpaceCraft::~TSpaceCraft()
{}

TVector TSpaceCraft::RightParts()
{
	TVector NewVector;
	NewVector.x0 = vector.x3;
	NewVector.x1 = vector.x4;
	NewVector.x2 = vector.x5;
	NewVector.x3 = -1 * W * vector.x0 / pow(FindRadius(), 3);
	NewVector.x4 = -1 * W * vector.x1 / pow(FindRadius(), 3);
	NewVector.x5 = -1 * W * vector.x2 / pow(FindRadius(), 3);

	return (NewVector);
}

double TSpaceCraft::FindRadius()
{
	double Radius;

	Radius = sqrt(pow(vector.x0, 2) + pow(vector.x1, 2)+ pow(vector.x2,2));
	return (Radius);
}

#endif

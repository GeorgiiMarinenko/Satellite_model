#ifndef TSPACECRAFT_H
#define TSPACECRAFT_H
#include "TDynamicModel.h"

class TSpaceCraft:public TDynamicModel
{
private:
	double FindRadius();
public:
	TSpaceCraft(/* args */);
	~TSpaceCraft();

	TVector RightParts() override;
};

TSpaceCraft::TSpaceCraft(/* args */)
{
}

TSpaceCraft::~TSpaceCraft()
{
}

TVector TSpaceCraft::RightParts()
{
	TVector NewVector;
	NewVector.x0 = vector.x3;
	NewVector.x1 = vector.x4;
	NewVector.x2 = vector.x5;
	NewVector.x3 = -1 * W * vector.x0 / FindRadius();
	NewVector.x4 = -1 * W * vector.x1 / FindRadius();
	NewVector.x5 = -1 * W * vector.x2 / FindRadius();

	return (NewVector);
}

double TSpaceCraft::FindRadius()
{
	double Radius;

	Radius = sqrt(pow(vector.x0, 2) + pow(vector.x1, 2)+ pow(vector.x2,2));
	return (Radius);
}

#endif
